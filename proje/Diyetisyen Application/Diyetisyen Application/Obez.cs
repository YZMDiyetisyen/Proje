using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Obez : IHastalik
    {
        public bool HastalikAta(Hasta hasta)
        {
            return this.ObezHastaligiAta(hasta);
        }
        private bool ObezHastaligiAta(Hasta hasta)
        {
            hasta.HastalikAta(this);
            return true;
        }
        public string Bilgi()
        {
            return "Obezite Hastalığı";
        }
    }
}
