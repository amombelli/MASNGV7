using System;
using System.Linq;
using System.Windows.Forms;
using MASngFE.FIX;
using MASngFE.Forms;
using MASngFE.Forms.MaterialSearchBase;
using MASngFE.Forms.VendorSearchBase;
using MASngFE.MasterData;
using MASngFE.MasterData.BOM;
using MASngFE.MasterData.Customer_Master;
using MASngFE.MasterData.Material_Master;
using MASngFE.SuperMD;
using MASngFE.Transactional.CRM;
using MASngFE.Transactional.FI.Cobranza;
using MASngFE.Transactional.FI.Factura;
using MASngFE.Transactional.FI.FondoFijo;
using MASngFE.Transactional.FI.GestionCheques;
using MASngFE.Transactional.FI.VendorNCD;
using MASngFE.Transactional.MM;
using MASngFE.Transactional.MM.MMR;
using MASngFE.Transactional.SD.Hoja_de_Ruta;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;
using FrmCustomerSearch = MASngFE.MasterData.Customer_Master.FrmCustomerSearch;

namespace MASngFE.Application
{
    public partial class FrmDevelopmentForm : Form
    {
        public FrmDevelopmentForm(int modo = 0)
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // new EmailManager().SendEmail("marcelo@mombellisrl.com.ar");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var fx = new FrmMergeCustomersData();
            fx.Show();
        }

        private void btnCentroEntregas_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCentroPreparacionHojaRuta();
            f0.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f0 = new FrmMaterialMasterRename();
            f0.Show();
        }







        private void button11_Click(object sender, EventArgs e)
        {
            var f0 = new FrmMdb01BomSearch(0);
            f0.Show();
        }

        private void btnHr0_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var f0 = new FrmPedidosPendientesMaterial();
            f0.Show();
        }

        private void btnFixImputacion_Click(object sender, EventArgs e)
        {
            new FixImputacionIssues().FixIdCtaCteT0208();
        }

        private void tcode2_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            int idCliente = 705;
            int idCtaCte = 37461;
            var cta = new CtaCteCustomer(idCliente);
            var t207 = cta.AddRecordDocumentT0207FromIdCtaCte(idCtaCte);
        }


        private void button20_Click(object sender, EventArgs e)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lincomplete = db.T0400_FACTURA_H.Where(c => c.NumeroDoc == null || c.NumeroDoc == "" || c.NumeroDoc == "-");
                if (lincomplete.Count() > 200)
                {
                    lincomplete = lincomplete.Take(200);
                }


                foreach (var i in lincomplete)
                {
                    if (i.TIPOFACT == "L1")
                    {
                        if (!string.IsNullOrEmpty(i.ND_AFIP))
                        {
                            i.NumeroDoc = i.PV_AFIP + "-" + i.ND_AFIP;
                        }
                        else
                        {
                            i.NumeroDoc = "IDFX-" + i.IDFACTURA.ToString().PadLeft(8, '0');
                        }
                    }

                    if (i.TIPOFACT == "L2")
                    {
                        if (i.TIPO_DOC == "R2" || i.TIPO_DOC == "FA")
                        {
                            i.NumeroDoc = i.Remito;
                        }
                        if (i.Remito == "NCD")
                        {
                            var x = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == i.IDRemito);
                            if (x != null)
                            {
                                i.NumeroDoc = x.NDOC;
                            }
                        }
                    }
                }
                db.SaveChanges();
                MessageBox.Show(@"final");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var x = new FrmUt01ObtieneDatosPadronAFIP();
            x.Show();
        }


        private void button14_Click(object sender, EventArgs e)
        {
            var x = new FrmCustomerSearchNew();
            x.Show();
        }


        private void button24_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCustomerDocumentSearch();
            f0.Show();
        }


        private void button13_Click_1(object sender, EventArgs e)
        {
            var x = new CobranzaUtils().FixCobranzaDiasPp();
            MessageBox.Show($@"Se actualizaron {x} registros");
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            new Email2().SendEmail();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            var x = new CobranzaImputacion().ImputaCobranzaAutomatica(12571, ModoImputacion.Completa);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            var respuesta = new CobranzaUtils().DiasPromedioPagoFacturaImputada(35886);
            MessageBox.Show($@"Dias Imputacion {respuesta.DiasPP_FacturaRecibo} -- Dias Cobranza {respuesta.DiasPP_ReciboPago}");
        }

        
        private void button28_Click(object sender, EventArgs e)
        {
            var fx = new FrmFondoFijoConversion();
            fx.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            var f = new FrmFI42CobranzaTemporal();
            f.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var f = new FrmFI43ConversionCobranzas();
            f.Show();
        }

        private void btnChangeCobraznaType_Click(object sender, EventArgs e)
        {
            var f0 = new FrmFI47ChangeCobranzaType();
            f0.Show();
        }

        private void FrmDevelopmentForm_Load(object sender, EventArgs e)
        {
            GlobalApp.AppUsername = Environment.UserName;
            GlobalApp.Tcode = "-";
        }

        private void btnGoMain_Click(object sender, EventArgs e)
        {
            var f = new Frm00MainAppStart();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new FrmMdc02BillTo(1, -1, "MD");
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new FrmCustomerSearch();
            f.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var f0 = new FrmMasterDataSearchScreen(0, "MDSEARCH");
            f0.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new FrmMdc01CustomerSearchL1();
            f.Show();


        }

        private void button19_Click(object sender, EventArgs e)
        {
            var f = new FrmMdc00CustomerSearchSaldos();
            f.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var f = new FrmChequesInfo();
            f.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var f = new FrmAjusteStockSloc();
            f.Show();
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            var f = new FrmVendorSearchBase();
            f.Show();
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(@"no tiene asignado un form!");
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            var f = new FrmMaterialTypeManager();
            f.Show();
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            var x = new FrmMaterialMasterSearchBase();
            x.Show();
        }
    }
}
