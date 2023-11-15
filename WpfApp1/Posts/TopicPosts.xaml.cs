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
using WpfApp1.Schemas;

namespace WpfApp1.Posts
{
    /// <summary>
    /// Interaction logic for TopicPosts.xaml
    /// </summary>
    public partial class TopicPosts : Page
    {
        string username = "";
        Topic topic = null!;
        Server server = new Server();
        public TopicPosts()
        {
            InitializeComponent();
        }

        public TopicPosts(string username, int topicId) : this()
        {
            this.username = username;
            this.topic = server.GetTopic(topicId);
            LoadPosts();
        }

        private void LoadPosts()
        {
            List<PostDetails> posts = server.GetTopicPosts(topic.Id);
            postsList.ItemsSource = posts;
        }

        private async void Button_Reply_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidMessageField())
            {
                string message = messageField.Text;
                Dictionary<string, string> result = await Task.Run(() => server.Reply(topic.Id, username, message));
                if (result["details"] == "success")
                {
                    LoadPosts();
                }
            }            
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idToUpdate = (int)button.Tag;
            NavigationService.Navigate(new EditPost(username, idToUpdate));
        }

        private async void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idToDelete = (int)button.Tag;
            Dictionary<string, string> result = await Task.Run(() => server.DeletePost(idToDelete));
            if (result["details"] == "success")
            {
                LoadPosts();
            }
        }

        private void messageField_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidMessageField();
        }

        private bool IsValidMessageField()
        {
            string message = messageField.Text;
            MaterialDesignThemes.Wpf.HintAssist.SetHelperText(messageField, "");
            Style? style = this.FindResource("MaterialDesignOutlinedTextBox") as Style;
            if (style != null) messageField.Style = style;

            if (string.IsNullOrEmpty(message))
            {
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(messageField, "Required");
                messageField.Style = (Style)Resources["MessageHintRed"];
                return false;
            }
            return true;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TopicsList(username));
        }
    }
}
