using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class YesillikDunyasi : IDiyet
    {
        public bool DiyetAta(Hasta hastam)
        {
            return this.YesillikDunyasiDiyetiOlustur(hastam);
        }
        private bool YesillikDunyasiDiyetiOlustur(Hasta hastam)
        {
            hastam.DiyetYaz(this);
            return true;
        }
        public string Bilgi()
        {
            return "Yeşillik Dünyası";
        }
    }
}
