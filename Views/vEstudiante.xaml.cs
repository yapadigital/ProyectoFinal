using jcardenasS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jcardenasS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://localhost/uisraelws/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;





	public vEstudiante()
	{
		InitializeComponent();
		mostrar();

	}

	public async void mostrar()
	{
        var content = await cliente.GetStringAsync(Url);
        List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud= new ObservableCollection<Estudiante>(mostrarEst);
       	lvEstudiantes.ItemsSource = estud;

    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
	Navigation.PushAsync(new vAgregar());
		

    }

    private void lvEstudiantes_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
    {
		var objES =(Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(objES));	

    }
}