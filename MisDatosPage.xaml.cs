namespace ProyectoDesarrolloMovil
{
    public partial class MisDatosPage : ContentPage
    {
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public string Domicilio { get; set; }
        public int Edad { get; set; }

        public MisDatosPage()
        {
            InitializeComponent();

            // Simulación de datos. Puedes obtenerlos desde un modelo o API.
            NombreCompleto = "Luis B.";
            NombreUsuario = "LuisB123";
            Correo = "luiss04br1@gmail.com";
            Genero = "Masculino";
            Domicilio = "Ciudad, País";
            Edad = 30;

            BindingContext = this; // Asignar el contexto de enlace a la clase actual
        }

        // Evento para el icono de regresar
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); // Regresar a la página anterior
        }

        // Evento para el botón "Actualizar datos"
        private async void OnActualizarClicked(object sender, EventArgs e)
        {
            // Lógica para actualizar datos
            await DisplayAlert("Actualizar", "Funcionalidad de actualización no implementada.", "OK");
        }

        // Evento para el botón "Eliminar cuenta"
        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            // Lógica para eliminar cuenta
            await DisplayAlert("Eliminar", "Funcionalidad de eliminación no implementada.", "OK");
        }
    }
}
