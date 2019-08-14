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
    [Table(nameof(Actualizacion))]
    public class Actualizacion
    {
        [PrimaryKey,AutoIncrement]
        public int IdActualizacion { get; set; }
        public string Tabla { get; set; }
    }
}
