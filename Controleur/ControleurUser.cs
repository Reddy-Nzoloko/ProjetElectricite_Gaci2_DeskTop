using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WindowsFormsApp1.Controleur
{
    internal class ControleurUser
    {
        private Dictionary<string,string> champs{get; set;}
        public string LastMessage { get; private set;} = string.Empty;
        public ControleurUser(Dictionary<string, string> champs)
        {
            this.champs = champs;
        }

        // contoleur pour l'insertion
        public async Task<bool> Insert()
        {
            Modele.ClassMuser classMusers = new Modele.ClassMuser();
            bool success = await classMusers.insert(champs);
            LastMessage = classMusers.LastMessage;
            return success;
        }
    }
}
