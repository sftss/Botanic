using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Caracteristique
    {
        #region Champs
        private int numCaracteristique;
        private string nomCaracteristique;
        #endregion

        #region Propriete
        public int NumCaracteristique
        {
            get
            {
                return numCaracteristique;
            }

            set
            {
                if (value > 0)
                {
                    numCaracteristique = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro de la caractéristique doit être supérieur à 0.");
                }
            }
        }

        public string NomCaracteristique
        {
            get
            {
                return this.nomCaracteristique;
            }

            set
            {
                if (value.Length <= 50 && Regex.IsMatch(nomCaracteristique, @"^[a-zA-Z]+$"))
                {
                    nomCaracteristique = value;
                }
                else
                {
                    throw new ArgumentException("Le nom de la caractéristique doit contenir uniquement des lettres et ne pas dépasser 50 caractères.");
                }
            }
        }
        #endregion

        #region Constructeur
        public Caracteristique(int numCaracteristique, string nomCaracteristique)
        {
            this.NumCaracteristique = numCaracteristique;
            this.NomCaracteristique = nomCaracteristique;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Caracteristique caracteristique &&
                   this.NumCaracteristique == caracteristique.NumCaracteristique &&
                   this.NomCaracteristique == caracteristique.NomCaracteristique;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCaracteristique, this.NomCaracteristique);
        }


        #endregion

    }
}
