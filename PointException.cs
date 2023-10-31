using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogHomeWorkInteface2022
{
    public class PointException:Exception
    {
        public string Message { get; set; }
        public PointException():base("Сработала ошибка при распределении очков")
        {

        }

        public PointException(string message):base(message)
        {
            Message = message;
        }
    }
}
