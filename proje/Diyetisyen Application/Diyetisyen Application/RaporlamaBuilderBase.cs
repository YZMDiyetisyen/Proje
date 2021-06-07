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
            string output = BuildTc();
            output += BuildIsim();
            output += BuildSoyisim();
            output += BuildHastalik();
            output += BuildDiyet();
            return output;
        }
        public abstract string BuildTc();
        public abstract string BuildDiyet();
        public abstract string BuildIsim();
        public abstract string BuildSoyisim();
        public abstract string BuildHastalik();
    }
}
