using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class RaporlamaManager
    {
        private RaporlamaBuilderBase Builder;
        public RaporlamaManager(RaporlamaBuilderBase builder)
        {
            Builder = builder;
        }
        public string Build()
        {
            return Builder.BuildOutput();
        }
        // opsiyonel
        public string BuildUpsideDown()
        {
            string output = Builder.BuildDiyet();
            output += (this.GetType().Name.Contains("Json") ? "," : "") + Builder.BuildHasta();
            return output;
        }
    }
}
