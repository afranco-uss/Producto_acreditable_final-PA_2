namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_MAE_TIPO_USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_MAE_TIPO_USUARIO()
        {
            T_GENM_USUARIO = new HashSet<T_GENM_USUARIO>();
        }

        [Key]
        public int ID_TIPO_USUARIO { get; set; }

        [StringLength(250)]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_GENM_USUARIO> T_GENM_USUARIO { get; set; }
    }
}
