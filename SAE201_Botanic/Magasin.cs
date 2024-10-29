using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Magasin
    {
        #region Champs
        private int numMagasin;
        private string nomMagasin;
        private string rueMagasin;
        private string CPMagasin;
        private string villeMagasin;
        private string horaire;
        #endregion

        #region Propriete
        public int NumMagasin
        {
            get
            {
                return numMagasin;
            }

            set
            {
                if (value > 0)
                {
                    numMagasin = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro du magasin doit être supérieur à 0.");
                }
            }
        }

        public string NomMagasin
        {
            get
            {
                return nomMagasin;
            }

            set
            {
                if (value.Length <= 50 && Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    nomMagasin = value;
                }
                else
                {
                    throw new ArgumentException("Le nom du magasin doit contenir uniquement des lettres et ne pas dépasser 50 caractères.");
                }
            }
        }

        public string RueMagasin
        {
            get
            {
                return rueMagasin;
            }

            set
            {
                if (value.Length <= 50)
                {
                    rueMagasin = value;
                }
                else
                {
                    throw new ArgumentException("La rue du magasin doit contenir uniquement des lettres et ne pas dépasser 50 caractères.");
                }
            }
        }

        public string CPMagasin1
        {
            get
            {
                return CPMagasin;
            }

            set
            { 
                if(value.Length <=5 && Regex.IsMatch(value, @"^[0-9]+$"))
                {
                    CPMagasin = value;
                }
                else
                {
                    throw new ArgumentException("Le code postal du magasin doit contenir uniquement des chiffres et ne pas dépasser 5 caractères.");
                }
            }
        }

        public string VilleMagasin
        {
            get
            {
                return villeMagasin;
            }

            set
            {
                if (value.Length <= 50)
                {
                    villeMagasin = value;
                }
                else
                {
                    throw new ArgumentException("La ville du magasin doit contenir uniquement des lettres et ne pas dépasser 50 caractères.");
                }
            }
        }

        public string Horaire
        {
            get
            {
                return this.horaire;
            }

            set
            {
                //if (Regex.IsMatch(value, @"^([01]\d|2[0-3])H([0-5]\d)-([01]\d|2[0-3])H([0-5]\d)$"))
                //{
                    horaire = value;
                //}
                //else
                //{
                //    throw new ArgumentException("L'horaire doit être au format HH:mm.");
                //}
            }
        }
        #endregion

        #region Constructeur
        public Magasin(int numMagasin, string nomMagasin, string rueMagasin, string cPMagasin1, string villeMagasin, string horaire)
        {
            this.NumMagasin = numMagasin;
            this.NomMagasin = nomMagasin;
            this.RueMagasin = rueMagasin;
            this.CPMagasin1 = cPMagasin1;
            this.VilleMagasin = villeMagasin;
            this.Horaire = horaire;
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Magasin magasin &&
                   this.NumMagasin == magasin.NumMagasin &&
                   this.NomMagasin == magasin.NomMagasin &&
                   this.RueMagasin == magasin.RueMagasin &&
                   this.CPMagasin1 == magasin.CPMagasin1 &&
                   this.VilleMagasin == magasin.VilleMagasin &&
                   this.Horaire == magasin.Horaire;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumMagasin, this.NomMagasin, this.RueMagasin, this.CPMagasin1, this.VilleMagasin, this.Horaire);
        }

        #endregion
    }
}
