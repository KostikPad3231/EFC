using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using WpfApp1.Models;
using WpfApp1.Posts;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Page
    {
        private string RealUsername = "";
        private Server server = new Server();
        public UserDetails()
        {
            InitializeComponent();
        }

        public UserDetails(string username) : this()
        {
            RealUsername = username;
            usernameField.Text = RealUsername;
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void usernameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsUsernameFieldValid();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            if(IsUsernameFieldValid())
            {
                string username = usernameField.Text;
                Dictionary<string, string> result = server.UpdateUser(RealUsername, username);
                if (result["details"] == "failed")
                {
                    MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, result["username"]);
                    usernameField.Style = (Style)Resources["HintRed"];
                }
                else if (result["details"] == "success")
                {
                    NavigationService.Navigate(new TopicsList(username));
                }
            }
        }

        private bool IsUsernameFieldValid()
        {
            string username = usernameField.Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            if (style != null) usernameField.Style = style;

            if (string.IsNullOrEmpty(username))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(usernameField, "Required");
                usernameField.Style = (Style)Resources["HintRed"];
                return false;
            }
            return true;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TopicsList(RealUsername));
        }
    }
}
