using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.BOM
{
    public enum StatusFormula
    {
        Temporal,
        Correcto,
        Suspendida,
        Invalida,
    }

    public class BOMCreateUpdateManager
    {
        public BOMCreateUpdateManager(int idFormula)
        {
            _idFormula = idFormula;
            H = new TecserData(GlobalApp.CnnApp).T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == _idFormula);
            I = new TecserData(GlobalApp.CnnApp).T0021_FORMULA_I.Where(c => c.FORMULA == _idFormula).ToList();
        }

        public BOMCreateUpdateManager(string primario, string nel, string descripcionFormula, string desarrolladoPara,
            bool formulaActiva = true, StatusFormula status = StatusFormula.Temporal)
        {
            H = new T0020_FORMULA_H()
            {
                ID_FORMULA = -1,
                IDMATERIAL = primario.ToUpper(),
                NEL = nel,
                ACTIVA = formulaActiva,
                BATCH_SIZE = 0,
                DESARROLLADO = desarrolladoPara,
                DESC_FORMULA = descripcionFormula,
                STATUS = status.ToString(),
                FControloda = true,
                FControlFecha = DateTime.Today,
                FControlResp = GlobalApp.AppUsername,
                FORM_FECHA = DateTime.Today,
                FORM_VERSION = GetNewVersionFormula(primario.ToUpper()),
                USER = GlobalApp.AppUsername,
            };
            I = new List<T0021_FORMULA_I>();
        }

        //------------------------------------------------------------------------------------------
        private T0020_FORMULA_H H;
        private List<T0021_FORMULA_I> I;
        private int _idFormula;
        private const int ColumnBase = 26;
        private const int DigitMax = 7; // ceil(log26(Int32.Max))
        private const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        //------------------------------------------------------------------------------------------
        //Version nueva 2018.11.28
        private static string GetNewVersionFormula(string materialCrear)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(materialCrear.ToUpper())).ToList();
                if (x.Count == 0)
                {
                    return "A";
                }
                else
                {
                    if (x.Count > 25)
                    {
                        if (
                            db.T0020_FORMULA_H.SingleOrDefault(
                                c =>
                                    c.IDMATERIAL.ToUpper().Equals(materialCrear.ToUpper()) &&
                                    c.FORM_VERSION.ToUpper().Equals(x.Count.ToString())) != null)
                        {
                            return (x.Count + 1).ToString();
                        }
                        else
                        {
                            return x.Count.ToString();
                        }
                    }
                    else
                    {
                        var fx = IndexToColumn(x.Count + 1).ToUpper();
                        if (
                            db.T0020_FORMULA_H.SingleOrDefault(
                                c =>
                                    c.IDMATERIAL.ToUpper().Equals(materialCrear.ToUpper()) &&
                                    c.FORM_VERSION.ToUpper().Equals(fx)) != null)
                        {
                            return (x.Count + 1).ToString();
                        }
                        else
                        {
                            return x.Count.ToString();
                        }
                    }
                }
            }
        }

        private static string IndexToColumn(int index)
        {
            if (index <= 0)
                throw new IndexOutOfRangeException("index must be a positive number");

            if (index <= ColumnBase)
                return Digits[index - 1].ToString();

            var sb = new StringBuilder().Append(' ', DigitMax);
            var current = index;
            var offset = DigitMax;
            while (current > 0)
            {
                sb[--offset] = Digits[--current % ColumnBase];
                current /= ColumnBase;
            }

            return sb.ToString(offset, DigitMax - offset);
        }

        private int GetNewItemId()
        {
            return I.Count * 10 + 10;
        }

        public int AddItem(string itemMaterial, decimal cantidad, int secuencia = 0)
        {
            if (cantidad <= 0)
            {
                return -1;
            }

            var item = new T0021_FORMULA_I()
            {
                ID_ITEM = GetNewItemId(),
                ITEM = itemMaterial.ToUpper(),
                CANTIDAD = cantidad
            };
            if (secuencia == 0)
            {
                item.Secuencia = I.Count + 1;
            }
            else
            {
                item.Secuencia = secuencia;
            }

            I.Add(item);
            RecalculaPorcentaje();
            return item.ID_ITEM;
        }

        private void RecalculaPorcentaje()
        {
            decimal sumaCantidad = 0;
            var idx = 10;
            foreach (var itemList in I.OrderBy(c => c.ID_ITEM))
            {
                itemList.ID_ITEM = idx;
                sumaCantidad += (decimal)itemList.CANTIDAD;
                idx += 10;
            }

            H.BATCH_SIZE = sumaCantidad;
            foreach (var itemList in I)
            {
                itemList.CANTIDAD_PORC = itemList.CANTIDAD * 100 / sumaCantidad;
            }
        }

        public int UpdateCreateBomFromMemory()
        {
            if (CheckBomOKToSave() == false)
                return -1;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H.ID_FORMULA == -1)
                {
                    H.ID_FORMULA = db.T0020_FORMULA_H.Max(c => c.ID_FORMULA) + 1;
                    foreach (var ix in I)
                    {
                        ix.FORMULA = H.ID_FORMULA;
                    }

                    db.T0020_FORMULA_H.Add(H);
                    if (db.SaveChanges() > 0)
                    {
                        db.T0021_FORMULA_I.AddRange(I);
                        if (db.SaveChanges() > 0)
                        {
                            _idFormula = H.ID_FORMULA;
                            return H.ID_FORMULA;
                        }

                        return -1;
                    }

                    return -1;
                }
                else
                {
                    //modo edicion de formula
                    var formulaH = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == _idFormula);
                    db.Entry(formulaH).CurrentValues.SetValues(H);
                    db.SaveChanges();
                    var items = db.T0021_FORMULA_I.Where(c => c.FORMULA == _idFormula).ToList();
                    db.T0021_FORMULA_I.RemoveRange(items);
                    db.T0021_FORMULA_I.AddRange(I);
                    if (db.SaveChanges() > 0)
                        return H.ID_FORMULA;
                    return -1;
                }
            }
        }

        private bool CheckBomOKToSave()
        {
            var rtn = true;

            if (H == null)
                return false;

            if (I == null)
                return false;

            if (I.Count == 0)
                return false;

            RecalculaPorcentaje();


            return rtn;
        }

        public bool RevalidateBom(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                if (x == null)
                    return false;

                x.FControloda = true;
                x.FControlFecha = DateTime.Now;
                x.FControlResp = Environment.UserName;
                db.SaveChanges();
                return true;
            }
        }

        public bool CleanBomRevalidation(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                if (x == null)
                    return false;

                x.FControloda = false;
                x.FControlFecha = null;
                x.FControlResp = null;
                db.SaveChanges();
                return true;
            }
        }
        //------------------------------------------------------------------------------------------


        /// <summary>
        /// Chequea si la alternativa existe para el mismo material a fabricar
        /// </summary>
        public bool CheckAlternativeAlreadyExist(string materialFabricar, string alternativa)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0020_FORMULA_H.Where(
                        c =>
                            c.IDMATERIAL.ToUpper()
                                .Equals(materialFabricar.ToUpper()) &&
                            c.FORM_VERSION.ToUpper().Equals(alternativa.ToUpper())).ToList();

                if (x.Count > 0)
                    return true;
                return false;
            }
        }

        public int CreaHeader(string primario, string descripcionFormula, string desarrolladoPara, string numeroFormula,
            string nel = null, bool formulaActiva = true, bool formulaControlada = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var bomStatus = BOMStatus.StatusHeader.FormulaOK.ToString();
                var h = new T0020_FORMULA_H
                {
                    IDMATERIAL = primario,
                    ACTIVA = formulaActiva,
                    DESARROLLADO = desarrolladoPara,
                    DESC_FORMULA = descripcionFormula,
                    ID_FORMULA = db.T0020_FORMULA_H.Max(c => c.ID_FORMULA) + 1,
                    FORM_VERSION = numeroFormula,
                    NEL = nel,
                    STATUS = bomStatus,
                    BATCH_SIZE = 1,
                    COLOR = "ND",
                };

                //Control Formula
                if (formulaControlada)
                {
                    h.FControloda = true;
                    h.FControlFecha = DateTime.Today;
                    h.FControlResp = Environment.UserName;
                }
                else
                {
                    h.FControloda = false;
                    h.FControlResp = "N/D";
                }

                //Log creacion
                h.USER = Environment.UserName;
                h.FORM_FECHA = DateTime.Now;
                db.T0020_FORMULA_H.Add(h);
                if (db.SaveChanges() > 0)
                    return h.ID_FORMULA;
                return 0;
            }
        }


        //------------------------------------------------------------------------------------------
        //sin revisar

        public BOMCreateUpdateManager()
        {
            //remover este constructor!
        }

        private int DefineNextIdItem(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var it = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                return it.Count * 10 + 10;
            }
        }

        public int CreateOrUpdateBOMHeader(T0020_FORMULA_H data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (data.ID_FORMULA == 0)
                {
                    //Creacion de Formula
                    data.USER = Environment.UserName;
                    data.FORM_FECHA = DateTime.Now;
                    data.ID_FORMULA = db.T0020_FORMULA_H.Max(c => c.ID_FORMULA) + 1;
                    db.T0020_FORMULA_H.Add(data);
                    var md =
                        db.T0010_MATERIALES.SingleOrDefault(
                            c => c.IDMATERIAL.ToUpper().Equals(data.IDMATERIAL.ToUpper()));

                    if (data.NEL != null)
                        md.NEL = Convert.ToInt32(data.NEL);

                    if (!string.IsNullOrEmpty(data.DESARROLLADO))
                        md.DesarrolladoPara = data.DESARROLLADO;

                    return db.SaveChanges() > 0 ? data.ID_FORMULA : 0;
                }
                else
                {
                    //Modificacion de Formula existente
                    var query = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == data.ID_FORMULA);
                    if (query == null)
                        return -1;

                    db.Entry(query).CurrentValues.SetValues(data);
                    query.FORM_MODIF = DateTime.Now;
                    query.LogUpdatedBy = GlobalApp.AppUsername;

                    var md =
                        db.T0010_MATERIALES.SingleOrDefault(
                            c => c.IDMATERIAL.ToUpper().Equals(data.IDMATERIAL.ToUpper()));
                    if (query.NEL != null)
                    {
                        bool isNumeric;
                        int n;
                        isNumeric = int.TryParse(query.NEL, out n);
                        if (isNumeric)
                        {
                            md.NEL = Convert.ToInt32(n);
                        }
                    }

                    if (!string.IsNullOrEmpty(query.DESARROLLADO))
                    {
                        md.DesarrolladoPara = query.DESARROLLADO;
                    }

                    return db.SaveChanges() > 0 ? query.ID_FORMULA : 0;
                }
            }
        }

        public int CreateOrUpdateBOMItems(List<T0021_FORMULA_I> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (items.Count == 0)
                    return -1;

                var formulaId = items[0].FORMULA;
                var data = db.T0021_FORMULA_I.Where(c => c.FORMULA == formulaId).ToList();
                if (data.Count > 0)
                {
                    db.T0021_FORMULA_I.RemoveRange(data);
                }

                db.T0021_FORMULA_I.AddRange(items);
                db.SaveChanges();
                return 1;
            }
        }

        public bool AddItemToBom(int idFormula, string materialComponenteFormula, decimal cantidad)
        {
            var i = new T0021_FORMULA_I();
            i.FORMULA = idFormula;
            i.ITEM = materialComponenteFormula;
            i.CANTIDAD = cantidad;
            i.CANTIDAD_PORC = 0;
            i.ID_ITEM = DefineNextIdItem(idFormula);
            i.Secuencia = 0;
            i.UNIDAD = new MaterialMasterManager().GetPrimarioInfo(materialComponenteFormula).UNIDAD;
            return AddItemToBom(i);
        }

        public bool AddItemToBom(T0021_FORMULA_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0021_FORMULA_I.Add(item);
                if (db.SaveChanges() > 0)
                {
                    UpdateItemPorcentual(item.FORMULA);
                    UpdateHeaderAfterItemAdded(item.FORMULA);
                    return true;
                }

                return false;
            }
        }

        private void UpdateItemPorcentual(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                if (items.Count == 0)
                    return;

                var totalQty = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).Sum(c => c.CANTIDAD);
                if (totalQty == null || totalQty == 0)
                    return;

                foreach (var i in items)
                {
                    i.CANTIDAD_PORC = i.CANTIDAD / totalQty;
                }

                db.SaveChanges();
            }
        }

        private void UpdateHeaderAfterItemAdded(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var i = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();

                if (h == null)
                    return;

                if (i.Count == 0)
                {
                    h.ACTIVA = false;
                    h.STATUS = BOMStatus.StatusHeader.FormulaIssues.ToString();
                }
                else
                {
                    decimal batchSize = 0;
                    foreach (var it in i)
                    {
                        batchSize = batchSize + it.CANTIDAD.Value;
                    }

                    h.BATCH_SIZE = batchSize;
                    h.STATUS = batchSize > 0
                        ? BOMStatus.StatusHeader.FormulaOK.ToString()
                        : BOMStatus.StatusHeader.FormulaIssues.ToString();
                    db.SaveChanges();
                }
            }
        }

        public void FlagForDeletion(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                h.F4D = true;
                h.ACTIVA = false;
                h.FORM_MODIF = DateTime.Now;
                h.LogUpdatedBy = Environment.UserName;
                db.SaveChanges();
            }
        }

        public void UnFlagForDeletion(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                h.F4D = false;
                h.FORM_MODIF = DateTime.Now;
                h.LogUpdatedBy = Environment.UserName;
                db.SaveChanges();
            }
        }
    }
}