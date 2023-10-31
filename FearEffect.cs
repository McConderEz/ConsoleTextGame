using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class FearEffect : BaseEffect
    {
        public FearEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }

        public void Fear(Hero unit)
        {
            if (this.Duration == 3)
            {
                unit.PhysDamage -= EffectStrength;
                unit.PhysResistance -= EffectStrength;
            }
            this.Duration -= 1;
            if(this.Duration == 0)
            {
                Duration = 5;
                unit.PhysDamage += EffectStrength;
                unit.PhysResistance += EffectStrength;
                unit.UnitEventHandler -= Fear;
                foreach (var temp in unit.effectsOnUnit)
                {
                    //FearEffect fearEffect = (FearEffect)temp;
                    if (temp.Name == "Устрашение")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }

        }

        public void ApplyFearOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Fear;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект устрашения!", Console.ForegroundColor = ConsoleColor.DarkBlue);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
