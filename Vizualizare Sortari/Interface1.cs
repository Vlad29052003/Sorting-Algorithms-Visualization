using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizualizare_Sortari
{
    internal interface Interface1
    {
        /**
         * Forces the classes that inherit it to implements the nextStep() method.
         * This methos is used in order to make the pause/resume possible.
         **/
        void NextStep();
    }
}