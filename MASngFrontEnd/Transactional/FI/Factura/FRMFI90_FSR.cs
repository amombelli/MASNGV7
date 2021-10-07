using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FRMFI90_FSR : Form
    {
        private List<T0401_FACTURA_I> _itemFactura = new List<T0401_FACTURA_I>();
        private T0400_FACTURA_H _headerFactura;
        private List<FsRDataStructure> _data = new List<FsRDataStructure>();
        public FRMFI90_FSR()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMFI90_FSR_Load(object sender, EventArgs e)
        {
            t0006MCLIENTESBindingSource.DataSource = new Fsr().GetListaclienteFsr();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                t0046OVITEMBindingSource.DataSource = new Fsr().GetListaItemsFsr();
                return;
            }
            else
            {
                var yy = (T0006_MCLIENTES)cmbCliente.SelectedItem;
                t0046OVITEMBindingSource.DataSource = new Fsr().GetListaItemsFsr(Convert.ToInt32(cmbCliente.SelectedValue));
            }

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idOV = Convert.ToInt32(datagridview[iDOVDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var idItem = Convert.ToInt32(datagridview[iDITEMDataGridViewTextBoxColumn.Name, e.RowIndex].Value);

            switch (cellValue)
            {
                case "ADD":
                    var xx = new FsRDataStructure()
                    {
                        IdOV = idOV,
                        IdItem = idItem
                    };
                    _data.Add(xx);
                    //using (var f0 = new FrmMM55RequisicionMain(idRc))
                    //{
                    //    DialogResult dr = f0.ShowDialog();
                    //    if (dr == DialogResult.OK)
                    //    {
                    //        //string custName = f0.CustomerName;
                    //        //SaveToFile(custName);

                    //    }
                    //}
                    //rcDataStructureBindingSource.DataSource = new RcManagement().GetRcCompleteList()
                    //    .OrderByDescending(c => c.IdRc).ToList();

                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void AddItemToFactura(int idOV, int idItem)
        {
            /* var dataAdd = new SalesOrderDataManager().GetDataItemFromDb(idOV, idItem);
             if (_headerFactura == null)
             {
                 var xcliente = new CustomerManager().GetCustomerBillToData(dataAdd.ClienteRZ);
                 _headerFactura = new T0400_FACTURA_H()
                 {
                     TotalFacturaN = 0,
                     TC = new ExchangeRateManager().GetExchangeRate(DateTime.Today),
                     IDRemito = null,
                     IDFACTURA = 0,
                     TotalFacturaB = 0,
                     CUIT = xcliente.CUIT,
                     Cliente = dataAdd.ClienteRZ,
                     DIRECCION_FAC = xcliente.Direccion_facturacion,
                     UserLog = GlobalApp.AppUsername,
                     FECHA = DateTime.Today,
                     FechaLog = DateTime.Now,
                     IdCtaCte = null,
                     FacturaMoneda = "ARS",
                     Impreso = false,
                     LOC_FAC = xcliente.Direfactu_Localidad,
                     RAZONSOC = xcliente.cli_rsocial,
                     TIPOFACT = dataAdd.MODO,
                     TIPO_DOC = "FA",
                     TotalIIBB = 0,
                     TotalImpo = 0,
                     TotalIVA21 = 0,
                     CAE = null,
                     CAE_VTO = null,
                     Descuento = 0,
                     DescuentoPorc = 0,
                 };
             }
             var xf = new T0401_FACTURA_I()
             {
                 TC = new ExchangeRateManager().GetExchangeRate(DateTime.Today),
                 IDFactura = 0,
                 IDITEM = 0,
                 ITEM = "VAP",
                 DESC_REMITO = "Facturacion " +dataAdd.Material,
                 KGDESPACHADOS_R = dataAdd.Cantidad,
                 MONEDA_FACT = "ARS",
                 IVA21 = true,
                 MONEDA_COTIZ = dataAdd.MonedaCotiz,
                 PRECIOU_COTIZ = dataAdd.PRECIO1,
             };
             if (dataAdd.MODO != "L1")
             {
                 xf.IVA21 = false;
                 xf.PRECIOU_COTIZ = dataAdd.PRECIO2,
             }*/
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            var f = new FrmFI20MainDocument(_data);
            f.Show();
        }
    }
}
