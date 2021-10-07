using System.Collections.Generic;

namespace TecserEF.Entity.DataStructure
{
    public class RtnListControlInForm
    {
        public List<RtnElmentControlManaged> ObjetosOK { get; set; }
        public List<RtnElementosSingle> ObjetosNoManejados { get; set; }
        public List<RtnElementosSingle> ObjetosIgnorados { get; set; }
    }
}