namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_GENM_MATRICULA
    {
        [Key]
        public int ID_MATRICULA { get; set; }

        public int ID_ALUMNO { get; set; }

        public int ID_GRUPO { get; set; }

        public int ID_SEMESTRE { get; set; }

        [StringLength(7)]
        public string CODIGO_MATRICULA { get; set; }

        public DateTime? FECHA_MATRICULA { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public virtual T_GENM_ALUMNO T_GENM_ALUMNO { get; set; }

        public virtual T_GENM_GRUPO T_GENM_GRUPO { get; set; }

        public virtual T_MAE_SEMESTRE T_MAE_SEMESTRE { get; set; }
    }
}
