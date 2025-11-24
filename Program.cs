using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

public class Program
{
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;


        const int MaxLevel = 5; 

        const string MenuTitle = "===================================== MAIN MENU - CODEQUEST  =====================================";
        const string MenuOption1 = "1. Train your wizard\n2. Increase LVL\n3. Loot the mine\n4. Show inventory\n5. Buy items\n6. Show attacks by LVL\n7. Decode ancient Scroll\n8. Exit game";
        const string MenuPrompt = "Choose an option (1-8) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 8.";
        const string MsgName = "Enter your name: ";
        const string LineSeparator = "=========================================================================================================";
        const string Space = "";
        const string MsgErrorName = "Your name is not in the correct format";
        const string MsgPower1 = "You are repeating the 2nd call \n                          Gets the level -> {0}";
        const string Title1 = "Raoden el Elantrí";

        const string MsgPower2 = "You still confuse a whisk with a spoon \n                           Gets the level -> {0} ";
        const string Title2 = "Zyn the Buguejat";

        const string MsgPower3 = "You are a summoner of Brises Màgiques.\n                           Gets the level -> {0} ";
        const string Title3 = "Arka Nullpointer";

        const string MsgPower4 = "Wow! You can summon dragons without burning down the lab!\n                           Gets the level -> {0}";
        const string Title4 = "Elarion of the Embers";

        const string MsgPower5 = "You have achieved the rank of Master of the Arcana!\n                           Gets the level -> {0}";
        const string Title5 = "ITB - Wizard el Gris";


        const string Character1Msg = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                      Level : {1}

                        Power : {2}

=========================================================================================================
            ";
        const string Chap1UileTraining = @"
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
        const string Chap2Battle = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                You have encountered {0} , roll the die to determine your damage      

                                        Good luck, wizard....

=========================================================================================================";

        const string Chap2ShowMonster = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                    Monster : {0}                                       Hp:{1}
  
              ";

        const string Chap2Dice1 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |       | |
                                              |   o   | /
                                              |       |/ 
                                              '-------'


";
        const string Chap2Dice2 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |     o | |
                                              |       | /
                                              | o     |/ 
                                              '-------'
";
        const string Chap2Dice3 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              |     o | |
                                              |   o   | /
                                              | o     |/ 
                                              '-------'
";

        const string Chap2Dice4 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              |       | /
                                              | o   o |/ 
                                              '-------'
";
        const string Chap2Dice5 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              |   o   | /
                                              | o   o |/ 
                                              '-------'
                ";
        const string Chap2Dice6 = @"

                                                ________
                                               /       /|   
                                              /_______/ |
                                              | o   o | |
                                              | o   o | /
                                              | o   o |/ 
                                              '-------'
                ";


        const string Chap2TakeDamage = @"
                    
                                        The monster take damage!!

                                        You have done {0} damage

                                Press any key to roll the dice again...

=========================================================================================================";

        const string Chap2BattleEnd = @"
===================================== CHAPTER 2 - Increase LVL  ========================================

                                  The {0} ,  has been defeated!     

                                 {1}

                                     Press any key to continue
=========================================================================================================";

        const string Chap2MsgLevelUp = "\t    Level up ⬆️";
        const string Chap2MsgLevelMax = "You have already reached the maximum level (5)";
        const string Chap3Mine = @"
===================================== CHAPTER 3 - Loot the mine  ========================================

                                       You have entered the mine      

                               You have 5 attempts to find the treasures
                                       
                                      Press any key to continue

=========================================================================================================";
        const string Chap3ShowMine = @"
===================================== CHAPTER 3 - Loot the mine  ========================================

                                                                       Attempts : {0}

";

        const string Chap3MineLeaving = @"
===================================== CHAPTER 3 - Loot the mine  ========================================

                                      You've escaped the mine.....

                           You've obtained {0} bits in total, use them wisely

