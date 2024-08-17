using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T
{
    internal class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello World");
            Game game = new Game(800, 600, "LearnOpenTK");
            game.Run(60.0);
        }
    }
}
