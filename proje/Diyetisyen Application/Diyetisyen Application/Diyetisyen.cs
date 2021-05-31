using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Diyetisyen : User
    {
        private List<Hasta> Hastalar { get; set; }
        public Diyetisyen(string tcNo, string isim, string soyisim, string sifre) : base(tcNo, isim, soyisim, sifre)
        {
            Hastalar = new List<Hasta>();
        }
        public returnValue HastaAta(Hasta hastam)
        {
            returnValue temp = new returnValue();
            try
            {
                if (!this.Hastalar.Contains(hastam))
                {
                    this.Hastalar.Add(hastam);
                    temp.message = "Hasta Başarıyla Atandı!";
                }
                else
                {
                    temp.state = false;
                    temp.message = "Hasta Zaten Mevcut!";
                }
            }
            catch (Exception e)
            {
                temp.state = false;
                temp.message = e.Message;
            }
            return temp;
        }
        public Hasta[] HastalarListesi()
        {
            return Hastalar.ToArray();
        }
    }
}
