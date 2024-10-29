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
    public enum Mode { Creation, Modification };
    /// <summary>
    /// Logique d'interaction pour FicheCommande.xaml
    /// </summary>
    public partial class FicheCommande : Window
    {
        public FicheCommande(Mode leMode)
        {
            InitializeComponent();
            if (leMode == Mode.Creation)
                this.Title = "Creation d'une commande";
            else if (leMode == Mode.Modification)
                this.Title = "Modification d'une commande";
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in UCPannelCommande.mainPanel.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }

                if (Validation.GetHasError(uie))
                    ok = false;
            }
            UCPannelCommande.dpDateLivraison.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            if (ok)
                DialogResult = true;
            else
                MessageBox.Show(this, "Erreur", "Vérifiez vos informations.", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
