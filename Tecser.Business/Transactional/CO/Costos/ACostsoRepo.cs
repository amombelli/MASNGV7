using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CO.Costos
{

    /// <summary>
    /// Administracion de Costo de Reposicion
    /// Costo de Reposicion almacenado en T0036
    /// </summary>
    public class ACostoRepo : ACosto
    {
        public ACostoRepo(string material, decimal? xrate = null) : base(material, xrate)
        {
            TipoCosto = CostType.Reposicion;
            DatosUc = new AStructureReposicionRtn(material);
            _autoFix = true;
        }

        public AStructureReposicionRtn DatosUc;
        public T0036_CostoReposicion RecordT0036 { get; protected set; }
        

        //public DateTime FechaUltimaCompra { get; protected set; }
        //public int VendorUc { get; protected set; }
        //public decimal KgUltimaCompra { get; protected set; }
         
        public decimal VariacionARS { get; protected set; }
        public decimal VariacionUSD { get; protected set; }
        private bool _autoFix;

        /// <summary>
        /// Funcion Obtiene Costo Reposicion almancenado en T0036
        /// </summary>
        public override void GetCost()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                RecordT0036 = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == Material);
                if (RecordT0036 != null)
                {
                    DatosUc.PrecioArs = RecordT0036.CostoUCArs;
                    DatosUc.PrecioUsd = RecordT0036.CostoUCArs;
                    DatosUc.Material = Material;
                    DatosUc.FechaUCompra = RecordT0036.FechaUC;
                    DatosUc.KgUCompra = RecordT0036.KgUC;
                    DatosUc.SetVendor(RecordT0036.ProveedorID);
                    DatosUc.MonedaCompra = RecordT0036.MonedaCosto;
                    DatosUc.XRate = RecordT0036.TCConversion;
                    Encontrado = true;
                    FechaCosto = RecordT0036.FechaUC;
                    base.ValorARS = RecordT0036.CostoUCArs;
                    base.ValorUSD = RecordT0036.CostoUCUsd;
                    base.Moneda = RecordT0036.MonedaCosto;
                    VariacionARS = RecordT0036.VarCostoUCArs;
                    VariacionUSD = RecordT0036.VarCostoUCUsd;
                }
                else
                {
                    if (_autoFix)
                    {
                        FixObtieneCostoUcFromUltimoRegistro();
                        SetAutoFixIfRecordNotFound(false);
                        GetCost();
                    }
                    else
                    {
                        Encontrado = false;
                    }
                }
            }
        }
        
        /// <summary>
        /// Guarda el Registro de Costo en Tabla
        /// </summary>
        public void SaveCost(int vendorId, decimal kgCompra, Monedas.SMonedas moneda, decimal costoUnitario, DateTime fechaConta,
            decimal? tc = null, string user = null, bool manualUpdate = false)
        {
            if (user == null)
                user = GlobalApp.AppUsername;

            if (tc == null || tc <= 0)
                tc = base.XRate;

            DateTime? dateManualUpdate = null;
            string usermanualUpdate = null;

            if (manualUpdate)
            {
                dateManualUpdate = DateTime.Today;
                usermanualUpdate = user;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matData = base.MaterialData;
                var cost = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == Material);
                if (cost == null)
                {
                    var x = new T0036_CostoReposicion()
                    {
                        MonedaCosto = moneda.ToString(),
                        Material = Material,
                        CostoPPPArs = 0,
                        FechaCompraAnterior = fechaConta,
                        FechaUC = fechaConta,
                        ProveedorID = vendorId,
                        VarCostoUCUsd = 0,
                        VarCostoUCArs = 0,
                        DateManualUpd = dateManualUpdate,
                        UserManualUpd = usermanualUpdate,
                        UserConta = user,
                        ManualUpdated = manualUpdate,
                        KgUC = kgCompra,
                        Origen = matData.ORIGEN,
                        CostoUpdatedCostRoll = true, //indica costo no fue actualizado despues del CRoll
                        UpdatedAfterCR = true,
                        TCConversion = tc.Value,
                    };
                    if (moneda == Monedas.SMonedas.USD)
                    {
                        x.CostoUCUsd = costoUnitario;
                        x.CostoUCArs = costoUnitario * tc.Value;
                    }
                    else
                    {
                        x.CostoUCArs = costoUnitario;
                        x.CostoUCUsd = costoUnitario / tc.Value;
                    }
                    db.T0036_CostoReposicion.Add(x);
                    db.SaveChanges();
                }
                else
                {
                    cost.MonedaCosto = moneda.ToString();
                    cost.TCConversion = tc.Value;
                    cost.DateManualUpd = dateManualUpdate;
                    cost.FechaCompraAnterior = cost.FechaUC;
                    cost.FechaUC = fechaConta;
                    cost.ProveedorID = vendorId;
                    cost.UserManualUpd = usermanualUpdate;
                    cost.UserConta = user;
                    cost.ManualUpdated = manualUpdate;
                    cost.KgUC = kgCompra;
                    cost.Origen = matData.ORIGEN;
                    //CostoPPPUsd = 0,  todo: funcion PPP 
                    //CostoPPPArs = 0, todo: funcion PPP
                    var antPrecioArs = cost.CostoUCArs;
                    var antPrecioUsd = cost.CostoUCUsd;
                    if (moneda == Monedas.SMonedas.USD)
                    {
                        if (costoUnitario != cost.CostoUCUsd)
                        {
                            //hubo variacion de precio despues del costRoll
                            cost.CostoUpdatedCostRoll = true;
                            cost.UpdatedAfterCR = true; //flag el costo fue modificado despues del cost roll
                            cost.CostoUCUsd = costoUnitario;
                        }
                        cost.CostoUCArs = costoUnitario * tc.Value;
                    }
                    else
                    {
                        if (costoUnitario != cost.CostoUCArs)
                        {
                            //hubo variacion de precio despues del costRoll
                            cost.CostoUpdatedCostRoll = true;
                            cost.UpdatedAfterCR = true;
                            cost.CostoUCArs = costoUnitario;
                        }

                        cost.CostoUCUsd = costoUnitario / tc.Value;
                    }
                    cost.VarCostoUCArs = cost.CostoUCArs - antPrecioArs;
                    cost.VarCostoUCUsd = cost.CostoUCUsd - antPrecioUsd;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Actualizacion de Costo de Reposicion en forma manual para el mismo proveedor.
        /// Cambia solo el Costo
        /// </summary>
        public bool UpdateExistingCost(Monedas.SMonedas moneda, decimal nuevoCosto)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0036_CostoReposicion.SingleOrDefault(c => c.Material == Material);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    if (moneda == Monedas.SMonedas.ARS)
                    {
                        if (data.CostoUCArs == nuevoCosto)
                            return false;
                    }
                    else
                    {
                        if (data.CostoUCUsd == nuevoCosto)
                            return false;
                    }

                    data.ManualUpdated = true;
                    data.DateManualUpd = DateTime.Now;
                    data.UserManualUpd = GlobalApp.AppUsername;
                    data.UpdatedAfterCR = true;
                    if (moneda == Monedas.SMonedas.USD)
                    {
                        data.CostoUCUsd = nuevoCosto;
                        data.CostoUCArs = nuevoCosto * base.XRate;
                    }
                    else
                    {
                        data.CostoUCArs = nuevoCosto;
                        data.CostoUCUsd = nuevoCosto / base.XRate;
                    }

                    var costRollHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                    if (costRollHeader != null)
                    {
                        costRollHeader.UpdCompras = true;
                    }
                    return db.SaveChanges()>0;
                }
            }
        }

        /// <summary>
        /// Setea flag para ejecutar completa datos de UC basado en facturas ingresadas
        /// </summary>
        public void SetAutoFixIfRecordNotFound(bool valor)
        {
            _autoFix = valor;
        }
        
        /// <summary>
        /// Funcion usada como FIX para obtener datos almancenados historicamente en T404
        /// </summary>
        public void FixObtieneCostoUcFromUltimoRegistro()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == Material)
                    .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).Take(1).ToList();

                if (d404.Any())
                {
                    var x = d404[0];
                    if (x.PUNIT_USD == 0 || x.PUNIT_USD == null)
                    {
                        //Version vieja no manejaba PUNIT y Contabilizaba solo en ARS
                        x.MONEDA = "ARS";
                        x.PUNIT_ARS = decimal.Round((x.SUBTOTAL.Value / x.CANT.Value), 3);
                        x.PUNIT_USD = decimal.Round((x.PUNIT_ARS.Value / x.TC.Value), 3);
                    }

                    db.SaveChanges();
                    SaveCost(x.T0403_VENDOR_FACT_H.IDPROV, x.CANT.Value, Monedas.SMonedas.USD, x.PUNIT_USD.Value,
                        x.T0403_VENDOR_FACT_H.FECHA, x.TC.Value, x.T0403_VENDOR_FACT_H.LOGUSER, false);
                }
            }
        }

        /// <summary>
        /// Funcion usada com FIX para completar datos historicos en T0404
        /// </summary>
        public void FixCostosReposicionCeroOldVersion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == Material)
                    .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).ToList();
                foreach (var it in d404)
                {
                    if (it.MONEDA == null)
                        it.MONEDA = "ARS";

                    if (it.MonedaItemProveedor == null)
                        it.MonedaItemProveedor = "USD";

                    if (it.TC == null || it.TC == 0)
                        it.TC = new ExchangeRateManager().GetExchangeRate(it.T0403_VENDOR_FACT_H.FECHA);


                    if (it.CANT == null || it.CANT.Value == 0)
                        it.CANT = 1;

                    if (it.PUNIT_ARS == null || it.PUNIT_ARS == 0)
                        it.PUNIT_ARS = decimal.Round((it.SUBTOTAL.Value / it.CANT.Value), 3);

                    if (it.PUNIT_USD == null || it.PUNIT_USD == 0)
                        it.PUNIT_USD = decimal.Round((it.SUBTOTAL.Value / it.CANT.Value / it.TC.Value), 3);

                    db.SaveChanges();
                }
            }
        }

        //public List<CostoUltimasCompras> GetListadoUc(int topData = 10)
        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        var lista = new List<CostoUltimasCompras>();
        //        var d404 = db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == Material)
        //            .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).Take(topData).ToList();
        //        foreach (var data in d404)
        //        {
        //            var item = new CostoUltimasCompras()
        //            {
        //                FechaFactura = data.T0403_VENDOR_FACT_H.FECHA,
        //                IdProveedor = data.T0403_VENDOR_FACT_H.IDPROV,
        //                KgCompra = data.CANT.Value,
        //                Material = Material,
        //                NumeroOC = 1,
        //                RazonSocial = data.T0403_VENDOR_FACT_H.PROVRS,
        //                TC = data.T0403_VENDOR_FACT_H.TC
        //            };

        //            if (data.MonedaItemProveedor == null)
        //            {
        //                //Campo nuevo 20191030
        //                data.MonedaItemProveedor = "USD";
        //            }
        //            item.MonedaCotizacion = data.MonedaItemProveedor;

        //            //No hace conversion de TC porque fue realizada durante la contabilizacion.

        //            if (data.PUNIT_ARS == null)
        //                data.PUNIT_ARS = 0;

        //            if (data.PUNIT_USD == null)
        //                data.PUNIT_USD = 0;
        //            db.SaveChanges();
        //            item.PrecioARS = data.PUNIT_ARS.Value;
        //            item.PrecioUSD = data.PUNIT_USD.Value;
        //            lista.Add(item);
        //        }
        //        return lista;
        //    }
        //}

    }
}
