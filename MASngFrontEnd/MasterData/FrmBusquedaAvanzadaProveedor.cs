using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE.MasterData
{
    public partial class FrmBusquedaAvanzadaProveedor : Form
    {
        public FrmBusquedaAvanzadaProveedor()
        {
            InitializeComponent();
        }

        private List<T0005_MPROVEEDORES> _vendorList = new List<T0005_MPROVEEDORES>();

        private void dgvListaProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void FrmBusquedaAvanzadaProveedor_Load(object sender, EventArgs e)
        {
            _vendorList = new VendorManager().GetCompleteListVendors();
            t0005MPROVEEDORESBindingSource.DataSource = _vendorList;
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                t0005MPROVEEDORESBindingSource.DataSource = _vendorList;
                return;
            }
            else
            {
                var filteredList = _vendorList;
                filteredList = filteredList.Where(c => c.prov_rsocial.ToUpper().Contains(txtRazonSocial.Text.ToUpper())).ToList();
                t0005MPROVEEDORESBindingSource.DataSource = filteredList;
            }



            //var t = fileList.Where(file => filterList.Any(folder => file.ToUpperInvariant().Contains(folder.ToUpperInvariant())));

            //var t = _vendorList.Where(c => c.prov_rsocial == "a").ToList();

            //t0005MPROVEEDORESBindingSource.DataSource = vendor.ToList();
        }
    }
}
