using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    /// <summary>
    /// Manejo de bloqueo-desbloqueo de documentos
    /// </summary>
    public class DocumentBlockManager
    {
        /// <summary>
        /// Desde aca manejar que documentos agregan el bloqueo
        /// </summary>
        public enum TipoDocBlk
        {
            SalesOrder,
            Remito,
            Entrega
        }
        public enum ReturnDesbloqueo
        {
            DesbloqueadoOk,
            ErrorDocumento,
            YaDesbloqueado
        }
        public static bool IsDocumentoBloqueado(TipoDocBlk tipoDocBloqueo, int idDoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string tdoc;
                switch (tipoDocBloqueo)
                {
                    case TipoDocBlk.SalesOrder:
                        tdoc = "OV";
                        break;
                    case TipoDocBlk.Remito:
                        tdoc = "RE";
                        break;
                    case TipoDocBlk.Entrega:
                        tdoc = "";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipoDocBloqueo), tipoDocBloqueo, null);
                }
                var data = db.T0170BloqueoDocumentos.SingleOrDefault(c =>
                    c.TdocBloqueo == tdoc && c.IdDocBloqueo == idDoc);

                if (data == null)
                    return false;
                return data.BloqueoActivo;

            }
        }
        public ReturnDesbloqueo AutorizaDocumento(int idBloqueo, string comentarioDesbloqueo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0170BloqueoDocumentos.SingleOrDefault(c => c.IdBloqueo == idBloqueo);
                if (data == null)
                    return ReturnDesbloqueo.ErrorDocumento;

                data.BloqueoActivo = false;
                data.ComentarioDesbloqueo = comentarioDesbloqueo;
                data.FechaDesbloqueo = DateTime.Now;
                data.UsuarioDesbloqueo = GlobalApp.AppUsername;
                data.LogUserComputer = Environment.MachineName; //sobreescribe el nombre de equipo al desbloquear
                var rx = db.SaveChanges();
                return rx == 0 ? ReturnDesbloqueo.YaDesbloqueado : ReturnDesbloqueo.DesbloqueadoOk;
            }
        }
        public int AgregaDocumentoBlock(TipoDocBlk tipoDocBloqueo, int idDoc, string motivoInternoBloqueo, string comentarioAdicionalUser)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idblk = 1;
                string numeroDoc;
                DateTime fechaDoc;
                string tdoc = "";
                if (db.T0170BloqueoDocumentos.Any())
                    idblk = db.T0170BloqueoDocumentos.Max(c => c.IdBloqueo) + 1;

                switch (tipoDocBloqueo)
                {
                    case TipoDocBlk.SalesOrder:
                        var soD = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idDoc);
                        numeroDoc = soD.IDOV.ToString();
                        fechaDoc = soD.FECHA_OV.Value;
                        tdoc = "OV";
                        break;
                    case TipoDocBlk.Remito:
                        var reD = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idDoc);
                        numeroDoc = reD.NUMREMITO;
                        fechaDoc = reD.FECHA;
                        tdoc = "RE";
                        break;
                    case TipoDocBlk.Entrega:
                        numeroDoc = "";
                        fechaDoc = DateTime.Today;
                        tdoc = "";
                        throw new DataException("Tipo de Documento no manejado por la aplicacion");
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipoDocBloqueo), tipoDocBloqueo, null);
                }

                var stx = new T0170BloqueoDocumentos()
                {
                    IdDocBloqueo = idDoc,
                    BloqueoActivo = true,
                    FechaBloqueo = DateTime.Now,
                    MotivoBloqueo = motivoInternoBloqueo,
                    ComentarioAdicionalBloqueo = comentarioAdicionalUser,
                    NumeroDocBloqueo = numeroDoc,
                    ComentarioDesbloqueo = null,
                    FechaDesbloqueo = null,
                    UsuarioBloqueo = GlobalApp.AppUsername,
                    UsuarioDesbloqueo = null,
                    IdBloqueo = idblk,
                    TdocBloqueo = tdoc,
                    LogUserComputer = Environment.MachineName,
                    LogDate = DateTime.Now,
                };
                db.T0170BloqueoDocumentos.Add(stx);
                if (db.SaveChanges() == 1)
                    return idblk;
                return -1;
            }
        }
        public List<T0170BloqueoDocumentos> GetListdocumentos(bool onlybloqueado, int docAge = 45)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fechaMin = DateTime.Today.AddDays(docAge * -1);
                var data = db.T0170BloqueoDocumentos.Where(c => c.FechaBloqueo >= fechaMin).ToList();
                if (onlybloqueado)
                    return data.Where(c => c.BloqueoActivo).ToList();
                return data.ToList();
            }
        }
    }
}
