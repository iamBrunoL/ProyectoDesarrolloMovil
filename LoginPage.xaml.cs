using System.Text.RegularExpressions;

namespace ProyectoDesarrolloMovil
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Evento para mostrar u ocultar la contraseña
        private void OnShowPasswordClicked(object sender, EventArgs e)
        {
            passwordEntry.IsPassword = !passwordEntry.IsPassword;
            showPasswordIcon.Source = passwordEntry.IsPassword ? "eye_icon.png" : "eye_off_icon.png";
        }

        // Evento al hacer clic en el botón de Iniciar Sesión
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text?.Trim();
            string password = passwordEntry.Text?.Trim();

            // Validación para evitar XSS
            if (string.IsNullOrEmpty(username) || !IsValidInput(username))
            {
                await DisplayAlert("Error", "Por favor, ingresa un nombre de usuario válido.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(password) || !IsValidInput(password))
            {
                await DisplayAlert("Error", "Por favor, ingresa una contraseña válida.", "OK");
                return;
            }

            // Lógica para iniciar sesión
            await DisplayAlert("Éxito", "Inicio de sesión exitoso.", "OK");
        }

        // Función para validar la entrada de datos y evitar XSS
        private bool IsValidInput(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }

        // Evento para redirigir al registro
        private void OnRegisterTapped(object sender, EventArgs e)
        {
            // Lógica para redirigir a la página de registro
        }

        // Evento para redirigir a la política de privacidad
        private void OnPrivacyTapped(object sender, EventArgs e)
        {
            // Lógica para redirigir a la política de privacidad
        }
    }
}
