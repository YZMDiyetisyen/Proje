using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class YesillikDunyasi : IDiyet
    {
        public returnValue DiyetAta(Hasta hastam)
        {
            return this.YesillikDunyasiDiyetiOlustur(hastam);
        }
        private returnValue YesillikDunyasiDiyetiOlustur(Hasta hastam)
        {
            returnValue temp = hastam.DiyetYaz(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Yeşillik Dünyası";
        }
    }
}
