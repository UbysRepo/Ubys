using Common.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Network
{
    public abstract class AbstractServer<S, T> : Singleton<S>, IDisposable where T : AbstractClient
    {
        private NetworkAcceptor _acceptor;
        protected List<T> _clients;

        public AbstractServer()
        {
            _acceptor = new NetworkAcceptor();
            _clients = new List<T>();
        }

        /// <summary>
        /// liste des clients connectés
        /// </summary>
        public ReadOnlyCollection<T> Clients
        {//WARNING: pas safe thread
            get { return _clients.AsReadOnly(); }
        }

        /// <summary>
        /// Lancement du server
        /// </summary>
        public virtual void Initialize(string address, ushort port)
        {
            if (!_acceptor.Bind(address, port))
            {//exit or throw something
            }

            if (!_acceptor.Listen())
            {//exit or throw something
            }

            AbstractClient.Disconnected += OnDisconnected;
            _acceptor.Accepted += OnAccepted;
        }

        /// <summary>
        /// Arret du server
        /// </summary>
        public virtual void Stop()
        {
            _acceptor.Stop();
            _acceptor.Accepted -= OnAccepted;

            AbstractClient.Disconnected -= OnDisconnected;
        }

        /// <summary>
        /// Connection d'un client
        /// </summary>
        /// <param name="socket"></param>
        protected virtual void OnAccepted(Socket socket)
        {
            var client = Activator.CreateInstance(typeof(T), socket);

            lock (_clients)
            {
                _clients.Add(client as T);
            }
        }

        /// <summary>
        /// Deconnection d'un client
        /// </summary>
        /// <param name="client"></param>
        protected virtual void OnDisconnected(AbstractClient client)
        {
            lock(_clients)
            {
                _clients.Remove(client as T);
            }
        }

        /// <summary>
        /// Libère les ressources
        /// </summary>
        public virtual void Dispose()
        {
            _acceptor.Dispose();
        }
    }
}
