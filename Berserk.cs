using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class Berserk:Hero,IBerserk
    {

        public bool manaLocker = false;
        
        public Berserk(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1,string className = "Берсерк") :base(strength , agility ,durability, intelligence, className)
        {
            UnitEventHandler += LevelUp;
        }

        public override string GetState
        {
            get => $"LvL: {Level}\nExp: {Exp}\nHP: {Hp}\nPhysRes: {PhysResistance}\nMagicRes: {MagicResistance}\n" +
                $"PhysDamage: {PhysDamage}\nMagicDamage: {MagicDamage}\nAttackSpeed: {AttackSpeed}\nAttackRange: {AttackRange}" +
                $"\nMoveSpeed: {MoveSpeed}\nCritChance: {CritChance}\nHero: {ClassName}";
        }
       

        
        #region Навыки

        /// <summary>
        /// Навык Серия ударов, накладывает кровотечение с уроном 5 и 5 ходов
        /// Нанесеносит 3 обычных удара в 1 ход
        /// </summary>
        /// <param name="unit"></param>
        public void HitsSeries(Hero unit)
        {
            if (this.Mana >= 80)
            {
                manaLocker = false;
                Mana -= 80;
                Console.WriteLine("[Берсерк]Активирован навык 'Серия ударов'", Console.ForegroundColor = ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.White;
                var bleeding = new BleedingEffect("Кровотечение", 5, 5);
                bleeding.ApplyBleedingOnTarget(unit);

                for (var i = 0; i < 3; i++)
                {
                    ApplyHitOnTarget(unit);
                }
            }
            else
            {
                Console.WriteLine("[Берсерк]Не хватает маны на активацию навыка",Console.ForegroundColor = ConsoleColor.DarkMagenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
            
        }

        public void Intimidation(Hero unit)
        {
            if(Mana >= 40)
            {
                manaLocker = false;
                Mana -= 40;
                var fear = new FearEffect("Устрашение", 4, 3);
                Console.WriteLine("[Берсерк] Активирован навык 'Устрашение' ", Console.ForegroundColor = ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.White;
                fear.ApplyFearOnTarget(unit);
            }
            else
            {
                Console.WriteLine("[Берсерк]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkMagenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        public void LevelUp(Hero unit)
        {
            if(Exp >= RequiredExp)
            {
                Exp -= RequiredExp;
                RequiredExp *= 2;
                Level++;
                NextLevel++;
                PhysDamage += 2;
                PhysResistance += 1;
                Hp += 30;
                AttackSpeed *= 1.07;
                
                Console.WriteLine("Уровень повышен!",Console.ForegroundColor = ConsoleColor.Blue);
                Console.ForegroundColor = ConsoleColor.White;
            }            
        }

        /// <summary>
        /// Навык Ярость накладывает на берсерка эффект регенерации(+3) и усиления(+5) на 5 ходов
        /// </summary>
        public void Rage()
        {
            if (Mana >= 50)
            {
                manaLocker = false;
                Mana -= 50;
                var strengthUp = new StrengthUpEffect("Усиление", 5, 5);
                var regen = new Regeneration("Регенерация", 3, 5);
                Console.WriteLine("[Берсерк] Активирован навык 'Ярость' ", Console.ForegroundColor = ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.White;
                regen.ApplyRegenerationOnTarget(this);
                strengthUp.ApplyStregthUpOnTarget(this);
            }
            else
            {
                Console.WriteLine("[Берсерк]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkMagenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        #endregion
    }
}
