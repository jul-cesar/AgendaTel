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

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        try
        {
            // Abre la cámara para capturar una foto.
            var result = await MediaPicker.Default.CapturePhotoAsync();
            if (result != null)
            {
                // Define la ruta donde se guardará la imagen capturada.
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

                // Abre el stream de la imagen capturada y guarda la imagen en la ruta especificada.
                using (var stream = await result.OpenReadAsync())
                using (var newFile = File.OpenWrite(localFilePath))
                {
                    await stream.CopyToAsync(newFile);
                }

                // Asigna la ruta de la imagen al campo 'Image' del objeto 'Contacto'.
                Contacto.Image = localFilePath;

                // Actualiza la imagen en la interfaz de usuario con la imagen recién capturada.
                ProfileImage.Source = ImageSource.FromStream(() => new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            }
        }
        catch (Exception ex)
        {
            // Muestra un mensaje de error en la consola si ocurre algún problema durante la captura de la foto.
            Console.WriteLine($"Error al capturar la imagen: {ex}");
        }
    }


    private async void ImageButton_Clicked_3(object sender, EventArgs e)
    {
        try
        {
            // Abre la galería para seleccionar una foto existente.
            var result = await MediaPicker.PickPhotoAsync();
            if (result != null)
            {
                // Define la ruta donde se guardará la imagen seleccionada.
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);

                // Abre el stream de la imagen seleccionada y guarda la imagen en la ruta especificada.
                using (var stream = await result.OpenReadAsync())
                using (var newFile = File.OpenWrite(localFilePath))
                {
                    await stream.CopyToAsync(newFile);
                }

                // Asigna la ruta de la imagen al campo 'Image' del objeto 'Contacto'.
                Contacto.Image = localFilePath;

                // Actualiza la imagen en la interfaz de usuario con la imagen seleccionada.
                ProfileImage.Source = ImageSource.FromStream(() => new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            }
        }
        catch (Exception ex)
        {
            // Muestra un mensaje de error en la consola si ocurre algún problema durante la selección de la foto.
            Console.WriteLine($"Error al seleccionar la imagen: {ex}");
        }
    }


}