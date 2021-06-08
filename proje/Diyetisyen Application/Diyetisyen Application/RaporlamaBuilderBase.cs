using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public abstract class RaporlamaBuilderBase
    {
        protected RaporlamaInfo Info;

        public RaporlamaBuilderBase(RaporlamaInfo raporlamaInfo)
        {
            Info = raporlamaInfo;
        }
        //opsiyonel.
        public string BuildOutput()
        {
            string output = BuildHasta();
            output += (this.GetType().Name.Contains("Json") ? "," : "")+BuildDiyet();
            return output;
        }
        public abstract string BuildHasta();
        public abstract string BuildDiyet();
    }
}
