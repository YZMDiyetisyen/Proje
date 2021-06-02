using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Akdeniz: IDiyet
    {
        public returnValue DiyetAta(Hasta hastam)
        {
            return this.AkdenizDiyetiOlustur(hastam);
        }
        private returnValue AkdenizDiyetiOlustur(Hasta hastam)
        {
            returnValue temp= hastam.DiyetYaz(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Akdeniz";
        }
    }
}
