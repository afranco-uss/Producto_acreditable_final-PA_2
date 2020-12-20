namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_GENM_AULA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GENM_AULA()
        {
            T_GENM_GRUPO = new HashSet<T_GENM_GRUPO>();
        }

        [Key]
        public int ID_AULA { get; set; }

        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public int? CANTIDAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_GRUPO> T_GENM_GRUPO { get; set; }

        public List<T_GENM_AULA> listarAula()
        {
            var aulas = new List<T_GENM_AULA>();

            try
            {
                using (var context = new MatriculasContext())
                {
                     aulas  = context.T_GENM_AULA.Where(x => x.FLG_ESTADO == "1").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return aulas;
        }
    }
}
