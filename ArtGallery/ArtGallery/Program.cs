using ArtGallery.Controller;
using ArtGallery.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGallery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //CVizitator cVizitator = new CVizitator();
            //Application.Run(cVizitator.GetVWelcome());
            CWelcome cWelcome = new CWelcome();

            Application.Run(cWelcome.GetVWelcome());

        }
    }
}
