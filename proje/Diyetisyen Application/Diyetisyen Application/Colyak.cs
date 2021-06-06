using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Colyak : IHastalik
    {
        public bool HastalikAta(Hasta hasta)
        {
            return this.ColyakHastaligiAta(hasta);
        }
        private bool ColyakHastaligiAta(Hasta hasta)
        {
            hasta.HastalikAta(this);
            return true;
        }
        public string Bilgi()
        {
            return "Çölyak Hastalığı";
        }
    }
}
