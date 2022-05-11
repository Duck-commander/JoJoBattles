using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoJoBattles
{ 
    internal class BattleMechanic
    {
        public void Battle(Enemy enemy1, Enemy enemy2)
        {
            const int timePause = 1000;

            BattleInterfase battleInterfase = new BattleInterfase();

            battleInterfase.DrawBattleInit(enemy1, enemy2);
            Thread.Sleep(timePause);

            while (true)
            {
                HitEnemy(enemy1, enemy2);
                battleInterfase.DrawBattleUpdate(enemy1, enemy2);
                Thread.Sleep(timePause);
                if (enemy2.Hp == 0)
                    break;

                HitEnemy(enemy2, enemy1);
                battleInterfase.DrawBattleUpdate(enemy1, enemy2);
                Thread.Sleep(timePause);
                if (enemy1.Hp == 0)
                    break;

                enemy1.Stamina += 10;
                enemy2.Stamina += 10;
            }
            Console.Read();
        }

        private void HitEnemy (Enemy enemy1, Enemy enemy2)
        {
            Random random = new Random();

            int maxAbilityCount = -1;
            int countsSelectedAbility = 1;

            foreach (int abilityCount in enemy1.Abilities.Values.Reverse())
            {
                if (abilityCount <= enemy1.Stamina)
                {
                    maxAbilityCount = abilityCount;
                    break;
                }
            }

            float x = 0.75f / (enemy1.MaxHp - 100);
            float randModify = 1.25f + (enemy1.MaxHp - enemy1.Hp) * x;

            int randAbilityCost = random.Next(0, (int)(maxAbilityCount * randModify + 1));

            int selectedAbilityCost = -1;

            foreach (var abilityCount in enemy1.Abilities.Values.Reverse())
            {
                if (abilityCount <= maxAbilityCount && abilityCount <= randAbilityCost)
                {
                    if (selectedAbilityCost == -1)
                    {
                        selectedAbilityCost = abilityCount;
                        continue;
                    }
                    if (abilityCount == selectedAbilityCost)
                    {
                        countsSelectedAbility++;
                        continue;
                    }
                    else
                        break;
                }
            }

            if (countsSelectedAbility > 1)
            {
                countsSelectedAbility = random.Next(1, countsSelectedAbility + 1);
            }

            foreach (var kvp in enemy1.Abilities.Reverse())
            {
                if (kvp.Value == selectedAbilityCost)
                {
                    if (countsSelectedAbility > 1)
                    {
                        countsSelectedAbility--;
                        continue;
                    }
                    kvp.Key(enemy2);
                    enemy1.Stamina -= kvp.Value;
                    break;
                }
            }
        }
    }
}
