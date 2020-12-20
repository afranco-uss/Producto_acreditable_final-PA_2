namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_GENM_USUARIO
    {
        [Key]
        public int ID_USUARIO { get; set; }

        public int ID_PERSONA { get; set; }

        public int ID_TIPO_USUARIO { get; set; }

        [StringLength(1)]
        public string FLG_ESTADO { get; set; }

        public int? ID_USUARIO_REG { get; set; }

        public DateTime? FEC_REG { get; set; }

        public int? ID_USUARIO_ACT { get; set; }

        public DateTime? FEC_ACT { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE_USUARIO { get; set; }

        [Required]
        [StringLength(50)]
        public string CONTRASENA { get; set; }

        public virtual T_GENM_PERSONA T_GENM_PERSONA { get; set; }

        public virtual T_MAE_TIPO_USUARIO T_MAE_TIPO_USUARIO { get; set; }

        public ResponseModel AccederUsuario(string nomusuario,string clave)
        {
            var rm = new ResponseModel();
            //clave = HashHelper.MD5(clave);
            try
            {
                using (var context = new MatriculasContext())
                {
                    var usuario = context.T_GENM_USUARIO.Where(x => x.NOMBRE_USUARIO == nomusuario)
                                                      .Where(x => x.CONTRASENA == clave).SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.ID_USUARIO.ToString());
                        rm.SetResponse(true);
                        rm.tipoUsuario = usuario.ID_TIPO_USUARIO.ToString();
                      
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o clave incorrectos");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;

        }
    }
}
