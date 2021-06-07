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
        public override string BuildTc()
        {
            return string.Format("{}", this.Info.Tc);
        }
        public override string BuildIsim()
        {
            return string.Format("{}", this.Info.Isim);
        }
        public override string BuildSoyisim()
        {
            return string.Format("{}", this.Info.Soyisim);
        }
        public override string BuildHastalik()
        {
            return string.Format("{}", this.Info.Hastalik);
        }


        public override string BuildDiyet()
        {
            return string.Format("{}", this.Info.Diyet);
        }
       



    }
}
