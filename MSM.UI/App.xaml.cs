using MahApps.Metro.Controls;
using MSM.Socketing;
using MSM.UI.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MSM.UI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Duerme 4 segundos antes de cargar la ventana principal para enseñar durante
        /// este tiempo la imagen de bienvenida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            MainWindow = main;

            Server server = Server.Instance;

            try {
                server.Init();
            } catch (SocketException)
            {
                // Puede recogerse una excepción por cerrarse el servidor antes de que establezca
                // una excepción.
            }
            

            Thread.Sleep(4000);

            main.Show();
        }


    }
}
