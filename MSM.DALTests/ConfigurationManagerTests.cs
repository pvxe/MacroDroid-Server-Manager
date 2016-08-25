using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSM.DAL;
using MSM.Model.Macro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.DAL.Tests
{
    [TestClass()]
    public class ConfigurationManagerTests
    {
        
        public void ConfigurationManagerTest()
        {
            // Test method yet not determined            
        }

        /// <summary>
        /// Prueba a obtener un objeto KeyboardMacro del
        /// archivo de configuración cuando éste es por defecto
        /// (macros vacías sin modificaciones)
        /// </summary>
        [TestMethod()]
        public void GetKeyboardMacroByIdTest()
        {
            
            ConfigurationManager configManager = new ConfigurationManager();
            File.Delete(configManager.Path); // Borrar el config para generar uno por defecto de nuevo
            configManager = new ConfigurationManager(); // Vuelta a llamar al ctor para recrear el archivo

            // Comprobar que el archivo existe
            Assert.IsTrue(File.Exists(configManager.Path));

            KeyboardMacro kbMacroM0 = configManager.GetKeyboardMacroById("M0");

            // Aserciones
            Assert.IsNotNull(kbMacroM0, "No hemos obtenido un objeto keyboardMacro");
            Assert.IsTrue(kbMacroM0.Keystrokes.Count.Equals(0));
        }
    }
}