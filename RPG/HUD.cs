using System;
using System.Threading;

namespace RPG
{
    internal class HUD
    {
        static public void Initialization()
        {
            string fighterType;
            string fighterName;
            bool loading = true;
            int seconds = 5;

            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("Hi please select Figther {0} :\n" +
               "Type '1'  ->  Warrior\n" +
               "Type '2'  ->  Wizard\n", i);

                fighterType = Console.ReadLine();

                switch (fighterType)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Fighter selected!\n" +
                            "Please enter your Warrior's name\n");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Wizard selected!\n" +
                            "Please enter your Wizard's name\n");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Not a fighter type :c\n");
                        i -= 1;
                        break;
                }

                fighterName = Console.ReadLine();

                if (fighterType == "1")
                {
                    Warrior warrior = new Warrior(fighterName);
                    Commentator.CommentMatch(warrior);
                    if (i == 1)
                    {
                        App.P1 = warrior;
                    }
                    else if (i == 2)
                    {
                        App.P2 = warrior;
                    }
                }
                else if (fighterType == "2")
                {
                    Wizard wizard = new Wizard(fighterName);
                    Commentator.CommentMatch(wizard);
                    if (i == 1)
                    {
                        App.P1 = wizard;
                    }
                    else if (i == 2)
                    {
                        App.P2 = wizard;
                    }
                }
            }

            if (App.P1 != null && App.P2 != null)
            {
                Console.Clear();
                Console.WriteLine($"Prepare for the battle between {App.P1.GetType().ToString().Substring(4)} {App.P1.Name} and {App.P2.GetType().ToString().Substring(4)} {App.P2.Name}!\n");
                Thread.Sleep(1000);
                while (loading)
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine($"{seconds}\n");
                    seconds -= 1;
                    Thread.Sleep(1000);

                    if (seconds <= 0)
                        loading = false;
                }
            }
        }

        public static void DisplayStats()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("-------------------------------".PadRight(55) + $"Round {App.Round}".PadRight(34) + "-------------------------------");
            Console.Write($"| Class: {App.P1.GetType().ToString().Substring(4)}".PadRight(30) + "|".PadRight(59) +
                "|" + $"Class: {App.P2.GetType().ToString().Substring(4)}".PadLeft(28) + "|".PadLeft(2));
            Console.Write($"| Name: {App.P1.Name.Substring(0, Math.Min(App.P1.Name.Length, 20))}".PadRight(30) + "|".PadRight(59) +
                "|" + $"Name: {App.P2.Name.Substring(0, Math.Min(App.P2.Name.Length, 20))}".PadLeft(28) + "|".PadLeft(2));
            Console.Write($"| HP: {App.P1.HP}".PadRight(30) + "|".PadRight(59) +
                "|" + $"HP: {App.P2.HP}".PadLeft(28) + "|".PadLeft(2));
            Console.Write($"| Mana: {App.P1.MP}".PadRight(30) + "|".PadRight(59) +
                "|" + $"Mana: {App.P2.MP}".PadLeft(28) + "|".PadLeft(2));
            Console.Write($"| Attack: {App.P1.ATK}".PadRight(30) + "|".PadRight(59) +
                "|" + $"Attack: {App.P2.ATK}".PadLeft(28) + "|".PadLeft(2));
            Console.Write($"| Defense: {App.P1.DEF}".PadRight(30) + "|".PadRight(59) +
                "|" + $"Defense: {App.P2.DEF}".PadLeft(28) + "|".PadLeft(2));
            Console.Write("-------------------------------".PadRight(89) + "-------------------------------");
        }
    }
}