using MahApps.Metro.Controls;
using MSM.Socketing;
using System.Windows;

namespace MSM.UI.Views
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closed(object sender, System.EventArgs e)
        {
            Server.Instance.Close();
            Application.Current.Shutdown();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    cc.Content = new FormularioDireccion();
        //}
    }
}
