using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SAE201_Botanic
{
    public class CommandeAchat : ICloneable
    {
        #region Champs
        private int numCommande;
        private Magasin unMagasin;
        private ModeTransport unModeTransport;
        private DateTime dateComande;
        private DateTime dateLivraison;
        private string modeLivraison;
        #endregion

        #region Propriete
        public int NumCommande
        {
            get
            {
                return numCommande;
            }

            set
            {
                if (value > 0)
                {
                    numCommande = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro de la commande doit être supérieur à 0.");
                }
            }
        }

        public Magasin UnMagasin
        {
            get
            {
                return unMagasin;
            }

            set
            {
                unMagasin = value;
            }
        }

        public ModeTransport UnModeTransport
        {
            get
            {
                return unModeTransport;
            }

            set
            {
                unModeTransport = value;
            }
        }

        public DateTime DateComande
        {
            get
            {
                return dateComande;
            }

            set
            {
                //if(value == DateTime.Today)
                //{
                    dateComande = value;
                //}
                //else
                //{
                //    throw new ArgumentOutOfRangeException("La date de commande doit être la date d'aujourd'hui");
                //}
            }
        }

        public DateTime DateLivraison
        {
            get
            {
                return dateLivraison;
            }

            set
            {
                if (value > DateTime.Today)
                {
                    dateLivraison = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("La date de livraison doit être la date du jour");
                }
            }
        }

        public string ModeLivraison
        {
            get
            {
                return this.modeLivraison;
            }

            set
            {
                if (value.Length <= 50 && Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    modeLivraison = value;
                }
                else
                {
                    throw new ArgumentException("Le mode de livraison doit contenir uniquement des lettres et ne doit pas dépasser 50 caractères.");
                }
            }
        }


        #endregion

        #region Constructeur
        public CommandeAchat(int numCommande, Magasin unMagasin, ModeTransport unModeTransport, DateTime dateComande, DateTime dateLivraison, string modeLivraison)
        {
            this.NumCommande = numCommande;
            this.UnMagasin = unMagasin;
            this.UnModeTransport = unModeTransport;
            this.DateComande = dateComande;
            this.DateLivraison = dateLivraison;
            this.ModeLivraison = modeLivraison;
        }

        public CommandeAchat()
        {
        }
        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is CommandeAchat achat &&
                   this.NumCommande == achat.NumCommande &&
                   EqualityComparer<Magasin>.Default.Equals(this.UnMagasin, achat.UnMagasin) &&
                   EqualityComparer<ModeTransport>.Default.Equals(this.UnModeTransport, achat.UnModeTransport) &&
                   this.DateComande.Equals(achat.DateComande) &&
                   this.DateLivraison.Equals(achat.DateLivraison) &&
                   this.ModeLivraison == achat.ModeLivraison;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCommande, this.UnMagasin, this.UnModeTransport, this.DateComande, this.DateLivraison, this.ModeLivraison);
        }

        public object Clone()
        {
            return new CommandeAchat(this.NumCommande, this.UnMagasin, this.UnModeTransport, this.DateComande, this.DateLivraison, this.ModeLivraison);
        }

        #endregion
    }
}
