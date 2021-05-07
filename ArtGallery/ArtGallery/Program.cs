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
            CVizitator cVizitator = new CVizitator();            
            CWelcome cWelcome = new CWelcome();
            Application.Run(cWelcome.GetVWelcome());


            //PersistentaOperaArta persistenta = new PersistentaOperaArta();
            //OperaArta opera = new OperaArta("new OPERA Actualizata", "luca mihai", 123);
            //Tablou tablou = new Tablou("TABLOU", "mihai", 333,"asd","ad");
            //Tablou tablou1 = new Tablou("TABLOU1", "mihai", 333,"asd","ad");
            //Tablou tablou2 = new Tablou("TABLOU2", "mihai", 333,"asd","ad");
            //Tablou tablou3 = new Tablou("TABLOU-creion1", "mihai", 333,"creion","acuarela");
            //Tablou tablou4 = new Tablou("TABLOU-creion2", "mihai", 333,"creion","acuarela");
            //Sculptura sculptura1 = new Sculptura("SCULPTURA marmura1", "mihai", 123, "marmura");
            //Sculptura sculptura2 = new Sculptura("SCULPTURA marmura2", "mihai", 123, "marmura");


            //persistenta.AdaugareOperaArta(sculptura1);
            // persistenta.AdaugareOperaArta(sculptura2);


 
            //foreach(OperaArta op in persistenta.FiltrareOpereTipSculptura("marmura"))
            //{
            //    MessageBox.Show(op.GetTitlu());
            //}
            
        }
    }
}
