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
        private string soyisim { get; set; }
        public User(string tcNo,string isim,string soyisim)
        {
            this.tcNo = tcNo;
            this.isim = isim;
            this.soyisim = soyisim;
        }
        public string BilgiYazdir()
        {
            return tcNo + " : " + isim + " " + soyisim;
        }
    }
}
