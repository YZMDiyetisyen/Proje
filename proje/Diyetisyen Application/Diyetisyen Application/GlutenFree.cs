using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class GlutenFree : IDiyet
    {
        public returnValue DiyetAta(Hasta hastam)
        {
            return this.GlutenFreeDiyetiOlustur(hastam);
        }
        private returnValue GlutenFreeDiyetiOlustur(Hasta hastam)
        {
            returnValue temp = hastam.DiyetYaz(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Gluten Free";
        }
    }
}
