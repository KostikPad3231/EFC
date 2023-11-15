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
using WpfApp1.Models;

namespace WpfApp1.Posts
{
    /// <summary>
    /// Interaction logic for EditPost.xaml
    /// </summary>
    public partial class EditPost : Page
    {
        string username = "";
        Post post = null!;
        Server server = new Server();
        public EditPost()
        {
            InitializeComponent();
        }

        public EditPost(string username, int postId) : this()
        {
            post = server.GetPost(postId)!;
            messageField.Text = post.Message;
            this.username = username;
        }

        private void messageField_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValidMessageField();
        }

        private async void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            if(IsValidMessageField())
            {
                string message = messageField.Text;
                Dictionary<string, string> result = await Task.Run(() => server.UpdatePost(post.Id, message));
                if (result["details"] == "success")
                {
                    NavigationService.Navigate(new TopicPosts(username, post.TopicId));
                }
            }
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
    }
}
