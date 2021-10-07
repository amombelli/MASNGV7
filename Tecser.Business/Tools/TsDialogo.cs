using System.Windows.Forms;
using TSControls;

namespace Tecser.Business.Tools
{
    public class TsDialogo
    {
        public static string StringDialog(string pregunta, string title)
        {
            using (var f0 = new FrmUserInputTexto(pregunta, title))
            {
                DialogResult rx = f0.ShowDialog();
                if (rx == DialogResult.OK)
                {
                    return f0.resultado;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
