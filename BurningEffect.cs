using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal class BurningEffect : BaseEffect
    {
        public BurningEffect(string name, int effectStrength, int duration) : base(name, effectStrength, duration)
        {
        }

        public void Burning(Hero unit)
        {
            if (this.Duration == 3)
                unit.PhysDamage -= unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.8));
            Console.WriteLine($"{unit.ClassName} {this.Name} -{unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.5))} Хп {this.Duration} Ход", Console.ForegroundColor = ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.White;
            unit.Hp -= unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.5));
            this.Duration -= 1;

            if (this.Duration == 0)
            {
                Duration = 3;
                unit.PhysDamage += unit.CalcMagicDMG(unit, (int)((double)EffectStrength * 0.8));
                unit.UnitEventHandler -= Burning;
                foreach (var temp in unit.effectsOnUnit)
                {
                    BurningEffect burningEffect = (BurningEffect)temp;
                    if (burningEffect.Name == "Горение")
                    {
                        unit.effectsOnUnit.Remove(temp);
                        break;
                    }
                }
            }
        }

        public void ApplyBurningOnTarget(Hero unit)
        {
            unit.UnitEventHandler += Burning;
            unit.effectsOnUnit.Add(this);
            Console.WriteLine($"На {unit.ClassName} наложен эффект Горения!", Console.ForegroundColor = ConsoleColor.DarkGreen);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
