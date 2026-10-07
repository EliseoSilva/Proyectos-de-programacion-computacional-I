using System;

namespace PrimeraAplicacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
           
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            ApplicationConfiguration.Initialize();
            Application.Run(new frmPrincipal());
        }
    }
}
