using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoJoBattles
{
    internal class Dio : Enemy
    {
        public Dio()
        {
            Name = "Dio";
            NameColor = ConsoleColor.DarkYellow;
            Description = "";
            Catchphrase = "";

            IsHaveStand = true;
            StandName = "The World";

            MaxHp = 1000;
            Hp = MaxHp;
            MaxStamina = 100;
            Stamina = MaxStamina;
            Strength = 100;

            Abilities.Add(MudaMuda, 20);
            Abilities.Add(RoadRoller, 35);
        }

        public void MudaMuda(Enemy enemy)
        {
            enemy.Hp -= this.Strength + 50;
            this.messageBoard.Add("Muda! Muda! Muda! Muda!");
        }

        public void RoadRoller(Enemy enemy)
        {
            Random random = new Random();
            if (random.Next(1, 101) <= 60)
                enemy.Hp -= 350;
            this.messageBoard.Add("Roaaaad Rolleeeeer!");
        }
    }
}
