using MSM.DAL;
using MSM.Model.Keyboard;
using MSM.Model.Macro;
using MSM.UI.Practices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MSM.UI.ViewModels
{
    // TODO: Falta añadir canExecute según isChecked de toggle button en vista
    public class EditMacroWindowViewModel : ViewModelBase
    {
        #region Properties

        private KeyboardMacro _KbMacro;
        public KeyboardMacro KbMacro
        {
            get
            {
                return _KbMacro;
            }
            private set
            {
                _KbMacro = value;
                NotifyPropertyChanged("KbMacro");
            }
        }

        private bool _IsRecordingSwitchEnabled;
        public bool IsRecordingSwitchEnabled
        {
            get { return _IsRecordingSwitchEnabled; }
            set
            {
                _IsRecordingSwitchEnabled = value;
                NotifyPropertyChanged("IsEditSwitchEnabled");
            }
        }

        private string _DisplayedMacroId;
        public string DisplayedMacroId
        {
            get { return _DisplayedMacroId; }
            set { _DisplayedMacroId = value; }
        }

        private int _SelectedKeystrokeIndex;
        public int SelectedKeystrokeIndex
        {
            get { return _SelectedKeystrokeIndex; }
            set
            {
                _SelectedKeystrokeIndex = value;
                NotifyPropertyChanged("SelectedKeystrokeIndex");
            }
        }


        // Command Properties

        private ObjectParameterRelayCommand _AddKeystrokeUpCommand;
        public ObjectParameterRelayCommand AddKeystrokeUpCommand
        {
            get
            {
                return _AddKeystrokeUpCommand;
            }
        }

        private ObjectParameterRelayCommand _AddKeystrokeDownCommand;
        public ObjectParameterRelayCommand AddKeystrokeDownCommand
        {
            get { return _AddKeystrokeDownCommand; }
        }

        private RelayCommand _OkCommand;
        public RelayCommand OkCommand
        {
            get
            {
                return _OkCommand;
            }
        }

        private RelayCommand _DeleteSelectedKeystrokeCommand;
        public RelayCommand DeleteSelectedKeystrokeCommand
        {
            get
            {
                return _DeleteSelectedKeystrokeCommand;
            }
        }

        #endregion

        #region Commands Implementation

        /// <summary>
        /// 
        /// </summary>
        /// <pre></pre>
        /// <param name="key">Key from KeyEventArgs, this arg is taken from code behind</param>
        private void AddKeystrokeUpCommand_Executed(object key)
        {
            if (key != null)
            {
                _KbMacro.AddKeystrokeUp((Key)key);
            }
            else
            {
                throw new NullReferenceException("Key");
            }
        }
        private bool AddKeystrokeUpCommand_CanExecute()
        {
            return IsRecordingSwitchEnabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Key from KeyEventArgs, this arg is taken from code behind</param>
        private void AddKeystrokeDownCommand_Executed(object key)
        {
            if (key != null)
            {
                _KbMacro.AddKeystrokeDown((Key)key);
            }
            else
            {
                throw new NullReferenceException("Key");
            }
        }
        private bool AddKeystrokeDownCommand_CanExecute()
        {
            return IsRecordingSwitchEnabled;
        }

        /// <summary>
        /// Sobrescribe el archivo config.json guardando
        /// los cambios que se hayan dado en la macro abierta.
        /// </summary>
        private void OkCommand_Executed()
        {
            ConfigurationManager configManager = new ConfigurationManager();
            configManager.SaveKeyboardMacroToConfig(_DisplayedMacroId, _KbMacro);
        }

        /// <summary>
        /// Invocado cada vez que se pulsa Supr debido al <see cref="KeyBinding"/>
        /// en la vista, por tanto controla tanto si es una pulsación para borrar
        /// un elemento de la lista o para grabar la pulsación en la lista.
        /// </summary>
        private void DeleteSelectedKeystrokeCommand_Executed()
        {
            // Condición para borrar el elemento seleccionado.
            if (!IsRecordingSwitchEnabled && _SelectedKeystrokeIndex >= 0)
            {
                _KbMacro.Keystrokes.RemoveAt(_SelectedKeystrokeIndex);
                _SelectedKeystrokeIndex = _KbMacro.Keystrokes.Count - 1;
            }
        }

        #endregion

        public EditMacroWindowViewModel(string displayedMacroId)
        {
            _IsRecordingSwitchEnabled = false;

            _AddKeystrokeUpCommand = new ObjectParameterRelayCommand(AddKeystrokeUpCommand_Executed, AddKeystrokeUpCommand_CanExecute);
            _AddKeystrokeDownCommand = new ObjectParameterRelayCommand(AddKeystrokeDownCommand_Executed, AddKeystrokeDownCommand_CanExecute);
            _OkCommand = new RelayCommand(OkCommand_Executed);
            _DeleteSelectedKeystrokeCommand = new RelayCommand(DeleteSelectedKeystrokeCommand_Executed);

            _KbMacro = new ConfigurationManager().GetKeyboardMacroById(displayedMacroId);
            _SelectedKeystrokeIndex = -1;
            DisplayedMacroId = displayedMacroId;
        }
    }
}
