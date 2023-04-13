using F23L034_GestBanque.Models;
using System.Collections;
using System.Threading.Channels;

namespace F23L034_GestBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banque banque = new Banque() { Nom = "TFTic Banking" };

            Personne norris = new Personne() { Nom = "Norris", Prenom = "Chuck", DateNaiss = new DateTime(1940, 03, 10) };

            Courant courant = new Courant()  //<-- utiliser le polymorphisme d'héritage
            { 
                Numero = "00001", 
                LigneDeCredit = 500, 
                Titulaire = norris 
            };

            Epargne epargne = new Epargne() //<-- utiliser le polymorphisme d'héritage
            {
                Numero = "00002",                
                Titulaire = norris
            };

            banque.Ajouter(courant);
            banque.Ajouter(epargne);

            banque["00001"]?.Depot(500);
            banque["00002"]?.Depot(1500);
            banque["00001"]?.Retrait(700);

            Compte? compte = banque["00002"];

            switch (compte)
            {
                case Courant c:
                    Console.WriteLine(c.LigneDeCredit);
                    break;
                case Epargne e:
                    Console.WriteLine(e.DernierRetrait);
                    break;
            }

            Console.WriteLine($"Solde du compte {courant.Numero} : {courant.Solde}");
            Console.WriteLine($"Solde du compte {epargne.Numero} : {epargne.Solde}");
            Console.WriteLine($"Avoir des comptes de Mme/Mr {norris.Nom} {norris.Prenom} : {banque.AvoirDesCompte(norris)}");            
        }
    }
}