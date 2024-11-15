using jcardenasS6.Models;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;


namespace jcardenasS6.Views;

public partial class vActualizarEliminar : ContentPage
{

    private Estudiante _estudiante;
    public vActualizarEliminar(Estudiante datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
        _estudiante = datos;

    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        WebClient client = new WebClient();
        var parametros = new System.Collections.Specialized.NameValueCollection();
        parametros.Add("nombre", txtNombre.Text);
        parametros.Add("apellido", txtApellido.Text);
        parametros.Add("edad", txtEdad.Text);
        string urlput = "http://localhost/uisraelws/estudiante.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text;
        client.UploadValues(urlput, "PUT", parametros);
        await Navigation.PushAsync(new vEstudiante());
        await DisplayAlert("Exito", "Registo actualizado!", "Aceptar");

    }


    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Eliminar", "¿Desea eliminar el registro?", "Eliminar", "Cancelar");
        if (result)
        {
            try
            {
                WebClient client = new WebClient();
                string urldelete = "http://localhost/uisraelws/estudiante.php?codigo=" + txtCodigo.Text;

               client.UploadValues(urldelete, "DELETE", new System.Collections.Specialized.NameValueCollection());

                await DisplayAlert("Éxito", "Registo eliminado", "Cerrar");

           await Navigation.PushAsync(new vEstudiante());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo eliminar el registro: " + ex.Message, "Cerrar");
            }
            await DisplayAlert("Eliminar", "Registro eliminado correctamente", "Cerrar");
        }
    }
}