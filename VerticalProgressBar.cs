using System.Windows.Forms;

namespace Audiolizer
{
    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04; // set PBS_VERTICAL flag
                return cp;
            }
        }
    }
}
