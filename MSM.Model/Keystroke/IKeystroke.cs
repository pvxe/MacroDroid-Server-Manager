using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM.Model.Keyboard
{
    public interface IKeystroke
    {
        // No extraigo la propiedad Key porque también existen ModifiedKeystrokes que se componen ModifiersKeys 
        // y Key normales, que se pueden presentar en distinta paridad, que aunque la aplicación no lo implemente
        // si no la extraigo en esta interfaz sigue siendo extensible en un futuro.
        //  1 MKS : 1 K (Ctrl+V), 
        //  n MKS : 1 K (Ctrl+Mayus+V),
        //  n:n


        void ExecuteKeystroke();
    }
}
