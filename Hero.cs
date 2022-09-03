using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public abstract class Hero//TODO:Добавить героя с гибридным уроном
    {
        public string ClassName { get; init; }
        public delegate void UnitStateChanger(Hero unit);
        public event UnitStateChanger UnitEventHandler;
        public static List<Hero> heroes = new List<Hero>();
        public List<BaseEffect> effectsOnUnit = new List<BaseEffect>();

        private int hp;
        public readonly int hpLimit;
        private int physResistance;
        private int magicResistance;
        private int physDamage;
        private int magicDamage;
        private int critChance;
        private int moveSpeed;
        private int attackRange;
        private int mana;//TODO:Добавить регенерацию маны
        private double attackSpeed;
        protected int Level;
        protected int NextLevel;
        public int Exp;//TODO:Потом сделать защищённым
        protected int RequiredExp;
        protected bool IsStunned = false;
        //TODO:Добавить характеристику шанса уклонения и парирования

        private int strength = 1;
        private int agility = 1;
        private int durability = 1;
        private int intelligence = 1;
        //TODO:Добавить аспект удачи
        

        public void PointDistribution(int strength = 1, int agility = 1,int durability = 1,int intelligence = 1)//TODO:Сделать защищённым
        {          
            if(strength > 1)
            {
                physDamage += 2 * strength;
            }

            if(agility > 1)
            {
                moveSpeed += 5 * agility;
                AttackSpeed += 0.05 * agility;
            }

            if(durability > 1)
            {
                hp += 20 * durability;
                physResistance += 2 * durability;
                magicResistance += 3 * durability;
            }

            if(intelligence > 1)
            {
                magicDamage += 2 * intelligence;
                attackRange += 10 * intelligence;
                mana += 20 * intelligence;
            }
        }

        public bool _IsStunned
        {
            get => IsStunned;
            set => IsStunned = value;
        }
        public int Hp
        {
            get => hp;
            set
            {
                if(value > 0)
                {
                    hp = value;
                }
                else
                {
                    hp = 0;
                    Console.WriteLine("Герой убит!",Console.ForegroundColor = ConsoleColor.Magenta);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public int PhysResistance
        {
            get => physResistance;
            set
            {
                if (value > 0)
                {
                    physResistance = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public int MagicResistance
        {
            get => magicResistance;
            set
            {
                if (value > 0)
                {
                    magicResistance = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public int PhysDamage
        {
            get => physDamage;
            set
            {
                if (value > 0)
                {
                    physDamage = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public int MagicDamage
        {
            get => magicDamage;
            set
            {
                if (value >= 0)
                {
                    magicDamage = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public int CritChance
        {
            get => critChance;
            set
            {
                if(value >= 0 && value <= 100)
                {
                    critChance = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод!");
                }
            }
        }
        public int MoveSpeed
        {
            get => moveSpeed;
            set
            {
                if(value >= 100 && value <= 1000)
                {
                    moveSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public int AttackRange
        {
            get => attackRange;
            set
            {
                if(value >= 100 && value <= 1000)
                {
                    attackRange = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }
        public double AttackSpeed
        {
            get => attackSpeed;
            set
            {
                if(value > 0.4 && value < 20.0)
                {
                    attackSpeed = value;
                }
                else
                {
                    throw new ArgumentException("Неверный ввод");
                }
            }
        }

        protected void BreakingChains()
        {
            UnitEventHandler = null;
            if(effectsOnUnit.Count() >= 1)
                effectsOnUnit.RemoveRange(0, effectsOnUnit.Count() - 1);
        }

        public int Mana
        {
            get => mana;
            set
            {
                if(value >= 0 && value <= 1000)
                {
                    mana = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение вне допустимых границ");
                }
            }
        }

        public Hero(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1,string className = "Герой")
        {
            Hp = 50;
            PhysResistance = 3;
            MagicDamage = 0;
            MagicResistance = 1;
            PhysDamage = 5;
            CritChance = 0;
            MoveSpeed = 100;
            AttackRange = 100;
            AttackSpeed = 0.5;
            Level = 1;
            NextLevel = Level + 1;
            RequiredExp = 100;
            Mana = 150;
            hpLimit = hp;
            ClassName = className;
        }

        public virtual int CalcMagicDMG(Hero unit, int MagicDamage)
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
            return totalDamage;
        }

        public virtual int CalcPhysicDMG(Hero unit,int PhysDamage)
        {
            double damageFactor = 0;
            if (unit.physResistance >= 0)
            {
                damageFactor = 100.0 / (100.0 + (double)unit.PhysResistance);
            }
            else
            {
                damageFactor = 2 - (100 / (100 - unit.PhysResistance));
            }

            int totalDamage = (int)(CritHit() * damageFactor);
            return totalDamage;
        }

        //TODO: упростить всё в один метод(Калькуляция урона и удар)

        public virtual void Hit(Hero unit)
        {
            double damageFactor = 0;
            if (unit.physResistance >= 0)
            {
                damageFactor = 100.0 / (100.0 + (double)unit.PhysResistance);
            }
            else
            {
                damageFactor = 2 - (100 / (100 - unit.PhysResistance));
            }

            int totalDamage = (int)(CritHit() * damageFactor);
            unit.Hp -= totalDamage;
            
            Console.WriteLine($"Удар по герою {totalDamage} дмг",Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            unit.UnitEventHandler -= Hit;
        }


        public virtual int CritHit()
        {
            if(CritChance == 0)
            {
                return PhysDamage;
            }
            else
            {
                Random random = new Random();
                if(random.Next(1,100) <= CritChance)
                {
                    return PhysDamage * 2;
                }
                else
                {
                    return PhysDamage;
                }
            }
        }
        
        
        public virtual void ApplyHitOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Hit;            
        }

        public void CheckEffectsOnUnit()
        {
            if(effectsOnUnit.Count == 0)
            {
                Console.WriteLine("На героя не наложено эффектов");
                return;
            }

            foreach(var temp in effectsOnUnit)
            {
                Console.WriteLine(temp.ToString());
            }
        }

        public void EndOfMove()
        {
            UnitEventHandler?.Invoke(this);                       
        }
    }
}
