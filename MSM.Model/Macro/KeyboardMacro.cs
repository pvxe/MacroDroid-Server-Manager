using MSM.Model.Keyboard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MSM.Model.Macro
{
    /// <summary>
    /// TODO: Estudio
    /// </summary>
    public class KeyboardMacro
    {
        private ObservableCollection<Keystroke> _Keystrokes;

        public ObservableCollection<Keystroke> Keystrokes
        {
            get
            {
                return _Keystrokes;
            }
        }

        public KeyboardMacro()
        {
            _Keystrokes = new ObservableCollection<Keystroke>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strokeType">Specify the keystroke type, down or up</param>
        /// <param name="key">Key involved</param>
        public void AddKeystroke(KeystrokeType strokeType, Key key)
        {
            _Keystrokes.Add(new Keystroke(strokeType, key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Key involved</param>
        public void AddKeystrokeDown(Key key)
        {
            _Keystrokes.Add(new Keystroke(KeystrokeType.KeystrokeDown, key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Key involved</param>
        public void AddKeystrokeUp(Key key)
        {
            _Keystrokes.Add(new Keystroke(KeystrokeType.KeystrokeUp, key));
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExecuteMacroKeystrokes()
        {
            foreach (Keystroke keystroke in Keystrokes)
            {
                keystroke.ExecuteKeystroke();
                Thread.Sleep(60);
            }
        }
    }
}