                                      Press any key to continue

=========================================================================================================";
        const string Chap3ShowMap = "\t\t\t\t  0 1 2 3 4";
        const string MsgInputAxisY = "Insert the y axis ᛨ : ";
        const string MsgInputAxisX = "Insert the x axis ⬌ : ";
        const string Chap3MsgMineOkPosition = "You mine at position [{0}][{1}] and you get {2} bits";
        const string Chap3MsgMineKoPosition = "There's nothing left to dig here: [{0}][{1}]";
        const string Chap3MsgMinePositionEmpty = "You mine at position [{0}][{1}] but found nothing.";
        const string Chap3MsgErrorAxis = "Invalid axis. Please enter a value between 0 and 4";
        const string MsgIncorrectFormat = "Incorrect format: {0}";
        const string MsgPressContinue = "Press any key to continue...";



        const string Chap4Inventory = @"
=======================================  CHAPTER 4 - Inventory  ==========================================
";
        const string Objects1 = "\t\t\t\t\t- Iron Dagger 🗡️";
        const string Objects2 = "\t\t\t\t\t- Healing Potion ⚗️";
        const string Objects3 = "\t\t\t\t\t- Ancient Key 🗝️";
        const string Objects4 = "\t\t\t\t\t- Crossbow 🏹";
        const string Objects5 = "\t\t\t\t\t- Metal Shield 🛡";

        const string Chap4MsgEmpty = "\t\t\t\t\tYour inventory is empty.\n";

        const string Chap5Shop = @"
=======================================  CHAPTER 5 - Buy Items  =========================================

                            Welcome to the store, choose your item to buy

                                                                            Bits:{0}
";

        const string Chap5MsgPurchase = @"
         
        You have purchased: {0}                                             -{1}

=========================================================================================================
";
        const string Chap5MsgOption = "Select the item you wish to buy (1 - 5) (0 to exit):";
        const string Chap5MsgLeaving = "Thank you for visiting the shop!";
        const string Chap5MsgNotBits = "You do not have enough bits to purchase this item.";
        const string Chap5MsgIncorretSelection = "The selection is incorrect.....";

        const string Chap6Ability = @"
===================================  CHAPTER 6 - Show attacks by LVL  ===================================

                                    Available attacks for level {0}:
";

        const string Chap7DecodeScroll = @"
=======================================  CHAPTER 7 - Decode Scrol  =========================================

                               
                            You found an ancient scroll with encrypted messages!

                        Scroll to decode:

                            1. The 🐲 sleeps in the mountain of fire 🔥
                            2. Ancient magic flows through the crystal caves
                            3. Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️

                                  You must decode the following scroll:

                                    1. Decipher spell (remove spaces)
                                    2. Count magical runes (vowels)
                                    3. Extract secret code (numbers)

    Choose a decoding operation: ";

        const string Chap7DecodeGUI = @"
=======================================  CHAPTER 7 - Decode Scrol  =========================================

                                You have chosen the message {0} to encrypt:

                               ""{1}""

                Result :

                 {2}{3}

============================================================================================================
";

        const string Chap7MsgFinished = @"
=======================================  CHAPTER 7 - Decode Scrol  =========================================

                Congratulations! You have successfully decoded all parts of the scroll.

============================================================================================================

";

        const string Chap7MsgDeciphered = "Deciphered Spell: ";
        const string Chap7MsgVowelsCount = " magical runes (vowels) found";
        const string Chap7MsgDecodedNumber = "🔮 Decoded number: ";
        

