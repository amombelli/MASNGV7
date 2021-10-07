using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.SuperMD;

namespace MASngFE.SuperMD
{
    public partial class FrmCo10GLStructureTree : Form
    {
        public FrmCo10GLStructureTree()
        {
            InitializeComponent();
        }

        private readonly GlAccountStructureManager _gl = new GlAccountStructureManager();
        private TreeNode _nodoSeleccionado;
        private Color _colorback = new Color();
        private Color _colorfore = new Color();

        public string Glseleccionado { get; private set; }

        private void trvGL_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(@"Se ha seleccionado la siguiente GL Account: " + trvGL.SelectedNode.Name);
            Glseleccionado = trvGL.SelectedNode.Name;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void FrmGLStructure_Load(object sender, EventArgs e)
        {
            ConfiguraCombobox();
            GeneraEstructuraArbol();
        }

        private void GeneraEstructuraArbol()
        {
            var gl = new GlAccountStructureManager();

            int i;
            trvGL.Nodes.Clear();
            trvGL.BeginUpdate();
            trvGL.BackColor = Color.WhiteSmoke;

            //Add Level0 
            var level0 = gl.GetListLevel0();
            for (i = 0; i < level0.Count(); i++)
            {
                var key0 = level0[i].IDC;

                var xnode = new TreeNode();
                xnode.Name = level0[i].IDC;
                xnode.Text = xnode.Name + " -" + level0[i].CUENTA_D;
                xnode.BackColor = Color.Azure;
                xnode.NodeFont = new Font(trvGL.Font, FontStyle.Bold);

                trvGL.Nodes.Add(xnode);
            }

            //Add Level1
            var level1 = gl.GetListLevel1();
            for (i = 0; i < level1.Count; i++)
            {
                var key0 = level1[i].IDL0.ToString();
                var index0 = trvGL.Nodes.Find(key0, true)[0].Index;
                var xnode = new TreeNode();
                xnode.Name = level1[i].IDC;
                xnode.Text = xnode.Name + " - " + level1[i].CUENTA_D;
                xnode.BackColor = Color.AliceBlue;
                trvGL.Nodes[index0].Nodes.Add(xnode);
            }

            //Add Level2

            var level2 = gl.GetListLevel2();
            for (i = 0; i < level2.Count; i++)
            {
                var key0 = level2[i].IDL0.ToString();
                var key1 = level2[i].IDL0.ToString() + "." + level2[i].IDL1.ToString();
                var index0 = trvGL.Nodes.Find(key0, true)[0].Index;
                var index1 = trvGL.Nodes.Find(key1, true)[0].Index;
                var xnode = new TreeNode();
                xnode.Name = level2[i].IDC;
                xnode.Text = xnode.Name + " - " + level2[i].CUENTA_D;
                xnode.BackColor = Color.FloralWhite;
                trvGL.Nodes[index0].Nodes[index1].Nodes.Add(xnode);
            }

            //Add Level3
            var level3 = gl.GetListLevel3();
            for (i = 0; i < level3.Count; i++)
            {
                var key0 = level3[i].IDL0.ToString();
                var key1 = level3[i].IDL0.ToString() + "." + level3[i].IDL1.ToString();
                var key2 = level3[i].IDL0.ToString() + "." + level3[i].IDL1.ToString() + "." + level3[i].IDL2;
                var index2 = trvGL.Nodes.Find(key2, true)[0].Index;
                var index1 = trvGL.Nodes.Find(key1, true)[0].Index;
                var index0 = trvGL.Nodes.Find(key0, true)[0].Index;

                var xnode = new TreeNode();
                xnode.Name = level3[i].IDC;
                xnode.Text = xnode.Name + " - " + level3[i].CUENTA_D;
                xnode.BackColor = Color.Azure;
                xnode.ForeColor = Color.DarkBlue;

                trvGL.Nodes[index0].Nodes[index1].Nodes[index2].Nodes.Add(xnode);
            }


            var level4 = gl.GetListLevel4();
            for (i = 0; i < level4.Count; i++)
            {
                var key0 = level4[i].IDL0.ToString();
                var key1 = level4[i].IDL0.ToString() + "." + level4[i].IDL1.ToString();
                var key2 = level4[i].IDL0.ToString() + "." + level4[i].IDL1.ToString() + "." + level4[i].IDL2;
                var key3 = level4[i].IDL0.ToString() + "." + level4[i].IDL1.ToString() + "." + level4[i].IDL2.ToString() +
                           "." + level4[i].IDL3.ToString();

                var index3 = trvGL.Nodes.Find(key3, true)[0].Index;
                var index2 = trvGL.Nodes.Find(key2, true)[0].Index;
                var index1 = trvGL.Nodes.Find(key1, true)[0].Index;
                var index0 = trvGL.Nodes.Find(key0, true)[0].Index;

                var xnode = new TreeNode();
                xnode.Name = level4[i].IDC;
                xnode.Text = xnode.Name + " - " + level4[i].CUENTA_D;
                xnode.ForeColor = Color.DarkRed;

                trvGL.Nodes[index0].Nodes[index1].Nodes[index2].Nodes[index3].Nodes.Add(xnode);
            }


            trvGL.EndUpdate();
            trvGL.Refresh();
        }

        private void ConfiguraCombobox()
        {
            cmbGLBuscar.DataSource = _gl.GetCompleteListaGL();
            cmbGLBuscar.DisplayMember = "GLDESC";
            cmbGLBuscar.ValueMember = "GL";
            //
        }






        private void cmbGLBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLBuscar.SelectedIndex > 0)
                BuscarGLenArbol(cmbGLBuscar.SelectedValue.ToString());
        }

        private void BuscarGLenArbol(string keyGl)
        {

            if (_nodoSeleccionado != null)
            {
                ResetNodoColor(_nodoSeleccionado);
            }
            var z = trvGL.Nodes.Find(keyGl, true);
            try
            {
                _nodoSeleccionado = z[0];
                _colorback = z[0].BackColor;
                _colorfore = z[0].ForeColor;
                z[0].BackColor = Color.Yellow;
                z[0].ForeColor = Color.Red;
                trvGL.SelectedNode = z[0];
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void ResetNodoColor(TreeNode nodo)
        {
            nodo.BackColor = _colorback;
            nodo.ForeColor = _colorfore;
        }


        private void cmbGLBuscar_TextUpdate(object sender, EventArgs e)
        {
            var lista1 = _gl.GetDataContains(cmbGLBuscar.Text).Select(c => new { c.GL, c.GLDESC });
            dgvSugerencia.DataSource = lista1.ToList();

        }

        private void dgvSugerencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedData = dgvSugerencia.Rows[e.RowIndex];
            BuscarGLenArbol(selectedData.Cells[0].Value.ToString());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trvGL_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
