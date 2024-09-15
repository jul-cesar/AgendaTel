using System.ComponentModel;
using AgendaTel.Modelos;

namespace AgendaTel.Paginas;

public partial class EditarContacto : ContentPage
{

    public Contacto Contacto { get; set; }
    public EditarContacto(Contacto contacto)
    {
        InitializeComponent();
        Contacto = contacto;
        BindingContext = Contacto;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var contactoAEditar = App.Contactos.FirstOrDefault(x => x.Nombre == Contacto.Nombre);

        if (contactoAEditar != null)
        {
            contactoAEditar.Nombre = nombreEntry.Text;
            contactoAEditar.Email = emailEntry.Text;
            contactoAEditar.Ocupacion = ocupacionEntry.Text;
            contactoAEditar.NumeroTel = numeroEntry.Text;
            await DisplayAlert("Éxito", "Contacto actualizado correctamente", "OK");
            await Navigation.PushAsync(new ContactosPagina());
        }
        else
        {
            await DisplayAlert("Error", "No se pudo encontrar el contacto para editar", "OK");
        }
    }
}