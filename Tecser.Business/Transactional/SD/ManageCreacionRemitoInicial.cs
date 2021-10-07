using System;
using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class HeaderSpecification
    {
        public int IdRemito;
        public string LX;
        public bool L5;
        public int? Rlink;
    }

    /// <summary>
    /// Dada la lista de items a agregar genera los Header/s remito y agrega en cada H
    /// los CostItems correspondientes. Los CostItems 
    /// </summary>
    public class ManageCreacionRemitoInicial
    {
        private List<T0056_REMITO_I> _itemList;
        private string _numeroRemitoGuid;
        private int _idCliente7;

        public List<HeaderSpecification> CreacionRemitosSegunTipoSO(List<T0056_REMITO_I> itemList, string numeroRemitoGuid, int idCliente7)
        {
            _itemList = itemList.Where(c => c.GENERAR_REMITO.Value).ToList();
            _numeroRemitoGuid = numeroRemitoGuid;
            _idCliente7 = idCliente7;

            var headerList = HeadersCreation(); //Crea los headers de los remitos de acuerdo a los tipos de OV
            AddItemsToHeaders(headerList);      //Agrega CostItems en cada header de acuerdo a los tipos
            return headerList;
        }

        /// <summary>
        /// Retorna el tipo de remito a generar.
        /// Si Retorna 1 = Solo L1
        /// Si Retorna 2 = Solo L2
        /// Si Retorna 3 = CostItems L1 + CostItems L2
        /// Si Retorna 4 = Solo CostItems L5 
        /// Si Retorna 5 = CostItems L5 + CostItems L1
        /// Si Retorna 6 = CostItems L5 + CostItems L2
        /// Si Retorna 7 = CostItems L5 + CostItems L1 + CostItems L2
        /// L5 = L5 y L6 = mix de L1 y L2 
        /// </summary>
        private int DefineRemitoTypesToGenerate()
        {
            var hayL5 = false;
            var hayL1 = false;
            var hayL2 = false;
            var lx = 0;

            foreach (var item in _itemList.Where(c => c.GENERAR_REMITO.Value == true))
            {
                if (item.L5 == true)
                {
                    hayL5 = true;
                }
                else
                {
                    if (item.LX == "L1")
                    {
                        hayL1 = true;
                    }
                    else
                    {
                        hayL2 = true;
                    }
                }
            }

            if (hayL5)
            {
                lx = 4;
            }
            if (hayL2)
            {
                lx += 2;
            }
            if (hayL1)
            {
                lx += 1;
            }
            return lx;
        }

        /// <summary>
        /// Esta funcion se podria optimizar en cuanto a lineas de codigo ya que en definitiva
        /// </summary>
        private List<HeaderSpecification> HeadersCreation()
        {
            var listaHeader = new List<HeaderSpecification>();
            var auxHeader = new HeaderSpecification();
            var remitoH = new RemitoHeaderManager();

            switch (this.DefineRemitoTypesToGenerate())
            {
                case 1:
                    //Solo Header L1
                    var header1 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, false),
                        L5 = false,
                        LX = "L1",
                        Rlink = null,
                    };
                    listaHeader.Add(header1);
                    break;
                case 2:
                    //Solo Header L2
                    var header2 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, false),
                        L5 = false,
                        LX = "L2",
                        Rlink = null,
                    };
                    listaHeader.Add(header2);
                    break;
                case 3:
                    //Header L1 + Header L2
                    var header12 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, false),
                        L5 = false,
                        LX = "L1",
                        Rlink = null,
                    };

                    var header21 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, false),
                        L5 = false,
                        LX = "L2",
                        Rlink = null,
                    };
                    listaHeader.Add(header12);
                    listaHeader.Add(header21);
                    break;
                case 4:
                    //Remito con todos los items L5   
                    var header1L5 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, true),
                        L5 = true,
                        LX = "L1",
                        Rlink = null,
                    };

                    var header2L5 = new HeaderSpecification()
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, true),
                        L5 = true,
                        LX = "L2",
                        Rlink = header1L5.IdRemito,
                    };
                    header1L5.Rlink = header2L5.IdRemito;
                    listaHeader.Add(header1L5);
                    listaHeader.Add(header2L5);
                    new RemitoHeaderManager().UpdateRlink(header1L5.IdRemito, header1L5.Rlink.Value);
                    break;
                case 5:
                    //CostItems L5 + CostItems L1
                    auxHeader.IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, true);
                    auxHeader.L5 = true;
                    auxHeader.LX = "L1";
                    auxHeader.Rlink = null;

                    var auxHeader4 = new HeaderSpecification
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, true),
                        L5 = true,
                        LX = "L2",
                        Rlink = auxHeader.Rlink,
                    };
                    auxHeader.Rlink = auxHeader4.IdRemito;
                    listaHeader.Add(auxHeader);
                    listaHeader.Add(auxHeader4);
                    new RemitoHeaderManager().UpdateRlink(auxHeader.IdRemito, auxHeader.Rlink.Value);
                    break;
                case 6:
                    //CostItems L5 + CostItems L2
                    auxHeader.IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, true);
                    auxHeader.L5 = true;
                    auxHeader.LX = "L1";
                    auxHeader.Rlink = null;

                    var auxHeader6 = new HeaderSpecification
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, true),
                        L5 = true,
                        LX = "L2",
                        Rlink = auxHeader.IdRemito,
                    };
                    auxHeader.Rlink = auxHeader6.IdRemito;
                    listaHeader.Add(auxHeader);
                    listaHeader.Add(auxHeader6);
                    new RemitoHeaderManager().UpdateRlink(auxHeader.IdRemito, auxHeader.Rlink.Value);

                    var auxHeaderL2Puro = new HeaderSpecification
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, false),
                        L5 = false,
                        LX = "L2",
                        Rlink = null,
                    };
                    listaHeader.Add(auxHeaderL2Puro);
                    break;
                case 7:
                    //CostItems L5 + items puro L1 + items puro L2
                    auxHeader.IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L1", _idCliente7, true);
                    auxHeader.L5 = true;
                    auxHeader.LX = "L1";
                    auxHeader.Rlink = null;

                    var auxHeader0 = new HeaderSpecification
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, true),
                        L5 = true,
                        LX = "L2",
                        Rlink = auxHeader.IdRemito
                    };
                    auxHeader.Rlink = auxHeader0.IdRemito;
                    listaHeader.Add(auxHeader);
                    listaHeader.Add(auxHeader0);
                    new RemitoHeaderManager().UpdateRlink(auxHeader.IdRemito, auxHeader.Rlink.Value);

                    var auxHeaderL2Puro_ = new HeaderSpecification
                    {
                        IdRemito = remitoH.GeneraRemitoHeader(_numeroRemitoGuid, "L2", _idCliente7, false),
                        L5 = false,
                        LX = "L2",
                        Rlink = null,
                    };
                    listaHeader.Add(auxHeaderL2Puro_);
                    break;
                default:
                    break;
            }
            return listaHeader;
        }
        //Numero de Remito se reemplaza en SQL x T+IDREMITO!

        /// <summary>
        /// Se genera un solo remito L1 (con items L1 y L5)
        /// Se genera un remito L2 con items L2
        /// Se genera un remito L5 con la parte L2 de un L5 
        /// </summary>
        private void AddItemsToHeaders(List<HeaderSpecification> headerList)
        {
            foreach (var item in _itemList)
            {
                if (item.L5)
                {
                    var elemento = headerList.Find(c => c.LX == "L1");
                    item.IDREMITO = elemento.IdRemito;
                    item.RLINK = elemento.Rlink;
                    var mystring = "T" + elemento.IdRemito;
                    item.NUMREMITO = mystring.Substring(Math.Max(0, mystring.Length - 8));
                    var remitoItem = new RemitoItemManager().AddRemitoItem(item);
                    //
                    //
                    var headerL2 = headerList.Find(c => c.L5 == true && c.LX == "L2");
                    item.IDREMITO = headerL2.IdRemito;
                    item.RLINK = headerL2.Rlink;
                    var mystring2 = "X" + headerL2.IdRemito;
                    item.NUMREMITO = mystring2.Substring(Math.Max(0, mystring.Length - 8));
                    item.LX = "L2";
                    var remitoItem2 = new RemitoItemManager().AddRemitoItem(item);
                }
                else
                {
                    if (item.LX == "L1")
                    {
                        //Remito L1
                        var elemento = headerList.Find(c => c.LX == "L1");
                        item.IDREMITO = elemento.IdRemito;
                        string mystring = "T" + elemento.IdRemito;
                        item.NUMREMITO = mystring.Substring(Math.Max(0, mystring.Length - 8));
                        var remitoItem = new RemitoItemManager().AddRemitoItem(item);
                    }
                    else
                    {
                        //Remito L2
                        var elemento = headerList.Find(c => c.L5 == false && c.LX == "L2");
                        item.IDREMITO = elemento.IdRemito;
                        string mystring = "T" + elemento.IdRemito;
                        item.NUMREMITO = mystring.Substring(Math.Max(0, mystring.Length - 8));
                        var remitoItem = new RemitoItemManager().AddRemitoItem(item);
                    }
                }
            }
        }
    }
}

