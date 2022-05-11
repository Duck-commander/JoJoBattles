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

        public void DrawBattleInit(Enemy enemy1, Enemy enemy2)
        {
            Console.Clear();
            DrawBorder();
            DrawStats(enemy1, enemy2);
            DrawMessageBord(enemy1, 1);
            DrawMessageBord(enemy2, Console.WindowWidth / 2 + 1);
        }

        public void DrawBattleUpdate(Enemy enemy1, Enemy enemy2)
        {
            DelLastSymb();
            DrawStats(enemy1, enemy2);
            DrawMessageBord(enemy1, 1);
            DrawMessageBord(enemy2, Console.WindowWidth / 2 + 1);
        }

        static void DrawStats(Enemy enemy1, Enemy enemy2)
        {
            Console.SetCursorPosition(2, 2);
            Console.ForegroundColor = enemy1.NameColor;
            Console.Write(enemy1.Name);
            Console.ResetColor();

            Console.SetCursorPosition(2, 4);
            Console.Write("HP:");

            Console.SetCursorPosition(2, 5);
            DrawHpBar(enemy1);

            Console.SetCursorPosition(2, 7);
            Console.Write("Stamina:");

            Console.SetCursorPosition(2, 8);
            DrawStaminaBar(enemy1);


            Console.SetCursorPosition(Console.WindowWidth - 2 - enemy2.Name.Length, 2);
            Console.ForegroundColor = enemy2.NameColor;
            Console.Write(enemy2.Name);
            Console.ResetColor();

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
            string hpText = HpStaminaText(countColomns, enemy, "HP");
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
            string staminaText = HpStaminaText(countColomns, enemy, "Stamina");
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
                Console.SetCursorPosition(j, Console.WindowHeight - Console.WindowHeight / 3 - 3);
                Console.WriteLine('-');
            }
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write('|');
                if (i > 0 && i < Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, i);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('|');
                    Console.ResetColor();
                }
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
        }

        private void DrawMessageBord(Enemy enemy, int position)
        {
            int boardMessage = Console.WindowWidth / 2 - 3;
            int globalLine = Console.WindowHeight - 2;
            position += 1;

            for (int i = enemy.messageBoard.Count; i > 0; i--)
            {
                int lengthMessage = enemy.messageBoard[i - 1].Length;
                int lines = lengthMessage / boardMessage;

                if (lines > 0 && lengthMessage % boardMessage > 0)
                    lines++;

                globalLine -= lines;
                int localLine = globalLine;

                if (globalLine <= Console.WindowHeight - Console.WindowHeight / 3 - 3)
                    break;

                Console.SetCursorPosition(position, globalLine);
                for (int j = 0; j < boardMessage; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(position, globalLine);
                int k = 1;
                foreach (var letter in enemy.messageBoard[i - 1])
                {
                    Console.Write(letter);
                    k++;
                    if (k > boardMessage)
                    {
                        Console.SetCursorPosition(position, ++localLine);
                    }
                }

                globalLine--;
            }
        }

        static string HpStaminaText(int countColomns, Enemy enemy, string status)
        {
            string info;
            //string strLocInfo;
            //string strMaxInfo;
            if (status == "HP")
            {
                info = $"{enemy.Hp} / {enemy.MaxHp}";
                //strLocInfo = $"{enemy.Hp}";
                //strMaxInfo = $"{enemy.MaxHp}";
            } else 
            {
                info = $"{enemy.Stamina} / {enemy.MaxStamina}";
                //strLocInfo = $"{enemy.Stamina}";
                //strMaxInfo = $"{enemy.MaxStamina}";
            }

            bool needHpPlus = (enemy.Hp.ToString().Length + 1) % 2 == 0
                && status == "HP";

            bool needStaminaPlus = enemy.Stamina.ToString().Length % 2 == 0 && status != "HP"; 

            bool needPlus = needHpPlus || needStaminaPlus;

            int halfVoidCount = (countColomns / 2 - info.Length / 2);
            string result = "";
            for (int i = 0; i < halfVoidCount + (needPlus ? 1 : 0); i++)
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

        private void DelLastSymb()
        {
            Console.CursorLeft -= 1;
            Console.Write(" ");
        }

    }
}
