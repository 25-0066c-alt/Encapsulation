using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Encapsulation
{
    internal class Program
    {
        static Random random = new Random();
        public class You
        {
            public int PHealth { get; private set; }
            public bool IsAlive
            {
                get { return PHealth > 0; }
            }

            public You()
            {
                PHealth = 1000;
            }
            public void TakeDamage()
            {
                int damage = random.Next(10, 401);
                PHealth -= damage;

                if (PHealth < 0)
                {
                    PHealth = 0;
                }

                Console.WriteLine($"You took {damage} damage!");
                Console.WriteLine($"Current HP: {PHealth}");            
            }
        }


            public class Hakari
        {
            public string Name { get; set; }
            public int Health { get; private set; }
            public bool IsAlive
            {
                get { return Health > 0; }
            }

            public Hakari()
            {
                Name = "Hakari";
                Health = 1000;
            }
            public void TakeDamage()
            {
                int damage = random.Next(10, 501);
                Health -= damage;

                if (Health < 0)
                {
                    Health = 0;
                }

                Console.WriteLine($"{Name} took {damage} damage!");
                Console.WriteLine($"Current HP: {Health}");

                //healing spot
                int healingChance;

                if (damage >= 400)
                {
                    healingChance = 75;
                }
                else if (damage >= 300)
                {
                    healingChance = 50;
                }
                else if (damage >= 200)
                {
                    healingChance = 30;
                }
                else if (damage >= 100)
                {
                    healingChance = 15;
                }

                else
                {
                    healingChance = 5;
                }

                int roll = random.Next(1, 101);

                if (roll <= healingChance && Health > 0)
                {
                    Health += 300;

                    if (Health > 1000)
                    {
                        Health -= 1000;
                    }

                    Console.WriteLine($"HAKARI HIT JACKPOT! He healed 300 HP!");
                    Console.WriteLine($"Current HP: {Health}");
                }
            }

        }

        static void Main(string[] args)
        {

            Hakari hakari = new Hakari();
            You you = new You();

            Console.WriteLine("             WELCOME TO FIGHT HAKARI!             ");
            Console.WriteLine();
            Console.WriteLine("MECHANICS:");
            Console.WriteLine(" Press [ENTER] to attack Hakari.");
            Console.WriteLine(" Hakari will immediately counterattack.");
            Console.WriteLine(" The more damage Hakari takes, the higher his chance");
            Console.WriteLine(" to hit a JACKPOT and heal 300 HP!");
            Console.WriteLine("\nPress ENTER to start the game!");
            Console.ReadKey();
            Console.Clear();

            while (you.IsAlive && hakari.IsAlive)
            {
                Console.WriteLine(@"
   .------\ /------.
   |       -       |
   |               |
   |               |
   |               |
_______________________
===========.===========
  / ~~~~~     ~~~~~ \
 /|     |     |      \
 W   ---  / \  ---   W
 \.      |o o|      ./
  |                 |
  \    #########    /
   \  ## ----- ##  /
    \##         ##/
     \_____v_____/");
                Console.WriteLine("\nPress ENTER to attack Hakari");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Hakari's Health");
                Console.WriteLine(@"
   .------\ /------.
   |       -       |
   |               |
   |               |
   |               |
_______________________
===========.===========
  / ~~~~~     ~~~~~ \
 /|   0  |    | 0    \
 W   ---  / \  ---   W
 \.      |o o|      ./
  |                 |
  \    #########    /
   \  ## ----- ##  /
    \##  _____  ##/
     \_____v_____/");
                hakari.TakeDamage();

                Console.WriteLine();

                Console.WriteLine("Your health");
                you.TakeDamage();

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

                Console.Clear();
            }

            if (!you.IsAlive && !hakari.IsAlive)
            {
                Console.WriteLine("\nTied!");
            }
            else if (!you.IsAlive)
            {
                Console.WriteLine("\n\t\t\t     You lost!");
                Console.WriteLine(@"                                                                     
                            .-+*######+-.                            
                       ..+%%%##*##%%%%##%%%=..                       
                     .=%%+..----------*%%#*#%%-.                     
                   .=%*..:---------------*%%**%%-.                   
                  .%%..:-------------------#%#**%#.                  
                 :%* .:---------------------+%#**%%.                 
                .%+  ------------------------+%#**#%.                
               .##..:-------------------------*%***%%.               
               :%- .--------------------------=%#**#%:               
               =%: .---------------------------%%***%=.              
               +%. .----#####*--+#-=#####+----=%%***%*.              
               +%. .----##---##=+#--#*---##---=%%***%*.              
               +%. .----##---*#=+#--#*---*#--==%%***%*               
               +%. .----######=-+#--######--===%%***%*               
               +%. .----##+##=--+#--#*----=====%%***%*               
               +%. .----##--=##-+#-=#*---======%%***%*               
               +%. .--------------------=======%%***%*                                        
               +%. .-------------==============%%***%*.                       
               +%. .-----======================%%***%*.              
               +%. .===========================%%***%*.                          
         .-+***#%***###########################%%###%#**++-.                     
       :%%############################################%%%%%%%:       
       .:--::::::::::::::::::::::::::::::::::::::::::::::::::.  ");
            }
            else
            {
                Console.WriteLine("\nHakari lost!");
            }
            Console.ReadKey();

        }
    }
}
