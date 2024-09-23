using AgendaTel.Modelos;

namespace AgendaTel.Paginas;

public partial class AgregarContacto : ContentPage
{
    public AgregarContacto()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)

    {
        if (String.IsNullOrEmpty(telefonoEntry.Text))
        {
            await DisplayAlert("Numero requerido", "Por favor ingresa un nro de telefono", "Ok");
        }
        else
        {
            var nuevoContacto = new Contacto
            {
                Direccion = direccionEntry.Text,
                Email = correoEntry.Text,
                Image = "https://th.bing.com/th/id/R.8e2c571ff125b3531705198a15d3103c?rik=gzhbzBpXBa%2bxMA&riu=http%3a%2f%2fpluspng.com%2fimg-png%2fuser-png-icon-big-image-png-2240.png&ehk=VeWsrun%2fvDy5QDv2Z6Xm8XnIMXyeaz2fhR3AgxlvxAc%3d&risl=&pid=ImgRaw&r=0",
                Nombre = nombreEntry.Text,
                NumeroTel = telefonoEntry.Text,
                Ocupacion = ocupacionEntry.Text,
            };
            App.Contactos.Add(nuevoContacto);

            await Navigation.PushAsync(new ContactosPagina());
        }
    }

}