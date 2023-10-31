using Inlämning_3.Models;
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
using System.Windows.Shapes;

namespace Inlämning_3
{
    /// <summary>
    /// Interaction logic for ChooseQuizToPlayPage.xaml
    /// </summary>
    public partial class ChooseQuizToPlayPage : Window
    {
        private Player CurrentPlayer;
        int selectedIndex = 0;
        
        public ChooseQuizToPlayPage(Player player)
        {
            CurrentPlayer = player;
            InitializeComponent();
            ChooseQuizToPlayListBox.ItemsSource = Quiz.AllQuizez;
        }

        private void ChooseQuizToPlayListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               selectedIndex = ChooseQuizToPlayListBox.SelectedIndex;
        }

        private void RetunToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page = new Page2StartWindow(CurrentPlayer);
            page.Show();
            this.Close();
        }

        private void AddQuizToPlayQuizButton_Click(object sender, RoutedEventArgs e)
        {
            
            PlaySpecificQuizPage playSpecificQuizPage = new PlaySpecificQuizPage(CurrentPlayer, selectedIndex);
            playSpecificQuizPage.Show();
            this.Close();
        }
    }
}
