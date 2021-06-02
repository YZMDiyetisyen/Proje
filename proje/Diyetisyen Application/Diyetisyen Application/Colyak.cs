using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Colyak : IHastalik
    {
        public returnValue HastalikAta(Hasta hasta)
        {
            return this.ColyakHastaligiAta(hasta);
        }
        private returnValue ColyakHastaligiAta(Hasta hasta)
        {
            returnValue temp = hasta.HastalikAta(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Çölyak Hastalığı";
        }
    }
}
