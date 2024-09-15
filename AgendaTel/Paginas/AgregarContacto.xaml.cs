using AgendaTel.Modelos;
using The49.Maui.BottomSheet;

namespace AgendaTel.Paginas;

public partial class AgregarContacto : ContentPage
{
    public AgregarContacto()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)

    {
        var nuevoContacto = new Contacto
        {
            Direccion = direccionEntry.Text,
            Email = correoEntry.Text,
            Image = "",
            Nombre = nombreEntry.Text,
            NumeroTel = telefonoEntry.Text,
            Ocupacion = ocupacionEntry.Text,
        };
        App.Contactos.Add(nuevoContacto);

        await Navigation.PushAsync(new ContactosPagina());
    }
}