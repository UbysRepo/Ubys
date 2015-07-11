using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    /// <summary>
    /// Cette classe permet de récupérer un objet
    /// de façon à ce que celui-ci ne soit déclaré
    /// qu'une seule fois tout au long du programme
    /// </summary>
    public abstract class Singleton<T> where T : class, new()
    {
        #region Fields
        private static T _instance = null;
        private static readonly object _lock = new object();    
        #endregion

        #region Properties
        /// <summary>
        /// Permet d'obtenir l'instance d'une classe
        /// </summary>
        /// <returns>L'objet si déjà crée, null si non</returns>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new T();
                    }
                }
                return _instance;
            }
        }
        #endregion
        
        
    }
}
