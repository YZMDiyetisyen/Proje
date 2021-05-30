using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class User
    {
        private string tcNo { get; set; }
        private string isim { get; set; }
        private string sifre { get; set; }
        private string soyisim { get; set; }
        public User(string tcNo,string isim,string soyisim,string sifre)
        {
            this.tcNo = tcNo;
            this.isim = isim;
            this.soyisim = soyisim;
            this.sifre=sifre;
        }

        public void BilgiYazdir()
        {
            Console.WriteLine( tcNo + " : " + isim + " " + soyisim);
        }
        public bool UserCheck(string tc, string sifre)
        {
            if (this.tcNo == tc && this.sifre == sifre)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
