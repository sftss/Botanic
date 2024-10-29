using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE201_Botanic
{
    /// <summary>
    /// Logique d'interaction pour login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void Goto_MdpOublie(object sender, RoutedEventArgs e)
        {
            spConnexion.Visibility = Visibility.Hidden;
            spMdpOublie.Visibility = Visibility.Visible;
        }

        private void Goto_Connexion(object sender, RoutedEventArgs e)
        {
            tbIdentifiant.Text = "";
            pbMdp.Password = "";
            tbIdentifiant_mdpo.Text = "";
            lbIdentifiantIncorrecte.Visibility = Visibility.Hidden;
            lbIncorrecte.Visibility = Visibility.Hidden;
            spMdpOublie.Visibility = Visibility.Hidden;
            spDemandeEnvoyee.Visibility = Visibility.Hidden;
            spConnexion.Visibility = Visibility.Visible;
        }

        private void Goto_DemandeEnvoye(object sender, RoutedEventArgs e)
        {
            if (tbIdentifiant_mdpo.Text.Length >= 2)
            {
                spMdpOublie.Visibility = Visibility.Hidden;
                spDemandeEnvoyee.Visibility = Visibility.Visible;
            }
            else lbIdentifiantIncorrecte.Visibility = Visibility.Visible;
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connexion = new NpgsqlConnection();
            try
            {
                connexion = new NpgsqlConnection();
                connexion.ConnectionString = $"Server=srv-peda-new;" + 
                    $"port=5433;" + 
                    $"Database=sae_botanic;" + 
                    $"Search Path=sae_botanic_s;" +
                    $"uid={tbIdentifiant.Text};" + 
                    $"password={pbMdp.Password};";
                connexion.Open();
                ValiderConnexion();

            }
            catch (Exception ex)
            {
                lbIncorrecte.Visibility = Visibility.Visible;
                pbMdp.Password = "";
            }
        }

        private void ValiderConnexion()
        {
            lbIncorrecte.Visibility = Visibility.Hidden;
            var mainWin = new MainWindow();
            Close();
            mainWin.Show();
        }
    }
}
