using CalculadoraDeRendimiento.Modelo;
using Microsoft.Data.Sqlite; // 👈 este using cambia
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CalculadoraDeRendimiento
{
    public class Logica
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static Logica _instancia = null;

        public static Logica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Logica();
                }
                return _instancia;
            }
        }

        public List<Abundamiento> Listar()
        {
            List<Abundamiento> oLista = new List<Abundamiento>();

            using (var conexion = new SqliteConnection(cadena)) // 👈 cambia a SqliteConnection
            {
                conexion.Open();
                string query = "SELECT * FROM CapacidadMaquinas";

                using (var cmd = new SqliteCommand(query, conexion)) // 👈 cambia a SqliteCommand
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Abundamiento()
                        {
                            id = dr.GetInt32(dr.GetOrdinal("id")),
                            modelo = dr.GetString(dr.GetOrdinal("modelo")),
                            capacidad_colmada = dr.GetDouble(dr.GetOrdinal("capacidad_colmada")),
                            capacidad_ras = dr.GetDouble(dr.GetOrdinal("capacidad_ras")),
                            espesor_carga_m = dr.GetDouble(dr.GetOrdinal("espesor_carga_m")),
                            espesor_descarga_m = dr.GetDouble(dr.GetOrdinal("espesor_descarga_m")),
                            ancho_m = dr.GetDouble(dr.GetOrdinal("ancho_m"))
                        });
                    }
                }
            }

            return oLista;
        }


        public List<string> ListarModelosBulldozer()
        {
            List<string> listaModelos = new List<string>();

            using (var conexion = new SqliteConnection(cadena))
            {
                conexion.Open();

                // Usamos DISTINCT para que no traiga modelos repetidos
                // si un modelo tiene varios tipos de hoja.
                string query = "SELECT DISTINCT modelo FROM HojasMaquina_Buldozer";

                using (var cmd = new SqliteCommand(query, conexion))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Agregamos el nombre del modelo (que es un string) a la lista
                        listaModelos.Add(dr["modelo"].ToString());
                    }
                }
            }
            return listaModelos;
        }




        public List<string> ListarTiposDeHojaPorModelo(string modelo)
        {
            List<string> listaTipos = new List<string>();

            using (var conexion = new SqliteConnection(cadena))
            {
                conexion.Open();

                // La consulta ahora filtra por el modelo específico.
                string query = "SELECT tipo_hoja FROM HojasMaquina_Buldozer WHERE modelo = @modelo";

                using (var cmd = new SqliteCommand(query, conexion))
                {
                    // ¡Importante! Usamos parámetros para evitar inyección SQL.
                    // Esto es una práctica de seguridad fundamental.
                    cmd.Parameters.AddWithValue("@modelo", modelo);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaTipos.Add(dr["tipo_hoja"].ToString());
                        }
                    }
                }
            }
            return listaTipos;
        }



        public List<string> ListarMateriales()
        {
            List<string> listaMateriales = new List<string>();

            using (var conexion = new SqliteConnection(cadena))
            {
                conexion.Open();

                // Usamos DISTINCT por si acaso hay algún material duplicado.
                string query = "SELECT DISTINCT suelo FROM TablaDe_Abundamiento_Y_Enjuntamiento";

                using (var cmd = new SqliteCommand(query, conexion))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Agregamos el nombre del suelo (material) a la lista.
                        listaMateriales.Add(dr["suelo"].ToString());
                    }
                }
            }
            return listaMateriales;
        }








        // Dentro de tu clase Logica.cs, añade este nuevo método:

        public Material ObtenerPropiedadesMaterial(string nombreSuelo)
        {
            Material materialEncontrado = null; // Empezamos con null

            using (var conexion = new SqliteConnection(cadena))
            {
                conexion.Open();

                // Seleccionamos todas las columnas donde el suelo coincida
                string query = "SELECT * FROM TablaDe_Abundamiento_Y_Enjuntamiento WHERE suelo = @suelo LIMIT 1";

                using (var cmd = new SqliteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@suelo", nombreSuelo);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // Si encontramos el material
                        {
                            materialEncontrado = new Material()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                suelo = dr["suelo"].ToString(),
                                abundamiento_a = Convert.ToDouble(dr["abundamiento_a"]),
                                abundamiento_b = Convert.ToDouble(dr["abundamiento_b"]),
                                enjuntamiento_a = Convert.ToDouble(dr["enjuntamiento_a"]),
                                enjuntamiento_b = Convert.ToDouble(dr["enjuntamiento_b"])
                            };
                        }
                    }
                }
            }
            return materialEncontrado; // Devolvemos el objeto completo o null si no se encontró
        }

        public HojaBulldozer ObtenerDatosHoja(string modelo, string tipoHoja)
        {
            HojaBulldozer hoja = null;
            using (var conexion = new SqliteConnection(cadena))
            {
                conexion.Open();
                // 1. Añadimos 'modelo' a la consulta SELECT
                string query = "SELECT modelo, tipo_hoja, longitud_m, alto_m FROM HojasMaquina_Buldozer WHERE modelo = @modelo AND tipo_hoja = @tipoHoja LIMIT 1";

                using (var cmd = new SqliteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@tipoHoja", tipoHoja);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hoja = new HojaBulldozer()
                            {
                                // 2. Asignamos el valor a la nueva propiedad
                                modelo = dr["modelo"].ToString(),
                                tipo_hoja = dr["tipo_hoja"].ToString(),
                                longitud_m = Convert.ToDouble(dr["longitud_m"]),
                                alto_m = Convert.ToDouble(dr["alto_m"])
                            };
                        }
                    }
                }
            }
            return hoja;
        }


    }
}
