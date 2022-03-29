using System;
using System.Threading;

namespace RPG
{
    internal class App
    {
        //Warrior YASOU = new Warrior("YASOU", 1000, 0, 9999, 667, true);
        static private Fighters p1 = null;

        static private Fighters p2 = null;
        static private int round = 0;

        public void Run()
        {
            Console.Title = "~~~RPG_FIGHTER~~~";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            HUD.Initialization();
            //HUD.DisplayStats();

            p1.Enemy = p2;
            p2.Enemy = p1;

            bool run = true;
            if (p1 != null && p2 != null)
            {
                while (run)
                {
                    Console.Clear();
                    HUD.DisplayStats();
                    p1.Fight();
                    if (p2.HP != 0)
                        p2.Fight();

                    if (p1.HP <= 0 || p2.HP <= 0)
                    {
                        HUD.DisplayStats();
                        Thread.Sleep(2000);
                        run = false;
                    }

                    Console.ReadKey();
                    Round += 1;
                }
            }
        }

        static public Fighters P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        static public Fighters P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        static public int Round
        {
            get { return round; }
            set { round = value; }
        }
    }
}