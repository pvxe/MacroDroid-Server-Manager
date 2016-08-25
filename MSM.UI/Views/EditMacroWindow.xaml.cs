using MahApps.Metro.Controls;
using MSM.UI.ViewModels;
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
using System.Windows.Shapes;

namespace MSM.UI.Views
{
    /// <summary>
    /// Lógica de interacción para EditMacroWindow.xaml
    /// </summary>
    public partial class EditMacroWindow : MetroWindow
    {
        public EditMacroWindow()
        {
            InitializeComponent();
        }

        public EditMacroWindow(object macroId)
        {
            //MessageBox.Show(algo.ToString());

            /*
            La asignación del DataContext se hace a través del constructor para 
            aprovechar la variable que se pasa, que es el identificador la macro.
            */
            DataContext = new EditMacroWindowViewModel(macroId.ToString());
            InitializeComponent();
        }

        /// <summary>
        /// Invocación desde la UI del comando del ViewModel correspondiente a este evento
        /// si la tecla pulsada no es Repeat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMacroWindow_KeyUp(object sender, KeyEventArgs e)
        {
            EditMacroWindowViewModel vm = (EditMacroWindowViewModel)DataContext;

            if (!e.Key.Equals(Key.Delete) && !e.IsRepeat && vm.IsRecordingSwitchEnabled)
            {
                vm.AddKeystrokeUpCommand.Execute(e.Key);
            }
        }

        /// <summary>
        /// Control del evento de pulsación de tecla para el enrutamiento adecuado
        /// de instrucciones al viewmodel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditMacroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            EditMacroWindowViewModel vm = (EditMacroWindowViewModel)DataContext;

            // Si la tecla no es pulsada por repetición y estando activada la
            // escucha de teclas se invoca el comando pertinente, en caso de no
            // cumplirse esta condición comprobamos si se está pulsando Esc con
            // la escucha desactivada para deseleccionar la lista.

            if (!e.IsRepeat && vm.IsRecordingSwitchEnabled)
            {
                vm.AddKeystrokeDownCommand.Execute(e.Key);
            } else if (!vm.IsRecordingSwitchEnabled && e.Key.Equals(Key.Escape)) {
                vm.SelectedKeystrokeIndex = -1;
            }
        }
    }
}
