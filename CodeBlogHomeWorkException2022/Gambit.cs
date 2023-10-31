using CodeBlogHomeWorkInteface2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkException2022
{
    public class Gambit : Hero,IGambit
    {
        public bool manaLocker = false;
        public Gambit(int strength = 1, int agility = 1, int durability = 1, int intelligence = 1, string className = "Гамбит") : base(strength, agility, durability, intelligence, className)
        {
            UnitEventHandler += LevelUp;
        }
        public void LevelUp(Hero unit)//Подогнать под героя
        {
            if (Exp >= RequiredExp)
            {
                Exp -= RequiredExp;
                RequiredExp *= 2;
                Level++;
                NextLevel++;
                PhysDamage += 2;
                PhysResistance += 1;
                Hp += 30;
                AttackSpeed *= 1.07;

                Console.WriteLine("Уровень повышен!", Console.ForegroundColor = ConsoleColor.Blue);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
        public void ActivateCombination()
        {
            Console.WriteLine("\t1)Алмаз");
            Console.WriteLine("\t2)Крест");
            Console.WriteLine("\t3)Пика");
            Console.WriteLine("\t4)Сердце");
            int key = Menu.ReadInteger();
            //switch(key)
        }

        /// <summary>
        /// комбинация из 3х бубн даёт даёт сопротивление к физ. урону
        /// </summary>
        /// <param name="unit"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Diamond(Hero unit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// комбинация из 3х крестов даёт магическое пробивание
        /// </summary>
        /// <param name="unit"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Club(Hero unit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// комбинация из 3х сердец даёт шанс застакать некоторое количество хп от автоатак с опред. шансом на несколько ходов
        /// </summary>
        /// <param name="unit"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Heart(Hero unit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// комбинация из 3х пик даёт магический вампиризм.
        /// </summary>
        /// <param name="unit"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Spade(Hero unit)
        {
            throw new NotImplementedException();
        }

        
        
    }
}
