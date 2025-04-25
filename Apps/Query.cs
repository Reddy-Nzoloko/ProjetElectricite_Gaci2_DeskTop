using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1.Apps
{
    internal class Query
    {
        public static MySqlConnection Conn;// variable de la connexion 
        public static string ip_ { set; get; }
        public static string port_ { set; get; }
        public static string DataBase_ { set; get; }
        public static string UserName_ { set; get; }
        public static string passWord_ { set; get; }

        //Chaine de connexion et ouverture ce celle ci 
        public static void connection()
        {
            try
            {
                string ip = Settings.Default.ip;
                string username = Settings.Default.UserName;
                string database = Settings.Default.DataBase;
                string port = Settings.Default.port;
                string Password = Settings.Default.Password;

                string connection_string = $"server={ip}; port={port}; user={username}; password={Password};database={database}";

                Conn = new MySqlConnection(connection_string);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex.Message);
            }
        }

        // Test de la connexion 
        public static void TestConnection()
        {
            try
            {
                // chaine de connexion dynamique 
                MySqlConnection conn_ = new MySqlConnection();
        
                string stringConnection = $"server={ip_}; port={port_}; user={UserName_}; password= {passWord_}; database={DataBase_}";
                conn_ = new MySqlConnection(stringConnection);

                // essaie d'ouverture de connexion pour valider son ouverture
                if (conn_.State == ConnectionState.Closed)
                {
                    conn_.Open();
                    MessageBox.Show("Connexion établie");
                }
                else
                {
                    conn_.Close();
                    MessageBox.Show("Connexion à Echouer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur " + ex.Message);
            }
        }
        public static async Task<bool> Open()
        {
            connection();
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            var openAsync = Conn?.OpenAsync();
            if (openAsync == null) return false;
            await openAsync;
            return true;
        }
        public static async Task<bool> Closed()
        {
            connection();
            if (Conn.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            var closeAsync = Conn?.CloseAsync();
            if (closeAsync == null) return false;
            await closeAsync;
            return true;
        }

        ///Code non encore etudier modification dans la bdd
        public async static Task<bool> updatePrepared(string tableName, MySqlParameter keyParam, params MySqlParameter[] sqlParams)
        {
            string updateParamStr = string.Join(",",
                sqlParams.Select(sqlparam => string.Format("{0}= {1}", sqlparam.ParameterName.Substring(1), sqlparam.ParameterName))
                );
            // param = @param 
            string KeyMatchSql = string.Format("{0}={1}",
                keyParam.ParameterName.Substring(1),
                keyParam.ParameterName);
            //sql Query 
            string updateSql = string.Format("UPDATE{0} SET{1} WHERE {2}", 
                tableName,
                updateParamStr,
                KeyMatchSql);
            bool result = false;
            using (var command = new MySqlCommand(updateSql, Conn))
            {
                command.Parameters.Add(keyParam);
                command.Parameters.AddRange(sqlParams);
                await command.ExecuteScalarAsync();
                result = true;
            }
            return result;
        }

        ///Code non encore etudier insersion dans la bdd
        public async static Task<bool> InsertPrepared(string tableName, MySqlParameter keyParam, params MySqlParameter[] sqlParams)
        {
            // procedure comment delimiter list of parm name with leading @ stripped  eg. param1, param2, param3
            string columnNameStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName.Substring(1)));
            //procedure comment delimiter list of param
            string valueParamStr = string.Join(", ", sqlParams.Select(sqlParam => sqlParam.ParameterName));

            // Insert dans la bdd *
            string insertSql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName,columnNameStr,valueParamStr);
            bool result = false;
            using (var command = new MySqlCommand(insertSql, Conn))
            {
                command.Parameters.AddRange(sqlParams);
                await command.ExecuteScalarAsync();
                result = true;
            }
            return result;  
        }

        ///Code non encore etudier suppression dans la bdd
        public async static Task<bool> deletePrepared(string tableName, MySqlParameter keyParam, params MySqlParameter[] sqlParams)
        {
            // procedure comment delimiter list of parm name with leading @ stripped  eg. param1, param2, param3
            string columnNameStr = string.Join(",", sqlParams.Select(sqlParam => sqlParam.ParameterName.Substring(1)));
            //procedure comment delimiter list of param
            string valueParamStr = string.Join(",", sqlParams.Select(sqlParam => sqlParam.ParameterName));

            // Insert dans la bdd *
            string deleteSql = string.Format("DELETE FROM{0}({1}) WHERE ({1})", tableName, columnNameStr, valueParamStr);
            bool result = false;
            using (var command = new MySqlCommand(deleteSql, Conn))
            {
                command.Parameters.AddRange(sqlParams);
                await command.ExecuteScalarAsync();
                result = true;
            }
            return result;
        }

        // Get data
        public static void getData(string query)
        {
            try
            {
                var command  = new MySqlCommand(query, Conn);
                command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur" + ex.Message);

            }
        }
    }
}
