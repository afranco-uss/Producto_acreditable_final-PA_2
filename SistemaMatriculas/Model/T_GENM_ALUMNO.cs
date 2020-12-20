namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_GENM_ALUMNO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GENM_ALUMNO()
        {
            T_GENM_MATRICULA = new HashSet<T_GENM_MATRICULA>();
            T_GENM_NOTA = new HashSet<T_GENM_NOTA>();
        }

        [Key]
        public int ID_ALUMNO { get; set; }

        [StringLength(7)]
        public string CODIGO { get; set; }

        [StringLength(250)]
        public string SEMESTRE_INGRESO { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public int ID_PERSONA { get; set; }

        public virtual T_GENM_PERSONA T_GENM_PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_MATRICULA> T_GENM_MATRICULA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_NOTA> T_GENM_NOTA { get; set; }

        public List<T_GENM_ALUMNO> ListarAlumnos()
        {
            var alumnos = new List<T_GENM_ALUMNO>();

            try
            {
                using (var context = new MatriculasContext())
                {
                    alumnos = context.T_GENM_ALUMNO.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return alumnos;
        }
    }

 
}
