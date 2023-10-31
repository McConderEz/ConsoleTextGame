using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class ReducedArmorEffect:BaseEffect
    {
        public ReducedArmorEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }

        public void ReducedArmor(Hero unit)
        {
            if (this.Duration == 2)
            {
                unit.PhysResistance /= 2;
                unit.MagicResistance /= 2;
            }
            this.Duration -= 1;
            if (this.Duration == 0)
            {
                Duration = 2;
                unit.PhysResistance *= 2;
                unit.MagicResistance *= 2;
                unit.UnitEventHandler -= ReducedArmor;
                foreach (var temp in unit.effectsOnUnit)
                {
                    ReducedArmorEffect reducedArmorEffect = (ReducedArmorEffect)temp;
                    if (temp.Name == "Снижение брони")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }

        }

        public void ApplyReducedArmorOnTarget(Hero unit)
        {
            unit.UnitEventHandler += ReducedArmor;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект снижение физ. и маг. брони!", Console.ForegroundColor = ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
