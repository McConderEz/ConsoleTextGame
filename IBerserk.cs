using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    
    public interface IBerserk:ILevel
    {
        
        void Rage();//Активный навык
        void HitsSeries(Hero unit);//Пассивный навык
        void Intimidation(Hero unit);//Пассивный навык
    }
}
