using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Customers
{
    public class PercepcionesManager
    {

        //TODO: 2021.05.27 Percecpciones ARBA -- Si la percecpcion aun no fue informada se podria al desimputar
        //Anular el pago para poder post-ponerlo pero hay que manejar el "informado" 

        /// <summary>
        /// Clase de Manejo de Percecpciones ARBA
        /// Atencion: IdFactura en 402 corresponde a IDFACTURAX en T400.
        /// </summary>

        public decimal GetPercepcionDocumento(int idFacturaX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var doc = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);
            }
            return 0;
        }
        public bool AddFacturaPercepcion(int idFacturaX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factu = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURAX == idFacturaX);
                if (factu == null)
                    return false;

                if (factu.TotalIIBB == 0)
                    return false;

                int multiplicador = 1;
                if (factu.TIPO_DOC == "NC") multiplicador = -1;

                var data = new T0402_FACTURA_PERCEP()
                {
                    IdFactura = idFacturaX,
                    IdCliente = factu.Cliente,
                    NumFactura = factu.PV_AFIP + "-" + factu.ND_AFIP,
                    FechaFactura = factu.FECHA,
                    IIBB_Perc_TXT = factu.IIBB_TXT,
                    IIBB_Perc_Porc = factu.IIBB_PORC,
                    IIBB_Perc_ARS = factu.TotalIIBB * multiplicador,
                    IIBB_Perc_ARS_Saldo = factu.TotalIIBB * multiplicador,
                    IIBB_Perc_DocPago = null,
                    IIBB_Perc_FechaPago = null,
                    IDCtaCte = factu.IdCtaCte,
                    FechaImputacion = null,
                    Informado = false,
                };
                db.T0402_FACTURA_PERCEP.Add(data);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Valida que la factura se puede imputar desde el punto de vista de una percepcion
        /// Por ejemplo que la Percepcion se cubre con la cobranza
        /// </summary>
        public bool ValidaImputacionFacturaPermitida(int idCtaCteFactura, int idCtaCtePago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataF = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idCtaCteFactura);
                if (dataF == null)
                    return false;

                var documentoPago = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCtePago);
                if (documentoPago == null)
                    return false;

                if (dataF.TIPOFACT != "L1")
                    return true; //Desde el punto de vista de percepcion se puede imputar.

                var idFacturaX = dataF.IDFACTURAX;
                var data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);
                if (data == null)
                {
                    if (dataF.TotalIIBB > 0)
                    {
                        //No esta la percepcion en la tabla.- Agregar como FIX
                        new PercepcionesManager().AddFacturaPercepcion(idFacturaX.Value);
                        if (documentoPago.SALDOFACTURA * -1 < dataF.TotalIIBB)
                            return false; //El monto de la cobranza no alcanza para imputar la percpecion
                        return true;
                    }
                    else
                    {
                        return true; //No Existen Percepciones en este documento
                    }
                }
                else
                {
                    //Desde el punto de vista de perecpecion se puede imputar factura (Percepcion ya imputada)
                    if (data.IIBB_Perc_ARS_Saldo == 0)
                        return true;
                }

                //El monto de la cobranza no alcanza para imputar la percpecion
                if (documentoPago.SALDOFACTURA * -1 < data.IIBB_Perc_ARS_Saldo) return false;
                return true;
            }
        }

        /// <summary>
        /// Cuando una factura es anulada completamente por una NC se elmina la info de la percepcion de la tabla
        /// </summary>
        public void RemovePercepcionIIBB_FacturaAnuladaCompleta(int idFacturaAnula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFacturaAnula);
                if (t400 == null) return;
                var idFacturaX = t400.IDFACTURAX;
                var x = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);
                if (x == null)
                    return;
                db.T0402_FACTURA_PERCEP.Remove(x);
                db.SaveChanges();
            }
        }
        public bool ImputaPagoUpdatePercepcion(int idCtaCteFactura, int idCtaCtePago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataF = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idCtaCteFactura);
                if (dataF == null)
                {
                    MessageBox.Show(
                        @"Se ha encontrado el documento en Tabla T0400 - Notifique a Andres de Error",
                        @"Error Grave -- MSG020A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (dataF.TotalIIBB == 0) return true;

                var idFacturaX = dataF.IDFACTURAX;
                var data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);
                if (data == null)
                {
                    //** por un error la percepcion no esta en la tabla! 
                    //** pero se agrega en forma automatica -- fix
                    new PercepcionesManager().AddFacturaPercepcion(idFacturaX.Value);
                    data = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.IdFactura == idFacturaX);
                    MessageBox.Show(
                        @"Se ha agregado la percecpion a la tabla porque no estaba. Por favor notifique sobre esta situacion a Andres",
                        @"MSG021A", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (data == null)
                        return false;

                }

                if (data.IIBB_Perc_ARS_Saldo == 0) return false;

                var documentoPago = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCtePago);
                if (documentoPago == null) return false;

                data.IDCtaCte = idCtaCteFactura;
                data.FechaImputacion = DateTime.Today;
                data.IIBB_Perc_ARS_Saldo = 0;
                data.IIBB_Perc_DocPago = documentoPago.NUMDOC;
                data.IIBB_Perc_FechaPago = documentoPago.Fecha;
                db.SaveChanges();
                return true;
            }
        }

    }
}
