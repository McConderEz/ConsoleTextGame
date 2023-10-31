using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class VoidSpirit: Hero,ILevel,IVoidSpirit
    {
        public bool manaLocker = false;
        public VoidSpirit(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1, string className = "Дух Пустоты") : base(strength, agility, durability, intelligence, className)
        {
            UnitEventHandler += LevelUp;           
        }

        public override string GetState
        {
            get => $"LvL: {Level}\nExp: {Exp}\nHP: {Hp}\nPhysRes: {PhysResistance}\nMagicRes: {MagicResistance}\n" +
                $"PhysDamage: {PhysDamage}\nMagicDamage: {MagicDamage}\nAttackSpeed: {AttackSpeed}\nAttackRange: {AttackRange}" +
                $"\nMoveSpeed: {MoveSpeed}\nCritChance: {CritChance}\nHero: {ClassName}";
        }

        public void LevelUp(Hero unit)
        {
            if (Exp >= RequiredExp)
            {
                Exp -= RequiredExp;
                RequiredExp *= 2;
                Level++;
                NextLevel++;
                PhysDamage += 2;
                MagicDamage += 2;
                PhysResistance += 1;
                Hp += 10;
                AttackSpeed *= 1.02;
                Console.WriteLine("Уровень повышен!", Console.ForegroundColor = ConsoleColor.Blue);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void MagicCut(Hero unit)
        {
            int magicCut = 5 + (int)(MagicDamage * 0.4);
            if(unit.MagicResistance >= magicCut)
            {
                unit.MagicResistance -= magicCut;
                MagicResistance += magicCut;
                Console.WriteLine($"У {unit.ClassName} похищено {magicCut} ед. маг. сопротивления", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"У {unit.ClassName} слишком низкий показатель маг. сопротивления!");
            }                
        }

        public override void Hit(Hero unit)
        {
            int totalPhysDMG = CalcPhysicDMG(unit, PhysDamage);
            int totalMagicDMG = (int)(CalcMagicDMG(unit, hpLimit - Hp) * 0.1);
            int totalDamage = totalPhysDMG + totalMagicDMG;
            if (Parry(unit) || Dodge(unit))
            {
                unit.UnitEventHandler -= Hit;
                return;
            }
            unit.Hp -= totalDamage;
            Console.WriteLine($"Удар по {unit.ClassName} {totalPhysDMG} физ. дмг + {totalMagicDMG} маг. дмг", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.UnitEventHandler -= Hit;
        }

        public void SoundOfStorm(Hero unit)
        {            
            unit._IsStunned = true;
            if (hpLimit > Hp)
            {
                Hp += CalcPhysicDMG(unit, PhysDamage);
                Console.WriteLine($"{ClassName}  +{CalcPhysicDMG(unit, PhysDamage)} хп", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                ReducedArmorEffect reducedArmorEffect = new ReducedArmorEffect("Снижение брони", 1, 2);
                reducedArmorEffect.ApplyReducedArmorOnTarget(this);
            }
            
        }

        public void SpiritWorld(Hero unit)
        {
            var spiritWorldFirst = new SpiritWorldEffect("Мир Духов", this.PhysResistance, 3,this.MagicResistance);
            var spiritWorldSecond = new SpiritWorldEffect("Мир Духов", unit.PhysResistance, 3,unit.MagicResistance);
            spiritWorldFirst.ApplySpiritWorldOnTarget(this);
            spiritWorldSecond.ApplySpiritWorldOnTarget(unit);
        }

        public void ActivateMagicCut(Hero unit)
        {
            if(Mana >= 60)
            {
                manaLocker = false;
                Mana -= 60;
                Console.WriteLine("[Дух Пустоты]Активирован навык 'Магический разрез'", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                MagicCut(unit);
            }
            else
            {
                Console.WriteLine("[Дух Пустоты]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        public void ActivateSoundOfStorm(Hero unit)
        {
            if (Mana >= 50)
            {
                manaLocker = false;
                Mana -= 50;
                Console.WriteLine("[Дух Пустоты]Активирован навык 'Звук ветра'", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                SoundOfStorm(unit);
            }
            else
            {
                Console.WriteLine("[Дух Пустоты]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

        public void ActivateSpiritWorld(Hero unit)
        {
            if(Mana >= 75)
            {
                manaLocker = false;
                Mana -= 75;
                Console.WriteLine("[Дух Пустоты]Активирован навык 'Мир Духов'", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                SpiritWorld(unit);
            }
            else
            {
                Console.WriteLine("[Дух Пустоты]Не хватает маны на активацию навыка", Console.ForegroundColor = ConsoleColor.Magenta);
                Console.ForegroundColor = ConsoleColor.White;
                manaLocker = true;
                return;
            }
        }

    }
}
