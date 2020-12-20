namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_GENM_NOTA
    {
        [Key]
        public int ID_NOTA { get; set; }

        public int ID_TIPO_EVALUACION { get; set; }

        public int ID_ASIGNATURA { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        public int ID_ALUMNO { get; set; }

        public decimal? NOTA { get; set; }

        public virtual T_GENM_ALUMNO T_GENM_ALUMNO { get; set; }

        public virtual T_GENM_ASIGNATURA T_GENM_ASIGNATURA { get; set; }

        public virtual T_MAE_TIPO_EVALUACION T_MAE_TIPO_EVALUACION { get; set; }
    }
}
