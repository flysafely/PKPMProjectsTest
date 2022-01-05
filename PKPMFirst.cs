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
using BIMBase.DB.Geometry;

namespace PKPMFirstProject
{
    [BPExternalCommandAttribute(Name = "Hello")]
    public class PKPMFirst : IBPPointCommand
    {
        BPGePoint3d m_ptS;
        BPGePoint3d m_ptE;
        int m_nFlag = 0;

        public override bool OnLeftClick(BPCommandContext context)
        {
            if (m_nFlag == 0)
            {
                m_nFlag = 1;
                m_ptS = context.MousePoint;
            }
            else if (m_nFlag == 1)
            {
                m_nFlag = 0;
                m_ptE = context.MousePoint;
                BPGeGraphics graphic = createGraphic();
                graphic.save();
            }
            
            return true;
        }
        public override void OnDynamicDraw(BPCommandContext context)
        {
            if (m_nFlag == 0) return;
            m_ptE = context.MousePoint;
            BPViewport vp = BPApplication.Singleton().ActiveDocument.ViewManager.getSelectedViewport();
            BPGeGraphics graphic = createGraphic();
            vp.dynamicDraw(graphic);
        }
        public BPGeGraphics createGraphic()
        {
            BPViewport vp = BPApplication.Singleton().ActiveDocument.ViewManager.getSelectedViewport();
            BPModel model = vp.getTargetModel();
            BPGeGraphics graphic = new BPGeGraphics(model);
            BPGeSegment3d line = new BPGeSegment3d(m_ptS, m_ptE);
            //BPArchWall newWall = new BPArchWall(line, 0, 0);
            graphic.addCurve(BPGeCurveBase.createSegment(line));
            return graphic;
        }
    }
}
