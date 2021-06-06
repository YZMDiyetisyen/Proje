using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class GlutenFree : IDiyet
    {
        public bool DiyetAta(Hasta hastam)
        {
            return this.GlutenFreeDiyetiOlustur(hastam);
        }
        private bool GlutenFreeDiyetiOlustur(Hasta hastam)
        {
            hastam.DiyetYaz(this);
            return true;
        }
        public string Bilgi()
        {
            return "Gluten Free";
        }
    }
}
