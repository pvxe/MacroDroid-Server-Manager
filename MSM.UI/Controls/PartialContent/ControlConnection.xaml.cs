using MSM.UI.ViewModels.PartialContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSM.UI.Controls.PartialContent
{
    /// <summary>
    /// Lógica de interacción para ControlConnection.xaml
    /// </summary>
    public partial class ControlConnection : UserControl
    {
        public ControlConnection()
        {
            InitializeComponent();
            this.Name = "ControlConnection";
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ControlConnectionViewModel vm = (ControlConnectionViewModel)DataContext;
            if (!vm.bw.CancellationPending)
            {
                vm.bw.CancelAsync();
            }           
        }
    }
}
