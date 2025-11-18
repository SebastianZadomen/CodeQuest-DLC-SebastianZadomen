using System;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;

        const string MenuTitle = "===================================== MAIN MENU - CODEQUEST  =====================================";
        const string MenuOption1 = "1. Train your wizard\n2. Increase LVL\n3. Loot the mine\n4. Show inventory\n5. Buy items\n6. Show attacks by LVL\n7. Decode ancient Scroll\n8. Exit game";
        const string MenuPrompt = "Choose an option (1-8) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 8.";
        const string MsgName = "Enter your name: ";
        const string LineSeparator = "=========================================================================================================";
        const string Space = "";
        const string MsgErrorName = "Your name is not in the correct format";
        const string MsgPower1 = "You are repeating the 2nd call \n                         Gets the level -> {0}";
        const string Title1 = "Raoden el Elantrí";

        const string MsgPower2 = "You still confuse a whisk with a spoon \n                          Gets the level -> {0} ";
        const string Title2 = "Zyn the Buguejat";

        const string MsgPower3 = "You are a summoner of Brises Màgiques.\n                          Gets the level -> {0} ";
        const string Title3 = "Arka Nullpointer";

        const string MsgPower4 = "Wow! You can summon dragons without burning down the lab!\n                          Gets the level -> {0}";
        const string Title4 = "Elarion of the Embers";

        const string MsgPower5 = "You have achieved the rank of Master of the Arcana!\n                          Gets the level -> {0}";
        const string Title5 = "ITB - Wizard el Gris";


        const string Character1Msg = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                      Level : {1}

                        Power : {2}

=========================================================================================================
            ";
        const string Char1UileTraining = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                       Level : {1}

                        Power : {2}

                        Day: {3}                          Hour : {4}

=========================================================================================================
            ";

        const string PowerUiLevel = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                       Level : {1}

                        Power : {2}

                        Title : ";
        const string Char2Battle = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                You have encountered {0} , roll the die to determine your damage      

                                        Good luck, wizard....

=========================================================================================================";

        const string Char2ShowMonster = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                    Monster : {0}                                       Hp:{1}
  
              ";

        const string Char2Dice1 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |       | |
                                              |   o   | /
                                              |       |/ 
                                              '-------'


";
        const string Char2Dice2 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |     o | |
                                              |       | /
                                              | o     |/ 
                                              '-------'
";
        const string Char2Dice3 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |     o | |
                                              |   o   | /
                                              | o     |/ 
                                              '-------'
";

        const string Char2Dice4 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              |       | /
                                              | o   o |/ 
                                              '-------'
";
        const string Char2Dice5 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              |   o   | /
                                              | o   o |/ 
                                              '-------'
                ";
        const string Char2Dice6 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              | o   o | /
                                              | o   o |/ 
                                              '-------'
                ";


        const string Char2TakeDamage = @"
                    
                                        The monster take damage!!

                                        You have done {0} damage

                                Press any key to roll the dice again...

=========================================================================================================";

        const string Char2BattleEnd = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                                  The {0} ,  has been defeated!     

                                               Level up ⬆️

