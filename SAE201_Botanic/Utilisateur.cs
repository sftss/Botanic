using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Botanic
{
    public class Utilisateur
    {
        #region Chammps
        private int numUtilisateur;
        private Magasin unMagasin;
        private string loginUtilisateur;
        private string mdpUtilisateur;
        #endregion

        #region Propriete
        public int NumUtilisateur
        {
            get
            {
                return numUtilisateur;
            }

            set
            {
                if (value > 0)
                {
                    numUtilisateur = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Le numéro de l'utilisateur doit être supérieur à 0.");
                }
            }
        }

        public string LoginUtilisateur
        {
            get
            {
                return loginUtilisateur;
            }

            set
            {
                loginUtilisateur = value;
            }
        }

        public string MdpUtilisateur
        {
            get
            {
                return this.mdpUtilisateur;
            }

            set
            {
                this.mdpUtilisateur = value;
            }
        }

        public Magasin UnMagasin
        {
            get
            {
                return this.unMagasin;
            }

            set
            {
                this.unMagasin = value;
            }
        }
        #endregion

        #region Constructeur
        public Utilisateur(int numUtilisateur, Magasin unMagasin, string loginUtilisateur, string mdpUtilisateur)
        {
            this.NumUtilisateur = numUtilisateur;
            this.UnMagasin = unMagasin;
            this.LoginUtilisateur = loginUtilisateur;
            this.MdpUtilisateur = mdpUtilisateur;
        }

        #endregion

        #region Methode
        public override bool Equals(object? obj)
        {
            return obj is Utilisateur utilisateur &&
                   this.NumUtilisateur == utilisateur.NumUtilisateur &&
                   EqualityComparer<Magasin>.Default.Equals(this.UnMagasin, utilisateur.UnMagasin) &&
                   this.LoginUtilisateur == utilisateur.LoginUtilisateur &&
                   this.MdpUtilisateur == utilisateur.MdpUtilisateur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumUtilisateur, this.UnMagasin, this.LoginUtilisateur, this.MdpUtilisateur);
        }
        #endregion
    }
}
