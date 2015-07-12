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
        #region Fields
        private NetworkAcceptor _acceptor;
        protected List<T> _clients;
        #endregion

        #region Properties
        /// <summary>
        /// Liste des clients connectés
        /// WARNING: non safe-thread.
        /// </summary>
        public ReadOnlyCollection<T> Clients
        {
            get 
            {
                return _clients.AsReadOnly(); 
            }
        }
        #endregion

        #region Constructor
        public AbstractServer()
        {
            _acceptor = new NetworkAcceptor();
            _clients = new List<T>();
        }
        #endregion 

        #region Public methods
        /// <summary>
        /// Initialisation du serveur.
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
        /// Arrêt du serveur.
        /// </summary>
        public virtual void Stop()
        {
            _acceptor.Stop();
            _acceptor.Accepted -= OnAccepted;

            AbstractClient.Disconnected -= OnDisconnected;
        }
        /// <summary>
        /// Libère les ressources
        /// </summary>
        public virtual void Dispose()
        {
            _acceptor.Dispose();
        }
        #endregion

        #region Protected methods
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
        /// Déconnexion d'un client.
        /// </summary>
        /// <param name="client"></param>
        protected virtual void OnDisconnected(AbstractClient client)
        {
            lock (_clients)
            {
                _clients.Remove(client as T);
            }
        }
        #endregion
    }
}
