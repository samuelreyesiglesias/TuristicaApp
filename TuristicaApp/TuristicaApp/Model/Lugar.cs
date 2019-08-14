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
    [Table(nameof(Lugar))]
    public class Lugar
    {
        [PrimaryKey, AutoIncrement]
        public int IdLugar { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Ofrece { get; set; }
        public string Precios { get; set; }
        public string HorarioAtencion { get; set; }
        public string Ubicacion { get; set; }
        public string FotoPortada { get; set; }
    }
}
