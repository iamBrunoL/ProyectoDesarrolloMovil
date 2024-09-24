using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProyectoDesarrolloMovil
{
    public partial class PanelControlPage : ContentPage, INotifyPropertyChanged
    {
        // Lista de opciones completas
        private ObservableCollection<Option> options = new ObservableCollection<Option>
        {
            new Option { ImageSource = "perfil.png", Name = "Mis datos"},
            new Option { ImageSource = "empleado.png", Name = "Empleados"},
            new Option {ImageSource = "producto.png", Name = "Productos" },
            new Option { ImageSource = "proveedor.png", Name = "Proveedores"},
            new Option { ImageSource = "cliente.png", Name = "Clientes" }
        };

        private ObservableCollection<Option> _filteredOptions;
        public ObservableCollection<Option> FilteredOptions
        {
            get => _filteredOptions;
            set
            {
                _filteredOptions = value;
                OnPropertyChanged(nameof(FilteredOptions)); // Notificar a la UI que la propiedad ha cambiado
            }
        }

        public string UserName { get; set; } = "LuisB"; // Nombre del usuario

        public PanelControlPage()
        {
            InitializeComponent();

            // Inicializa la lista filtrada con todas las opciones
            FilteredOptions = new ObservableCollection<Option>(options);

            BindingContext = this;
        }

        // Evento que se dispara cuando el texto de búsqueda cambia
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            // Filtrar las opciones que contienen el texto de búsqueda
            var filtered = options
                .Where(option => option.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                .ToList();

            // Actualiza la lista filtrada
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
