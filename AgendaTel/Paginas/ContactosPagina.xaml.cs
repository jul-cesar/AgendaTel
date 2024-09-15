using AgendaTel.Modelos;

namespace AgendaTel.Paginas;

public partial class ContactosPagina : ContentPage
{
    public ContactosPagina()
    {
        InitializeComponent();
        contactosView.ItemsSource = App.Contactos;
    }

    private async void addContactButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarContacto());
    }

    private async void contactosView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var contact = e.CurrentSelection.FirstOrDefault() as Contacto;
            if (contact != null)
            {
                // Desactiva la selección si no quieres que el contacto permanezca resaltado
                contactosView.SelectedItem = null;

                // Navega a la página de detalles del contacto seleccionado
                await Navigation.PushAsync(new DetallesContacto(contact));
            }
        }
    }
}