using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Hasta : User
    {
        private IDiyet Diyet { get; set; }
        public Hasta(string tcNo, string isim, string soyisim) : base(tcNo, isim, soyisim)
        {
        }
        public void DiyetYaz(IDiyet diyet)
        {
            this.Diyet = diyet;
        }
        public string DiyetBilgisi()
        {
            return Diyet.DiyetBilgi();
        }
    }
}
