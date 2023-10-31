using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public interface ILevel
    {
        void LevelUp(Hero unit);
        string GetState { get; }
    }
}
