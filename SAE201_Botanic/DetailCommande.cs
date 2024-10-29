using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class DetailCommande
    {
        #region Champs
        private CommandeAchat uneCommande;
        private Produit unProduit;
        private int quantite;
        #endregion

        #region Propriete
        public CommandeAchat UneCommande
        {
            get
            {
                return uneCommande;
            }

            set
            {
                uneCommande = value;
            }
        }

        public Produit UnProduit
        {
            get
            {
                return unProduit;
            }

            set
            {
                unProduit = value;
            }
        }

        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                if (value > 0)
                {
                    quantite = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La quantité doit être supérieur à 0.");
                }
            }
        }

        #endregion

        #region Constructeur
        public DetailCommande(CommandeAchat uneCommande, Produit unProduit, int quantite)
        {
            this.UneCommande = uneCommande;
            this.UnProduit = unProduit;
            this.Quantite = quantite;
        }

        public DetailCommande(int quantite)
        {
            Quantite = quantite;
        }


        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is DetailCommande commande &&
                   EqualityComparer<CommandeAchat>.Default.Equals(this.UneCommande, commande.UneCommande) &&
                   EqualityComparer<Produit>.Default.Equals(this.UnProduit, commande.UnProduit) &&
                   this.Quantite == commande.Quantite;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.UneCommande, this.UnProduit, this.Quantite);
        }
        #endregion

    }
}
