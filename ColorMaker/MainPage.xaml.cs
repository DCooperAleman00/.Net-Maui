
using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	int count = 0;
	String hexValue;


    public MainPage()
	{
		InitializeComponent();
	}

	//nos permite ver cuando los valores han cambiado
    private void Slider_ValueChange(object sender, ValueChangedEventArgs e)
	{
		//obtener el valor de los slider
		var red = sldRed.Value;
        var green = sldGreen.Value;
        var blue = sldBlue.Value;

        //Color.FromRgb nos permite pasar un colorr v a r para generar la combinacion de los colores
        Color color = Color.FromRgb(red, green, blue);

		//establece el color correspondiente a los slider
		SetColor(color);
    }


	private void SetColor(Color color)
	{
		//muestra el cambio de colores el los botones y el backgroud
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
        hexValue = color.ToHex();//nos proporcionará cual es el valor hexadecimal del color
		lblHex.Text = hexValue;

    }

	//generar el color alaeatorio
	private void btnRandom_Clicked(object sender, EventArgs e)
	{

		var random = new Random();

		//rellena el valor, de datos aleatorio
		var color = Color.FromRgb(
			random.Next(0,256),
            random.Next(0, 256),
            random.Next(0, 256));

		//invocamos el metodo pasando el color generado de forma aleatoria
		SetColor(color);

		//indicar el color random a los sliders
		sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
    }

	//metodo para copiar el codigo hexadecimal
    private async void ImagedButton_Clicked(object sender, EventArgs e)
	{
		//
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color copiado",
			CommunityToolkit.Maui.Core.ToastDuration.Short,12);
		await toast.Show();
	}


}

