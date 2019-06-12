using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaehlerauswertung_Konfiguration
{
    class serielleParameter
    {
        public void gesendeteStrings (string serielleParameterString)
        {
            string[] serielleParameterArray = serielleParameterString.Split('$');
        }
    }
}
