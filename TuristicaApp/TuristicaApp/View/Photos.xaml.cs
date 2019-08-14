using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristicaApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristicaApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Photos : ContentPage
    {
        public Photos(int IdLugar)
        {
            InitializeComponent();
            CRUD db = new CRUD();
            List<Fotos> datos = db.LeerPhotos(IdLugar);
            StackFotos.ItemsSource = datos.ToList();
        }
    }
}