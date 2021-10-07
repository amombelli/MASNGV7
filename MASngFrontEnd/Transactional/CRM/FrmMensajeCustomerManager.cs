using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CRM;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmMensajeCustomerManager : Form
    {
        public FrmMensajeCustomerManager()
        {
            InitializeComponent();
        }

        private CustomerMessageManager _msg = new CustomerMessageManager();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmMensajeCustomerManager_Load(object sender, EventArgs e)
        {
            cmbClienteFantasia.DisplayMember = "Cli_Fantasia";
            cmbClienteFantasia.ValueMember = "IdCliente";
            cmbClienteFantasia.DataSource = new CustomerManager().GetCompleteListofBillTo(false);
        }

        private void cmbClienteFantasia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbClienteFantasia.Text) == false)
            {
                _msg.AsignaCliente(Convert.ToInt32(cmbClienteFantasia.SelectedValue));
                //_context = Msg.GetContextForActiveMessage();
                CustomerMsgBS.DataSource = _msg.GetListOfMessages();
                //CustomerActiveMsgBS.DataSource = Msg.GetActiveMessage(); // _context.CustomerMensajes.ToList();
                CustomerActiveMsgBS.DataSource = _msg.GetActiveMessage1();
            }
        }

        private void btnNuevoMensaje_Click(object sender, EventArgs e)
        {
            CustomerActiveMsgBS.EndEdit();
            _msg.Context.SaveChanges();

        }

        private void btnNuevaRespuesta_Click(object sender, EventArgs e)
        {
            CustomerActiveMsgBS.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
