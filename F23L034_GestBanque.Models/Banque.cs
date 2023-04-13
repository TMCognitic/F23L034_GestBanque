using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace F23L034_GestBanque.Models
{
    public class Banque
    {
        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();

        public string Nom { get; set; }

        public Compte? this[string numero]
        {
            get 
            {
                _comptes.TryGetValue(numero, out Compte? courant);
                return courant;
            }
        }

        public void Ajouter(Compte compte)
        {
            _comptes.Add(compte.Numero, compte);
        }


        public void Supprimer(string numero)
        {
            _comptes.Remove(numero);
        }

        public double AvoirDesCompte(Personne titulaire)
        {
            double total = 0D;

            foreach (Compte compte in _comptes.Values) 
            {
                if(compte.Titulaire == titulaire)
                {
                    total += compte;
                }
            }

            return total;
        }
    }
}
