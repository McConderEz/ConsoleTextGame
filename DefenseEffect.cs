using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class DefenseEffect : BaseEffect
    {
        public DefenseEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }


        public void DefenseUp(Hero unit)
        {
            if (this.Duration == 5)
                unit.PhysResistance += EffectStrength;
            this.Duration -= 1;
            if (this.Duration == 0)
            {
                unit.PhysResistance -= EffectStrength;
                Duration = 5;
                unit.UnitEventHandler -= DefenseUp;
                foreach (var temp in unit.effectsOnUnit)
                {
                    DefenseEffect def = (DefenseEffect)temp;
                    if (def.Name == "Защита")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        }

        public void ApplyDefenseUpOnTarget(Hero unit)
        {
            unit.UnitEventHandler += DefenseUp;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект усиление защиты!", Console.ForegroundColor = ConsoleColor.DarkGray);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
