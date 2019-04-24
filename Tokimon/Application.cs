using System;
using System.Collections.Generic;

namespace Tokimon {
    internal class Application {
        public static void Main(string[] args) {
            string menuName = "Main Menu";
            string[] menuOptions = {"List Tokimons", "Add a new Tokimon", "Remove a Tokimon",
                "Change Tokimon strength", "DEBUG: Dump objects (toString)", "Exit"};
            
            Interface menu = new Interface(menuName, menuOptions);
            menu.PrintMenu();

            int choice = menu.Input();

            List<Tokimon> tokimonContainer = new List<Tokimon>();
            String tokiName = "";
            double tokiSize = 0;
            String tokiType = "";
            int tokiStrength = 0;

            while(true) {
                if(choice == 1) {
                    PrintAllTokimons(tokimonContainer);
                    choice = NewChoice(menu);
                } else if(choice == 2) {
                    AddATokimon(tokiName, tokiType, tokiSize, tokimonContainer);
                    menu.PrintMenu();
                    choice = menu.Input();
                } else if(choice == 3) {
                    PrintAllTokimons(tokimonContainer);
                    
                    if(!(tokimonContainer.Count == 0)) {
                        RemoveTokimon(tokimonContainer);
                    }
    
                    choice = NewChoice(menu);
                } else if(choice == 4) {
                    PrintAllTokimons(tokimonContainer);
    
                    if(!(tokimonContainer.Count == 0)) {
                        IncreaseStrength(tokiStrength, tokimonContainer);
                    }
    
                    choice = NewChoice(menu);
                } else if(choice == 5) {
                    if(tokimonContainer.Count == 0) {
                        Console.WriteLine("\n You don't have any Tokimon objects.\n");
                    } else {
                        PrintAllTokimonObjects(tokimonContainer);
                    }
    
                    choice = NewChoice(menu);
                } else {
                    return;
                }
            }
    }

    private static void PrintAllTokimons(List<Tokimon> tokimonContainer) {
        Console.WriteLine("\n *********************");
        Console.WriteLine("* List of Tokimons: *");
        Console.WriteLine("********************* \n");

        if(tokimonContainer.Count == 0) {
            Console.WriteLine("You don't have any Tokimon.");
            Console.WriteLine();
            return;
        }

        int count = 0;

        foreach(Tokimon toki in tokimonContainer) {
            Console.WriteLine((count + 1) + ". " + toki.TokiName +
                    ", " + toki.TokiSize + " m, " + toki.TokiType +
                    " Ability, " + toki.TokiStrength + " Strength");

            count++;
        }

        Console.WriteLine();
    }

    private static void AddATokimon(String tokiName, String tokiType, double tokiSize, List<Tokimon> tokimonContainer) {
        Console.Write("Enter Tokimon's name:   ");
        tokiName = Console.ReadLine();

        Console.Write("Enter Tokimon's type:   ");
        tokiType = Console.ReadLine();

        Console.Write("Enter Tokimon's size:   ");
        tokiSize = Double.Parse(Console.ReadLine());

        Console.WriteLine();

        Tokimon tokimon = new Tokimon(tokiName, tokiSize, tokiType, 0);

        tokimonContainer.Add(tokimon);
    }

    private static void RemoveTokimon(List<Tokimon> tokimonContainer) {
        Console.WriteLine("Enter the Tokimon number you'd like to remove (0 to cancel): ");
        Console.Write(">  ");
        int tokiNumber = Int32.Parse(Console.ReadLine());
        Console.WriteLine();

        while(tokiNumber < 0 || tokiNumber > tokimonContainer.Count) {
            Console.WriteLine("Enter a valid number (0 to cancel): ");
            Console.Write(">  ");
            tokiNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        if(tokiNumber == 0) {
            return;
        }

        tokimonContainer.RemoveAt(tokiNumber - 1);
    }

    private static void IncreaseStrength(int tokiStrength, List<Tokimon> tokimonContainer) {
        Console.WriteLine("Enter the Tokimon number you'd like to increase strength for (0 to cancel): ");
        Console.Write(">  ");
        int tokiNumber = Int32.Parse(Console.ReadLine());
        Console.WriteLine();

        while(tokiNumber < 0 || tokiNumber > tokimonContainer.Count) {
            Console.WriteLine("Enter a valid Tokimon number (0 to cancel): ");
            Console.Write(">  ");
            tokiNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        if(tokiNumber == 0) {
            return;
        }

        Console.WriteLine("Enter new strength: ");
        tokiStrength = Int32.Parse(Console.ReadLine());
        Console.WriteLine();

        while(tokiStrength < 0) {
            Console.WriteLine("Strength can't be less than 0");
            tokiStrength = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        Tokimon toki = tokimonContainer[tokiNumber - 1];
        toki.TokiStrength = tokiStrength;
    }

    private static void PrintAllTokimonObjects(List<Tokimon> tokimonContainer) {
        Console.WriteLine("\n All Tokimon objects:");

        foreach(Tokimon toki in tokimonContainer) {
            Console.WriteLine(toki + "\n");
        }
    }

    private static int NewChoice(Interface menu) {
        menu.PrintMenu();

        return menu.Input();
    }
    
    }
}