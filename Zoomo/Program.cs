using System;
using System.Threading.Tasks;

namespace Zoomo
{
    class Program
    {
        public static void Main(string[] args)
        {
            var showMenu = true;
            while (showMenu)
            {
                var menu = new Menu.Menu();
                
                showMenu = menu.DisplayAndStartProgram();
            }
            
        }
    }
}