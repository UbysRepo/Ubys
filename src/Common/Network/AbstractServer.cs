using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

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
        #endregion

        #region Properties

        #endregion

        #region Private methods
        /// <summary>
        /// Méthoe permettant d'accepter le client 
        /// désireux de se connecter au serveur.
        /// </summary>
        private async void BeginAcceptClient()
        {
            TcpClient client;

            while (true)
            {
                try
                {
                    client = await this._listener.AcceptTcpClientAsync();
                    this.EndAcceptClient(client);
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
                this.BeginAcceptClient();
            }
            catch (Exception e)
            {
                //todo : logs
            }
        }
        protected abstract void EndAcceptClient(TcpClient sock);
        #endregion
    }
}
