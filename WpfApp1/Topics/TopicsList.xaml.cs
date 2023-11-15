using MaterialDesignThemes.Wpf;
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
using WpfApp1.Posts;
using WpfApp1.Schemas;
using WpfApp1.Topics;

namespace WpfApp1
{
    enum Order
    {
        Nothing = 0,
        Desc = 1,
        Asc = 2,
    }
    /// <summary>
    /// Interaction logic for Topics.xaml
    /// </summary>
    public partial class TopicsList : Page
    {
        Server server = new Server();
        private string username = "";
        private int curPage = 0;
        private int pagesCount;
        private string stringToSearch = "";
        private Order sorting = Order.Nothing;

        public TopicsList()
        {
            InitializeComponent();
            LoadData();
        }

        public TopicsList(string username) : this()
        {
            this.username = username;
            UserNameLabel.Content = username;
        }

        private void LoadData()
        {
            (int pagesCount, List<TopicDetails> topics) = server.GetTopics(curPage, stringToSearch, (int)sorting);
            this.pagesCount = pagesCount;
            topicsList.ItemsSource = topics;
            curPageField.Text = (curPage + 1).ToString();
        }

        private async void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idToDelete = (int)button.Tag;
            Dictionary<string, string> result = await Task.Run(() => server.DeleteTopic(idToDelete));
            if (result["details"] == "success")
            {
                LoadData();
            }
        }

        private void Button_New_Topic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewTopic(username));
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idToUpdate = (int)button.Tag;
            NavigationService.Navigate(new EditTopic(idToUpdate, username));
        }

        private void TextBlock_Name_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock topic = (TextBlock)sender;
            int topicId = (int)topic.Tag;
            NavigationService.Navigate(new TopicPosts(username, topicId));
        }

        private void UserNameLabel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserDetails(username));
        }

        private void Button_First_Click(object sender, RoutedEventArgs e)
        {
            curPage = 0;
            LoadData();
        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            if(curPage > 0) {
                --curPage;
                LoadData();
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            if (curPage < pagesCount - 1)
            {
                ++curPage;
                LoadData();
            }
        }

        private void Button_Last_Click(object sender, RoutedEventArgs e)
        {
            if(pagesCount > 0)
            {
                curPage = pagesCount - 1;
            }
            else
            {
                curPage = 0;
            }
            LoadData();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            stringToSearch = searchField.Text;
            curPage = 0;
            LoadData();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            if(sorting == Order.Nothing || sorting == Order.Asc)
            {
                sorting = Order.Desc;
                SortIcon.Kind = PackIconKind.TriangleSmallDown;
            }
            else if(sorting == Order.Desc) { 
                sorting = Order.Asc;
                SortIcon.Kind = PackIconKind.TriangleSmallUp;
            }
            LoadData();
        }
    }
}
