using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace SAE201_Botanic
{
    
    public partial class Filtres : Window
    {

        private List<Categorie> listeCategorie = new List<Categorie>();
        private List<TypeProduit> listeType = new List<TypeProduit>();
        private List<Couleur> listeCouleur = new List<Couleur>();
        private ApplicationData appData = new ApplicationData();


        public Categorie categorieSelect;
        public TypeProduit typeProduitSelect;
        public double prixMinSelect, prixMaxSelect;
        public Couleur couleurSelect;


        public Filtres()
        {

            InitializeComponent();

            DataTable lesTypes = appData.Read("SELECT * FROM type_produit");
            foreach (DataRow unType in lesTypes.Rows)
            {
                try
                {
                    TypeProduit type = new TypeProduit(int.Parse(unType["numtype"].ToString()), unType["nomType"].ToString());
                    listeType.Add(type);
                    Button btnType = CreerBoutonFiltre();
                    btnType.Click += new RoutedEventHandler(this.AfficherSousCategorie);
                    btnType.Content = type.NomType;
                    pageCategorie.Children.Add(btnType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            DataTable lesCategories = appData.Read($"SELECT * FROM categorie");
            TypeProduit leType;
            foreach (DataRow uneCategorie in lesCategories.Rows)
            {
                try
                {
                    foreach (TypeProduit unType in listeType)
                    {
                        if (unType.NumType == int.Parse(uneCategorie["numtype"].ToString()))
                        {
                            leType = unType;
                            Categorie categorie = new Categorie(int.Parse(uneCategorie["numcategorie"].ToString()), leType, uneCategorie["libellecategorie"].ToString());
                            listeCategorie.Add(categorie);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


            DataTable lesCouleurs = appData.Read("SELECT * FROM couleur");
            foreach (DataRow uneCouleur in lesCouleurs.Rows)
            {
                try
                {
                    Couleur couleur = new Couleur(uneCouleur["nomcouleur"].ToString());
                    listeCouleur.Add(couleur);
                    Button btnCouleur = CreerBoutonFiltre();
                    btnCouleur.Click += new RoutedEventHandler(this.RetourFiltreAvecCouleur);
                    btnCouleur.Content = couleur.NomCouleur;
                    pageCouleur.Children.Add(btnCouleur);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private Button CreerBoutonFiltre()
        {
            Button btn = new Button();
            btn.Height = 30;
            btn.Padding = new Thickness(10, 0, 0, 0);
            btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            btn.HorizontalContentAlignment = HorizontalAlignment.Left;
            btn.Background = Brushes.White;
            btn.Foreground = Brushes.Gray;
            btn.Cursor = Cursors.Hand;
            btn.BorderThickness = new Thickness(0);
            return btn;
        }

        private void ValiderFiltres(object sender, RoutedEventArgs e)
        {
            string txtBtnCategorie = btnSelectionCategorie.Content.ToString();
            string txtBtncouleur = btnSelectionCouleur.Content.ToString();
            bool estType = false;

            foreach (TypeProduit unType in listeType)
            {
                if (unType.NomType == txtBtnCategorie)
                {
                    typeProduitSelect = unType;
                    estType = true;
                    break;
                }
            }
            if (!(estType))
            {
                foreach (Categorie uneCategorie in listeCategorie)
                {
                    if (uneCategorie.LibelleCategorie == txtBtncouleur)
                    {
                        categorieSelect = uneCategorie;
                        break;
                    }
                }
            }

            if (!double.TryParse(tbPrixMin.Text, out prixMinSelect)) prixMinSelect = -1;
            if (!double.TryParse(tbPrixMax.Text, out prixMaxSelect)) prixMaxSelect = -1;

            foreach (Couleur uneCouleur in listeCouleur)
            {
                if (uneCouleur.NomCouleur == txtBtncouleur)
                {
                    couleurSelect = uneCouleur;
                    break;
                }
            }

            Close();
        }





        private void AfficherCouleur(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Visible;
        }



        private void AfficherCategories(object sender, RoutedEventArgs e)
        {
            pageFiltres.Visibility = Visibility.Hidden;
            pageSousCategorie.Visibility = Visibility.Hidden;
            pageCategorie.Visibility = Visibility.Visible;
        }



        private void AfficherSousCategorie(object sender, RoutedEventArgs e)
        {
            spBoutonsSousCategories.Children.Clear();

            Button btnTout = CreerBoutonFiltre();
            btnTout.Content = "Tout";
            btnTout.Click += new RoutedEventHandler(this.RetourFiltreAvecCategorie);
            spBoutonsSousCategories.Children.Add(btnTout);
            Button btn;
            if (sender is Button)
            {
                btn = (Button)sender;
                lbPageSousCategorie.Content = btn.Content;
                foreach (Categorie uneCategorie in listeCategorie)
                {
                    if (uneCategorie.UnTypeProduit.NomType == btn.Content)
                    {
                        Button btnCategorie = CreerBoutonFiltre();
                        btnCategorie.Click += new RoutedEventHandler(this.RetourFiltreAvecCategorie);
                        btnCategorie.Content = uneCategorie.LibelleCategorie;
                        spBoutonsSousCategories.Children.Add(btnCategorie);
                    }
                }
                pageCategorie.Visibility = Visibility.Hidden;
                pageSousCategorie.Visibility = Visibility.Visible;
            }
        }



        private void AfficherFiltre()
        {
            pageCategorie.Visibility = Visibility.Hidden;
            pageSousCategorie.Visibility = Visibility.Hidden;
            pageCouleur.Visibility = Visibility.Hidden;
            pageFiltres.Visibility = Visibility.Visible;
        }





        private void RetourFiltre(object sender, RoutedEventArgs e)
        {
            AfficherFiltre();
        }



        private void RetourFiltreAvecTout(object sender, RoutedEventArgs e)
        {
            Button btn;
            StackPanel sp;
            if (sender is Button)
            {
                btn = (Button)sender;
                if (btn.Parent is StackPanel)
                {
                    sp = (StackPanel)btn.Parent;
                    if (sp.Name == "pageCategorie" || btn.Name == "btnSupprimerCategorie") btnSelectionCategorie.Content = "Tout";
                    else if (sp.Name == "pageCouleur" || btn.Name == "btnSupprimerCouleur") btnSelectionCouleur.Content = "Tout";
                }
            }
            AfficherFiltre();
        }



        private void RetourFiltreAvecCouleur(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
            {
                btn = (Button)sender;
                btnSelectionCouleur.Content = btn.Content;
            }
            AfficherFiltre();
        }



        private void RetourFiltreAvecCategorie(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
            {
                btn = (Button)sender;
                if (btn.Content == "Tout") btnSelectionCategorie.Content = lbPageSousCategorie.Content;
                else btnSelectionCategorie.Content = btn.Content;
            }
            AfficherFiltre();
        }



        private void SupprimerFiltrePrix(object sender, RoutedEventArgs e)
        {
            tbPrixMin.Text = string.Empty;
            tbPrixMax.Text = string.Empty;
        }



        
    }



}
