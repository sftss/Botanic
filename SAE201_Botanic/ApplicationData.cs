using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAE201_Botanic
{
    public class ApplicationData
    {
        private ObservableCollection<Produit> lesProduits;
        private ObservableCollection<CommandeAchat> lesCommandes;
        private NpgsqlConnection connexion;

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }

        public ObservableCollection<CommandeAchat> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes= value;
            }
        }

        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ApplicationData()
        {
            LesProduits = new ObservableCollection<Produit>();
            LesCommandes = new ObservableCollection<CommandeAchat>();
            ConnexionBD();
            //Read();
        }

        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection
                {
                    ConnectionString = "Server=srv-peda-new;" +
                    "port=5433;" +
                    "Database=sae_botanic;" +
                    "Search Path = sae_botanic_s;" +
                    "uid=tasdemis;" +
                    "password=r9H2lI;"
                };
                Connexion.Open();
                Console.WriteLine("Connexion réussie !");
            }
            catch (Exception e)
            {
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
            { Console.WriteLine("Problème à la déconnexion : " + e); }
        }

        public DataTable Read(string commandeSql)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(commandeSql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Erreur : " + e  + "  " + commandeSql, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }
        }  

        private int MethodeGenerique(string sql)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb; // nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                MessageBox.Show("Problème de requête : " + sqlE.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        #region Methode requete commande
        public int CreateCommande(CommandeAchat c)
        {
            string sql = $"INSERT INTO commande_achat (numcommande, nummagasin, modetransport, datecommande, datelivraison, modelivraison) " +
                         $"VALUES ({c.NumCommande}, {c.UnMagasin.NumMagasin}, '{c.UnModeTransport.ModedeTransport}', '{c.DateComande:yyyy-MM-dd}', " +
                         $"'{c.DateLivraison:yyyy-MM-dd}', '{c.ModeLivraison}');";
            MethodeGenerique(sql);
            return 0;
        }

        public int UpdateCommande(CommandeAchat c)
        {
            string sql = $"UPDATE sae_botanic_s.commandeachat SET numcommande = '{c.NumCommande}', nummagasin = '{c.UnMagasin.NumMagasin}', modetransport = '{c.UnModeTransport.ModedeTransport}', " +
                         $"datecommande = '{c.DateComande:dd-MM-yyyy}', datelivraison= '{c.DateLivraison:dd-MM-yyyy}', modelivraison= '{c.ModeLivraison}' " +
                         $"WHERE id = {c.NumCommande};";
            MethodeGenerique(sql);

            return 0;
        }

        public int DeleteCommande(CommandeAchat c)
        {
            string sql = $"DELETE FROM sae_botanic_s.commandeachat WHERE numcommande = {c.NumCommande};";
            MethodeGenerique(sql);

            return 0;
        }

        public int AssocierProduitACommande(CommandeAchat c, Produit p, int quantite)
        {
            string sql = $"INSERT INTO commande_produit (idcommande, idproduit, quantite) VALUES ({c.NumCommande}, {p.NumProduit}, {quantite});";
            MethodeGenerique(sql);
            return 0;
        }
        #endregion

        #region Methode requete produit
        public int CreateProduit(Produit p)
        {
            string sql = $"INSERT INTO produit (numproduit, nomcouleur, numcategorie, numfournisseur, nomproduit, tailleproduit, descriptionproduit, prixvente, prixachat) " +
                         $"VALUES ({p.NumProduit}, {p.UneCouleur.NomCouleur}, '{p.UneCategorie.NumCategorie}', '{p.UnFournisseur.NumFournisseur}', " +
                         $"'{p.NomProduit}', '{p.TailleProduit}', '{p.DescriptionProduit}', '{p.PrixVente}', '{p.PrixAchat}');";
            MethodeGenerique(sql);
            return 0;
        }

        public int UpdateProduit(Produit p)
        {
            string sql = $"UPDATE sae_botanic_s.produit SET numProduit= '{p.NumProduit}', nomCouleur = '{p.UneCouleur.NomCouleur}', numCategorie = '{p.UneCategorie.NumCategorie}'," +
                $" numFournisseur = '{p.UnFournisseur.NumFournisseur}', nomProduit= '{p.NomProduit}', tailleProduit= '{p.TailleProduit}'," +
                $" descriptionProduit= '{p.DescriptionProduit}', prixVente= '{p.PrixVente}', prixAchat= '{p.PrixAchat}'" +
                $"WHERE id = {p.NumProduit};";
            MethodeGenerique(sql);

            return 0;
        }

        public int DeleteProduit(Produit p)
        {
            string sql = $"DELETE FROM sae_botanic_s.produit! WHERE numproduit = {p.NumProduit};";
            MethodeGenerique(sql);

            return 0;
        }
        #endregion
    }
}
