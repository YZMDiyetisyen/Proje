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
        private IHastalik Hastalik { get; set; }
        public Hasta(string tcNo, string isim, string soyisim, string sifre) : base(tcNo, isim, soyisim, sifre)
        {
            Diyet = null;
            Hastalik = null;
        }
        public void DiyetYaz(IDiyet diyet)
        {
            this.Diyet = diyet;
        }
        public void HastalikAta(IHastalik hastalik)
        {
            this.Hastalik = hastalik;
        }
        public string DiyetBilgisi()
        {
            return Diyet.Bilgi();
        }
        public string HastalikBilgisi()
        {
            return Hastalik.Bilgi();
        }
    }
}
