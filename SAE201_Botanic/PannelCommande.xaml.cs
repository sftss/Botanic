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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201_Botanic
{
    /// <summary>
    /// Logique d'interaction pour PannelCommande.xaml
    /// </summary>
    public partial class PannelCommande : UserControl
    {
        public PannelCommande()
        {
            InitializeComponent();
            dpDateLivraison.DisplayDateStart = DateTime.Now;
            dpDateLivraison.SelectedDate = DateTime.Now;
            dpDatCommande.SelectedDate = DateTime.Now;
        }
    }
}
