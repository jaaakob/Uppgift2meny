using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift2meny
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Main menu:
Ange 0 för att avsluta
1 för att beräkna dit pris
2 för att beräkna priset för en grupp");
        Start:
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
                        goto Start;
                    }

                    if (oneage < 20) { Console.WriteLine("Ungdomspris: 80 kr"); }
                    else if (oneage > 65) { Console.WriteLine("Pensionärspris: 90 kr"); }
                    else { Console.WriteLine("Standardpris: 120 kr"); }
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
                        if (age < 20) { totPris += 80; }
                        else if (age > 65) { totPris += 90; }
                        else { totPris += 120; }
                    }
                    Console.WriteLine("För " + size + " personer kostar det:" + totPris + "kr");
                    break;
                default: // Fel input
                    Console.WriteLine("Ange ett alternativ!");
                    goto Start;
            }
        }
    }
}
