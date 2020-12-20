namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_MAE_SEMESTRE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_MAE_SEMESTRE()
        {
            T_GENM_MATRICULA = new HashSet<T_GENM_MATRICULA>();
        }

        [Key]
        public int ID_SEMESTRE { get; set; }

        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_MATRICULA> T_GENM_MATRICULA { get; set; }

        public List<T_MAE_SEMESTRE> listarSemestre()
        {
            var semestre = new List<T_MAE_SEMESTRE>();

            try
            {
                using (var context = new MatriculasContext())
                {
                    semestre = context.T_MAE_SEMESTRE.Where(x => x.FLG_ESTADO == "1").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return semestre;

        }
    }
}
