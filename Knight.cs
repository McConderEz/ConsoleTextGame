using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class Knight:Hero,IKnight
    {
        public bool manaLocker = false;


        public Knight(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1, string className = "Рыцарь") : base(strength, agility, durability, intelligence,className)
        {
            UnitEventHandler += LevelUp;            
        }

        public override string GetState
        {
            get => $"LvL: {Level}\nExp: {Exp}\nHP: {Hp}\nPhysRes: {PhysResistance}\nMagicRes: {MagicResistance}\n" +
                $"PhysDamage: {PhysDamage}\nMagicDamage: {MagicDamage}\nAttackSpeed: {AttackSpeed}\nAttackRange: {AttackRange}" +
                $"\nMoveSpeed: {MoveSpeed}\nCritChance: {CritChance}\nHero: {ClassName}";
        }

        public void BreakingChains()
        {
            if(Mana >= 90)
            {
                manaLocker = false;
                Mana -= 90;
                Console.WriteLine("[Рыцарь]Активирован навык 'Разлом Цепей'", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.WriteLine("С героя сняты все эффекты");
                Console.ForegroundColor = ConsoleColor.White;
                base.BreakingChains();
            }
            else
            {
                Console.WriteLine("Недостаточно манны");
                manaLocker = true;
                return;
            }
        }

        public void DeusVult()
        {
            if(Mana >= 50)
            {
                manaLocker = false;
                Mana -= 50;
                Console.WriteLine("[Рыцарь]Активирован навык 'Deus Vult'", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.ForegroundColor = ConsoleColor.White;
                DefenseEffect def = new DefenseEffect("Защита", 15, 5);
                def.ApplyDefenseUpOnTarget(this);
            }
            else
            {
                Console.WriteLine("Недостаточно маны!");
                manaLocker = true;
                return;
            }
        }

        public void LevelUp(Hero unit)
        {
            if (Exp >= RequiredExp)
            {
                Exp -= RequiredExp;
                RequiredExp *= 2;
                Level++;
                NextLevel++;
                PhysDamage += 1;
                PhysResistance += 3;
                MagicResistance += 1;
                Hp += 40;
                AttackSpeed *= 1.04;
                Console.WriteLine("Уровень повышен!");
            }
        }
    }
}
