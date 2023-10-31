using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class BleedingEffect : BaseEffect
    {
        public BleedingEffect(string name, int effectStrength,int duration) : base(name, effectStrength,duration)
        {

        }
        /// <summary>
        /// Эффект кровотечения наносит 5 урона за 1 ход
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public void Bleeding(Hero unit)
        {
            Console.WriteLine($"{unit.ClassName} {this.Name} -{this.EffectStrength} Хп {this.Duration} Ход", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.White;
            unit.Hp -= EffectStrength;
            this.Duration -= 1;
            if(this.Duration == 0)
            {
                Duration = 5;
                unit.UnitEventHandler -= Bleeding;
                foreach(var temp in unit.effectsOnUnit)
                {
                    //BleedingEffect bleedingEffect = (BleedingEffect)temp;
                    if(temp.Name == "Кровотечение")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        } 

        public void ApplyBleedingOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Bleeding;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект кровотечения!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
