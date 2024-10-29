using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Categorie
    {
        #region Champs
        private int numCategorie;
        private TypeProduit unTypeProduit;
        private string libelleCategorie;
        #endregion

        #region Propriete
        public int NumCategorie
        {
            get
            {
                return numCategorie;
            }

            set
            {
                if (value > 0)
                {
                    numCategorie = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro de la catégorie doit être supérieur à 0.");
                }
            }
        }

        public TypeProduit UnTypeProduit
        {
            get
            {
                return unTypeProduit;
            }

            set
            {
                unTypeProduit = value;
            }
        }

        public string LibelleCategorie
        {
            get
            {
                return this.libelleCategorie;
            }

            set
            {
                if (value.Length <= 100 && value.All(c => Char.IsLetter(c) || c == ' '))
                {
                    libelleCategorie = value;
                }
                else
                {
                    throw new ArgumentException("Le libelle catégorie doit contenir uniquement des lettres et ne pas dépasser 100 caractères.");
                }
            }
        }
        #endregion

        #region Constructeur
        public Categorie(int numCategorie, TypeProduit unTypeProduit, string libelleCategorie)
        {
            this.NumCategorie = numCategorie;
            this.UnTypeProduit = unTypeProduit;
            this.LibelleCategorie = libelleCategorie;
        }

        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Categorie categorie &&
                   this.NumCategorie == categorie.NumCategorie &&
                   EqualityComparer<TypeProduit>.Default.Equals(this.UnTypeProduit, categorie.UnTypeProduit) &&
                   this.LibelleCategorie == categorie.LibelleCategorie;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCategorie, this.UnTypeProduit, this.LibelleCategorie);
        }

        #endregion
    }
}
