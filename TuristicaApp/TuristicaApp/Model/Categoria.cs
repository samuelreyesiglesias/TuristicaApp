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
    [Table(nameof(Categoria))]
    public class Categoria
    {
        //[PrimaryKey,AutoIncrement]
        [PrimaryKey]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FotoCategoria { get; set; }
    }
}
