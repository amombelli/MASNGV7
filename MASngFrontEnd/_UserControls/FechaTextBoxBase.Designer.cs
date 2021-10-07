namespace MASngFE._UserControls
{
    partial class FechaTextBoxBase
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
            this.myTextBox = new System.Windows.Forms.MaskedTextBox();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // myTextBox
            // 
            this.myTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myTextBox.Location = new System.Drawing.Point(19, 26);
            this.myTextBox.Mask = "00/00/0000";
            this.myTextBox.Name = "myTextBox";
            this.myTextBox.Size = new System.Drawing.Size(100, 21);
            this.myTextBox.TabIndex = 0;
            this.myTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolTip1
            // 
            this.myToolTip.IsBalloon = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox myTextBox;
        private System.Windows.Forms.ToolTip myToolTip;
    }
}
