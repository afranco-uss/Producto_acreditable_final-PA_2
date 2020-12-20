using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial  class NotaPorAsignatura
    {
        public string CODIGO_MATRICULA { get; set; }
        public string NOMBRES { get; set; }
        public string ASIGNATURAS { get; set; }

        public string EVALUACION { get; set; }

        public decimal NOTA { get; set; }

        public string SEMESTRE { get; set; }
        public string CICLO { get; set; }
    }
}
