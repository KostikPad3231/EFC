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

namespace WpfApp1.Topics
{
    /// <summary>
    /// Interaction logic for EditTopic.xaml
    /// </summary>
    public partial class EditTopic : Page
    {
        string username = "";
        Server server = new Server();
        Topic topic = null!;
        public EditTopic()
        {
            InitializeComponent();
        }

        public EditTopic(int topicId, string username) : this()
        {
            topic = server.GetTopic(topicId);
            subjectField.Text = topic.Name;
            this.username = username;
        }

        private async void Button_Update_Topic_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidSubjectField())
            {
                string subject = subjectField.Text;
                Dictionary<string, string> result = await Task.Run(() => server.UpdateTopic(topic.Id, subject));
                if (result["details"] == "success")
                {
                    NavigationService.Navigate(new TopicsList(username));
                }
            }            
        }

        private void subjectField_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidSubjectField();
        }

        private bool IsValidSubjectField()
        {
            string subject = subjectField.Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(subjectField, "");
            Style? style = this.FindResource("MaterialDesignFloatingHintTextBox") as Style;
            if (style != null) subjectField.Style = style;

            if (string.IsNullOrEmpty(subject))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(subjectField, "Required");
                subjectField.Style = (Style)Resources["SubjectHintRed"];
                return false;
            }
            return true;
        }
    }
}
