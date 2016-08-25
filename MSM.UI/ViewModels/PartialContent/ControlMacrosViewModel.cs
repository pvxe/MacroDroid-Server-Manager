using MSM.UI.Practices;
using MSM.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.UI.ViewModels.PartialContent
{
    public class ControlMacrosViewModel : ViewModelBase
    {
        #region Commands

        private ObjectParameterRelayCommand _EditMacroCommand;

        public ObjectParameterRelayCommand EditMacroCommand
        {
            get { return _EditMacroCommand; }
        }

        #endregion

        #region Commands Implementation

        private void EditMacroCommandExecuted(object macroParameter)
        {
            EditMacroWindow editWindow = new EditMacroWindow(macroParameter);
            editWindow.ShowDialog();
        }

        #endregion

        public ControlMacrosViewModel()
        {
            _EditMacroCommand = new ObjectParameterRelayCommand(EditMacroCommandExecuted);
        }
    }
}
