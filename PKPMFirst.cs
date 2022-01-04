using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIMBase.Attributes;
using BIMBase.ApplicationService;
using BIMBase.UI;
using BIMBase.DB;

namespace PKPMFirst
{
    [BPExternalCommandAttribute(Name = "Hello")]
    public class PKPMFirst : IBPFunctionCommand
    {
        public override void OnExcute(BPCommandContext context)
        {
            MessageBox.Show("Hello World?");
            base.OnExcute(context);
        }
    }
}
