using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//LIBRERIA PARA Utilizar COMMANDS
using System.ComponentModel;
//IMPORTAMOS LA CARPETA MODEL
using TuristicaApp.Model;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartingTuristica : ContentPage
    {
        public StartingTuristica()
        {
            InitializeComponent();
            CRUD DB = new CRUD();
            ListadoCategorias.ItemsSource=DB.LeerCategorias();
        }

        private void ListadoCategorias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categoria CategoriaElegida = new Categoria();
            CategoriaElegida = (Categoria)e.SelectedItem;
            Navigation.PushAsync(new ViewCategory(CategoriaElegida));
        }

        
    }
}