        const string Welcome = "\t\t\tWelcome, {0} the {1} with level {2}";
        const string MsgOpIncorrect = "Select the correct option.";
        const int DaysMax = 5;
        const string MsgGoodBye = @"

█████ █   █  ███  █    █ █   █ █████   █████  ████   ███    █████  █      ███  █    █ █ █    █  █████ 
  █   █   █ █   █ ██   █ █  █  █       █     █    █ █   █   █   ██ █     █   █ ██  ██ █ ██   █ █      
  █   █████ █████ █ █  █ ███   █████   ███   █    █ ████    █████  █     █████  ████  █ █ █  █ █   ██ 
  █   █   █ █   █ █  █ █ █  █      █   █     █    █ █   █   █      █     █   █   ██   █ █  █ █ █    █ 
  █   █   █ █   █ █   ██ █   █ █████   █      ████  █   █   █      █████ █   █   ██   █ █   ██  ████ 

                    ░░░░░░░░▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒░░░░░░░░░ 
                    ░░░░░░░░▒▓▓▒▒▒▒▒░░░░░░░░░░░░░░░░▒▓▓▓▓▒▒▒▒▒░░░░░░░░░ 
                    ░░░░░░░░▒▓▓▓▒▒▒▒▒▓▓▒▒▒▒▒▓▒▓▒▓▒▒▒▒▒▓▓▓▒▒▒▓▒░░░░░░░░░ 
                    ░░░░░░░░░▓█▓▓▓▓▓▒▒▒▒▓▒▒▓▓▓▒▒▒▒░░▒▒▓▓▓▓▓▓▓▒░░░░░░░░░ 
                    ░░░░░░░░░▒▓▓▓▓▒▒▒▒▒▓▓▓▓▓▓▓▒▒▓▒░▒▒▒▒▒▓█▓▓▒░░░░░░░░░░ 
                    ░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓░░░░░░░░░░░ 
                    ░░░░░░░░░░▒▓▓▓▓▓▒▒▓▓▒▒▓▓▓▓▓▒▓▒▒▒▒▒▒▒▒▓▓▒░░░░░░░░░░░ 
                    ░░░░░░░░░░▒▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▒░▒░░░▒▒▒▒░░░░░░░░░░░░░░░ 
                    ░░░░░░░░░▒▓▓▓▓▓▒▓██▓▓▓▒▒▒▒▒░▒▒▒▒░░░░░░░░░░░░░░░░░░░ 
                    ░░░░░░░░░░▓▓▓▓▓██████▓▓▒▒▒░░█████▒░░░░░░░░░░░░░░░░░ 
                    ░░░░░░░░░░▒▓▓▓▓██████▓▒▒▒▒░░█████░░▒▒▒▒░░░░░░░░░░░░ 
                    ░░░░░░░░░░░▒▓▓██▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░ 
                    ░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒░░░▒▒▒▒░░░░░░░░░░░░░░░░░ 
                    ░░░░░░░░░░░░░▓▓▓▓▒▒▒░▒███▒░░░░░▒▒▓▓▒▓▒░░░░░░░░░░░░░ 
                    ░░░░░░░░░░░░░░▒▓▓▓▒▒▒▓▓██▓▒░░░░▒▓▓▓▓███░░░░░░░░░░░░ 
                    ░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▒▓▓▒▓██▓▓█▒░░░░░░░ 
                    ░░░░░░░░░░░░▓▓▓█████▓██▓▓▓▓▓▓▓▓▓█▓░▒▓▒▒▓████▓░░░░░░ 
                    ░░░░░░░░░░▒▓▓▓▓▓▓▓▓█████▓▓▓▓▓▒▒▒██▓░░▓█▓███████░░░░ 
                    ░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓███▓░░▓██▒██▓███░░░ 
                    ░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▒▒▒░▒░░▒▓▓▓██████▒▓█▓████▓██░░░ 
                    ░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▒▒░░░░░▒▒░▒▓██████▓██████████░░░ 
                    ░░░░░░░░░▒▓▓▓▓██▓▓▓▒▒▒▒░░░░▒░░▒▓██▓▓▓█▓█▓██████▒░░░ 
                    ░░░░░░░░░░▒▓▓████▓▓▒▒▒░░░░░░▒░▒▓▓▒▒▒▒▓██▓█████▓░░░░ 
                    ░░░░░░░░░░▒▓▓▓███▓▓▒▒▒▒▒▒░░░░░▒▓▓▓▓▓████▓██████▓░░░ 
                    ░░░░░░░░░░▒▓▓▓▓██▓▓▓▓▒▒▒▒░░░░▒▓▓▒░░░░▒███▓█████▓░░░ 
                    ░░░░░░░░░░░▒▒▒▓▓██▓▓▓▓▒▒░░░░░▒▓▒▒░▒▒▒▒▒▓███████▒░░░ 
                    ░░░░░░░░░░░▒▒▒▒▓▓█▓▓▓▓▒▒▒▒░░░▒▓▒▒▒▒▒▒▓▓████████░░░░ 
                    ░░░░░░░░░░░▒▒▒▒▒▒▓▓▓▓▓▓▓▒▒▒▒▒▒▓▒▒░░▒▒▒▒▓██████▒░░░░ 
                    ░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▓▓▓▒▒▒▓▓▓▒▒▓▓▓▓▓█████▓░░░░░░ 
                    ░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓▓▓▒▒▒▒▒▒▒▓██▒░░░░░░░ 
                    ░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▓▓▓▒▒▒░░░░░░░░░ 



"; 

