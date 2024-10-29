using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE201_Botanic
{
    public class DataAccess
    {
        private static DataAccess instance;
        private static string strConnexion = "Server=srv-peda-new;port=5433;"
        + $"Database=sae_botanic;Search Path=sae_botanic_s;uid=tasdemis;password=r9H2lI;";
        private DataAccess()
        {
            ConnexionBD();
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataAccess();
                return instance;
            }
        }

        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }

        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                MessageBox.Show("Problème de connexion : " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problème avec : " + selectSQL + e.ToString());
                return null;
            }
        }

        public int SetData(string setSQL)
        {
            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
    }
}
