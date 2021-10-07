using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO
{
    public partial class FrmDetalleDocumentos : Form
    {
        public FrmDetalleDocumentos()
        {
            InitializeComponent();
        }

        public FrmDetalleDocumentos(string periodo, string tipoLx, string tipoDoc)
        {
            this._periodo = periodo;
            this._tipoLx = tipoLx;
            this._tipoDoc = tipoDoc;
            InitializeComponent();
        }

        //-------------------------------------------------------------------
        private readonly string _periodo;
        private readonly string _tipoLx;
        private readonly string _tipoDoc;

        private void FrmDetalleDocumentos_Load(object sender, EventArgs e)
        {
            switch (_tipoDoc)
            {
                case "T400":
                    T400Bs.DataSource = new ConciliaGeneral().RetornaListaDocumentosPeriodo(_periodo, _tipoLx);
                    break;

                case "T201F":

                    break;
                case "T201C":

                    break;
                case "T205":

                    break;

                default:
                    break;
            }
        }
    }
}