        string titleUser = "";
        int op = 0;
        bool validInput = true;
        string inputName = "";
        int level = 1;
        int powerRandom;
        int powerCharacter = 0;
        int hourRandom = 0;
        bool validateName = true;
        //Chapter 2
        char mayusLetter;
        bool showWelcome = false;
        string[] monsterName = { "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍", "Ancient Dragon 🐉" };
        int[] monsterHp = { 3, 5, 10, 11, 18, 15, 20, 50 };
        int hpBattle = 0;
        int damage;
        int monsterRandom;
        //chapter 3 
        string[,] mining = new string[5, 5];
        string[,] showMining = new string[5, 5];
        int mapRandom;
        string notExcavated = "➖";
        string excaUnsuccessfully= "❌";
        string coin = "🪙";
        int mapY = 0;
        int mapX = 0;
        int attemps = 5;
        int bitCharacter = 0;
        int bitRandom;

        //chapter 4 
        int[] inventory  = {0, 0 , 0 , 0 , 0 };


        //chapter5
        string[] shop = { "Iron Dagger 🗡️", "Healing Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹", "Metal Shield 🛡️" };
        int[] price = { 30, 10, 50, 40, 20 };
        int shopOption;
        int optionCount = 1;
        bool validateShop = true;

        //chapter 6
        string[][] powerLevel = new string[][] {
            new string[]{"Magic Spark 💫" },
            new string[]{ "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" },
            new string[]{ "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" },
            new string[]{"Wave of Light ⚜️", "Storm of Wings 🐦" },
            new string[]{ "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" }
        }; 

        //chapter 7 
        int scrollOpcion = 0;
        string[] scrollText = { "The 🐲 sleeps in the mountain of fire 🔥", "Ancient magic flows through the crystal caves", "Spell: Ignis 5 🔥, Aqua 6 💧, Terra 3 🌍, Ventus 8 🌪️" };
        string saveWord = "";
        string result = "";
        int countVowels = 0 ;
        string secretNumber = "";
        int countCase1 = 0 ;
        int countCase2 = 0 ;
        int countCase3 = 0;

        var random = new Random();


