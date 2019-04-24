using System;

namespace Tokimon {
    public class Interface {
        private string menuName;
        private string[] menuoptions;

        public Interface(string menuName, string[] menuoptions) {
            this.menuName = menuName;
            this.menuoptions = menuoptions;
        }
        
        public void PrintMenu() {
            Console.WriteLine("*************");
            Console.WriteLine("* " + menuName + " *");
            Console.WriteLine("*************");

            for (int i = 0; i < menuoptions.Length; i++) {
                Console.WriteLine(i + 1 + ". " + menuoptions[i]);
            }
        }

        public int Input() {
            Console.WriteLine(">  ");

            String input = Console.ReadLine();
            int isInteger = ValidateInput(input);

            return isInteger;
        }

        private int ValidateInput(string input) {
            int isInteger = 0;
            
            while(true) {
                try {
                    isInteger = Int32.Parse(input);
                    break;
                } catch (FormatException e) {
                    Console.WriteLine("\nPlease choose one of the options.");
                    Console.WriteLine(">  ");
                }

                input = Console.ReadLine();
            }

            while(isInteger <= 0 || isInteger > 6) {
                Console.WriteLine("\nPlease choose one of the options.");
                Console.WriteLine(">  ");
                isInteger = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }

            return isInteger;
        }
    }
}