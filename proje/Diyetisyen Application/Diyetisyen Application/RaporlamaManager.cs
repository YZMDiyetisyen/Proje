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
            string product = Builder.BuildOutput();
            return product;
        }
        // opsiyonel
        public string BuildUpsideDown()
        {
            string product = Builder.BuildTc();
            product += Builder.BuildIsim();
            product += Builder.BuildSoyisim();
            product += Builder.BuildHastalik();
            product += Builder.BuildDiyet();
            return product;
        }
    }
}
