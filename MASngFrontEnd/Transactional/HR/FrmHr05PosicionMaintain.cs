using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHr05PosicionMaintain : Form
    {
        private int _modo;
        private readonly int _idPosicion;

        public FrmHr05PosicionMaintain(int modo, int idPosicion)
        {
            _modo = modo;
            _idPosicion = idPosicion;
            InitializeComponent();
        }

        public FrmHr05PosicionMaintain(int modo = 1)
        {
            _modo = modo;
            _idPosicion = -1;
            InitializeComponent();
        }

        private void FrmHr05PosicionMaintain_Load(object sender, EventArgs e)
        {
            if (_idPosicion == -1)
            {
            }
            else
            {
                var data = HrPosicionesManagement.GetPosicion(_idPosicion);
                txtIdPosicion.Text = _idPosicion.ToString();
                txtDescripcionPosicion.Text = data.PosicionDescripcion;
                ckActiva.Checked = data.Activo;
                ckConvenioUoyep.Checked = data.EnConvenio;
                //
                if (data.TipoLiquidacion == "QUINCENAL")
                {
                    rbQuincena.Checked = true;
                }
                else
                {
                    if (data.TipoLiquidacion == "MENSUAL")
                    {
                        rbMensual.Checked = true;
                    }
                    else
                    {
                        if (data.TipoLiquidacion == "SEMANAL")
                        {
                            rbSemanal.Checked = true;
                        }
                        else
                        {
                            rbNoAplicable.Checked = true;
                        }
                    }
                }

                //
                cValorHora.SetValue = data.ValorHora;
                cValorMensual.SetValue = data.ValorMensual;
                cValorAdicional.SetValue = data.Valor;
                cValorPresentismo.SetValue = data.AdicionalPresentismo;
                cValorBono1.SetValue = data.AdicionalBono1;
                cValorBono2.SetValue = data.AdicionalBono2;
                //
                txtComentario.Text = data.DescripcionVigencia;
                txtLastUpdate.Text = data.UltimaActualizacion == null
                    ? null
                    : data.UltimaActualizacion.Value.ToString("g");
            }

            if (_modo == 3)
            {
                btnGrabar.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var posx = new HrPosicionesManagement().CreateUpdatePosicion(MapPosicion());
            txtIdPosicion.Text = posx.ToString();
            if (_modo == 1)
            {
                MessageBox.Show(@"Se ha creado correctamente la posicion", @"Datos Creados", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _modo = 2;
            }
            else
            {
                MessageBox.Show(@"Se ha modifcado correctamente la posicion", @"Datos Modificados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private T0086_HHRR_POSICIONES MapPosicion()
        {
            var t = new T0086_HHRR_POSICIONES()
            {
                IDPOSICION = _idPosicion,
                Activo = ckActiva.Checked,
                AdicionalBono1 = cValorBono1.GetValueDecimal,
                AdicionalBono2 = cValorBono2.GetValueDecimal,
                EnConvenio = ckConvenioUoyep.Checked,
                PosicionDescripcion = txtDescripcionPosicion.Text,
                Valor = cValorAdicional.GetValueDecimal,
                AdicionalPresentismo = cValorPresentismo.GetValueDecimal,
                DescripcionVigencia = txtComentario.Text,
                UltimaActualizacion = DateTime.Now,
                ValorHora = cValorHora.GetValueDecimal,
                ValorMensual = cValorMensual.GetValueDecimal,
            };

            var tipoLiquidacion = @"NO-APLICA";
            if (rbQuincena.Checked == true)
                tipoLiquidacion = "QUINCENAL";

            if (rbMensual.Checked == true)
                tipoLiquidacion = "MENSUAL";

            if (rbSemanal.Checked == true)
                tipoLiquidacion = "SEMANAL";

            t.TipoLiquidacion = tipoLiquidacion;
            return t;
        }
    }
}