using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Helper
{
    class RawDataHelper
    {
        /// <summary>
        /// Chargement de la RawData, fichier flash envoyé au client lors de la phase d'authentification (ou après pour des fonctions un peu plus custom :p)
        /// </summary>
        public static byte[] Datas { get; set; }
        public static void InitializeRawData(string path)
        {
            Datas = File.ReadAllBytes(path);
        }
    }
}
