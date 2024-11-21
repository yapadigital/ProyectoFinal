using System.Net;

namespace jcardenasS6.Views;

public partial class vResena : ContentPage
{
	public vResena()
	{
		InitializeComponent();
	}

    private void btnGuardarR_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();


            var parametros = new System.Collections.Specialized.NameValueCollection();

            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido",txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://localhost/uisraelws/estudiante.php", "POST", parametros);
            Navigation.PushAsync(new vEstudiante ());

        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "CERRAR");

        }
    }
}