using System;
using System.Windows.Forms;
using Tecser.Business.SuperMD;

namespace MASngFE.SuperMD
{

    internal enum AddressCombo
    {
        Pais,
        Provincia,
        Partido,
        Localidad
    };

    public partial class FrmAddressStructure : Form
    {
        readonly AddressManager _addmng = new AddressManager("AR");

        public FrmAddressStructure()
        {
            InitializeComponent();
        }

        private void RefreshDataSource()
        {
            UnBindCombobox();
            cmbPais.Text = "AR";
            cmbProvincia.DataSource = _addmng.DatasourceRegion;
            cmbPartido.DataSource = _addmng.DataSourcePartido;
            cmbLocalidad.DataSource = _addmng.DatasourceLocalidad;

            cmbProvincia.SelectedValue = _addmng.GetSelectedRegion();
            cmbPartido.Text = "";
            cmbLocalidad.Text = "";
            BindCombobox();
        }


        private void ConfiguraCombobox()
        {
            cmbProvincia.ValueMember = "id";
            cmbProvincia.DisplayMember = "region";

            cmbPartido.ValueMember = "id";
            cmbPartido.DisplayMember = "partido";

            cmbLocalidad.ValueMember = "id";
            cmbLocalidad.DisplayMember = "Localidad";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //var f2 = new FrmCustomerDetailData(1, 0);
            //{
            //};
            //f2.Show();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cmbID6.Text) != true)
            //{
            //var f2 = new FrmCustomerDetailData(3, (int)cmbLocalidad.SelectedValue);
            {
            };
            //            f2.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Debe completar el cliente que quiere Visualizar", "Master de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerValoresPadronAFIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"En Construccion");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbLocalidad.Text) != true)
            {
                //  var f2 = new FrmCustomerDetailData(2, (int) cmbLocalidad.SelectedValue);
                {
                }
                ;
                //f2.Show();
            }
            else
            {
                MessageBox.Show("Complete el Cliente que desea Modificar", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void UnBindCombobox()
        {
            this.cmbProvincia.SelectedIndexChanged -= new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            Console.WriteLine("UNBIND Controles!");
        }
        private void BindCombobox()
        {
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged += new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            Console.WriteLine("Bind Controles Again");
        }

        private void FrmAddressStructure_Load(object sender, EventArgs e)
        {
            ConfiguraCombobox();
            RefreshDataSource();
        }

        private void ReasignaDatasoruceAddressCombo(AddressCombo combo)
        {
            UnBindCombobox();
            switch (combo)
            {
                case AddressCombo.Pais:

                    break;

                case AddressCombo.Provincia:
                    cmbProvincia.DataSource = _addmng.DatasourceRegion;
                    cmbLocalidad.DataSource = _addmng.DatasourceLocalidad;
                    cmbPartido.DataSource = _addmng.DataSourcePartido;


                    cmbPartido.Text = "";
                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Partido:
                    cmbProvincia.DataSource = _addmng.DatasourceRegion;
                    cmbLocalidad.DataSource = _addmng.DatasourceLocalidad;
                    cmbPartido.DataSource = _addmng.DataSourcePartido;
                    cmbProvincia.SelectedValue = _addmng.GetSelectedRegion();

                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Localidad:
                    cmbProvincia.DataSource = _addmng.DatasourceRegion;
                    cmbLocalidad.DataSource = _addmng.DatasourceLocalidad;
                    cmbPartido.DataSource = _addmng.DataSourcePartido;

                    cmbPartido.SelectedValue = _addmng.GetSelectedPartido();
                    cmbProvincia.SelectedValue = _addmng.GetSelectedRegion();
                    break;

            }
            BindCombobox();
        }


        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("provincia_selectedindexchanged");
            _addmng.SetRegion(Convert.ToInt32(cmbProvincia.SelectedValue));
            ReasignaDatasoruceAddressCombo(AddressCombo.Provincia);
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.Text != null)
            {
                Console.WriteLine("partido_selectedindexchanged");
                _addmng.SetPartido(Convert.ToInt32(cmbPartido.SelectedValue));
                ReasignaDatasoruceAddressCombo(AddressCombo.Partido);
            }
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocalidad.Text != null)
            {
                Console.WriteLine("localidad_selectedindexchanged");
                _addmng.SetLocalidad(Convert.ToInt32(cmbLocalidad.SelectedValue));
                ReasignaDatasoruceAddressCombo(AddressCombo.Localidad);
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("pais_selectedindexchanged");
        }
    }
}
