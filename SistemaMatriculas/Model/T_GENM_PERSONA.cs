namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_GENM_PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GENM_PERSONA()
        {
            T_GENM_ALUMNO = new HashSet<T_GENM_ALUMNO>();
            T_GENM_USUARIO = new HashSet<T_GENM_USUARIO>();
        }

        [Key]
        public int ID_PERSONA { get; set; }

        [StringLength(250)]
        public string NOMBRES { get; set; }

        [StringLength(250)]
        public string APELLIDO_PATERNO { get; set; }

        [StringLength(250)]
        public string APELLIDO_MATERNO { get; set; }

        [StringLength(250)]
        public string MAIL { get; set; }

        [StringLength(9)]
        public string NRO_TELEFONO { get; set; }

        public DateTime? FECHA_NACIMIENTO { get; set; }

        [StringLength(1)]
        public string SEXO { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        [StringLength(8)]
        public string DNI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_ALUMNO> T_GENM_ALUMNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_USUARIO> T_GENM_USUARIO { get; set; }


        public void GuardarAlumno()
        {
            try
            {
                using (var context = new MatriculasContext())
                {

                    this.ID_USUARIO_REG = 1;
                    this.FLG_ESTADO = "1";
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
