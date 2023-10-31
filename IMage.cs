using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public interface IMage:ILevel
    {
        void Requiem(Hero unit);
        void HeavensPunish(Hero unit);
        void GodChains(Hero unit,int skill);
    }
}
