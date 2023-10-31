using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public abstract class BaseEffect
    {
        public static List<BaseEffect> effects = new List<BaseEffect>();
        private string name;
        private int effectStrength = 1;
        private int duration = 1;
        public string Name
        {
            get => name;
            init
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException("Эффекту не присвоено название");
                }
            }
        }
        public int EffectStrength
        {
            get => effectStrength;
            set
            {
                if (value >= 1 && value <= 100)
                {
                    effectStrength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение задано вне допустим границ");
                }
            }

        }
        public int Duration
        {
            get => duration;
            set
            {
                if(value >= 0 && value <= 10)
                {
                    duration = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение находится вне допустимых границ");
                }
            }
        }

        public BaseEffect(string name,int effectStrength,int duration)
        {
            Name = name;
            EffectStrength = effectStrength;
            Duration = duration;
            effects.Add(this);
        }

        public override string ToString()
        {
            return $"{Name} {EffectStrength} дмг {Duration} ходов";
        }
    }
}
