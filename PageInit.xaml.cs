namespace PM02P012024;
using SQLite;

public partial class PageInit : ContentPage
{
    Controllers.PersonasController PersonDB;
    public PageInit()
    {
        InitializeComponent();
    }

    public PageInit(Controllers.PersonasController dbpath)
    {
        InitializeComponent();
        PersonDB = dbpath;
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        var person = new Models.Persona
        {
            Nombres = nombres.Text,
            Apellidos = apellidos.Text,
            FechaNac = FechaNac.Date,
            telefono = telefono.Text
        };

        if(await PersonDB.StorePerson(person) > 0)
        {
            await DisplayAlert("AVISO", "Registro ingresado con exito!", "OK");
        }

    }
}