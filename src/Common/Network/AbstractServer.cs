using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

//Exteral using.

namespace Common.Network
{
    /// <summary>
    /// Type modélisant un serveur Tcp de base.
    /// </summary>
    public abstract class AbstractServer
    {
        #region Fields
        protected TcpListener _listener; // Serveur d'écoute
        protected List<AbstractClient> _clients; //Liste des clients du serveur
        private Thread _acceptThread;
        #endregion

        #region Properties

        #endregion

        #region Private methods
        /// <summary>
        /// Méthode permettant d'accepter le client 
        /// désireux de se connecter au serveur.
        /// </summary>
        private void BeginAcceptClient()
        {
            Socket sock;

            while (true)
            {
                try
                {
                    sock = this._listener.AcceptSocket();
                    this.EndAcceptClient(sock);
                }
                catch
                {
                    //todo : logs
                }
            }
        }
        #endregion 

        #region Protected methods
        protected void Start()
        {
            try
            {
                this._listener.Start();

                this._acceptThread = new Thread(new ThreadStart(BeginAcceptClient));
                this._acceptThread.Start();
            }
            catch (Exception e)
            {
                //todo : logs
            }
        }
        /// <summary>
        /// Permet de déterminer le type du client accepté.
        /// </summary>
        /// <param name="sock">Client en cours de connexion.</param>
        protected abstract void EndAcceptClient(Socket sock);
        #endregion
    }
}
