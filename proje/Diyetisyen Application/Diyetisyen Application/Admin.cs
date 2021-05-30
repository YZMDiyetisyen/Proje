using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Admin : User
    {
        public Admin(string tcNo, string isim, string soyisim,string sifre) : base(tcNo,isim,soyisim,sifre)
        {
        }
    }
}
