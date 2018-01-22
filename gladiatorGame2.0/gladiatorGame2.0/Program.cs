using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiatorGame2._0
{
    class Program
    {
        // Create instances of classes - to assign variables in different scopes
        static void Main(string[] args)
        {
            Console.WindowWidth = 155;
            Menu menu = new Menu();
            Game game = new Game();

            menu.Greet();
            menu.NameChar();
            menu.ChooseChar();
            game.Combat();
        }

    }
}
