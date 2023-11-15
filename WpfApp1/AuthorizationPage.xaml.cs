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
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        Server server = new Server();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private async void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Password;
            if(IsFieldsValid())
            {
                Dictionary<string, string> result = await Task.Run(() => server.Login(username, password));
                if (result["details"] == "failed")
                {
                    nonFieldErrors.Text = result["non_field_errors"];
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

        private void passwordField_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password1 = ((PasswordBox)sender).Password;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordField, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintPasswordBox") as Style;
            if (style != null) passwordField.Style = style;

            if (string.IsNullOrEmpty(password1))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(passwordField, "Required");
                passwordField.Style = (Style)Resources["PasswordHintRed"];
            }
        }

        private bool IsFieldsValid()
        {
            string username = usernameField.Text;
            string password1 = passwordField.Password;
            return !(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password1));
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
