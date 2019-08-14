using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos carpeta MODEL
using TuristicaApp.Model;
using TuristicaApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPlace : ContentPage
    {
        public Lugar SelectedPlace { get; set; }
        public ViewPlace(Lugar LugarElegido)
        {
            InitializeComponent();
            SelectedPlace = new Lugar();
            SelectedPlace = LugarElegido;            
            CRUD DataBase = new CRUD();
            if(DataBase.LeerLugar(LugarElegido.IdLugar) != null)
            {
                BindingContext = DataBase.LeerLugar(LugarElegido.IdLugar);
            }else{
                _ = new Lugar();
                Lugar Nuevo = DataBase.LeerLugar(LugarElegido.IdLugar);
                BindingContext = Nuevo;
            }

            LoadingImage.IsVisible = false;
        }
        protected override void OnAppearing()
        {
            LoadingImage.IsVisible = false;
            base.OnAppearing();
        }

        public Random N { get; set; }
        public List<Fotos> ListadoFotos { get; set; }
        public Task<List<Fotos>> ListadoFotosTarea { get; set; }
        private async void BtnVerMas_Clicked(object sender, EventArgs e)
        {
            CRUD DB = new CRUD();
            if (DB.LeerActualizacion("Fotos") == null)
            {                
                    CheckMyConnection Connection = new CheckMyConnection();
                    if (Connection.CheckInternetConnection())
                    {
                        LoadingImage.IsVisible = true;
                        ClienteWebService client = new ClienteWebService();
                        DateTime hora = new DateTime();
                        N = new Random();
                        var result = await client.Get<List<Fotos>>("https://motelesanmiguel.com/Turistica/Vistas/JsonFotos.php?" + hora.Second.ToString() + N.Next().ToString() + hora.Second.ToString() + N.Next());
                        if (result != null)
                        {
                            foreach (var i in result.ToList())
                            {
                            Fotos NuevaFoto = new Fotos
                            {
                                IdFoto = i.IdFoto,
                                IdCategoria = i.IdCategoria,
                                IdLugar = i.IdLugar,
                                UrlImagen = i.UrlImagen
                            };
                            if (DB.InsertarFotos(NuevaFoto)==1)
                                {
                                    await DisplayAlert("Notificacion", "Datos insertados correctamente", "ok");
                                }
                                else
                                {
                                    await DisplayAlert("Error", "Datos no fueron registrados", "ok");
                                }
                            }
                        Actualizacion Actualizado = new Actualizacion
                        {
                            Tabla = "Fotos"
                        };
                        DB.InsertarActualizacion(Actualizado);
                            LoadingImage.IsVisible = false;
                        }
                        await Navigation.PushAsync(new Photos(SelectedPlace.IdLugar));
  
                }
                else
                    {
                        await DisplayAlert("Notificacion", "Por favor verifica tu conexion a internet", "ok");
                    }                 
            }
            else
            {
                LoadingImage.IsVisible = true;
                await Navigation.PushAsync(new Photos(SelectedPlace.IdLugar));
            }
        }
    }
}