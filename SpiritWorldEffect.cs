using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class SpiritWorldEffect : BaseEffect
    {
        int effectStrengthMagic;
        
        public SpiritWorldEffect(string name, int effectStrengthPhys, int duration,int effectStrengthMagic) : base(name, effectStrengthPhys, duration)
        {
            this.effectStrengthMagic = effectStrengthMagic;
        }

        public void SpiritWorld(Hero unit)
        {
            
            if (this.Duration == 3)
            {                
                unit.PhysResistance -= EffectStrength;
                unit.MagicResistance -= effectStrengthMagic;
            }
            this.Duration -= 1;
            if (this.Duration == 0)
            {
                Duration = 3;
                unit.PhysResistance += EffectStrength;
                unit.MagicResistance += effectStrengthMagic;
                unit.UnitEventHandler -= SpiritWorld;
                foreach (var temp in unit.effectsOnUnit)
                {
                    SpiritWorldEffect spiritWorldEffect = (SpiritWorldEffect)temp;
                    if (temp.Name == "Мир Духов")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }

        }

        public void ApplySpiritWorldOnTarget(Hero unit)
        {
            unit.UnitEventHandler += SpiritWorld;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"{unit.ClassName} в мире духов (отсутствие физ. и маг. брони!)", Console.ForegroundColor = ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
