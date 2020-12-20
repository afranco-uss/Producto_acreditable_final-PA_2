using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Conexion
    {
        private SqlConnection xconexion = new SqlConnection("Server=192.168.90.8;DataBase=BD_MATRICULA;Integrated Security=true");
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();



        public SqlConnection conectar()
        {
            builder.DataSource = "192.168.90.8";
            builder.InitialCatalog = "BD_MATRICULA";
            builder.UserID = "sa";
            builder.Password = "Redes--";
            builder.ApplicationName = "MyApp";
            Console.WriteLine(builder.ConnectionString);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Conexión válida");
                return connection;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }

           
        }
        /*    public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new TestContext())
                {
                    grid.Inicializar();

                    var query = ctx.Alumno.Where(x => x.id > 0);

                    // Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.id)
                                                             : query.OrderBy(x => x.id);
                    }

                    if (grid.columna == "Nombre")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Nombre)
                                                             : query.OrderBy(x => x.Nombre);
                    }

                    if (grid.columna == "Sexo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Sexo)
                                                             : query.OrderBy(x => x.Sexo);
                    }

                    if (grid.columna == "FechaNacimiento")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.FechaNacimiento)
                                                             : query.OrderBy(x => x.FechaNacimiento);
                    }

                    var alumnos = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in alumnos
                        select new
                        {
                            a.id,
                            a.Nombre,
                            a.Sexo,
                            a.FechaNacimiento
                        },
                        total
                    );
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }*/

        public AnexGRIDResponde listarOrdenMerito(AnexGRID grid, int idAsig, int idGrupo, int idAula, int idSemestre)
        {
            grid.Inicializar();
            SqlDataReader leer;
            List<OrdenMeritoResponse> listNotas = new List<OrdenMeritoResponse>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conectar();
            comando.CommandText = "PRD_LISTAR_ORDEN_MERITO";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IN_ID_ASIGNATURA", idAsig);
            comando.Parameters.AddWithValue("@IN_ID_GRUPO", idGrupo);
            comando.Parameters.AddWithValue("@IN_ID_AULA", idAula);
            comando.Parameters.AddWithValue("@IN_ID_SEMESTRE", idSemestre);

            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                OrdenMeritoResponse ord = new OrdenMeritoResponse();
                ord.NOMBRES = leer.GetString(1);
                ord.TIPO_EVAL = leer.GetString(2);
                ord.NOTA = leer.GetDecimal(3);
                ord.NOTA_TOTAL = leer.GetDecimal(4);
                listNotas.Add(ord);
            }

            var notasList = listNotas.Skip(grid.pagina)
                                  .Take(grid.limite)
                                  .ToList();

            var total = listNotas.Count();

            grid.SetData(
             from a in notasList
             select new
             {
                 a.NOMBRES,
                 a.TIPO_EVAL,
                 a.NOTA,
                 a.NOTA_TOTAL
             },
             total
         );
            return grid.responde();
        }

        public AnexGRIDResponde ListarNotas(AnexGRID grid, int idAlumno, int idSemestre)
        {
            grid.Inicializar();
            SqlDataReader leer;
            List<NotaPorAsignatura> listNotas = new List<NotaPorAsignatura>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conectar();
            comando.CommandText = "PRD_LISTAR_ALUMNO_MATRICULA";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IN_NOMBRE_COMPLETO", idAlumno);
            comando.Parameters.AddWithValue("@IN_ID_SEMESTRE", idSemestre);

            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                NotaPorAsignatura notas = new NotaPorAsignatura();
                notas.CODIGO_MATRICULA = leer.GetString(0);
                notas.NOMBRES = leer.GetString(1);
                notas.ASIGNATURAS= leer.GetString(2);
                notas.EVALUACION= leer.GetString(3);
                notas.NOTA= leer.GetDecimal(4);
                notas.SEMESTRE= leer.GetString(5);
                notas.CICLO= leer.GetString(6);
                listNotas.Add(notas);
            }

            var notasList = listNotas.Skip(grid.pagina)
                                    .Take(grid.limite)
                                    .ToList();

            var total = listNotas.Count();

            grid.SetData(
              from a in notasList
              select new
              {
                  a.CODIGO_MATRICULA,
                  a.NOMBRES,
                  a.ASIGNATURAS,
                  a.EVALUACION,
                  a.NOTA,
                  a.SEMESTRE,
                  a.CICLO
              },
              total
          );

            return grid.responde();

        }
        public AnexGRIDResponde Listar(AnexGRID grid,int idGrupo, int idAula, int idSemestre)
        {
            grid.Inicializar();
            SqlDataReader leer;
            List<AlumnosNota> alumnosNotas = new List<AlumnosNota>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conectar();
            comando.CommandText = "PRD_LISTAR_ALUMNO_AULA";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IN_ID_GRUPO", idGrupo);
            comando.Parameters.AddWithValue("@IN_ID_AULA", idAula);
            comando.Parameters.AddWithValue("@IN_ID_SEMESTRE", idSemestre);

            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                AlumnosNota al = new AlumnosNota();
                al.ID_ALUMNO = leer.GetInt32(0);
                al.CODIGO = leer.GetString(1);
                al.NOMBRES = leer.GetString(2);
                al.APELLIDO_PATERNO = leer.GetString(3);
                al.APELLIDO_MATERNO = leer.GetString(4);
                al.MAIL = leer.GetString(5);
                al.NRO_TELEFONO = leer.GetString(6);
                al.FECHA_NACIMIENTO = leer.GetDateTime(7);
                al.SEXO = leer.GetString(8);
                alumnosNotas.Add(al);
            }

            var alumnos = alumnosNotas.Skip(grid.pagina)
                                      .Take(grid.limite)
                                      .ToList();

            var total = alumnosNotas.Count();

            grid.SetData(
                from a in alumnos
                select new
                {
                    a.ID_ALUMNO,
                    a.NOMBRES,
                    a.SEXO,
                    a.FECHA_NACIMIENTO
                },
                total
            );
            return grid.responde();
        }

        #region ListarAlumnos
        public List<AlumnosNota> listarAlumnosMatriculadosxAula(int idGrupo, int idAula, int idSemestre)
        {
            //
            SqlDataReader leer;
            //DataTable tabla = new DataTable();
            List<AlumnosNota> alumnosNotas = new List<AlumnosNota>();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conectar();
            comando.CommandText = "PRD_LISTAR_ALUMNO_AULA";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IN_ID_GRUPO", idGrupo);
            comando.Parameters.AddWithValue("@IN_ID_AULA", idAula);
            comando.Parameters.AddWithValue("@IN_ID_SEMESTRE", idSemestre);

            leer = comando.ExecuteReader();
            while (leer.Read())
            {
                AlumnosNota al = new AlumnosNota();
                al.ID_ALUMNO = leer.GetInt32(0);
                al.CODIGO = leer.GetString(1);
                al.NOMBRES = leer.GetString(2);
                al.APELLIDO_PATERNO = leer.GetString(3);
                al.APELLIDO_MATERNO = leer.GetString(4);
                al.MAIL = leer.GetString(5);
                al.NRO_TELEFONO = leer.GetString(6);
                al.FECHA_NACIMIENTO = leer.GetDateTime(7);
                al.SEXO = leer.GetString(8);
                alumnosNotas.Add(al);
            }
            
            //tabla.Load(leer);

            // comando.Connection = this.conectar();
            return alumnosNotas;
        }
        #endregion
    }
}
