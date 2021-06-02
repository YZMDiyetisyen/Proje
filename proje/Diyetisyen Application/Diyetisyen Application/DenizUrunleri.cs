using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class DenizUrunleri : IDiyet
    {
        public returnValue DiyetAta(Hasta hastam)
        {
            return this.DenizUrunleriDiyetiOlustur(hastam);
        }
        private returnValue DenizUrunleriDiyetiOlustur(Hasta hastam)
        {
            returnValue temp = hastam.DiyetYaz(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Deniz Ürünleri";
        }
    }
}