        do
        {
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
                validInput = true;
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(MsgIncorrectFormat, ex.Message);
                validInput = false;
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MsgIncorrectFormat, ex.Message);
                validInput = false;
                Thread.Sleep(1000);

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
                                i = inputName.Length+1;
                                validateName = false;

                            }
                        }
                        


                        if (validateName && !inputName.Equals(""))
                        {
                            inputName = inputName.Substring(0, 1).ToUpper() + inputName.Substring(1).ToLower();
                            Console.WriteLine(Character1Msg, inputName, level, powerCharacter);
                            showWelcome = true;
                            for (int i = 1; i <= DaysMax; i++)
                            {
                                Console.Clear();
                                powerRandom = random.Next(1, 10);
                                hourRandom = random.Next(1, 24);
                                powerCharacter = powerCharacter + powerRandom;

                                Console.WriteLine(Chap1UileTraining, inputName, level, powerCharacter, i, hourRandom);
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
                        hpBattle = 0;
                        monsterRandom = random.Next(monsterName.Length);
                        hpBattle = monsterHp[monsterRandom];
                        Console.WriteLine(Chap2Battle, monsterName[monsterRandom]);
                        Console.ReadKey();
                        
                       

                        while (hpBattle > 0)
                        {
                            Console.Clear();
                            Console.WriteLine(Chap2ShowMonster, monsterName[monsterRandom], hpBattle);
                            damage = random.Next(1, 6);
                            switch (damage)
                            {
                                case 1:
                                    Console.WriteLine(Chap2Dice1);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 2:
                                    Console.WriteLine(Chap2Dice2);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 3:
                                    Console.WriteLine(Chap2Dice3);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 4:
                                    Console.WriteLine(Chap2Dice4);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 5:
                                    Console.WriteLine(Chap2Dice5);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                                case 6:
                                    Console.WriteLine(Chap2Dice6);
                                    Console.WriteLine(Chap2TakeDamage, damage);
                                    hpBattle -= damage;
                                    break;
                            }
                            Console.ReadKey();
                        }
                        
                       
                        if (level < 5)
                        {
                            Console.WriteLine(Chap2BattleEnd, monsterName[monsterRandom],Chap2MsgLevelUp);
                            Console.ReadKey();
                            level++;
                        }
                        else
                        {
                            Console.WriteLine(Chap2BattleEnd, monsterName[monsterRandom],Chap2MsgLevelMax);
                            Console.ReadKey();

                        }


                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(Chap3Mine);
                        Console.ReadKey();
                        for (int i = 0; i < mining.GetLength(0);i++)
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
                                    mining[i, j] = excaUnsuccessfully;
                                }
                            }
                        }
                        for (int i = 0; i < showMining.GetLength(0); i++)
                        {
                            for (int j = 0; j < showMining.GetLength(1); j++)
                            {
                                showMining[i, j] = notExcavated;
                                
                            }
                        }

                        while (attemps > 0)
                        {
                            Console.Clear();
                            Console.WriteLine(Chap3ShowMine, attemps);
   

                            Console.WriteLine(Chap3ShowMap);

                            for (int i = 0; i < showMining.GetLength(0); i++)
                            {
                                Console.Write($"\t\t\t\t{i}");
                                for (int j = 0; j < showMining.GetLength(1); j++)
                                {
                                    Console.Write(showMining[i,j]);
                                }
                                Console.WriteLine(Space);
                            }

                            try
                            {
                                Console.WriteLine(Space);
                                Console.Write(MsgInputAxisY);
                                mapY = Convert.ToInt32(Console.ReadLine());

                                Console.Write(MsgInputAxisX);
                                mapX = Convert.ToInt32(Console.ReadLine());

                                if (mapY >= 0 && mapY <= 4 && mapX >= 0 && mapX <= 4)
                                {
                                    if (mining[mapY, mapX].Equals(coin) && showMining[mapY, mapX].Equals(notExcavated))
                                    {
                                        bitRandom = random.Next(5, 50);
                                        showMining[mapY, mapX] = coin;
                                        Console.ForegroundColor = ConsoleColor.Green;


                                        Console.WriteLine(Chap3MsgMineOkPosition, mapY, mapX, bitRandom);
                                        bitCharacter += bitRandom;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        attemps--;


                                    }
                                    else if (mining[mapY, mapX].Equals(coin) && showMining[mapY, mapX].Equals(coin))
                                    {
                                        showMining[mapY, mapX] = excaUnsuccessfully;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(Chap3MsgMineKoPosition, mapY, mapX);
                                        attemps--;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }
                                    else
                                    {
                                        showMining[mapY, mapX] = excaUnsuccessfully;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(Chap3MsgMinePositionEmpty, mapY, mapX);
                                        attemps--;
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                    }

                              
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(Chap3MsgErrorAxis);
                                    attemps--;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(MsgIncorrectFormat,  ex.Message);
                                attemps--;
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                            Thread.Sleep(1500);
                        }
                        Console.Clear();
                        Console.WriteLine(Chap3MineLeaving, bitCharacter);
                        Console.ReadKey();
                        attemps = 5;
                        break;
                    case 4:
                        Console.Clear();   
                        Console.WriteLine(Chap4Inventory); 
                        if (inventory[0].Equals(0) && inventory[1].Equals(0) && inventory[2].Equals(0) && inventory[3].Equals(0) && inventory[4].Equals(0))
                        {
                            Console.WriteLine(Chap4MsgEmpty);

                        }

                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] != 0)
                            { 
                                for (int j = 0; j < inventory[i]; j++)
                                {
                                     
                                    switch (i)
                                    {
                                        case 0:
                                            Console.WriteLine("\t\t\t\t\t-{0}",shop[0]); ;
                                            break;
                                        case 1:
                                            Console.WriteLine("\t\t\t\t\t-{0}", shop[1]);

                                            break;
                                        case 2:
                                            Console.WriteLine("\t\t\t\t\t-{0}", shop[2]);

                                            break;
                                        case 3:
                                            Console.WriteLine("\t\t\t\t\t-{0}", shop[3]);
                                            break;
                                        case 4:
                                            Console.WriteLine("\t\t\t\t\t-{0}", shop[4]);
                                            break;
                                        
                                    }
                                }
                               
                            }
                        }
                        Console.WriteLine(Space);
                        Console.WriteLine(LineSeparator);
                        Console.WriteLine(MsgPressContinue);
                        Console.ReadKey();


                        break;
                    case 5:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine(Chap5Shop, bitCharacter);
                            for (int i = 0; i < shop.Length; i++)
                            {
                                if (i.Equals(3))
                                {
                                    Console.WriteLine("\t\t\t\t\t{0}. {1}\t\t\t\t{2}", optionCount, shop[i], price[i]);
                                    optionCount++;
                                }
                                else
                                {
                                    Console.WriteLine("\t\t\t\t\t{0}. {1}\t\t\t{2}", optionCount, shop[i], price[i]);
                                    optionCount++;

                                }
                            }
                            optionCount = 1;
                            Console.WriteLine(Space);
                            Console.Write(Chap5MsgOption);
                            shopOption = Int32.Parse(Console.ReadLine());
                            if (shopOption != 0)
                            {
                                if (shopOption >= 1 && shopOption <= 5)
                                {
                                    for (int i = 0; i < shop.Length; i++)
                                    {
                                        if (shopOption - 1 == i && price[shopOption - 1] <= bitCharacter)
                                        {
                                            inventory[i]++;
                                            bitCharacter -= price[i];
                                            i = shop.Length + 1;
                                            validateShop = true;
                                            Console.WriteLine(Chap5MsgPurchase, shop[shopOption - 1], price[shopOption - 1]);
                                            Console.WriteLine(Space);
                                            Console.WriteLine(MsgPressContinue);
                                            Console.ReadKey();

                                        }
                                        else
                                        {
                                            validateShop = false;

                                        }
                                    }
                                    if (!validateShop)
                                    {
                                        Console.WriteLine(Space);
                                        Console.WriteLine(Chap5MsgNotBits);
                                        Console.WriteLine(Space);
                                        Console.WriteLine(LineSeparator);
                                        Console.WriteLine(MsgPressContinue);
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Space);
                                    Console.WriteLine(Chap5MsgIncorretSelection);
                                    Console.WriteLine(Space);
                                    Console.WriteLine(LineSeparator);
                                    Console.WriteLine(MsgPressContinue);
                                    Console.ReadKey();
   


                                }

                            }
                            else
                            {
                                Console.WriteLine(Chap5MsgLeaving);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                                Console.ReadKey();


                            }

                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(MsgIncorrectFormat, ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Thread.Sleep(1000);

                        }
                        break;
                    case 6:
                        Console.WriteLine(Chap6Ability,level);
                        for (int i = 0; i < powerLevel.Length; i++)
                        {
                            if (level - 1 == i)
                            {
                                Console.Write("\t\t");
                                for (int j = 0; j < powerLevel[i].Length; j++)
                                {
                                    Console.Write("- {0} ", powerLevel[i][j]);
                                }
                            }
                            else if (level - 1 >= powerLevel.Length)
                            {
                                Console.Write("\t\t");
                                for (int j = 0; j < powerLevel[powerLevel.Length - 1].Length; j++)
                                {
                                    Console.Write("- {0} ", powerLevel[powerLevel.Length - 1][j]);
                                }

                                i = powerLevel.Length + 1;
                            }

                        }
                        Console.WriteLine(Space);
                        Console.WriteLine(LineSeparator);
                        Console.WriteLine(MsgPressContinue);
                        Console.ReadKey();
                        break;
                    case 7:
                        try
                        {
                            Console.Clear();
                            Console.Write(Chap7DecodeScroll);
                            scrollOpcion = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(Space);
                            result = "";
                        
                            switch (scrollOpcion)
                            {
                                case 1 :

                                    saveWord = scrollText[scrollOpcion - 1];
                                        for (int i = 0; i < saveWord.Length; i++)
                                        {
                                            if (saveWord[i].ToString() != " ")
                                            {
                                                result += saveWord[i];
                                            }

                                        }
                                    countCase1 = 1;
                                        Console.WriteLine(Chap7DecodeGUI, scrollOpcion, scrollText[scrollOpcion - 1], Chap7MsgDeciphered, result);                                    

                                break;
                                case 2:
                                    saveWord = scrollText[scrollOpcion-1];
                                    foreach (char vowels in saveWord)
                                    {
                                        if (vowels.Equals('a') || vowels.Equals('i') || vowels.Equals('o') || vowels.Equals('e') || vowels.Equals('u') || vowels.Equals('A') || vowels.Equals('E') || vowels.Equals('I') || vowels.Equals('O'))
                                        {
                                            countVowels++;
                                        }


                                    }
                                    countCase2 = 1;
                                    Console.WriteLine(Chap7DecodeGUI, scrollOpcion, scrollText[scrollOpcion - 1], countVowels, Chap7MsgVowelsCount);
                                    break;
                                case 3:
                                    saveWord = scrollText[scrollOpcion - 1];
                                    foreach (char number in saveWord) 
                                    {
                                        if (number >= '1' && number <= '9' )
                                        {
                                            secretNumber += number;
                                        }
                                    }
                                    countCase3 = 1;
                                    Console.WriteLine(Chap7DecodeGUI, scrollOpcion, scrollText[scrollOpcion - 1], Chap7MsgDecodedNumber, secretNumber);

                                    break;
                            }

                            if (  countCase1 + countCase2 + countCase3 ==  3 )
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine(Chap7MsgFinished);
                                Console.ForegroundColor = ConsoleColor.Gray;

                            }
                            Console.WriteLine(MsgPressContinue);
                            Console.ReadKey();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(MsgIncorrectFormat, ex.Message);
                        }
                        break;
                        case 8:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor= ConsoleColor.Black;

                        Console.Clear();
                        Console.WriteLine(MsgGoodBye);
                        break;
                        default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(InputErrorMessage);
                        Thread.Sleep(1000);
                        break;
                }
            }


        } while (op != 8);
    }

}
