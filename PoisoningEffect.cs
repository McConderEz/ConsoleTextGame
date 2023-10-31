using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class PoisoningEffect : BaseEffect 
    {
        public PoisoningEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }
        
        public void Poisoning(Hero unit)
        {
            
            unit.Hp -= unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.8));
            Console.WriteLine($"{unit.ClassName} {this.Name} -{unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.8))} Хп {this.Duration} Ход", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.White;
            this.Duration -= 1;

            if (this.Duration == 0)
            {                
                Duration = 3;
                unit.UnitEventHandler -= Poisoning;
                foreach (var temp in unit.effectsOnUnit)
                {
                    PoisoningEffect poisoningEffect = (PoisoningEffect)temp;
                    if (poisoningEffect.Name == "Отравление")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        }

        public void ApplyPoisoningOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Poisoning;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект отравления!", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
