using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class Regeneration : BaseEffect
    {
        public Regeneration(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }

        public void Regenaration(Hero unit)
        {
            Console.WriteLine($"{unit.ClassName} {this.Name} +{this.EffectStrength} Хп {this.Duration} Ход", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.White;
            if(unit.Hp < unit.hpLimit)
                unit.Hp += EffectStrength;
            this.Duration -= 1;
            if (this.Duration == 0)
            {
                Duration = 5;
                unit.UnitEventHandler -= Regenaration;
                foreach (var temp in unit.effectsOnUnit)
                {
                    //Regeneration regenEffect = (Regeneration)temp;
                    if (temp.Name == "Регенерация")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        }

        public void ApplyRegenerationOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Regenaration;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект Регенерации!", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}

