using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//LIBRERIA PARA Utilizar COMMANDS
using System.ComponentModel;
//LIBRERIA PARA USAR HttpClient CLASS
using System.Net;
using System.Net.Http;
//LIBRERIAS PARA PARSEAR JSON
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//IMPORTAMOS LA CARPETA MODEL
using TuristicaApp.Model;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCategory : ContentPage
    {
        public ViewCategory()
        {
            InitializeComponent();
        }
        public ViewCategory(Categoria DataOfCategory)
        {
            InitializeComponent();
            BindingContext = DataOfCategory;
            Button NewButton = new Button
            {
                Text = "Ver lugares de " + DataOfCategory.Nombre,
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromHex("#000066")
            };
            NewButton.Clicked += async (sender, args) =>
            {
                Actualizar(DataOfCategory.IdCategoria);
            };
            Layout4Btn.Children.Add(NewButton);
        }
        public Random n { get; set; }
        public Task<List<Lugar>> ListadoLugares { get; set; }
        private async void Actualizar(int IdCategoria)
        {
            CRUD DB = new CRUD();
            if (DB.LeerActualizacion("Lugares") == null) { 
            LoadingImage.IsVisible = true;
            ClienteWebService client = new ClienteWebService();
            DateTime hora = new DateTime();
            n = new Random();
            var result = await client.Get<List<Lugar>>("https://motelesanmiguel.com/Turistica/Vistas/JsonLugares.php?" + hora.Second.ToString() + n.Next().ToString() + hora.Second.ToString() + n.Next());
                if (result != null)
                {
                    foreach (var i in result.ToList())
                    {
                        Lugar NuevoLugar = new Lugar();
                        NuevoLugar.IdCategoria = i.IdCategoria;
                        NuevoLugar.Nombre = i.Nombre;
                        NuevoLugar.Descripcion = i.Descripcion;
                        NuevoLugar.Ofrece = i.Ofrece;
                        NuevoLugar.Precios = i.Precios;
                        NuevoLugar.HorarioAtencion = i.HorarioAtencion;
                        NuevoLugar.Ubicacion = i.Ubicacion;
                        NuevoLugar.FotoPortada = i.FotoPortada;
                        DB.InsertarLugar(NuevoLugar);
                    }
                    Actualizacion Actualizado = new Actualizacion();
                    Actualizado.Tabla = "Lugares";
                    DB.InsertarActualizacion(Actualizado);
                    await Navigation.PushAsync(new SeePlaces(IdCategoria));
                    LoadingImage.IsVisible = false;
                }
            }
            else
            {
                await Navigation.PushAsync(new SeePlaces(IdCategoria));
            }

        }

    }
}