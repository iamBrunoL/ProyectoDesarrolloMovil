using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace ProyectoDesarrolloMovil
{
    public partial class ActualizacionMisDatosPage : ContentPage
    {
        public List<string> Generos { get; set; }
        public string GeneroSeleccionado { get; set; }
        public int EdadSeleccionada { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }

        public ActualizacionMisDatosPage()
        {
            InitializeComponent();

            Generos = new List<string> { "Masculino", "Femenino", "No binario", "Prefiero no decirlo" };
            GeneroSeleccionado = Generos.FirstOrDefault();
            EdadSeleccionada = 18;
            Domicilio = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            NombreCompleto = string.Empty;
            NombreUsuario = string.Empty;

            BindingContext = this;
        }

        // Validación para los datos ingresados
        private bool ValidarDatos()
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(NombreCompleto))
            {
                DisplayAlert("Error", "El nombre completo no puede estar vacío.", "OK");
                return false;
            }

            // Validar correo electrónico
            if (!Regex.IsMatch(Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                DisplayAlert("Error", "Por favor, introduce un correo electrónico válido.", "OK");
                return false;
            }

            // Validar domicilio (que no esté vacío)
            if (string.IsNullOrWhiteSpace(Domicilio))
            {
                DisplayAlert("Error", "El domicilio no puede estar vacío.", "OK");
                return false;
            }

            // Validar teléfono (solo números)
            if (!Regex.IsMatch(Telefono, @"^\d{10}$"))
            {
                DisplayAlert("Error", "Por favor, introduce un número de teléfono válido (10 dígitos).", "OK");
                return false;
            }

            // Si todas las validaciones pasan
            return true;
        }

        // Evento para actualizar datos con validación y prevención de XSS
        private async void OnActualizarDatosClicked(object sender, EventArgs e)
        {
            // Llamar a la función de validación de datos
            if (!ValidarDatos())
            {
                return; // Si los datos no son válidos, no continuar
            }

            // Limpiar entradas para evitar XSS
            string nombreSeguro = LimpiarEntrada(NombreCompleto);
            string correoSeguro = LimpiarEntrada(Correo);
            string domicilioSeguro = LimpiarEntrada(Domicilio);
            string telefonoSeguro = LimpiarEntrada(Telefono);
            string nombreUsuarioSeguro = LimpiarEntrada(NombreUsuario);

            // Simulación de actualización de datos (aquí iría tu lógica para actualizar la base de datos o API)
            bool confirmacion = await DisplayAlert("Confirmación", "¿Deseas actualizar tus datos?", "Sí", "No");
            if (confirmacion)
            {
                // Aquí aplicarías la lógica real de actualización de datos
                await DisplayAlert("Actualización", "Datos actualizados correctamente.", "OK");
            }
        }

        // Función para limpiar posibles entradas de XSS
        private string LimpiarEntrada(string input)
        {
            return Regex.Replace(input, @"[<>""'%;)(&+]", string.Empty); // Remover caracteres peligrosos
        }

        // Evento para seleccionar imagen de perfil
        private async void OnSeleccionarImagenClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Seleccionar Imagen", "Funcionalidad para seleccionar una imagen de perfil.", "OK");
        }

        // Evento para manejar el cambio en el Slider de la edad
        private void OnEdadSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            EdadSeleccionada = (int)e.NewValue; // Actualizar el valor de la edad conforme se mueve el Slider
            OnPropertyChanged(nameof(EdadSeleccionada)); // Notificar que la propiedad ha cambiado
        }

        // Evento para cancelar la actualización
        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", "¿Deseas cancelar la actualización?", "Sí", "No");
            if (confirmacion)
            {
                await Navigation.PopAsync();
            }
        }

        // Manejar cambios en el campo de nombre completo
        private async void OnNombreCompletoTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            string texto = LimpiarEntrada(entry.Text);

            // Verificar caracteres no válidos
            if (entry.Text != texto)
            {
                await DisplayAlert("Error", "No se pueden ingresar caracteres no válidos en el nombre completo.", "OK");
            }

            entry.Text = texto; // Limpiar entrada en tiempo real
        }

        // Manejar cambios en el campo de nombre de usuario
        private async void OnNombreUsuarioTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            string texto = LimpiarEntrada(entry.Text);

            // Verificar caracteres no válidos
            if (entry.Text != texto)
            {
                await DisplayAlert("Error", "No se pueden ingresar caracteres no válidos en el nombre de usuario.", "OK");
            }

            entry.Text = texto; // Limpiar entrada en tiempo real
        }

        // Manejar cambios en el campo de domicilio
        private async void OnDomicilioTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            string texto = LimpiarEntrada(entry.Text);

            // Verificar caracteres no válidos
            if (entry.Text != texto)
            {
                await DisplayAlert("Error", "No se pueden ingresar caracteres no válidos en el domicilio.", "OK");
            }

            entry.Text = texto; // Limpiar entrada en tiempo real
        }
    }
}
