using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    internal interface IAlchemist:ILevel
    {
        public void DragonElement(Hero unit);

        public void SnakeElement(Hero unit);

        public void TurtleElement(Hero unut);

        public void LizardElement(Hero unit);
    }
}
