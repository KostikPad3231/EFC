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
    /// Interaction logic for NewTopic.xaml
    /// </summary>
    public partial class NewTopic : Page
    {
        Server server = new Server();
        string username = "";
        public NewTopic()
        {
            InitializeComponent();
        }

        public NewTopic(string username): this()
        {
            this.username = username;
        }

        private async void Button_New_Topic_Click(object sender, RoutedEventArgs e)
        {
            string subject = subjectField.Text;
            string message = messageField.Text;
            Dictionary<string, string> result = await Task.Run(() => server.NewTopic(username, subject, message));
            if (result["details"] == "success")
            {
                NavigationService.Navigate(new TopicsList(username));
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void subjectField_TextChanged(object sender, TextChangedEventArgs e)
        {
            string subject = ((TextBox)sender).Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(subjectField, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            if (style != null) subjectField.Style = style;

            if (string.IsNullOrEmpty(subject))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(subjectField, "Required");
                subjectField.Style = (Style)Resources["SubjectHintRed"];
            }
        }

        private void messageField_TextChanged(object sender, TextChangedEventArgs e)
        {
            string message = ((TextBox)sender).Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(messageField, "");
            Style? style = this.FindResource("MaterialDesignOutlinedTextBox") as Style;
            if (style != null) messageField.Style = style;

            if (string.IsNullOrEmpty(message))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(messageField, "Required");
                messageField.Style = (Style)Resources["MessageHintRed"];
            }
        }
    }
}
