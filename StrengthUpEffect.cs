using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class StrengthUpEffect : BaseEffect
    {
        public StrengthUpEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }
        public void StrengthUp(Hero unit)
        {            
            if(this.Duration == 5)
                unit.PhysDamage += EffectStrength;
            this.Duration -= 1;
            if (this.Duration == 0)
            {
                unit.PhysDamage -= EffectStrength;
                Duration = 5;
                unit.UnitEventHandler -= StrengthUp;
                foreach (var temp in unit.effectsOnUnit)
                {
                    StrengthUpEffect strengthUpEffect = (StrengthUpEffect)temp;
                    if (strengthUpEffect.Name == "Усиление")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        }

        public void ApplyStregthUpOnTarget(Hero unit)
        {
            unit.UnitEventHandler += StrengthUp;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект усиление физ. силы!", Console.ForegroundColor = ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
