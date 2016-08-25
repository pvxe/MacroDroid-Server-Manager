using MSM.Model.Macro;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace MSM.DAL
{
    /// <summary>
    /// Clase encargada de leer y sobrescribir el archivo de configuracion config.json
    /// </summary>
    public class ConfigurationManager
    {
        #region Properties

        /// <summary>
        /// Propiedad de solo lectura que devuelve la ruta 
        /// del archivo de configuración.
        /// </summary>
        public string Path
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\config.json";
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de ConfigurationManager comprueba
        /// la existencia de un fichero de configuración y
        /// en caso de no existir crea uno por defecto en la
        /// ruta predeterminada.
        /// </summary>
        public ConfigurationManager()
        {
            if (!ExistsConfigFile())
            {
                CreateDefaultConfigFile();
            }
        }

        #endregion

        // PUBLIC METHODS REGION

        #region Public Methods

        public KeyboardMacro GetKeyboardMacroById(string id)
        {
            JObject keyboardMacroJSON = GetJObjectMacroFromConfig(id);
            return keyboardMacroJSON.ToObject<KeyboardMacro>();
        }

        /// <summary>
        /// Sobrecribe el archivo de configuración modificando
        /// el keyboardmacro identificado por parametro por el nuevo.
        /// </summary>
        /// <param name="macroId"></param>
        /// <param name="newKeyboardMacro"></param>
        public void SaveKeyboardMacroToConfig(string macroId, KeyboardMacro newKeyboardMacro)
        {
            JObject configJsonObjectWithChanges = GetJObjectConfig();
            configJsonObjectWithChanges[macroId] = JObject.FromObject(newKeyboardMacro);

            File.WriteAllText(Path, configJsonObjectWithChanges.ToString());
        }

        #endregion

        // PRIVATE METHODS REGION

        #region Private Methods

        // IO

        /// <summary>
        /// Comprueba si existe un fichero de configuración
        /// </summary>
        /// <returns>True si existe, false en caso contrario</returns>
        private bool ExistsConfigFile()
        {
            return File.Exists(Path);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateDefaultConfigFile()
        {
            // Por seguridad, aunque tengo la precondición de que esto se llama cuando no existe archivo de config
            if (!ExistsConfigFile())
            {
                JObject defaultConfigJSON = JObject.Parse(
                    "{" 
                    + "\"M0\": {\"Keystrokes\": []}," 
                    + "\"M1\": {\"Keystrokes\": []},"
                    + "\"M2\": {\"Keystrokes\": []},"
                    + "\"M3\": {\"Keystrokes\": []},"
                    + "\"M4\": {\"Keystrokes\": []},"
                    + "\"M5\": {\"Keystrokes\": []},"
                    + "}"
                    );



                File.WriteAllText(Path, defaultConfigJSON.ToString());
            }
    }

    /// <summary>
    /// Lee todo el fichero config.json y devuelve
    /// la cadena de texto resultante.
    /// </summary>
    /// <returns>La cadena leída</returns>
    private string ReadAllTextConfig()
    {
        return File.ReadAllText(Path);
    }

    // JSON

    /// <summary>
    /// Serializa la cadena de caracteres de 
    /// config.json a <see cref="JObject"/> 
    /// </summary>
    /// <returns>Resultado del parseo a JObject</returns>
    private JObject GetJObjectConfig()
    {
        return JObject.Parse(ReadAllTextConfig());
    }

    /// <summary>
    /// Obtiene el <see cref="JObject"/> correspondiente
    /// al key proporcionado(m0-m5)
    /// </summary>
    /// <param name="macroId"></param>
    /// <returns>El JObject correspondiente a la macro con esa id</returns>
    private JObject GetJObjectMacroFromConfig(string macroId)
    {
            JObject result;
            //TODO: Sacar el checkeo a un método a parte, quizás.
            bool validStartLetter = macroId.StartsWith("M");

            int macroIdParsed = int.Parse(macroId.Substring(1));
            bool validMacroId = macroIdParsed >= 0 && macroIdParsed < 6;

            if (validStartLetter && validMacroId)
            {
                result = GetJObjectConfig()[macroId] as JObject;
            } else
            {
                throw new ArgumentException("macroId arg not valid format");
            }

            return result;
    }

    #endregion
}
}
