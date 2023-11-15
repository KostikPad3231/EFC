using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Server server = new Server();
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private async void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameField.Text;
            string password1 = password1Field.Password;
            if (IsFieldsValid())
            {
                Dictionary<string, string> result = await Task.Run(() => server.CreateUser(username, password1));
                if (result["details"] == "failed")
                {
                    MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, result["username"]);
                    usernameField.Style = (Style)Resources["HintRed"];
                }
                else
                {
                    NavigationService.Navigate(new TopicsList(username));
                }
            }
        }

        private void usernameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = ((TextBox)sender).Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            if (style != null) usernameField.Style = style;

            if (string.IsNullOrEmpty(username))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, "Required");
                usernameField.Style = (Style)Resources["HintRed"];
            }
        }

        private void password1Field_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password1 = ((PasswordBox)sender).Password;
            ClearPasswordStyles(password1Field);

            if (string.IsNullOrEmpty(password1))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(password1Field, "Required");
                password1Field.Style = (Style)Resources["PasswordHintRed"];
            }

            CheckPasswordsMismatch();
        }

        private void password2Field_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password2 = ((PasswordBox)sender).Password;
            ClearPasswordStyles(password2Field);

            if (string.IsNullOrEmpty(password2))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(password2Field, "Required");
                password2Field.Style = (Style)Resources["PasswordHintRed"];
            }

            CheckPasswordsMismatch();
        }

        private void ClearPasswordStyles(Control control)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(control, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintPasswordBox") as Style;
            if (style != null) control.Style = style;
        }

        private void CheckPasswordsMismatch()
        {
            string password1 = password1Field.Password;
            string password2 = password2Field.Password;
            if (!password1.Equals(password2))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(password2Field, "Password mismatch");
                password2Field.Style = (Style)Resources["PasswordHintRed"];
            }
        }

        private bool IsFieldsValid()
        {
            string username = usernameField.Text;
            string password1 = password1Field.Password;
            string password2 = password2Field.Password;
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password1) && !string.IsNullOrEmpty(password2) && password1.Equals(password2);
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
