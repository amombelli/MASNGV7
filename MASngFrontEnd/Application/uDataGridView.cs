using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MASngFE.Application
{
    [Designer(typeof(ControlDesigner))]
    public partial class UDataGridView : DataGridView
    {
        public UDataGridView() : base()
        {
            InitializeComponent();
        }
    }
}
