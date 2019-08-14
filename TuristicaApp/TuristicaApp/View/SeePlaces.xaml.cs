using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//importamos carpeta model
using TuristicaApp.Model;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeePlaces : ContentPage
    {
        public SeePlaces(int IdCategoria)
        {
            InitializeComponent();
            CRUD DB = new CRUD();
            DisplayAlert("ok", "ok" + IdCategoria, "ok");
            if (DB.LeerCategoria(IdCategoria) != null){
                BindingContext = DB.LeerCategoria(IdCategoria);
            }
            if (DB.LeerLugaresPorCategoria(IdCategoria) != null){
                ListadoLugares.ItemsSource = DB.LeerLugaresPorCategoria(IdCategoria);
            }
            else
            {
                ListadoLugares.ItemsSource = DB.LeerLugares();
            }
        }
        private void ListadoLugares_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Lugar LugarElegido = new Lugar();
            LugarElegido = (Lugar)e.SelectedItem;
            Navigation.PushAsync(new ViewPlace(LugarElegido));
        }
    }
}