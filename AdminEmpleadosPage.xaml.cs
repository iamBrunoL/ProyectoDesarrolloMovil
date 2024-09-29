using System.Collections.ObjectModel;

namespace ProyectoDesarrolloMovil
{
    public partial class AdminEmpleadosPage : ContentPage
    {
        public ObservableCollection<Empleado> Empleados { get; set; }

        public AdminEmpleadosPage()
        {
            InitializeComponent();

            Empleados = new ObservableCollection<Empleado>
            {
                new Empleado { IdEmpleado = 1, NombreEmpleado = "Juan Pérez", TelefonoEmpleado = "1234567890", ImagenEmpleado = "profile_placeholder.png" },
                new Empleado { IdEmpleado = 2, NombreEmpleado = "María López", TelefonoEmpleado = "0987654321", ImagenEmpleado = "profile_placeholder.png" }
            };

            BindingContext = this;
        }

        // Evento para regresar a la pantalla anterior
        private async void OnRegresarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Evento para redirigir a la pantalla de agregar empleados
        private async void OnAgregarEmpleadoClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new AgregarEmpleadoPage());
        }

        // Evento para buscar empleados
        private void OnBuscarEmpleadoTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue.ToLower();
            EmpleadosCollectionView.ItemsSource = Empleados.Where(emp => emp.NombreEmpleado.ToLower().Contains(searchTerm) || emp.TelefonoEmpleado.Contains(searchTerm));
        }

        // Evento para redirigir a la pantalla de detalles del empleado
        private async void OnVerDetallesClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var empleadoId = (int)button.CommandParameter;

            var empleadoSeleccionado = Empleados.FirstOrDefault(emp => emp.IdEmpleado == empleadoId);
            if (empleadoSeleccionado != null)
            {
                await Navigation.PushAsync(new DetalleEmpleadoPage(empleadoSeleccionado));
            }
        }
    }

    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string ImagenEmpleado { get; set; }
    }
}
