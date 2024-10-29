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
    public enum ModeP { Creation, Modification };
    /// <summary>
    /// Logique d'interaction pour FicheProduit.xaml
    /// </summary>
    public partial class FicheProduit : Window
    {
        public FicheProduit(ModeP leMode)
        {
            InitializeComponent();
            if (leMode == ModeP.Creation)
                this.Title = "Creation d'un produit";
            else if (leMode == ModeP.Modification)
                this.Title = "Modification d'un produit";
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in UCPanelProduit.mainPanelProduit.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }

                if (Validation.GetHasError(uie))
                    ok = false;
            }
            if (ok)
                DialogResult = true;
            else
                MessageBox.Show(this, "Erreur", "Vérifiez vos informations.", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
