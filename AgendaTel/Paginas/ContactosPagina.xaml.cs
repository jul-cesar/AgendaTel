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
                contactosView.SelectedItem = null;

                await Navigation.PushAsync(new DetallesContacto(contact));
            }
        }
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrEmpty(text))
        {
            contactosView.ItemsSource = App.Contactos;
        }
        else
        {
            var contactosFiltrados = App.Contactos
                .Where(c => c.Nombre.ToLower().Contains(text))
                .ToList();

            contactosView.ItemsSource = contactosFiltrados;
        }
    }



}