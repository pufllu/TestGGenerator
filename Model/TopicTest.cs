using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGGenerator
{
    public partial class TopicTest
    {
        public int id { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual Test Test { get; set; }
    }
}
