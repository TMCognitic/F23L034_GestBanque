namespace F23L034_GestBanque.Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;
        
        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                    return; //todo : à remplacer par une erreur...

                _ligneDeCredit = value;
            }
        }

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }
    }
}