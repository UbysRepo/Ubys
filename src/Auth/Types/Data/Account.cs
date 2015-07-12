using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Enum;

namespace Auth.Types.Data
{
    class Account
    {
        #region Fields

        #endregion

        #region Properties
        public int Id
        { 
            get;
            private set;
        }
        public string Username
        {
            get;
            private set;
        }
        public string Password
        {
            get;
            private set;
        }
        public RolePlayerEnum Role
        {
            get;
            private set;
        }
        public bool IsBanned
        {
            get;
            private set;
        }
        public DateTime EndBanned
        {
            get;
            private set;
        }
        public DateTime LastConnection
        {
            get;
            private set;
        }
        public DateTime SubscriptionDate
        {
            get;
            private set;
        }
        #endregion

        #region Builder
        public Account(string username)
        {
            this.Username = username;
        }
        #endregion

        #region Private methods

        #endregion

        #region Public methods

        #endregion
    }
}
