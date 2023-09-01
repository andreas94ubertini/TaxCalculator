using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator
{
    public static class Functions
    {
        private static List<Taxpayer> taxpayers = new List<Taxpayer>();
        

        public static void Menu()
        {
            if (taxpayers.Count > 0)
            {
                Console.WriteLine("Premi 1 per inserire un nuovo contribuente, 2 per vedere la lista di quelli esistenti, 3 per chiudere il programma");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    CreateTaxPayer();
                }else if (choice == "2")
                {
                    Console.WriteLine("Ecco la lista");
                    ShowList();
                    Menu();
                }else if (choice == "3") {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Premi 1 per inserire un nuovo contribuente, 2 per chiudere il programma");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    CreateTaxPayer();
                }
                else if (choice == "2")
                {
                    Environment.Exit(0);
                }
            }

        }
        private static void CreateTaxPayer()
        {
            string birthday = "";
            Console.WriteLine("Inserisci nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Inserisci cognome: ");
            string surname = Console.ReadLine();
            try
            {
                Console.WriteLine("Inserisci data di nascita: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                 birthday = date.ToShortDateString();
            }
            catch
            {
                Console.WriteLine("Formato data non corretto prova con dd/mm/yyyy");
                CreateTaxPayer();
            }

            Console.WriteLine("Inserisci codice fiscale: ");
            string taxCode = Console.ReadLine();
            Console.WriteLine("Inserisci genere: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Inserisci comune di residenza: ");
            string municipality = Console.ReadLine();
            Console.WriteLine("Inserisci reddito annuo");
            double income = Convert.ToDouble(Console.ReadLine());
            Taxpayer taxpayer = new Taxpayer(name, surname, birthday, taxCode, gender, municipality, income);
            taxpayers.Add(taxpayer);
            ShowResume(taxpayer);
            Menu();


        }
        private static void ShowResume(Taxpayer taxpayer)
        {
            string tax = String.Format("{0:0,0.0€}", taxpayer.TaxToPay());
            string income = String.Format("{0:0,0.0€}", taxpayer.Income);
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL’IMPOSTA DA VERSARE:");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {taxpayer.Name} {taxpayer.Surname},");
            Console.WriteLine($"nato il: {taxpayer.Birthday} ({taxpayer.Gender.Substring(0,1).ToUpper()}),");
            Console.WriteLine($"residente in : {taxpayer.Municipality},");
            Console.WriteLine($"codice fiscale : {taxpayer.TaxCode}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato : {income},");
            Console.WriteLine();
            Console.WriteLine($"imposta da versare : {tax}");
        }
        private static void ShowList()
        {
            Console.WriteLine("==============Lista dei contribuenti==============");

            foreach (Taxpayer t in taxpayers)
            {
                string tax = String.Format("{0:0,0.0€}", t.TaxToPay());
                Console.WriteLine(t.Name +" "+t.Surname+" imposta da pagare: "+ tax);
            }
            Console.WriteLine("==================================================");
        }
    }
}
