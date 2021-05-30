using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class DenizUrunleri : IDiyet
    {
        public bool DiyetAta(Hasta hastam)
        {
            return this.DenizUrunleriDiyetiOlustur(hastam);
        }
        private bool DenizUrunleriDiyetiOlustur(Hasta hastam)
        {
            hastam.DiyetYaz(this);
            return true;
        }
        public string DiyetBilgi()
        {
            return "Deniz Ürünleri";
        }
    }
}