=========================================================================================================";



        const string Welcome = "\t\t\tWelcome, {0} the {1} with level {2}";
        const string MsgOpIncorrect = "Select the correct option.";



        const int DaysMax = 5;

        string titleUser = "";
        int op = 0;
        int doorRandom;
        bool validInput = true;
        int inputNum = 0;
        string inputName = "";
        int level = 1;
        int powerRandom;
        int powerCharacter = 0;
        int hourRandom = 0;
        bool validateName = true;
        int bitcoinCharacter = 0;
        int bitcoinsRandom;
        char mayusLetter;
        bool showWelcome = false;
        string[] monsterName = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍", "Ancient Dragon 🐉" };
        int[] monsterHp = { 3, 5, 10, 11, 18, 15, 20, 50 };
        int hpBattle;
        int damage;
        int monsterRandom;
        //chapter 3 
        char[,] mining = new char[5, 5];
        char[,] showMining = new char[5, 5];
        int mapRandom;
        char excavated = '➖';
        char fail = '❌';
        char coin = '🪙';
        int mapX = 0;
        int mapY = 0;
        int attemps = 5;






        var random = new Random();


        do
        {
            Thread.Sleep(1500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(MenuTitle);
            if (showWelcome)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Welcome, inputName, titleUser,level);
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            Console.WriteLine(MenuOption1);

            Console.Write(MenuPrompt);


            

            try
            {
                op = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(LineSeparator);

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }

            if (validInput)
            {
                switch (op)
                {
                    case 1:
                        Console.Write(MsgName);
                        inputName = Console.ReadLine();

                        validateName = true;


                        for (int i = 0; i < inputName.Length; i++)
                        {
                            if ((inputName[i] >= 'A' && inputName[i] <= 'Z') || (inputName[i] >= 'a' && inputName[i] <= 'z'))
                            {
                                validateName = true;

                            }
                            else
                            {
                                i = 5;
                                validateName = false;

                            }
                        }
                        inputName = inputName.Substring(0, 1).ToUpper() + inputName.Substring(1).ToLower();


                        if (validateName)
                        {
                            Console.WriteLine(Character1Msg, inputName, level, powerCharacter);
                            showWelcome = true;
                            for (int i = 1; i <= DaysMax; i++)
                            {
                                Console.Clear();
                                powerRandom = random.Next(1, 10);
                                hourRandom = random.Next(1, 24);
                                powerCharacter = powerCharacter + powerRandom;

                                Console.WriteLine(Char1UileTraining, inputName, level, powerCharacter, i, hourRandom);
                                Thread.Sleep(2000);
                            }
                            Console.Clear();
                            if (powerCharacter < 20)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgPower1, Title1);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                titleUser = Title1;
                                Thread.Sleep(3000);

                            }
                            if (powerCharacter >= 20 && powerCharacter < 30)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgPower2, Title2);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                titleUser = Title2;

                                Thread.Sleep(3000);


                            }
                            else if (powerCharacter >= 30 && powerCharacter < 35)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgPower3, Title3);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                titleUser = Title3;

                                Thread.Sleep(3000);


                            }
                            else if (powerCharacter >= 35 && powerCharacter < 40)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgPower4, Title4);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                titleUser = Title4;

                                Thread.Sleep(3000);


                            }
                            else if (powerCharacter >= 40)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgPower5, Title5);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                titleUser = Title5;

                                Thread.Sleep(3000);


                            }
                        }
                        else
                        {
                            Console.WriteLine(MsgErrorName);
                            Thread.Sleep(1500);
                        }

                        break;
                    case 2:
                        monsterRandom = random.Next(monsterName.Length);
                        Console.WriteLine(Char2Battle, monsterName[monsterRandom]);
                        Console.ReadKey();
                        Console.Clear();
                        hpBattle = monsterHp[monsterRandom];




                        while (hpBattle > 0)
                        {
                            Console.Clear();
                            Console.WriteLine(Char2ShowMonster, monsterName[monsterRandom], hpBattle);
                            damage = random.Next(1, 6);
                            switch (damage)
                            {
                                case 1: 
                                Console.WriteLine(Char2Dice1);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 2:
                                    Console.WriteLine(Char2Dice2);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 3:
                                    Console.WriteLine(Char2Dice3);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 4:
                                    Console.WriteLine(Char2Dice4);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 5:
                                    Console.WriteLine(Char2Dice5);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 6:
                                    Console.WriteLine(Char2Dice6);
                                    Console.WriteLine(Char2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                            }
                            Console.ReadKey();

                        }
                        Console.WriteLine(Char2BattleEnd, monsterName[monsterRandom]);
                        Console.ReadKey();

                        level++;

                        break;
                    case 3:
                        Console.Clear();
                        for(int i = 0; i < mining.GetLength(0);i++)
                        {
                            for (int j = 0; j < mining.GetLength(1); j++)
                            {
                                mapRandom = random.Next(1, 10);
                                if (mapRandom <= 3)
                                {
                                    mining[i, j] = coin ;
                                }
                                else
                                {
                                    mining[i, j] = excavated;
                                }
                            }
                        }

                        while(attemps > 0)
                        {
                            Console.WriteLine(" 1 2 3 4");

                            for (int i = 0; i < mining.GetLength(0); i++)
                            {
                                Console.Write($"{i}");
                                for (int j = 0; j < mining.GetLength(1); j++)
                                {
                                    Console.Write(mining[i,j]);
                                }
                                Console.WriteLine("");
                            }
                            Console.ReadKey();
                        }
                        break;

                    default:

                        Console.WriteLine(MsgOpIncorrect);

                        break;
                }
            }


        } while (op != 8);
    }

}
