using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Modele
{
    internal class ClassMuser
    {
        public Dictionary<string, string> callback;
        public string LastMessage { get; private set; } = string.Empty;
        public async Task<bool> insert(Dictionary<string , string > args)
        {
            try
            {
                if(await Apps.Query.Open())
                {
                    Apps.Schema schema = new Apps.Schema();
                    bool isinserted = await Apps.Query.InsertPrepared(
                        schema.table["TableUtilisateur"],
                        new MySqlParameter($"@{schema.Tutilisateur["nomComplet"]}", args["nomComplet"]),
                         new MySqlParameter($"@{schema.Tutilisateur["nomUtilisateur"]}", args["nomUtilisateur"]),
                          new MySqlParameter($"@{schema.Tutilisateur["passwords"]}", args["passwords"])
                        );
                    LastMessage = isinserted ? "information enregistrer avec succes" : "echec d'enregistrement";
                    return isinserted;
                    
                }
                else {
                    LastMessage = "Connexion à la base de données impossible";
                    return false; 
                }
            }

            catch (Exception ex) {
                LastMessage = "erreur lors de l'insertion " + ex.Message;
                return false;
            }
            

    }
       
    }
}
