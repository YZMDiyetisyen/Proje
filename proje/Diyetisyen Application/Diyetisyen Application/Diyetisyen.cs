using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class Diyetisyen : User
    {
        private List<Hasta> Hastalar { get; set; }
        public Diyetisyen(string tcNo, string isim, string soyisim) : base(tcNo, isim, soyisim)
        {
            Hastalar = new List<Hasta>();
        }
        public void HastaAta(Hasta hastam)
        {
            this.Hastalar.Add(hastam);
        }
    }
}
