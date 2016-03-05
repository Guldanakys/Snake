using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool.Models
{
    [Serializable]
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
        }
    }
}
