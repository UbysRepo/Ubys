using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
//External using
using Common.Network;
using Common.Utils;
using Auth.Utils;

namespace Auth.Network
{
    public sealed class AuthServer : AbstractServer<AuthServer, AuthClient>
    {

        #region Constructor
        public AuthServer() : base()
        {
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Lancement du server
        /// </summary>
        public void Initialize()
        {
            base.Initialize(Configuration.IPAddress, Configuration.Port);

            Console.WriteLine("Listening to {0}:{1}", Configuration.IPAddress, Configuration.Port); // NLog?
        }
        /// <summary>
        /// Arrêt du serveur.
        /// </summary>
        public override void Stop()
        {
            base.Stop();

            foreach (var client in _clients)
            {
                client.Disconnect();
                client.Dispose();
            }
            _clients.Clear();
        }
        /// <summary>
        /// Libère les ressources utilisées.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Acceptation d'un client.
        /// </summary>
        /// <param name="socket">Socket du client client tentant de se connecter.</param>
        protected override void OnAccepted(Socket socket)
        {
            base.OnAccepted(socket);

            Console.WriteLine("Incoming connection {0}", socket.RemoteEndPoint.ToString());
        }
        /// <summary>
        /// Déconnexion d'un client
        /// </summary>
        /// <param name="client"></param>
        protected override void OnDisconnected(AbstractClient client)
        {
            base.OnDisconnected(client);

            Console.WriteLine("Client disconnected");

            client.Dispose();
        }
        #endregion
        
    }
}
