namespace MASngFE._UserControls
{
    partial class FechaControlBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // FechaControlBase
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ForeColor = System.Drawing.Color.White;
            this.Mask = "00/00/0000";
            this.Text = "  /  /";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FechaControlBase_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip myToolTip;
    }
}
