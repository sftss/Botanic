using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Fournisseur
    {
        #region Champs
        private int numFournisseur;
        private string nomFournisseur;
        private bool codeLocal;
        #endregion

        #region Propriete
        public int NumFournisseur
        {
            get
            {
                return numFournisseur;
            }

            set
            {
                if (value > 0)
                {
                    numFournisseur = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro du fournisseur doit être supérieur à 0.");
                }
            }
        }

        public string NomFournisseur
        {
            get
            {
                return nomFournisseur;
            }

            set
            {
                if (value.Length <= 100 && value.All(c => Char.IsLetter(c) || c == ' '))
                {
                    nomFournisseur = value;
                }
                else
                {
                    throw new ArgumentException("Le nom du fournisseur doit contenir uniquement des lettres et ne pas dépasser 100 caractères.");
                }
            }
        }

        public bool CodeLocal
        {
            get
            {
                return this.codeLocal;
            }

            set
            {
                this.codeLocal = value;
            }
        }
        #endregion

        #region Constructeur
        public Fournisseur(int numFournisseur, string nomFournisseur, bool codeLocal)
        {
            this.NumFournisseur = numFournisseur;
            this.NomFournisseur = nomFournisseur;
            this.CodeLocal = codeLocal;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Fournisseur fournisseur &&
                   this.NumFournisseur == fournisseur.NumFournisseur &&
                   this.NomFournisseur == fournisseur.NomFournisseur &&
                   this.CodeLocal == fournisseur.CodeLocal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumFournisseur, this.NomFournisseur, this.CodeLocal);
        }

        #endregion

    }
}
