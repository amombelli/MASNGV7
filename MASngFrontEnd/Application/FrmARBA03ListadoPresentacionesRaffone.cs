using System;
using System.Data;
using System.Windows.Forms;

namespace MASngFE.Application
{
    public partial class FrmArba03ListadoPresentacionesRaffone : Form
    {
        public FrmArba03ListadoPresentacionesRaffone(DataTable data)
        {
            _data = data;
            InitializeComponent();
        }

        private DataTable _data;


        private void FrmARBA03ListadoPresentacionesRaffone_Load(object sender, EventArgs e)
        {
            dgvListadoArba.DataSource = _data;
        }
    }
}
