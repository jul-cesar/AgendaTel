using System.Collections.ObjectModel;
using AgendaTel.Modelos;
using AgendaTel.Paginas;

namespace AgendaTel
{
    public partial class App : Application
    {

        public static ObservableCollection<Contacto> Contactos { get; set; } = new ObservableCollection<Contacto>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactosPagina());

        }
    }
}
