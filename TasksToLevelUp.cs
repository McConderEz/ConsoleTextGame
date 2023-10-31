using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class TasksToLevelUp
    {
        

        public void FightWithGoblins(Hero unit,int amount)
        {
            for(var i = 0;i < amount; i++)
            {
                unit.Hp -= 2;
                Console.WriteLine($"Герой убил гоблина, +10 exp, -2 hp ");
                unit.Exp += 10;
                if(unit.Hp <= 0)
                {
                    Console.WriteLine("Герой погиб");
                    Hero.heroes.Remove(unit);
                    break;
                }
            }
        }

        public void FightWithOrks(Hero unit,int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                unit.Hp -= 15;
                Console.WriteLine($"Герой убил орка, +35 exp, -15 hp ");
                unit.Exp += 35;
                if (unit.Hp <= 0)
                {
                    Console.WriteLine("Герой погиб");
                    Hero.heroes.Remove(unit);
                    break;
                }
            }
        }
    }
}
