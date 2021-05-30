﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Diyetisyen diyetisyen = new Diyetisyen("11111","Sezer","Yıldırım");
            Hasta hasta = new Hasta("2222","Ali","Atay");

            diyetisyen.HastaAta(hasta);

            DiyetFactory diyetFactory = new DiyetFactory(); 
            IDiyet diyet=diyetFactory.CreateDiyetFactory(DiyetTipleri.GlutenFree);
            diyet.DiyetAta(hasta);

            Console.WriteLine(hasta.DiyetBilgisi());
            Console.Read();
        }
    }
}
