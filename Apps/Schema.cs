using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Apps
{
    internal class Schema
    {
        public Dictionary<string, string> table = new Dictionary<string, string>
        {
            {"TableUtilisateur", "tableutilisateur"}
        };

        public Dictionary<string, string> Tutilisateur = new Dictionary<string, string>
        {
            {"idUser","idUser"},
            {"nomComplet", "nomComplet"},
            {"nomUtilisateur","nomUtilisateur"},
            {"passwords","passwords"},
        };

    }
}
