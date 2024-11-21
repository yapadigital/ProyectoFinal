namespace jcardenasS6.Views;

public partial class vMapa : ContentPage
{
	public vMapa()
	{
		InitializeComponent();
	}

    private void btnBuscarT_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.VTesoro());
    }
}