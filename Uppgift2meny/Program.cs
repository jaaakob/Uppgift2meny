using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift2meny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Main menu
0 för att avsluta
1 för att beräkna dit pris
2 för att beräkna priset för en grupp
3 för att uprepa 10 gånger
4 för att skriva ut de tredje ordet i en mening");

            
            bool go = true;

            while (go)
            {
                var menuOpt = Console.ReadLine();

                switch (menuOpt)
                {
                    case "0": // exit
                        return;

                    case "1": // En person pris
                        Console.Write("Ange din ålder:");
                        string input1 = Console.ReadLine();
                        int oneage;
                        if (!int.TryParse(input1, out oneage))
                        {
                            Console.WriteLine("Ange en giltig siffra!");
                            break;
                        }
                        if (oneage < 5) { Console.WriteLine("Under 5 är gratis"); }
                        else if (oneage < 20) { Console.WriteLine("Ungdomspris: 80 kr"); }
                        else if (oneage < 65) { Console.WriteLine("´Standardpris: 120 kr"); }
                        else if (oneage < 100){ Console.WriteLine("Pensionärspris: 120 kr"); }
                        else { Console.WriteLine("Över 100 är gratis"); }
                        go = false;
                        break;

                    case "2": // Flera personer pris
                        Console.WriteLine("Hur många är ni:");
                        int size = Convert.ToInt32(Console.ReadLine());

                        List<int> ages = new List<int>();

                        Console.WriteLine("Ange alla åldrar:");

                        while (ages.Count < size)
                        {
                            int personnr = ages.Count + 1;
                            Console.Write("Person" + personnr + ":");

                            string input2 = Console.ReadLine();

                            if (!int.TryParse(input2, out int age))
                            {
                                Console.WriteLine("Ange en giltig siffra!");
                                continue;
                            }
                            ages.Add(age);
                        }
                        int totPris = 0;

                        foreach (int age in ages)
                        {
                            if (age <= 20 && age >= 5) { totPris += 80; }
                            else if (age <= 65 && age >= 20) { totPris += 120; }
                            else if (age >= 65 && age <= 100) { totPris += 90; }
                        }
                        if (totPris == 0) { Console.WriteLine("Under 5 och över 100 är gratis");}
                        Console.WriteLine("För " + size + " personer kostar det:" + totPris + "kr");
                        go = false;
                        break;

                    case "3": // Upprepa tio gånger
                        Console.Write("Enter input line:");
                        var input = Console.ReadLine();

                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(i + 1 + "." + input + ", ");
                        }
                        break;

                    case "4": // Det tredje ordet
                        Console.WriteLine("Ange en mening med minst tre ord:");
                        int x = 0;
                        do
                        {
                            var ord = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                            string[] orden = ord.ToArray();
                            x = orden.Count();

                            if (x < 3) { Console.WriteLine("Ange en mening med minst tre ord!"); }
                            else { Console.WriteLine(orden[2]); }
                            
                        } while (x < 3);
                        break;

                    default: // Fel input
                        Console.WriteLine("Ange ett alternativ!");
                        break;
                }
            }
        }
    }
}
