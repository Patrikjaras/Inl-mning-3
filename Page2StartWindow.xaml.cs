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
    /// Interaction logic for Page2StartWindow.xaml
    /// </summary>
    
    public partial class Page2StartWindow : Window
    {
        private Player CurrentPlayer;
        Quiz myQuiz = new Quiz();
        
        public Page2StartWindow(Player player)
        {
            
            InitializeComponent();
            
            CurrentPlayer = player;
            StartPageLabel.Content = $"Welcome {CurrentPlayer.Name}, what do you want to do?";
        }

        private void ReturnToHeadPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayGamePage playGamePage = new PlayGamePage(CurrentPlayer);
            playGamePage.Show();
            this.Close();
        }

        private void SpecificQuizButton_Click(object sender, RoutedEventArgs e)
        {
            myQuiz.LoadQuestionsFromFile();
            ChooseSpecificQuizPage chooseSpecificQuizPage = new ChooseSpecificQuizPage(CurrentPlayer);
            chooseSpecificQuizPage.Show();
            this.Close();
        }

        private void AddOrEditQButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateOrEditQuestionPage generateOrEditQuestionPage = new GenerateOrEditQuestionPage(CurrentPlayer);
            generateOrEditQuestionPage.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChooseQuizToPlayPage ChooseQuizToPlayPage = new ChooseQuizToPlayPage(CurrentPlayer);
            ChooseQuizToPlayPage.Show();
            this.Close();
        }
    }
}
