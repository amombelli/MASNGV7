using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.GLSManagement;
using TecserEF.Entity;

namespace MASngFE.Transactional.CO.GL
{
    public partial class FrmCO31GLS_TreeResults : Form
    {
        private readonly List<T0136_GLTREE> _data;

        public FrmCO31GLS_TreeResults()
        {
            InitializeComponent();
        }



        private void FrmCO31GLS_TreeResults_Load(object sender, EventArgs e)
        {
            var _data = new GLSManagement().GetTreeGenerated();
            t0136GLTREEBindingSource.DataSource = _data;
        }
    }
}
