using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoJoBattles
{
    internal class Enemy
    {
        /// <summary>
        /// Имя персонажа
        /// </summary>
        public string Name = "Not defined";
        /// <summary>
        /// Описание персонажа
        /// </summary>
        public string Description = "";
        /// <summary>
        /// Коронная фраза персонажа
        /// </summary>
        public string Catchphrase = "";

        public bool IsHaveStand = false;
        public string StandName = "Not defined";
        public bool IsHaveHamon = false;
        
        public int MaxHp = 0;
        private int hp = 0;
        /// <summary>
        /// Очки здоровья персонажа
        /// </summary>
        public int Hp 
        { 
            get { return hp; }
            set 
            { 
                if (value < 0)
                    hp = 0;
                else if (value > MaxHp)
                    hp = MaxHp;
                else hp = value;
            }
        }
        
        public int MaxStamina = 0;
        private int stamina = 0;
        public int Stamina 
        { 
            get { return stamina; }
            set 
            { 
                if (value > MaxStamina)
                    stamina = MaxStamina;
                else stamina = value;
            }
        }

        /// <summary>
        /// Сила персонажа
        /// </summary>
        public int Strength = 0;

        /// <summary>
        /// Список способностей
        /// </summary>
        public Dictionary<Action<Enemy>, int> Abilities = new Dictionary<Action<Enemy>, int>();

        public Enemy()
        {
            Abilities.Add(Hit, 0);
        }

        public void Hit(Enemy enemy)
        {
            enemy.Hp -= this.Strength;
        }
    }
}
