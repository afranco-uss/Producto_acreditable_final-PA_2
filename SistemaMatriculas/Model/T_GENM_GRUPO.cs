namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_GENM_GRUPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_GENM_GRUPO()
        {
            T_GENM_MATRICULA = new HashSet<T_GENM_MATRICULA>();
        }

        [Key]
        public int ID_GRUPO { get; set; }

        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public int ID_AULA { get; set; }

        public virtual T_GENM_AULA T_GENM_AULA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_MATRICULA> T_GENM_MATRICULA { get; set; }

        public List<T_GENM_GRUPO> ListarGrupo()
        {
            var grupos = new List<T_GENM_GRUPO>();

            try
            {
                using (var context = new MatriculasContext())
                {
                    grupos = context.T_GENM_GRUPO.Where(x => x.FLG_ESTADO =="1").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return grupos;
        }
    }
}
