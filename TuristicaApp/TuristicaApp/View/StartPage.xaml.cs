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
using TuristicaApp.ViewModel;
using Xamarin.Forms.StyleSheets;
using System.IO;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            using (var reader = new StringReader("navigationpage { background-color: red; }"))
            {
                this.Resources.Add(StyleSheet.FromReader(reader));
            }
            LoadingImage.IsVisible = false;
        }
        protected override void OnAppearing()
        {
            LoadingImage.IsVisible = false;
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            LoadingImage.IsVisible = false;
            base.OnDisappearing();
        }
        public Random N { get; set; }
        public List<Categoria> ListadoCategorias { get; set; }
        public Task<List<Lugar>> ListadoLugares { get; set; }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            CRUD DB = new CRUD();
            if (DB.LeerActualizacion("Categorias") == null)
            {
                CheckMyConnection Connection = new CheckMyConnection();
                if (Connection.CheckInternetConnection())
                {
                    LoadingImage.IsVisible = true;
                    ClienteWebService client = new ClienteWebService();
                    DateTime hora = new DateTime();
                    N = new Random();
                    var result = await client.Get<List<Categoria>>("https://motelesanmiguel.com/Turistica/Vistas/JsonCategorias.php?" + hora.Second.ToString() + N.Next().ToString() + hora.Second.ToString() + N.Next());
                    if (result != null)
                    {
                        foreach (var i in result.ToList())
                        {
                            Categoria NuevaCategoria = new Categoria
                            {
                                IdCategoria = i.IdCategoria,
                                Nombre = i.Nombre,
                                Descripcion = i.Descripcion,
                                FotoCategoria = i.FotoCategoria
                            };
                            DB.InsertarCategoria(NuevaCategoria);
                        }
                        Actualizacion Actualizado = new Actualizacion
                        {
                            Tabla = "Categorias"
                        };
                        DB.InsertarActualizacion(Actualizado);
                        LoadingImage.IsVisible = false;
                        await Navigation.PushAsync(new StartingTuristica());
                    }
                }
                else
                {
                    await DisplayAlert("Notificacion","Por favor verifica tu conexion a internet","ok");
                }
            }
            else
            {
                LoadingImage.IsVisible = true;
                await Navigation.PushAsync(new StartingTuristica());
            }
        }
        private void ToolbarIcon_Clicked(object sender, EventArgs e)
        {
            CRUD Data = new CRUD();
            Data.LimpiarCategorias();
            Data.LimpiarLugares();
            Data.LimpiarActualizacion();
            Data.LimpiarFotos();
            DisplayAlert("Mensaje","Datoss limpiados","ok");
        }
    }
    public class ClienteWebService
    {
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

}