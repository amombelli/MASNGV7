using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class FormsInProject
    {
        public class FormStructureReturn
        {
            public string Tipo { get; set; }
            public string FullName { get; set; }
            public string Namespace { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// Retorna una lista con todos los formularios del assembly
        /// </summary>
        public List<FormStructureReturn> GetAllFormsInProject(string assemblyName = "MasNg")
        {
            var rtnList = new List<FormStructureReturn>();
            var listOfAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(c => c.FullName.ToUpper().StartsWith(assemblyName.ToUpper()))
                .ToList();
            foreach (var asx in listOfAssemblies)
            {
                var formList = asx.GetTypes().Where(c => (typeof(Form).IsAssignableFrom(c))).ToList();
                foreach (var form in formList)
                {
                    var item = new FormStructureReturn
                    {
                        Name = form.Name,
                        FullName = form.FullName,
                        Namespace = form.Namespace,
                        Tipo = form.BaseType.Name
                    };
                    rtnList.Add(item);
                }
            }
            return rtnList.ToList();
        }

    }
}
