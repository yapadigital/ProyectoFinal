namespace jcardenasS6.Views;

public partial class VTesoro : ContentPage
{
	public VTesoro()
	{
		InitializeComponent();
	}

    private void btnEncontrarT_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vResena());
    }
}