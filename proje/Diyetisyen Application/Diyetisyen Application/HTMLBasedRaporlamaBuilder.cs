using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    class HTMLBasedRaporlamaBuilder : RaporlamaBuilderBase
    {
        public HTMLBasedRaporlamaBuilder(RaporlamaInfo raporlamaInfo) : base(raporlamaInfo)
        {

        }
        public override string BuildHasta()
        {
            string hastahtml = "";
            hastahtml += "<h1>Hasta:</h1>";
            hastahtml += "<b>TC:</b>" + this.Info.HastaTc;
            hastahtml += "<br><b>İsim:</b>" + this.Info.HastaAdi ;
            hastahtml += "<br><b>Soyisim:</b>" + this.Info.HastaSoyadi;
            hastahtml += "<br><b>Hastalık:</b>" + this.Info.Hastalik ;
            return hastahtml;
        }
        public override string BuildDiyet()
        {
            string diyetHtml = "";
            diyetHtml += "<h3>Diyet:</h3>";
            diyetHtml += "<h5>" + this.Info.Diyet + "</h5>";
            return diyetHtml;
        }
    }
}
