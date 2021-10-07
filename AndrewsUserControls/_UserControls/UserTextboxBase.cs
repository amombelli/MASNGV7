using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace MASngFE._UserControls
{
    public abstract partial class UserTextboxBase : UserControl
    {
        protected UserTextboxBase()
        {
            InitializeComponent();
            //this.Size = new Size(txt.Width,txt.Height);
        }

        public decimal ValueD { protected set; get; }
        protected decimal ValorMin;
        protected decimal ValorMax;
        protected bool AllowBackSpace = false;
        protected bool AllowNegative = false;
        protected bool AllowMoneda = true;
        protected int CantidadDecimales;
        
        //Formato Decimal
        protected virtual void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se declara la funcionalidad en cada clase heredada
            MessageBox.Show(@"Esta funcion va redefinida en la implementacion!");
        }

        public virtual void Init(decimal valorMinimo, decimal valorMaximo, bool allowBackSp, bool allowSignoMenos,
            bool allowSignoMoneda, Color fc = default(Color),
            Color bc = default(Color), float tamanoLetra = 9,int cantidadDecimales=2)
        {
            
        }

        protected virtual void txt_Validating(object sender, CancelEventArgs e)
        {
            MessageBox.Show(@"Esta funcion va redefinida en la implementacion!");
        }

        private void txt_Validated(object sender, EventArgs e)
        {

        }

        private void txt_Leave(object sender, EventArgs e)
        {
           
        }

        private void UTextBoxCurrency_SizeChanged(object sender, EventArgs e)
        {
            txt.Size = new Size(this.Width,this.Height);
        }

        private void UserTextboxBase_Load(object sender, EventArgs e)
        {

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
