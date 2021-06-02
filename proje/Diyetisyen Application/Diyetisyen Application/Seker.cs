﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class Seker:IHastalik
    {
        public returnValue HastalikAta(Hasta hasta)
        {
            return this.SekerHastaligiAta(hasta);
        }
        private returnValue SekerHastaligiAta(Hasta hasta)
        {
            returnValue temp = hasta.HastalikAta(this);
            return temp;
        }
        public string Bilgi()
        {
            return "Şeker Hastalığı";
        }
    }
}
