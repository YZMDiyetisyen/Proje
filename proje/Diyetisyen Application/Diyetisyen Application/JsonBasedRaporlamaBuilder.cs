using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class JsonBasedRaporlamaBuilder : RaporlamaBuilderBase
    {
        public JsonBasedRaporlamaBuilder(RaporlamaInfo raporlamaInfo) : base(raporlamaInfo)
        {

        }
        public override string BuildHasta()
        {
            return "\"Hasta\":{\"TC\":\"" + this.Info.HastaTc + "\",\"İsim\":\"" + this.Info.HastaAdi + "\",\"Soyisim\":\"" + this.Info.HastaSoyadi + "\",\"Hastalık\":\"" + this.Info.Hastalik + "\"}";
        }
        public override string BuildDiyet()
        {
            return "\"Diyet\":\"" + this.Info.Diyet+ "\"";
        }




    }
}
