namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class T_GENM_ASIGNATURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GENM_ASIGNATURA()
        {
            T_GENM_NOTA = new HashSet<T_GENM_NOTA>();
        }

        [Key]
        public int ID_ASIGNATURA { get; set; }

        public int ID_TIPO_ASIGNATURA { get; set; }

        public int ID_CICLO_PLAN { get; set; }

        [StringLength(250)]
        public string NOMBRE { get; set; }

        public int? CREDITO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public virtual T_MAE_TIPO_ASIGNATURA T_MAE_TIPO_ASIGNATURA { get; set; }

        public virtual T_MAE_CICLO_PLAN T_MAE_CICLO_PLAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_NOTA> T_GENM_NOTA { get; set; }

        public List<T_GENM_ASIGNATURA> ListarAsignaturas()
        {
            var asignaturas = new List<T_GENM_ASIGNATURA>();

            try
            {
                using (var context = new MatriculasContext())
                {
                    asignaturas = context.T_GENM_ASIGNATURA.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return asignaturas;
        }

        public void Guardar()
        {
            try
            {
                using (var context = new MatriculasContext())
                {

                    this.ID_TIPO_ASIGNATURA = 1;
                    this.ID_CICLO_PLAN = 1;
                    this.ID_USUARIO_REG = 1;
                    context.Entry(this).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception E)
            {

                throw;
            }
        }
    }
}
