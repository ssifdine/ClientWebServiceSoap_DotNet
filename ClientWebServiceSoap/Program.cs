using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebServiceSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialiser le client du service SOAP
                ServiceSoap.WebServiceSoapImplClient stub = new ServiceSoap.WebServiceSoapImplClient();

                // Appeler les différentes fonctionnalités
                ConvertirMontant(stub);
                ObtenirCompteParId(stub, 1);
                ListerTousLesComptes(stub);

                Console.WriteLine("Appuyez sur Entrée pour quitter...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
        }

        /// <summary>
        /// Convertit un montant en utilisant le service SOAP.
        /// </summary>
        /// <param name="stub">Client du service SOAP</param>
        private static void ConvertirMontant(ServiceSoap.WebServiceSoapImplClient stub)
        {
            try
            {
                double montant = 900;
                double resultat = stub.conversion(montant);
                Console.WriteLine($"Conversion de {montant} : {resultat}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la conversion : " + ex.Message);
            }
        }

        /// <summary>
        /// Récupère un compte par ID et affiche ses informations.
        /// </summary>
        /// <param name="stub">Client du service SOAP</param>
        /// <param name="id">ID du compte</param>
        private static void ObtenirCompteParId(ServiceSoap.WebServiceSoapImplClient stub, int id)
        {
            try
            {
                ServiceSoap.compte compte = stub.getCompte(id);
                if (compte != null)
                {
                    Console.WriteLine($"Compte récupéré - Code : {compte.code}, Solde : {compte.solde}");
                }
                else
                {
                    Console.WriteLine($"Aucun compte trouvé pour l'ID {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du compte : " + ex.Message);
            }
        }

        /// <summary>
        /// Liste tous les comptes disponibles.
        /// </summary>
        /// <param name="stub">Client du service SOAP</param>
        private static void ListerTousLesComptes(ServiceSoap.WebServiceSoapImplClient stub)
        {
            try
            {
                ServiceSoap.compte[] comptes = stub.getComptes();
                Console.WriteLine("Liste des comptes :");
                foreach (ServiceSoap.compte c in comptes)
                {
                    Console.WriteLine($"Code : {c.code}, Solde : {c.solde}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la liste des comptes : " + ex.Message);
            }
        }
    }
}
