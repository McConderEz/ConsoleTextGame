using CodeBlogHomeWorkInteface2022;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkException2022
{
    public static class Helper
    {
        public static string WhoIsStronger(this Hero character1, Hero character2)
        {
            int count = 0;
            if(character1.PhysDamage > character2.PhysDamage)
            {
                count++;
            }else if(character1.PhysDamage < character2.PhysDamage)
            {
                count--;
            }

            if(character1.CritChance > character2.CritChance)
            {
                count++;
            }
            else if(character1.CritChance < character2.CritChance)
            {
                count--;
            }

            if(count > 0)
            {
                return character1.ClassName;
            }
            else if(count < 0)
            {
                return character2.ClassName;
            }
            else
            {
                return "Равны";
            }


        }

        public static string WhoIsHardier(this Hero character1, Hero character2)
        {
            int count = 0;
            if (character1.Hp > character2.Hp)
            {
                count++;
            }
            else if (character1.Hp < character2.Hp)
            {
                count--;
            }

            if (character1.PhysResistance > character2.PhysResistance)
            {
                count++;
            }
            else if (character1.PhysResistance < character2.PhysResistance)
            {
                count--;
            }

            if (character1.MagicResistance > character2.MagicResistance)
            {
                count++;
            }
            else if (character1.MagicResistance < character2.MagicResistance)
            {
                count--;
            }

            if (count > 0)
            {
                return character1.ClassName;
            }
            else if (count < 0)
            {
                return character2.ClassName;
            }
            else
            {
                return "Равны";
            }
        }

        public static T GenRandomCharacterBuild<T>(this T hero)
            where T : Hero
        {
            Random rnd = new Random();

            int strength = rnd.Next(0, 8);
            int agility = rnd.Next(0,8 - strength);
            int durability = rnd.Next(0,8 - (strength + agility));
            int intelligence = rnd.Next(0, 8 - (strength + agility + durability));
            if (strength + agility + durability + intelligence > 8)
                throw new PointException("Вы превысили количество допустимых очков на распределение");
            hero.PointDistribution(strength, agility, durability, intelligence);
            return hero;
        }



        public static string ConvertToString(this IEnumerable heroes)
        {
            string result = "";
            foreach (var hero in heroes)
            {
                result += hero.ToString() + "\r\n" + new string('-', 20) + "\r\n";
            }

            return result;
        }
    }
}
