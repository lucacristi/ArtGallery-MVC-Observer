using ArtGallery.Controller;
using ArtGallery.Model;
using ArtGallery.Model.Persistenta;
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

            //model
            ModelArtGallery model = new ModelArtGallery();
            //view
            VWelcome vWelcome = new VWelcome(model);
            //controller
            CWelcome cWelcome = vWelcome.GetCWelcome();
            //pass the view of the controller
            Application.Run(cWelcome.GetVWelcome());

        }
    }
}
