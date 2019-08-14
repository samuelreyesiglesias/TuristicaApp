using System;
using System.Collections.Generic;
using System.Text;
//Importamos paquete SQLite en librerias.
using SQLite;
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Importamos la libreria que nos permite hacer uso de Rutas. Necesaria para usar la clase Path
using System.IO;
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Importamos carpeta Model
using TuristicaApp.Model;

namespace TuristicaApp.Model
{
    public class CRUD
    {
        public SQLiteConnection MyDb { get; set; }

        //CONSTRUCTOR QUE INICIALIZA LA CONEXION A BASE DE DATOS
        public CRUD()
        {
            string Ruta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "a4.db3");

            MyDb = new SQLiteConnection(Ruta);
            MyDb.CreateTable<Categoria>();
            MyDb.CreateTable<Lugar>();
            MyDb.CreateTable<Fotos>();
            MyDb.CreateTable<Actualizacion>();
        }
        //ESCRIBIR UN METODO PARA INSERTAR DATO
        public int InsertarCategoria(Categoria datos)
        {
            return MyDb.Insert(datos);
        }
        //CRUD CATEGORIA
        public int EliminarCategoria(Categoria datos)
        {
            return MyDb.Delete(datos);
        }
        public int ActualizarCategoria(Categoria datos)
        {
            return MyDb.Update(datos);
        }

        public Categoria LeerCategoria(int IdCategoria)
        {
            return MyDb.Table<Categoria>().Where(n => n.IdCategoria == IdCategoria).FirstOrDefault();
        }
        public List<Categoria> LeerCategorias()
        {
            return MyDb.Table<Categoria>().ToList();
        }


        //CRUD PARA LUGARES
        public int InsertarLugar(Lugar datos)
        {
            return MyDb.Insert(datos);
        }
        public int EliminarLugar(Lugar datos)
        {
            return MyDb.Delete(datos);
        }


        public int LimpiarCategorias()
        {
            return MyDb.DeleteAll<Categoria>();
            //return MyDb.Execute($"DELETE * FROM Categoria");
        }
        public int LimpiarActualizacion()
        {
            return MyDb.DeleteAll<Actualizacion>();
            //return MyDb.Execute($"DELETE * FROM Categoria");
        }

        public int LimpiarFotos()
        {
            return MyDb.DeleteAll<Fotos>();
            //return MyDb.Execute($"DELETE * FROM Categoria");
        }
        public int LimpiarLugares()
        {
            return MyDb.DeleteAll<Lugar>();
            //return MyDb.Table<Categoria>().Delete();
            //return MyDb.Execute($"DELETE * FROM Lugar");
        }
        public int ActualizarLugar(Lugar datos)
        {
            return MyDb.Update(datos);
        }

        public Lugar LeerLugar(int IdLugar)
        {
            return MyDb.Table<Lugar>().Where(n => n.IdLugar == IdLugar).FirstOrDefault();
        }
        public List<Lugar> LeerLugaresPorCategoria(int IdCategoria)
        {
            return MyDb.Table<Lugar>().Where(n => n.IdCategoria == IdCategoria).ToList();
        }
        public List<Lugar> LeerLugares()
        {
            return MyDb.Table<Lugar>().ToList();
        }


        //CRUD ACTUALIZACION

        public int InsertarActualizacion(Actualizacion datos)
        {
            return MyDb.Insert(datos);
        }
        public int EliminarActualizacion(Actualizacion datos)
        {
            return MyDb.Delete(datos);
        }
        public int ActualizarActualiacion(Actualizacion datos)
        {
            return MyDb.Update(datos);
        }

        public Actualizacion LeerActualizacion(string Tabla)
        {
            return MyDb.Table<Actualizacion>().Where(n => n.Tabla == Tabla).FirstOrDefault();
        }
        public List<Actualizacion> LeerActualizaciones()
        {
            return MyDb.Table<Actualizacion>().ToList();
        }



        //CRUD FOTOS

        public int InsertarFotos(Fotos datos)
        {
            return MyDb.Insert(datos);
        }
        public int EliminarFotos(Fotos datos)
        {
            return MyDb.Delete(datos);
        }
        public int ActualizarFotos(Fotos datos)
        {
            return MyDb.Update(datos);
        }

        public List<Fotos> LeerPhotos(int IdLugar)
        {
            return MyDb.Table<Fotos>().Where(n => n.IdLugar == IdLugar).ToList();
        }

        public List<Fotos> LeerFotos()
        {

            try
            {
                return MyDb.Table<Fotos>().ToList();
            }
            catch (Exception erorr)
            {
                System.Diagnostics.Debug.WriteLine("mensaje eror:"+erorr);
                int a = 0;
            }
            List<Fotos> lista =new List<Fotos>();
            return lista;
        }

    }
}
