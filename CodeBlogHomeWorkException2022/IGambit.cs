using CodeBlogHomeWorkInteface2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkException2022
{
    internal interface IGambit
    {
        public void Diamond(Hero unit);

        public void Club(Hero unit);

        public void Heart(Hero unit);

        public void Spade(Hero unit);
    }
}
