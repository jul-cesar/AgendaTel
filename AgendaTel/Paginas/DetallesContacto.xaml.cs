using AgendaTel.Modelos;

namespace AgendaTel.Paginas;

public partial class DetallesContacto : ContentPage
{
    public Contacto Contacto { get; set; }
    public DetallesContacto(Contacto contacto)
    {
        InitializeComponent();

        Contacto = contacto;

        BindingContext = Contacto;
    }

    public async Task MakePhoneCallAsync(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            await DisplayAlert("Error", "No hay un número de teléfono disponible.", "OK");
            return;
        }

        try
        {
            PhoneDialer.Default.Open(phoneNumber);
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "Las llamadas no son soportadas en esta plataforma.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo iniciar la llamada: {ex.Message}", "OK");
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (Contacto != null)
        {
            await MakePhoneCallAsync(Contacto.NumeroTel);
        }
        else
        {
            await DisplayAlert("Error", "No se ha seleccionado ningún contacto.", "OK");
        }
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        try
        {

            if (Contacto != null && !string.IsNullOrWhiteSpace(Contacto.NumeroTel))
            {
                await Sms.ComposeAsync(new SmsMessage
                {
                    Body = "Escribe aquí tu mensaje",
                    Recipients = new List<string> { Contacto.NumeroTel }
                });
            }
            else
            {
                await DisplayAlert("Error", "No se pudo obtener el número de teléfono del contacto.", "OK");
            }
        }
        catch (FeatureNotSupportedException ex)
        {
            await DisplayAlert("Error", $"Enviar mensajes no es soportado en esta plataforma. Detalle del error: {ex.Message}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error al intentar enviar el mensaje. Detalle del error: {ex.Message}", "OK");
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditarContacto(Contacto));
    }

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        var contactoAEliminar = App.Contactos.FirstOrDefault(x => x.Nombre == Contacto.Nombre);

        App.Contactos.Remove(contactoAEliminar);

        await Navigation.PushAsync(new ContactosPagina());

    }
}