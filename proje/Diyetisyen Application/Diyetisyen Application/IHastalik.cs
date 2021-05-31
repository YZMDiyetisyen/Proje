using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public interface IHastalik
    {
        string Bilgi();
        bool HastalikAta(Hasta hasta);
    }
}
