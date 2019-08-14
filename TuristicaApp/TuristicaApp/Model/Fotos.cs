using System;
using System.Collections.Generic;
using System.Text;
//importamos
using SQLite;
namespace TuristicaApp.Model
{
    [Table(nameof(Fotos))]
    public class Fotos
    {
        [PrimaryKey,AutoIncrement]
        public int IdFoto { get; set; }
        public int IdCategoria { get; set; }
        public int IdLugar { get; set; }
        public string UrlImagen { get; set; }
    }
}
