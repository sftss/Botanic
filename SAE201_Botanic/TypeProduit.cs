using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class TypeProduit
    {
        #region Champs
        private int numType;
        private string nomType;
        #endregion

        #region Propriete
        public int NumType
        {
            get
            {
                return numType;
            }

            set
            {
                if (value > 0)
                {
                    numType = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro du type doit être supérieur à 0.");
                }
            }
        }

        public string NomType
        {
            get
            {
                return this.nomType;
            }

            set
            {
                if (value.Length <= 100 && value.All(c => Char.IsLetter(c) || c == ' '))
                {
                    nomType = value;
                }
                else
                {
                    throw new ArgumentException("Le type du produit doit contenir uniquement des lettres et ne pas dépasser 100 caractères.");
                }
            }
        }

        #endregion

        #region Constructeur
        public TypeProduit(int numType, string nomType)
        {
            this.NumType = numType;
            this.NomType = nomType;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is TypeProduit produit &&
                   this.NumType == produit.NumType &&
                   this.NomType == produit.NomType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumType, this.NomType);
        }

        #endregion
    }
}
