using MSM.UI.Practices;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MSM.UI.Controls.PartialContent;

namespace MSM.UI.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Props

        // User controls

        private UserControl _CurrentContent;

        public UserControl CurrentContent
        {
            get { return _CurrentContent; }
            set
            {
                _CurrentContent = value;
                NotifyPropertyChanged("CurrentContent");
                NotifyPropertyChanged("ControlMacros");
            }
        }

        // Commands

        private RelayCommand _ForegroundConnectionContentCommand;

        public RelayCommand ForegroundConnectionContentCommand
        {
            get { return _ForegroundConnectionContentCommand; }
        }

        private RelayCommand _ForegroundMacrosContentCommand;

        public RelayCommand ForegroundMacrosContentCommand
        {
            get { return _ForegroundMacrosContentCommand; }
        }

        // Transición que será ejecutado al cambiar de Content

        private TransitionType _NextTransition;

        public TransitionType NextTransition
        {
            get
            {
                return _NextTransition;
            }
            set
            {
                _NextTransition = value;
                NotifyPropertyChanged("NextTransition");
            }
        }


        #endregion

        #region Commands Implementation

        // ForegroundConnectionContent

        
        private void ForegroundConnectionContentCommand_Executed()
        {
            NextTransition = TransitionType.LeftReplace;
            CurrentContent = new ControlConnection();
        }

        private bool ForegroundConnectionContentCommand_CanExecute()
        {
            return CurrentContent.Name.Equals("ControlMacros");
        }

        // ForegroundMacrosContent

        private void ForegroundMacrosContentCommand_Executed()
        {
            NextTransition = TransitionType.RightReplace;
            CurrentContent = new ControlMacros();
        }

        private bool ForegroundMacrosContentCommand_CanExecute()
        {
            return CurrentContent.Name.Equals("ControlConnection");
        }

        #endregion

        public MainWindowViewModel()
        {
            _ForegroundConnectionContentCommand = new RelayCommand(ForegroundConnectionContentCommand_Executed, ForegroundConnectionContentCommand_CanExecute);
            _ForegroundMacrosContentCommand = new RelayCommand(ForegroundMacrosContentCommand_Executed, ForegroundMacrosContentCommand_CanExecute);

            _CurrentContent = new ControlMacros();
            //_CurrentContent = new ControlPrueba();
        }
    }
}
