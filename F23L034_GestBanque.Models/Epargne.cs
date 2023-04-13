namespace F23L034_GestBanque.Models
{
    public class Epargne : Compte
    {
        private DateTime _dernierRetrait;

        public DateTime DernierRetrait
        {
            get
            {
                return _dernierRetrait;
            }

            private set
            {
                _dernierRetrait = value;
            }
        }

        public override void Retrait(double montant)
        {
            double oldSolde = Solde;
            base.Retrait(montant);

            if(oldSolde != Solde)
            {
                DernierRetrait = DateTime.Now;
            }
        }
    }
}