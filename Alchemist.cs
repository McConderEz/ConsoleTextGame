using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class Alchemist: Hero, IAlchemist
    {
        public bool manaLocker = false;

        public Alchemist(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1, string className = "Алхимик") : base(strength, agility, durability, intelligence, className)
        {
            //UnitEventHandler += LevelUp;
        }

        public override string GetState
        {
            get => $"LvL: {Level}\nExp: {Exp}\nHP: {Hp}\nPhysRes: {PhysResistance}\nMagicRes: {MagicResistance}\n" +
                $"PhysDamage: {PhysDamage}\nMagicDamage: {MagicDamage}\nAttackSpeed: {AttackSpeed}\nAttackRange: {AttackRange}" +
                $"\nMoveSpeed: {MoveSpeed}\nCritChance: {CritChance}\nHero: {ClassName}";
        }

        public void DragonElement(Hero unit)
        {
            if (Mana >= 30)
            {
                manaLocker = false;
                Mana -= 30;
                var burning = new BurningEffect("Горение", 5 + (int)(0.3 * MagicDamage), 3);               
                Console.WriteLine("[Алхимик] Активирован навык 'Элемент дракона' ", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                burning.ApplyBurningOnTarget(unit);
            }
            else
            {
                Console.WriteLine("[Алхимик]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
            }
        }

        public void LevelUp(Hero unit)
        {
            throw new NotImplementedException();
        }

        public void LizardElement(Hero unit)
        {
            if (Mana >= 50)
            {
                manaLocker = false;
                Mana -= 50;
                var regen = new Regeneration("Регенерация", 2 + (int)(0.3 * MagicDamage), 3);
                Console.WriteLine("[Алхимик] Активирован навык 'Элемент ящерицы' ", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                regen.ApplyRegenerationOnTarget(this);
            }
            else
            {
                Console.WriteLine("[Алхимик]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        public void SnakeElement(Hero unit)
        {
            if (Mana >= 30)
            {
                manaLocker = false;
                Mana -= 30;
                var poison = new PoisoningEffect("Отравление", 5 + (int)(0.3 * MagicDamage), 3);
                Console.WriteLine("[Алхимик] Активирован навык 'Элемент змеи' ", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                poison.ApplyPoisoningOnTarget(unit);
            }
            else
            {
                Console.WriteLine("[Алхимик]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        public void TurtleElement(Hero unut)
        {
            if (Mana >= 60)
            {
                manaLocker = false;
                Mana -= 60;
                Console.WriteLine("[Алхимик] Активирован навык 'Элемент черепахи' ", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                DefenseEffect def = new DefenseEffect("Защита", 5 + (int)(0.3 * MagicDamage), 5);
                def.ApplyDefenseUpOnTarget(this);
            }
            else
            {
                Console.WriteLine("[Алхимик]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.DarkGreen);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }
    }
}
