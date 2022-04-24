using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoJoBattles
{
    internal class BattleInterfase
    {
        const int countColomns = 20;

        public void DrawBattle(Enemy enemy1, Enemy enemy2)
        {
            Console.Clear();
            DrawBorder();
            DrawStats(enemy1, enemy2);
            Console.SetCursorPosition(3, 13);

            
        }

        static void DrawStats(Enemy enemy1, Enemy enemy2)
        {
            Console.SetCursorPosition(2, 2);
            Console.Write(enemy1.Name);
            Console.SetCursorPosition(2, 4);
            Console.Write("HP:");
            Console.SetCursorPosition(2, 5);
            DrawHpBar(enemy1);
            Console.SetCursorPosition(2, 7);
            Console.Write("Stamina:");
            Console.SetCursorPosition(2, 8);
            DrawStaminaBar(enemy1);

            Console.SetCursorPosition(Console.WindowWidth - 2 - enemy2.Name.Length, 2);
            Console.Write(enemy2.Name);
            Console.SetCursorPosition(Console.WindowWidth - 5, 4);
            Console.Write("HP:");
            Console.SetCursorPosition(Console.WindowWidth - 24, 5);
            DrawHpBar(enemy2);
            Console.SetCursorPosition(Console.WindowWidth - 10, 7);
            Console.Write("Stamina:");
            Console.SetCursorPosition(Console.WindowWidth - 24, 8);
            DrawStaminaBar(enemy2);
        }

        static void DrawHpBar(Enemy enemy)
        {
            string hpText = hpStaminaText(countColomns, enemy, "HP");
            Console.Write('[');

            int greenColomn = (enemy.Hp - enemy.Hp % countColomns) / 
                ((enemy.MaxHp - enemy.MaxHp % countColomns) / countColomns);

            int j = 1;
            foreach (var i in hpText)
            {
                if (j <= greenColomn)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(i);
                j++;
            }

            Console.ResetColor();
            Console.Write(']');
        }

        static void DrawStaminaBar(Enemy enemy)
        {
            string staminaText = hpStaminaText(countColomns, enemy, "Stamina");
            Console.Write('[');

            int greenColomn = (enemy.Stamina - enemy.Stamina % countColomns) /
                ((enemy.MaxStamina - enemy.MaxStamina % countColomns) / countColomns);

            int j = 1;
            foreach (var i in staminaText)
            {
                if (j <= greenColomn)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else Console.ResetColor();
                Console.Write(i);
                j++;
            }

            Console.ResetColor();
            Console.Write(']');
        }

        static void DrawBorder()
        {
            for (int j = 0; j < Console.WindowWidth; j++)
            {
                Console.SetCursorPosition(j, 0);
                Console.Write('-');
                Console.SetCursorPosition(j, Console.WindowHeight - 1);
                Console.Write('-');
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write('|');
            }
            Console.SetCursorPosition(0, 0);
            Console.Write('*');
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write('*');
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write('*');
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
            Console.Write('*');
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(1, 1);
        }

        static string hpStaminaText(int countColomns, Enemy enemy, string status)
        {
            string info;
            if (status == "HP")
            {
                info = $"{enemy.Hp} / {enemy.MaxHp}";
            } else info = $"{enemy.Stamina} / {enemy.MaxStamina}";
            int halfVoidCount = countColomns / 2 - info.Length / 2;
            string result = "";
            for (int i = 0; i < halfVoidCount; i++)
            {
                result += ' ';
            }

            result += info;

            for (int i = 1; i < halfVoidCount; i++)
            {
                result += ' ';
            }

            return result;
        }

    }
}
