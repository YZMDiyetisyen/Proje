using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Seker:IHastalik
    {
        public bool HastalikAta(Hasta hasta)
        {
            return this.SekerHastaligiAta(hasta);
        }
        private bool SekerHastaligiAta(Hasta hasta)
        {
            hasta.HastalikAta(this);
            return true;
        }
        public string Bilgi()
        {
            return "Şeker Hastalığı";
        }
    }
}
