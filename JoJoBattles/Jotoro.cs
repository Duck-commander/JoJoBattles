using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoJoBattles
{
    internal class Jotoro : Enemy
    {
        public Jotoro()
        {
            Name = "Jotoro";
            NameColor = ConsoleColor.DarkBlue;
            Description = "";
            Catchphrase = "";
            
            IsHaveStand = true;
            StandName = "Star Platinum";

            MaxHp = 1000;
            Hp = MaxHp;
            MaxStamina = 100;
            Stamina = MaxStamina;
            Strength = 100;

            Abilities.Add(OraOra, 20);
        }

        public void OraOra(Enemy enemy)
        {
            enemy.Hp -= this.Strength + 50;
            this.messageBoard.Add("Ora! Ora! Ora! Ora! Ora!");
        }
    }
}
