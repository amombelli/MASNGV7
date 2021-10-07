using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using TSControls;

namespace MASngFE.NewUserControls
{
    public partial class _frmABMAdressControl : Form
    {
        public _frmABMAdressControl()
        {
            InitializeComponent();
        }

        private bool _altaPais = false;
        private bool _altaProvincia = false;
        private bool _altaPartido = false;
        private bool _altaLocalidad = false;
        private string _paisFound;
        private int _provinciaFound;
        private int _partidoFound;
        private int _localidadFound;

        

        private void _frmABMAdressControl_Load(object sender, EventArgs e)
        {
            iconPais.Set = CIconos.Azul;
            iconProvincia.Set = CIconos.Azul;
            iconPartido.Set = CIconos.Azul;
            iconLocalidad.Set = CIconos.Azul;
            _paisFound = null;
            _provinciaFound = -1;
            _partidoFound = -1;
            _localidadFound = -1;
            LoadTreeStruct();
        }

        private void LoadTreeStruct()
        {
            var add = new ControlAddressManager();
            tvAddress.Nodes.Clear();
            tvAddress.BeginUpdate();
            Color nodeBackColor = Color.AntiqueWhite;

            //Add Level PAIS
            var lPais = add.GetListaPaises();
            for (var i=0; i<lPais.Count;i++)
            {
                var node = new TreeNode()
                {
                    BackColor = nodeBackColor,
                    Name = lPais[i],
                    Text = @"Pais - "+lPais[i],
                    ForeColor = Color.Blue,
                    NodeFont = new Font(base.Font,FontStyle.Bold)
                };
                tvAddress.Nodes.Add(node);
                //Add Level Provincia para Pais
                var lProvincia = add.GetProvincia(lPais[i].ToString());
                for (var i1 = 0; i1 < lProvincia.Count; i1++)
                {
                    var index0 = tvAddress.Nodes.Find(lProvincia[i].Pais, true)[0].Index;
                    var node1 = new TreeNode()
                    {
                        Name = "A-"+lProvincia[i1].Id.ToString(),
                        Text = lProvincia[i1].Region.ToString(),
                    };
                    tvAddress.Nodes[index0].Nodes.Add(node1);
                    //Agrego Provincia a Pais
                    var lPartido = add.GetPartido(lProvincia[i1].Id);
                    for (var i2 = 0; i2 < lPartido.Count; i2++)
                    {
                        var indexPr = tvAddress.Nodes.Find("A-"+lPartido[i2].IdProvincia.ToString(),true)[0].Index;
                        var node2 = new TreeNode()
                        {
                            Name = "B-"+lPartido[i2].Id.ToString(),
                            Text = lPartido[i2].Partido
                        };
                        tvAddress.Nodes[index0].Nodes[indexPr].Nodes.Add(node2);
                        //Agrege Partido a Provincia
                        var lLocalidad = add.GetLocalidad(lPartido[i2].Id);
                        for (var i3 = 0; i3 < lLocalidad.Count; i3++)
                        {
                            var indexPart = tvAddress.Nodes.Find("B-" + lLocalidad[i3].IdPartido.ToString(), true)[0].Index;
                            var node3 = new TreeNode()
                            {
                                Name = "C-" + lLocalidad[i3].Id.ToString(),
                                Text = lLocalidad[i3].Localidad,
                                ForeColor = Color.LightCoral,
                            };
                            tvAddress.Nodes[index0].Nodes[indexPr].Nodes[indexPart].Nodes.Add(node3);
                        }
                    }
                }
            }
            tvAddress.EndUpdate();
            tvAddress.Refresh();
        }
        
        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            if (txtPais.Text.Length == 2)
            {
                if (ControlAddressManager.CheckExistePais(txtPais.Text))
                {
                    iconPais.Set = CIconos.TrianguloNaranja;
                    _paisFound = txtPais.Text;
                    _altaPais = false;
                }
                else
                {
                    iconPais.Set = CIconos.Mas;
                    _altaPais = true;
                    _paisFound = null;
                }
                SearchPais(tvAddress.Nodes, txtPais.Text);

            }
        }
        private void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            ep1.SetError(txtProvincia, string.Empty);
            if (txtProvincia.Text.Length >= 4 && ckAutoValidar.Checked)
            { 
                _provinciaFound = ControlAddressManager.CheckExisteProvincia(txtPais.Text, txtProvincia.Text);
                if (_provinciaFound>0)
                {
                    iconProvincia.Set = CIconos.TrianguloNaranja;
                    _altaProvincia = false;
                }
                else
                {
                    if (_provinciaFound == 0)
                    {
                        //Aparecieron varios registros
                        iconProvincia.Set = CIconos.Equis;
                        _altaProvincia = false;
                        ep1.SetError(txtProvincia,"Mas de un Resultado");
                    }
                    else
                    {
                        //retorna Id -1 
                        iconProvincia.Set = CIconos.Mas;
                        _altaProvincia = true;
                    }
                }
            }
            //Busqueada en Arbol Provincia?
            SearchProvinciaPaisTree(tvAddress.Nodes, txtPais.Text, txtProvincia.Text);

        }

        private void txtPartido_TextChanged(object sender, EventArgs e)
        {
            tvAddress.BackColor = Color.White;
            _partidoFound = -1;
            _altaPartido = false;
            if (txtPartido.Text.Length > 4 && ckAutoValidar.Checked)
            {
                _partidoFound = ControlAddressManager.CheckExistePartido(_provinciaFound, txtPartido.Text);
                if (_partidoFound>0)
                {
                    iconPartido.Set = CIconos.TrianguloNaranja;
                    _altaPartido = false;

                }
                else
                {
                    if (_partidoFound == 0)
                    {
                        //Aparecieron varios registros de partidos
                        iconPartido.Set = CIconos.Equis;
                        _altaPartido = false;
                        ep1.SetError(txtPartido, "Mas de un Resultado entrontado");
                    }
                    else
                    {

                        iconPartido.Set = CIconos.Mas;
                        _altaPartido = true;
                    }
                }

                //Busqueda en Arbol -


                //Busca Localidad en Arbol
                if (string.IsNullOrEmpty(txtProvincia.Text))
                {
                    //provincia vacia
                    SearchRecursive(tvAddress.Nodes[0].Nodes, txtPartido.Text, true);
                }
                else
                {
                    var treeProvincia = SearchProvinciaPaisTree(tvAddress.Nodes, txtPais.Text, txtProvincia.Text);
                    if (treeProvincia != null)
                    {
                        var xtree = SearchPartidoProvincia(treeProvincia.Nodes, txtPartido.Text);
                    }
                }
            }
        }
        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            _localidadFound = -1;
            _altaLocalidad = false;
            ep1.SetError(txtLocalidad,string.Empty);

            if (txtLocalidad.Text.Length > 4 && ckAutoValidar.Checked)
            {
                if (_partidoFound == -1)
                {
                    //Esta ingresando localidad pero no hay partido valido
                    //Intenta ver si existe alguna localidad para el partido .- 
                    _localidadFound =
                        ControlAddressManager.CheckExisteLocalidadProvincia(_provinciaFound, txtLocalidad.Text);
                    if (_localidadFound > 0)
                    {
                        //Existe una Localidad --> Linkeada a la Provincia --> Falta Partido.
                        iconLocalidad.Set = CIconos.ExclamacionYellow;
                        //podria completar acá el partido! ****
                        _altaLocalidad = false;
                    }
                    else
                    {
                        if (_localidadFound == 0)
                        {
                            //Han Aparecido varias localidades linkeados a la provincia
                            //Tendria que asignar partido para determinar si hay uno.
                            ep1.SetError(txtLocalidad,
                                "No se puede asignar/determinar partido porque hay varias Localidades vinculadas a la Provincia");
                            _altaLocalidad = false;
                            iconLocalidad.Set = CIconos.Estrella;
                            //hay que deterimnar partido para poder chequear si puede o no dar alta
                        }
                        else
                        {
                            //No aparecio localidad //pero debe seleccionar un partido para poder dar el alta
                            iconLocalidad.Set = CIconos.Corazon;
                            _altaLocalidad = false;
                            ep1.SetError(txtLocalidad,
                                "Localidad no Existe pero no se puede dar de alta porque hay que asignar un partido");
                        }
                    }
                    //** Busqueda en Arbol
                    var treeProvincia = SearchProvinciaPaisTree(tvAddress.Nodes, txtPais.Text, txtProvincia.Text);
                    if (treeProvincia != null)
                    {
                        var xtree = SearchLocalidadSinPartido(treeProvincia.Nodes, txtLocalidad.Text);
                    }
                }
                else
                {
                    //El Partido esta completo
                    _localidadFound =
                        ControlAddressManager.CheckExisteLocalidadPartido(_partidoFound, txtLocalidad.Text);
                    if (_localidadFound > 0)
                    {
                        //Partido-Localidad Existe
                        iconLocalidad.Set = CIconos.TrianguloNaranja;
                        _altaLocalidad = false;
                    }
                    else
                    {
                        if (_localidadFound == 0)
                        {
                            //Aparecieron varios registros de Localiddad-Partido
                            iconLocalidad.Set = CIconos.Equis;
                            _altaLocalidad = false;
                            ep1.SetError(txtLocalidad, "Mas de un Resultado entrontado");
                        }
                        else
                        {
                            //no hay registros encontrados
                            iconLocalidad.Set = CIconos.Mas;
                            _altaLocalidad = true;
                        }
                    }

                    //** Busqueda en Arbol
                    var treeProvincia = SearchProvinciaPaisTree(tvAddress.Nodes, txtPais.Text, txtProvincia.Text);
                    if (treeProvincia != null)
                    {
                        var xtree = SearchPartidoProvincia(treeProvincia.Nodes, txtPartido.Text);
                        if (xtree != null)
                        {
                            SearchLocalidadConPartido(xtree.Nodes, txtLocalidad.Text);
                        }
                    }
                }
            }

            ////Busqued en Arbol
            //    tvAddress.Nodes[0].Collapse();
            //    TreeNode nodeRootSearch;
            //     if (string.IsNullOrEmpty(txtPartido.Text))
            //    {
            //        //no hay partido
            //        if (string.IsNullOrEmpty(txtProvincia.Text))
            //        {
            //            //no hay provincia
            //            nodeRootSearch = tvAddress.Nodes[0];
            //            SearchRecursive(nodeRootSearch.Nodes, txtLocalidad.Text, true, 3);
            //        }
            //        else
            //        {
            //            //hay provincia
            //            nodeRootSearch = BuscaRama(tvAddress.Nodes[0], txtProvincia.Text, false);
            //            SearchRecursive(nodeRootSearch.Nodes, txtLocalidad.Text, true, 3);
            //        }
            //    }
            //    else
            //    {
            //        //hay partido
            //        if (string.IsNullOrEmpty(txtProvincia.Text))
            //        {
            //            //no hay provincia
            //            var add = new ControlAddressManager();
            //            var listaProv = add.GetListaProvincias(txtPais.Text);
   
            //            foreach (var pr in listaProv)
            //            {
            //                var nodoProvincia = BuscaRama(tvAddress.Nodes[0], pr);
            //                if (nodoProvincia != null)
            //                {
            //                    nodeRootSearch = BuscaRama(nodoProvincia, txtPartido.Text, false);
            //                    if (nodeRootSearch != null)
            //                    {
            //                        SearchRecursive(nodeRootSearch.Nodes, txtLocalidad.Text, true, 3);
            //                    }
            //                }
            //            }
                        
            //        }
            //        else
            //        {
            //            //hay provincia
            //            //nodeRootSearch = BuscaRama(tvAddress.Nodes[0], txtProvincia.Text, false);
            //            //nodeRootSearch = BuscaRama(nodeRootSearch, txtPartido.Text, false);
            //            SearchRecursive(tvAddress.Nodes[0].Nodes, txtLocalidad.Text, true, 3);
            //        }
            //    }
            //    //var x = BuscaRama(tvAddress.Nodes[0], txtProvincia.Text);
            //    //SearchRecursive(x.Nodes, txtLocalidad.Text)
            //    //if (nodeRootSearch != null)
            //      //  SearchRecursive(nodeRootSearch.Nodes, txtLocalidad.Text, true, 3);
            //}
        }


        /// <summary>
        /// Funcion que busca un elemento en una unica Rama 
        /// </summary>
        private TreeNode BuscaRama(TreeNode root, string texto,bool buscaHijos=true)
        {
            foreach (TreeNode node in root.Nodes)
            {
                Debug.Print("Estoy en Nodo:" + node.Text + " Profundidad:" + node.Level + " Nodos Abajo=:" + node.Nodes.Count);
                if (node.Text.ToUpper() == texto.ToUpper())
                {
                    return node;
                }

                if (node.Nodes.Count > 0 && buscaHijos)
                    return BuscaRama(node, texto,buscaHijos);
            }
            return null;
        }
        private TreeNode SearchPartidoProvincia(IEnumerable nodeProvincia, string partido)
        {
            if (nodeProvincia == null)
                return null;
            foreach (TreeNode node in nodeProvincia)
            {
                if (node.Text.ToUpper().Equals(partido.ToUpper()))
                {
                    tvAddress.SelectedNode = node;
                    node.BackColor = Color.LightGreen;
                    return node;
                }
                if (node.Text.ToUpper().StartsWith(partido.ToUpper()))
                {
                    tvAddress.SelectedNode = node;
                    node.BackColor = Color.LightSalmon;
                }
                else
                {
                    node.BackColor = Color.White;
                }
            }
            return null;
        }
        private TreeNode SearchProvinciaPaisTree(IEnumerable nodes, string pais, string provincia)
        {
            var nodePais = SearchPais(tvAddress.Nodes, txtPais.Text);
            if (nodePais != null)
            {
                foreach (TreeNode node in nodePais.Nodes)
                {
                    if (node.Text.ToUpper().Equals(provincia.ToUpper()))
                    {
                        tvAddress.SelectedNode = node;
                        node.BackColor = Color.LightGreen;
                        return node;
                    }
                    if (node.Text.ToUpper().StartsWith(provincia.ToUpper()))
                    {
                        tvAddress.SelectedNode = node;
                        node.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        node.BackColor = Color.White;
                    }
                }
            }
            return null;
        }
        private TreeNode SearchPais(IEnumerable nodes, string paisX)
        {
            tvAddress.BackColor = Color.White;
            foreach (TreeNode node in nodes)
            {
                if (node.Name.ToUpper().Equals(paisX.ToUpper()))
                {
                    tvAddress.SelectedNode = node;
                    node.BackColor = Color.LightGreen;
                    return node;
                }
                else
                {
                    node.BackColor = Color.White;
                }
            }
            return null;
        }
        
        private TreeNode SearchLocalidadConPartido(IEnumerable nodePartido,string localidad)
        {
            if (nodePartido == null)
                return null;
            foreach (TreeNode node in nodePartido)
            {
                if (node.Text.ToUpper().Equals(localidad.ToUpper()))
                {
                    tvAddress.SelectedNode = node;
                    node.BackColor = Color.LightGreen;
                    return node;
                }
                if (node.Text.ToUpper().StartsWith(localidad.ToUpper()))
                {
                    tvAddress.SelectedNode = node;
                    node.BackColor = Color.LightSalmon;
                }
                else
                {
                    node.BackColor = Color.White;
                }
            }
            return null;
        }

        private TreeNode SearchLocalidadSinPartido(IEnumerable nodeProvincia, string localidad)
        {
            if (nodeProvincia == null)
                return null;

            foreach (TreeNode node in nodeProvincia)
            {
                foreach (TreeNode nodePart in node.Nodes)
                {
                    if (nodePart.Text.ToUpper().Equals(localidad.ToUpper()))
                    {
                        tvAddress.SelectedNode = nodePart;
                        node.BackColor = Color.LightGreen;
                        return nodePart;
                    }
                    if (nodePart.Text.ToUpper().StartsWith(localidad.ToUpper()))
                    {
                        tvAddress.SelectedNode = nodePart;
                        nodePart.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        nodePart.BackColor = Color.White;
                    }
                }
            }
            return null;
        }



        private bool SearchRecursive(IEnumerable nodes, string text, bool buscaHijos=true, int? levelSearch=null)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text.ToUpper().Contains(text.ToUpper()))
                {
                    if (levelSearch == null)
                    {
                        tvAddress.SelectedNode = node;
                        node.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        if (levelSearch.Value == node.Level)
                        {
                            tvAddress.SelectedNode = node;
                            node.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            node.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    node.BackColor = Color.White;
                }

                if (buscaHijos)
                {
                    if (SearchRecursive(node.Nodes, text,buscaHijos,levelSearch))
                        return true;
                }
            }
            return false;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPais.Text))
            {
                ep1.SetError(this.txtPais, "Pais es Requerido");
                return;
            }
            else
            {
                if (txtPais.Text.Length != 2)
                {
                    ep1.SetError(this.txtPais, "Pais debe tener longitud =2");
                    return;
                }
                else
                {
                    ep1.SetError(txtPais, string.Empty);
                }
            }

            if (string.IsNullOrEmpty(txtProvincia.Text))
            {
                ep1.SetError(txtProvincia,"Provincia es Requerido");
                return;
            }
            else
            {
                ep1.SetError(txtProvincia, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPartido.Text) && !string.IsNullOrEmpty(txtLocalidad.Text))
            {
                //Localidad es != nulo pero el partido es nulo .-
                //No se puede dar de alta una localidad sin un partido.
                ep1.SetError(txtLocalidad,"Si se provee Localidad - Se debe proveer Partido");
                return;
            }
            

            if (string.IsNullOrEmpty(txtPartido.Text))
            {
                //No hay Partido - Esta intentando dar de alta Provincia
                //Chequea si provincia existe
                if (_provinciaFound>0)
                {
                    ep1.SetError(txtProvincia,"La Provincia Ya Existe");
                    return;
                }
                else
                {
                    ep1.SetError(txtProvincia,string.Empty);
                    //Dar de alta Provincia....--->
                }
            }
            else
            {
                //El Partido ha sido provisto
                if (string.IsNullOrEmpty(txtLocalidad.Text))
                {
                    //No hay localidad - Solo intenta dar de alta Partido
                    if (_partidoFound > 0)
                    {
                        ep1.SetError(txtPartido, "El Partido Ya Existe");
                        return;
                    }
                    else
                    {
                        ep1.SetError(txtProvincia, string.Empty);
                        //Dar de alta Partido....--->   
                    }
                }
                else
                {
                    //Localidad ha sido provista
                    if (_localidadFound > 0)
                    {
                        //esta localidad ya existe
                        ep1.SetError(txtPartido, "La Localidad Ya Existe");
                        return;
                    }
                    else
                    {
                        ep1.SetError(txtLocalidad, string.Empty);
                        //dar de alta Localidad -->>
                    }
                }
            }

        }
    }
}
