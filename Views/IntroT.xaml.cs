namespace jcardenasS6.Views;

public partial class IntroT : ContentPage
{
	public IntroT()
	{
		InitializeComponent();
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vMapa());
    }
}