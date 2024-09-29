using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ProyectoDesarrolloMovil
{
    public partial class PanelControlPage : ContentPage, INotifyPropertyChanged
    {
        // Lista de opciones completas
        private ObservableCollection<Option> options = new ObservableCollection<Option>
        {
            new Option { ImageSource = "perfil.png", Name = "Mis datos", TargetPage = typeof(MisDatosPage) },
            new Option { ImageSource = "empleado.png", Name = "Empleados", TargetPage = typeof(AdminEmpleadosPage) },
            new Option { ImageSource = "producto.png", Name = "Productos" },
            new Option { ImageSource = "proveedor.png", Name = "Proveedores" },
            new Option { ImageSource = "cliente.png", Name = "Clientes" }
        };

        private ObservableCollection<Option> _filteredOptions;
        public ObservableCollection<Option> FilteredOptions
        {
            get => _filteredOptions;
            set
            {
                _filteredOptions = value;
                OnPropertyChanged(nameof(FilteredOptions));
            }
        }

        public string UserName { get; set; } = "LuisB"; // Nombre del usuario

        // Comando para manejar la selección de opciones
        public ICommand OnOptionSelectedCommand { get; }

        public PanelControlPage()
        {
            InitializeComponent();

            // Inicializa la lista filtrada con todas las opciones
            FilteredOptions = new ObservableCollection<Option>(options);

            // Inicializa el comando
            OnOptionSelectedCommand = new Command<Option>(OnOptionSelected);

            BindingContext = this;
        }

        // Método para manejar la selección de una opción
        private async void OnOptionSelected(Option selectedOption)
        {
            if (selectedOption.TargetPage != null)
            {
                // Navega a la página de destino
                var page = (Page)Activator.CreateInstance(selectedOption.TargetPage);
                await Navigation.PushAsync(page);
            }
        }

        // Evento que se dispara cuando el texto de búsqueda cambia
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var filtered = options
                .Where(option => option.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                .ToList();

            FilteredOptions.Clear();
            foreach (var option in filtered)
            {
                FilteredOptions.Add(option);
            }
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Clase que representa cada opción en el panel de control
    public class Option
    {
        public string ImageSource { get; set; }
        public string Name { get; set; }
        public Type TargetPage { get; set; } // La página de destino cuando se hace clic en la opción
    }
}
