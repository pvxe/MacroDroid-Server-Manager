using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSM.DAL;
using MSM.Model.Keyboard;
using MSM.Model.Macro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MSM.Model.Keyboard.Tests
{
    [TestClass()]
    public class KeystrokeTests
    {

        [TestMethod()]
        public void ExecuteKeystrokeTest()
        {
            //List<Keystroke> macro = new List<Keystroke>();
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeDown, Key.H));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeUp, Key.H));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeDown, Key.O));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeUp, Key.O));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeDown, Key.L));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeUp, Key.L));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeDown, Key.A));
            //macro.Add(new Keystroke(KeystrokeType.KeystrokeUp, Key.A));

            ConfigurationManager config = new ConfigurationManager();
            

            KeyboardMacro kbMacro = config.GetKeyboardMacroById("M0");
            Thread.Sleep(5000);

            kbMacro.ExecuteMacroKeystrokes();
            
        }
    }
}