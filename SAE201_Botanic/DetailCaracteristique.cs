using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class DetailCaracteristique
    {
        #region Champs
        private Produit unProduit;
        private Caracteristique uneCaracteristique;
        private string valeurCaracteristique;
        #endregion

        #region Propriete
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

        public Caracteristique UneCaracteristique
        {
            get
            {
                return uneCaracteristique;
            }

            set
            {
                uneCaracteristique = value;
            }
        }

        public string ValeurCaracteristique
        {
            get
            {
                return this.valeurCaracteristique;
            }

            set
            {
                if (value.Length <= 20 && Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    valeurCaracteristique = value;
                }
                else
                {
                    throw new ArgumentException("Le nom du fournisseur doit contenir uniquement des lettres et ne doit pas dépasser 20 caractères.");
                }
            }
        }

        #endregion

        #region Constructeur
        public DetailCaracteristique(Produit unProduit, Caracteristique uneCaracteristique)
        {
            this.UnProduit = unProduit;
            this.UneCaracteristique = uneCaracteristique;
        }

        public DetailCaracteristique(Produit unProduit, Caracteristique uneCaracteristique, string valeurCaracteristique) : this(unProduit, uneCaracteristique)
        {
            this.ValeurCaracteristique = valeurCaracteristique;
        }

        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is DetailCaracteristique caracteristique &&
                   EqualityComparer<Produit>.Default.Equals(this.UnProduit, caracteristique.UnProduit) &&
                   EqualityComparer<Caracteristique>.Default.Equals(this.UneCaracteristique, caracteristique.UneCaracteristique) &&
                   this.ValeurCaracteristique == caracteristique.ValeurCaracteristique;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.UnProduit, this.UneCaracteristique, this.ValeurCaracteristique);
        }


        #endregion

    }
}
