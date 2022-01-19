using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Game
{
    class Unit
    {
        public int damage;
        public int health;
    }

    class Shield
    {
        public int armor;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game();
            void Game()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
          _______  _______  _______ 
|\     /|(  ___  )(  ____ )(  ____ \
| )   ( || (   ) || (    )|| (    \/
| | _ | || (___) || (____)|| (_____ 
| |( )| ||  ___  ||     __)(_____  )
| || || || (   ) || (\ (         ) |
| () () || )   ( || ) \ \__/\____) |
(_______)|/     \||/   \__/\_______)
 _             _____       _              
| |           |  _  |     (_)             
| |__  _   _  | | | |_   _ _ _______  ___ 
| '_ \| | | | | | | | | | | |_  / _ \/ __|
| |_) | |_| | \ \/' / |_| | |/ /  __/\__ \
|_.__/ \__, |  \_/\_\\__,_|_/___\___||___/
        __/ |                             
       |___/                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Unit unit = new Unit();
                Unit enemyUnit = new Unit();
                Shield shield = new Shield();
                Shield enemyShield = new Shield();

                unit.health = 100;
                enemyUnit.health = 100;
                Random unitShieldRandom = new Random();
                Random enemyUnitShieldRandom = new Random();
                Random random = new Random();
                Random randomEnemyUnit = new Random();

                while (unit.health > 0 && enemyUnit.health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("|===========================|");
                    Console.WriteLine("|Нажмите, чтоб Ударить!     |");
                    Console.WriteLine("|===========================|");
                    Console.ReadLine();
                    shield.armor = unitShieldRandom.Next(1, 10);
                    enemyShield.armor = enemyUnitShieldRandom.Next(1, 11);

                    unit.damage = random.Next(5, 15);
                    Console.WriteLine($"Урон юнита: {unit.damage}");
                    enemyUnit.damage = randomEnemyUnit.Next(0, 19);
                    Console.WriteLine($"Урон вражеского юнита: {enemyUnit.damage}");

                    unit.health -= enemyUnit.damage;
                    if (shield.armor > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Успешно удалось парировать атаку соперника!\nЩит отразил: {shield.armor} единиц урона");
                        unit.health += shield.armor;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Парировать не удалось...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (unit.health > 80)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        UnitHpColorWhite();
                    }
                    if (unit.health < 80 && unit.health > 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        UnitHpColorWhite();
                    }
                    if (unit.health < 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        UnitHpColorWhite();
                        MinMaxHpOfUnit();
                    }

                    enemyUnit.health -= unit.damage;
                    if (enemyShield.armor > 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Врагу успешно удалось парировать атаку!\nЩит отразил: {enemyShield.armor} единиц урона");
                        enemyUnit.health += enemyShield.armor;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Врагу парировать не удалось...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (enemyUnit.health > 80)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        EnemyUnitHpColorWhite();
                    }

                    if (enemyUnit.health < 80 && enemyUnit.health > 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        EnemyUnitHpColorWhite();
                    }

                    if (enemyUnit.health < 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        EnemyUnitHpColorWhite();
                        MinMaxHpOfEnemyUnit();
                    }
                }

                if (unit.health > 0 && enemyUnit.health < 0 || enemyUnit.health == 0 && unit.health != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Так держать! Победа наша");
                }
                else if (unit.health == 0 & enemyUnit.health == 0 || unit.health < 0 && enemyUnit.health < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ничья!");
                }
                else if (unit.health <= 0 && enemyUnit.health > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Мы проиграли...\nВ следующий раз нам точно повезет");
                }

                Winner();

                void EnemyUnitHpColorWhite()
                {
                    MinMaxHpOfEnemyUnit();
                    Console.WriteLine($"Здоровье вражеского юнита: {enemyUnit.health}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void UnitHpColorWhite()
                {
                    MinMaxHpOfUnit();
                    Console.WriteLine($"Здоровье юнита: {unit.health}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                void MinMaxHpOfUnit()
                {
                    if (unit.health < 0)
                    {
                        unit.health = 0;
                    }
                    if (unit.health > 100)
                    {
                        unit.health = 100;
                    }
                }

                void MinMaxHpOfEnemyUnit()
                {
                    if (enemyUnit.health < 0)
                    {
                        enemyUnit.health = 0;
                    }
                    if (enemyUnit.health > 100)
                    {
                        enemyUnit.health = 100;
                    }
                }
            }

            void Winner()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int userInput = 0;

                do
                {
                    userInput = DisplayMenu();
                    if (userInput == 1)
                    {
                        Console.WriteLine("Перезапуск");
                        Game();
                    }

                } while (userInput != 3);

                int DisplayMenu()
                {
                    Console.WriteLine(@"Для перезапуска - нажмите ""ВВОД""");
                    var result = Console.ReadLine();

                    if (result == null)
                    {
                        Winner();
                    }
                    return 1;
                }
            }
        }
    }
}