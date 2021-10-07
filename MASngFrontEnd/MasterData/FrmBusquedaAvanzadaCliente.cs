using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE.MasterData
{
    public partial class FrmBusquedaAvanzadaCliente : Form
    {
        public FrmBusquedaAvanzadaCliente()
        {
            InitializeComponent();
        }
        private List<T0006_MCLIENTES> _customerList = new List<T0006_MCLIENTES>();
        private void FrmBusquedaAvanzadaCliente_Load(object sender, EventArgs e)
        {
            _customerList = new CustomerManager().GetCompleteListofBillTo().ToList();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                t0006MCLIENTESBindingSource.DataSource = _customerList;
                return;
            }
            else
            {
                var filteredList = _customerList;
                filteredList = filteredList.Where(c => c.cli_rsocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper())).ToList();
                t0006MCLIENTESBindingSource.DataSource = filteredList;
            }
        }
    }
}
