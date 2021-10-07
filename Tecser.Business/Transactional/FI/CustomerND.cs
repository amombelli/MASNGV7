using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{

    /// <summary>
    /// Nueva Clase de Gestion de Notas de Debito 2021.07.10
    /// </summary>
    public class CustomerNd:CustomerDoc
    {
        public CustomerNd(MotivoNotaDebito xmotivo)
        {
            _motivoDocumento = xmotivo;
            motivoDocumentoString = xmotivo.ToString();
        }
        /// <summary>
        /// Constructor para cargar datos existentes
        /// </summary>
        public CustomerNd(int idFactura400)
        {
            //Este constructor no esta en uso todavia
            Id400 = idFactura400;
            //_t400 = new GestionT400(idFactura400,ManageDocumentType.TipoDocumento.NotaDebitoVentaA);
        }
        
        public enum MotivoNotaDebito
        {
            AnulaDocumento,
            ChequeRechazado,
            ChequeSinRechazo,
            DiferenciaPrecio,
            DiferenciaCambio,
            DiferenciaKg,
            DevolucionMaterial,
            DesGeneralDocumentos,
            DesGeneralPeriodo,
            GastoBancario,
            SinMotivo
        }
        public MotivoNotaDebito MapMotivoFromTextoToType(string motivo)
        {
            if (String.IsNullOrEmpty(motivo))
                return MotivoNotaDebito.SinMotivo;
            try
            {
                return (MotivoNotaDebito)Enum.Parse(typeof(MotivoNotaDebito), motivo, true);
            }
            catch (Exception)
            {
                return MotivoNotaDebito.SinMotivo;
                throw;
            }
        }
        private MotivoNotaDebito _motivoDocumento;
        public void AnulaNotaCreditoCompleta(int idDocumentoOrigen)
        {
            //primero Crear Header
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var docOri = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idDocumentoOrigen);
                var itemOri = db.T0401_FACTURA_I.Where(c => c.IDFactura == idDocumentoOrigen).ToList();

                SetDocumentoAsociado(idDocumentoOrigen);
                T300.H3.IdMotivoAsociado = IdFacturaAsociada;

                foreach (var it in itemOri)
                {
                    //Una anulacion de NC con ND se toma como si la cotizacion hubiese sido en pesos y se recalcula el valor USD segun el TC del día de la fecha de emision de ND
                    string itemDescOri = it.DESC_REMITO;
                    string newDescription;
                    if (it.ITEM == "DESCGRAL")
                    {
                        newDescription = "Anulacion #" + itemDescOri + $"# NC {docOri.NumeroDoc}";
                    }
                    else
                    {
                        if (itemDescOri.StartsWith("**") || itemDescOri.StartsWith("##"))
                        {
                            itemDescOri = itemDescOri.Substring(2);
                            newDescription = "*" + itemDescOri;
                        }
                        else
                        {
                            if (itemDescOri.StartsWith("*") || itemDescOri.StartsWith("#"))
                            {
                                itemDescOri = itemDescOri.Substring(1);
                                newDescription = "%" + itemDescOri;
                            }
                            else
                            {
                                newDescription = $"Anula Item NC {docOri.NumeroDoc}";
                            }
                        }
                    }

                    //validacion de longitud de descripcion
                    var descripcionLen = newDescription.Length;
                    if (descripcionLen >= 199)
                    {
                        newDescription = newDescription.Substring(0, 199);
                    }

                    //Nota de debito el signo es siempre positivo
                    decimal cantidadI = it.KGDESPACHADOS_R.Value;
                    if (cantidadI < 1)
                    {
                        cantidadI = cantidadI * -1;
                    }

                    T400.AddItemsMemory(it.ITEM, newDescription, cantidadI, "ARS", it.PRECIOU_FACT_ARS, it.GLV, it.GLI,
                        it.IVA21, it.CostoStd, null, null, null);
                }

                //Luego de Agregar Items - Coloca exacto los importes del documento original
                T400.H4.Descuento = docOri.Descuento;
                T400.H4.DescuentoPorc = docOri.DescuentoPorc;
                T400.H4.TotalFacturaB = docOri.TotalFacturaB;
                T400.H4.TotalImpo = docOri.TotalImpo;
                T400.H4.TotalIVA21 = docOri.TotalIVA21;
                T400.H4.TotalIIBB = docOri.TotalIIBB;
                T400.H4.TotalFacturaN = docOri.TotalFacturaN;
                T400.H4.IIBB_PORC = docOri.IIBB_PORC;
                T400.H4.IIBB_TXT = docOri.IIBB_TXT;
                T400.H4.Tax2Alicuota = docOri.Tax2Alicuota;
                T400.H4.Tax2Descripcion = docOri.Tax2Descripcion;
                T400.H4.Tax2Importe = docOri.Tax2Importe;
                T400.MapH4ImportesToImportes();
            }
        }
        /// <summary>
        /// Gestion de Registro en Tablas 
        /// </summary>
        public void SetIdChequeRechazado(int idCheque)
        {
            T300.UpdateIdAsociadoAltearnativo(idCheque);
        }
        
  
    }
}
