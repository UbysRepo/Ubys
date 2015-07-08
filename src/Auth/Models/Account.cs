using Auth.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models
{
    /// <summary>
    /// Modele du compte
    /// </summary>
    class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Pseudo { get; set; }
        public ServerRoleEnum Role { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnwser { get; set; }
        public string Lang { get; set; }
        public string Email { get; set; }
        public bool Banned { get; set; }
    }
}
