using System;
using System.Collections.Generic;
using AssetSystem;

namespace Tejo_Activity_Inheritance_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PropertyAsset> propertyAssets = new List<PropertyAsset>();
            bool run = true;
            while (run)
            {
                SystemMenu.DisplaySystemMenu();
                Console.WriteLine("Enter choice:(1-5)");
                int.TryParse(Console.ReadLine(), out int value);
                switch (value)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter Code: ");
                        string num = Console.ReadLine();
                        Console.Write("Enter Tax: ");
                        double.TryParse(Console.ReadLine(), out double tax);
                        Console.Write("Enter Frontage: ");
                        double.TryParse(Console.ReadLine(), out double front);
                        Console.Write("Enter Depth: ");
                        double.TryParse(Console.ReadLine(), out double depth);
                        ResidentialLot lot = new ResidentialLot(num, tax, front, depth);
                        Console.Write($"{lot.DisplayResidentialLot()}");
                        propertyAssets.Add(lot);
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter Code: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Tax: ");
                        double.TryParse(Console.ReadLine(), out double vpt);
                        Console.Write("Enter Radius: ");
                        double.TryParse(Console.ReadLine(), out double radius);
                        CircularStorageDepot depot = new CircularStorageDepot(name, vpt, radius);
                        Console.Write($"{depot.DisplayCircularStorageDepot()}");
                        propertyAssets.Add(depot);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Code: ");
                        string code = Console.ReadLine();
                        Console.Write("Enter Tax: ");
                        double.TryParse(Console.ReadLine(), out double taxRate);
                        Console.Write("Enter Base of Triangle: ");
                        double.TryParse(Console.ReadLine(), out double baseT);
                        Console.Write("Enter Height of Triangle: ");
                        double.TryParse(Console.ReadLine(), out double height);
                        Console.Write("Enter Side 1 of Triangle: ");
                        double.TryParse(Console.ReadLine(), out double side1);
                        Console.Write("Enter Side 2 of Triangle: ");
                        double.TryParse(Console.ReadLine(), out double side2);
                        Console.Write("Enter Side 3 of Triangle: ");
                        double.TryParse(Console.ReadLine(), out double side3);
                        TriangularPark park = new TriangularPark(code, taxRate, baseT, height, side1, side2, side3);
                        Console.Write($"{park.DisplayTriangularPark()}");
                        propertyAssets.Add(park);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("...\n");
                        DisplayAllAssetsTable();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Goodbye!!!");
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid! Please type 1-5");
                        break;
                    }
                if (propertyAssets != null)
                {
                    Console.WriteLine("Asset Successfully Added");
                }
            }

             void DisplayAllAssetsTable()
            {
                if (propertyAssets.Count == 0)
                {
                    Console.WriteLine("The system database is completely empty. Please add assets first!");
                    return;
                }

                double totalCombinedTax = 0.0;

                Console.WriteLine("=========================================================================");
                Console.WriteLine($"{"Property Code",-15} | {"Area (sq m)",-12} | {"Perimeter (m)",-14} | {"Est. Tax ($)",-15}");
                Console.WriteLine("=========================================================================");

                foreach (PropertyAsset asset in propertyAssets)
                {
                    double area = asset.ComputeFootprintArea();
                    double perimeter = asset.ComputeEnclosurePerimeter();
                    double estimatedTax = asset.ComputeEstimatedTax();

                    totalCombinedTax += estimatedTax;

                    Console.WriteLine($"{asset.PropertyCode,-15} | {area,-12:F2} | {perimeter,-14:F2} | ${estimatedTax,-14:F2}");
                }

                Console.WriteLine("=========================================================================");
                Console.WriteLine($"Total Combined Tax for All Stored Assets: ${totalCombinedTax:F2}");
                Console.WriteLine("=========================================================================");
            }

            static void DisplayAssetCalculations(PropertyAsset asset)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine($"Property Code        : {asset.PropertyCode}");
                Console.WriteLine($"Tax Rate / Unit Area : ${asset.TaxRatePerUnitArea:F2}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Footprint Area       : {asset.ComputeFootprintArea():F2} sq m");
                Console.WriteLine($"Enclosure Perimeter  : {asset.ComputeEnclosurePerimeter():F2} m");
                Console.WriteLine($"Estimated Tax        : ${asset.ComputeEstimatedTax():F2}");
                Console.WriteLine("==================================================");
            }
        }
    }
}