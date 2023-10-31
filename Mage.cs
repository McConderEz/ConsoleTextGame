using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class Mage:Hero,IMage
    {
        public bool manaLocker = false;
        private static  int requiemDuration = 4;
        private static int stunDuration = 1;
        public Mage(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1,string className = "Маг") : base(strength, agility, durability, intelligence,className)
        {
            UnitEventHandler += LevelUp;
        }

        public override string GetState
        {
            get => $"LvL: {Level}\nExp: {Exp}\nHP: {Hp}\nPhysRes: {PhysResistance}\nMagicRes: {MagicResistance}\n" +
                $"PhysDamage: {PhysDamage}\nMagicDamage: {MagicDamage}\nAttackSpeed: {AttackSpeed}\nAttackRange: {AttackRange}" +
                $"\nMoveSpeed: {MoveSpeed}\nCritChance: {CritChance}\nHero: {ClassName}";
        }

        
        
        public void GodChains(Hero unit,int skill)
        {
            if(this.Mana >= 50)
            {
                manaLocker = false;
                this.Mana -= 50;
                if (stunDuration == 0)
                {
                    stunDuration = 1;
                    unit._IsStunned = false;
                }
                else
                {
                    Console.WriteLine("[Маг]Активирован навык 'Цепи Бога'", Console.ForegroundColor = ConsoleColor.DarkYellow);
                    Console.WriteLine("Враг оглушён!(Пропускает ход)");
                    Console.ForegroundColor = ConsoleColor.White;                    
                    unit._IsStunned = true;
                    switch (skill)
                    {
                        case 1:
                            ApplyHitOnTarget(unit);
                            break;
                        case 2:
                            ActivateHevansPunish(unit);
                            break;
                        case 3:
                            ActivateRequiem(unit);
                            break;
                        default:
                            throw new Exception("Ошибка в выборе скилла для комбинации мага");
                    }
                }
            }
            else
            {
                Console.WriteLine("Недостаточно маны!");
                manaLocker = true;
                return;
            }
        }


        
        public void ActivateHevansPunish(Hero unit)
        {
            if(Mana >= 40)
            {
                manaLocker = false;
                Mana -= 40;
                Console.WriteLine("[Маг]Активирован навык 'Карма Небес'", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.ForegroundColor = ConsoleColor.White;
                ApplyHeavensPunishOnTarget(unit);
            }
            else
            {
                Console.WriteLine("Недостаочно маны!");
                manaLocker = true;
                return;
            }
        }

        public void HeavensPunish(Hero unit)
        {
            Console.WriteLine($"1-й удар молнии {CalcMagicDMG(unit, (int)((double)MagicDamage * 0.8))} дмг",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.Hp -= CalcMagicDMG(unit, (int)((double)MagicDamage * 0.8));
            Console.WriteLine($"2-й удар молнии {CalcMagicDMG(unit, (int)((double)MagicDamage * 0.5))} дмг", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.Hp -= CalcMagicDMG(unit, (int)((double)MagicDamage * 0.5));
            Console.WriteLine($"3-й удар молнии {CalcMagicDMG(unit, (int)((double)MagicDamage * 0.3))} дмг", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.Hp -= CalcMagicDMG(unit, (int)((double)MagicDamage * 0.3));
            unit.UnitEventHandler -= HeavensPunish;
        }

        public void ApplyHeavensPunishOnTarget(Hero unit)
        {
            unit.UnitEventHandler += HeavensPunish;
        }

        public override void Hit(Hero unit)
        {
            double damageFactor = 0;
            if (unit.MagicResistance >= 0)
            {
                damageFactor = 100.0 / (100.0 + (double)unit.MagicResistance);
            }
            else
            {
                damageFactor = 2 - (100 / (100 - unit.MagicResistance));
            }

            int totalDamage = (int)(MagicDamage * damageFactor);

            if (Parry(unit) || Dodge(unit))
            {
                unit.UnitEventHandler -= Hit;
                return;
            }
            unit.Hp -= totalDamage;

            Console.WriteLine($"Удар по герою {totalDamage} дмг", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.UnitEventHandler -= Hit;
        }

        public void LevelUp(Hero unit)
        {
            if (Exp >= RequiredExp)
            {
                Exp -= RequiredExp;
                RequiredExp *= 2;
                Level++;
                NextLevel++;
                MagicDamage += 2;
                AttackRange += 10;
                MagicResistance += 1;
                Hp += 15;
                AttackSpeed *= 1.02;
                Console.WriteLine("Уровень повышен!");
            }
        }


        public void ActivateRequiem(Hero unit)
        {
            if(Mana >= 30)
            {
                manaLocker = false;
                Mana -= 30;
                Console.WriteLine("[Маг]Активирован навык 'Реквием'", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.ForegroundColor = ConsoleColor.White;
                ApplyRequiemOnTarget(unit);
            }
            else
            {
                Console.WriteLine("Не хватает маны!");
                manaLocker = true;
                return;
            }
        }

        

        public void Requiem(Hero unit)
        {
            int totalDamage = CalcMagicDMG(unit,2 + (int)((double)MagicDamage * 0.2) + (int)((double)unit.hpLimit * 0.02));
            unit.Hp -= totalDamage; //Наносит 4% урон от текущего здоровья цели
            Console.WriteLine($"Навык Реквием нанёс {totalDamage}дмг",Console.ForegroundColor = ConsoleColor.DarkYellow);
            Console.ForegroundColor = ConsoleColor.White;
            requiemDuration -= 1;
            if(requiemDuration == 0)
            {
                requiemDuration = 4;
                unit.UnitEventHandler -= Requiem;
            }
        }

        public void ApplyRequiemOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Requiem;

        }
    }
}
