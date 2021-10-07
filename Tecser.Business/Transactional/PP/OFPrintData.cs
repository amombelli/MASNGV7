using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.PP;

namespace Tecser.Business.Transactional.PP
{

    
    public class OFPrintData
    {
        private readonly int _numeroOF;

        public OFPrintData(int numeroOF)
        {
            _numeroOF = numeroOF;
        }
        public List<DsHeaderOF> GetHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T0070_PLANPRODUCCION, DsHeaderOF>());
                var mapper = new Mapper(config);
                var of = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == _numeroOF);
                var r = db.T0032_RECURSOS.SingleOrDefault(c => c.IdRecurso == of.RECURSO);
                var rx = mapper.Map<DsHeaderOF>(of);
                if (r == null)
                {
                    rx.DescripcionRecurso = "No-Data";
                    rx.NombreRecurso = "No-Data";
                }
                else
                {
                    rx.DescripcionRecurso = r.DescRecurso;
                    rx.NombreRecurso = r.NombreRecurso;
                }
                var rtn1 = new List<DsHeaderOF>();
                rtn1.Add(rx);
                return rtn1;
            }
        }
        public List<DsItemOF> GetItems()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new List<DsItemOF>();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T0073_FORMULA_PRINT, DsItemOF>());
                var mapper = new Mapper(config);
                var i0 = db.T0073_FORMULA_PRINT.Where(c => c.OF == _numeroOF).ToList();
                foreach (var i in i0)
                {
                    var m = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == i.Primario);
                    var rx = mapper.Map<DsItemOF>(i);
                    rx.DescOrdenFab = m.DescripcionFormulacion;
                    rx.DescTecnica = m.DescripcionTecnicaLab;
                    rtn.Add(rx);
                }
                return rtn;
            }
        }
        
    }
}
