using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Obez : IHastalik
    {
        public returnValue HastalikAta(Hasta hasta)
        {
            return this.ObezHastaligiAta(hasta);
        }
        private returnValue ObezHastaligiAta(Hasta hasta)
        {
            returnValue temp= hasta.HastalikAta(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Obezite Hastalığı";
        }
    }
}
