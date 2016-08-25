using MSM.Model.InputSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;

namespace MSM.Model.Keyboard
{
    /// <summary>
    /// Representa un keystroke, tanto down como up.
    /// </summary>
    public class Keystroke : IKeystroke
    {
        public KeystrokeType KeystrokeType { get; set; }
        public Key Key { get; set; }
        //public double Delay { get; set; }

        /// <summary>
        /// Constructor por parámetros, con delay por defecto de 0.5 segundos
        /// </summary>
        /// <param name="keystrokeType"></param>
        /// <param name="key"></param>
        public Keystroke(KeystrokeType keystrokeType, Key key)
        {
            KeystrokeType = keystrokeType;
            Key = key;
            //Delay = 0.5;
        }

        /// <summary>
        /// Invoca el SendInput de SendInputWrapper para que se ejecute
        /// la pulsación correspondiente <see cref="KeystrokeType"/> de la 
        /// tecla correspondiente <see cref="Key"/>
        /// </summary>
        public void ExecuteKeystroke()
        {
            SendInputWrapper sendInput = new SendInputWrapper();
            sendInput.SendInput(this);
        }

    }
}
