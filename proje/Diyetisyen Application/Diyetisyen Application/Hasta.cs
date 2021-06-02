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
        public returnValue DiyetYaz(IDiyet diyet)
        {
            returnValue temp = new returnValue();
            try
            {
                if (diyet!=null)
                {
                    this.Diyet = diyet;
                    temp.message = "Hasta Diyeti Belirlendi!";
                }
                else
                {
                    temp.state = false;
                    temp.message = "Diyet Bilgisi Geçersiz/Boş!";
                }
            }
            catch (Exception e)
            {
                temp.state = false;
                temp.message = e.Message;
            }
            return temp;
        }
        public returnValue HastalikAta(IHastalik hastalik)
        {
            returnValue temp = new returnValue();
            try
            {
                if (hastalik != null)
                {
                    this.Hastalik = hastalik;
                    temp.message = "Hastalık Bilgisi Belirlendi!";
                }
                else
                {
                    temp.state = false;
                    temp.message = "Hastalık Bilgisi Geçersiz/Boş!";
                }
            }
            catch (Exception e)
            {
                temp.state = false;
                temp.message = e.Message;
            }
            return temp;
        }
        public string DiyetBilgisi()
        {
            return (Diyet!=null? Diyet.Bilgi() : "Diyet Ataması Gerçekleşmedi!");
        }
        public string HastalikBilgisi()
        {
            return (Hastalik != null ? Hastalik.Bilgi() : "Hastalık Bilgisi Bulunamadı, lütfen bilgi girişini sağlayınız!");
        }
    }
}
