using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class DiyetFactory
    {
        public IDiyet CreateDiyetFactory(DiyetTipleri diyetTipi)
        {
            switch (diyetTipi)
            {
                case DiyetTipleri.Akdeniz:return new Akdeniz();
                case DiyetTipleri.GlutenFree:return new GlutenFree();
                case DiyetTipleri.DenizUrunleri: return new DenizUrunleri();
                case DiyetTipleri.YesillikDunyasi:return new YesillikDunyasi();
                default: return null;
            }
        }
    }
}
