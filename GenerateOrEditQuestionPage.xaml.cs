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
    /// Interaction logic for GenerateOrEditQuestionPage.xaml
    /// </summary>
    public partial class GenerateOrEditQuestionPage : Window
    {
        private Player CurrentPlayer;
        public GenerateOrEditQuestionPage(Player player)
        {
            CurrentPlayer = player;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditQuestionsPage editQuestionsPage = new EditQuestionsPage(CurrentPlayer);
            editQuestionsPage.Show();
            this.Close();   
        }

        private void ReturnToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page2StartWindow = new Page2StartWindow(CurrentPlayer);
            page2StartWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            GenerateQuestionPage generateQuestionPage = new GenerateQuestionPage(CurrentPlayer); 
            generateQuestionPage.Show();
            this.Close();
        }
    }
}
