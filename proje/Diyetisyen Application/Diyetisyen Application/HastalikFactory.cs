using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class HastalikFactory
    {
        public IHastalik CreateHastalikFactory(Hastaliklar hastalik)
        {
            switch (hastalik)
            {
                case Hastaliklar.Obez:return new Obez();
                case Hastaliklar.Colyak:return new Colyak();
                case Hastaliklar.Seker:return new Seker();
                default:return null;
            }
        }
    }
}
