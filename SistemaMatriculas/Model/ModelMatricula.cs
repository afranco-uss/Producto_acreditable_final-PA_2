using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class ModelMatricula
    {
        public List<T_GENM_GRUPO> listaGrupo { get; set; }
        public List<T_GENM_AULA> listaAulas { get; set; }
        public List<T_MAE_SEMESTRE> listaSemestres { get; set; }
    }
}
