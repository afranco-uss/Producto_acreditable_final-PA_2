using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class AlumnosNota
    {
        public int ID_ALUMNO { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDO_PATERNO { get; set; }
       public string APELLIDO_MATERNO {get;set;}
       public string MAIL{get;set;}
       public string NRO_TELEFONO {get;set;}
       public DateTime FECHA_NACIMIENTO {get;set;}
       public string SEXO {get;set;}
    
    }
}
