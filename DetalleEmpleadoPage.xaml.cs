namespace ProyectoDesarrolloMovil
{
    public partial class DetalleEmpleadoPage : ContentPage
    {
        public Empleado Empleado { get; set; }

        public DetalleEmpleadoPage(Empleado empleado)
        {
            InitializeComponent();
            Empleado = empleado;
            BindingContext = Empleado;
        }

        // Evento para regresar a la pantalla anterior
        private async void OnRegresarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Evento para redirigir a la pantalla de actualización de datos del empleado
        private async void OnActualizarDatosClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ActualizarEmpleadoPage(Empleado));
        }

        // Evento para confirmar la eliminación del empleado
        private async void OnEliminarEmpleadoClicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", "¿Estás seguro de eliminar este empleado?", "Sí", "No");
            if (confirmacion)
            {
                // Aquí se implementaría la lógica para eliminar el empleado
                await DisplayAlert("Empleado eliminado", "El empleado ha sido eliminado correctamente.", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
