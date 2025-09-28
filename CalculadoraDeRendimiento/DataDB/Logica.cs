using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.Sqlite; // 👈 este using cambia
using CalculadoraDeRendimiento.Modelo;

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
    }
}
