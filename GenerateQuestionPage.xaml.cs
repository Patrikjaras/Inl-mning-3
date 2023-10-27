using Inlämning_3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for GenerateQuestionPage.xaml
    /// </summary>
    public partial class GenerateQuestionPage : Window
    {
        private Player CurrentPlayer;
        private Quiz GenerateQuestion = new Quiz();
        public GenerateQuestionPage(Player player)
        {
            GenerateQuestion.LoadQuestionsFromFile();
            InitializeComponent();
            CurrentPlayer = player; 
        }

        private void RetunToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow Page2StartWindow = new Page2StartWindow(CurrentPlayer);
            Page2StartWindow.Show();
            this.Close();
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (EnterCateGoryTextBox.Text != "" && EnterQuestionTextBox.Text != "" && EnterFirstAnswerTextBox.Text != "" && EnterSecondAnswerTextBox.Text != "" && EnterThirdAnswerTextBox.Text != "" )
            {
                if (FirstAnswerCorrectCheckbox.IsChecked == true || SecondAnswerCorrectCheckbox.IsChecked == true || ThirdAnswerCorrectCheckbox.IsChecked == true)
                { 
                int ID = GenerateQuestion.GetNextID();
                string Category = EnterCateGoryTextBox.Text;
                string statement = EnterQuestionTextBox.Text;
                int correctAnswer = GetCorrectAnswer();
                string[] answers = { EnterFirstAnswerTextBox.Text, EnterSecondAnswerTextBox.Text, EnterThirdAnswerTextBox.Text };

                GenerateQuestion.AddQuestion(ID, Category, statement, correctAnswer, answers);

                MessageBox.Show($"Question has been added. Qustion number is {ID}!");
                EnterCateGoryTextBox.Clear();
                EnterQuestionTextBox.Clear();
                EnterFirstAnswerTextBox.Clear();
                EnterSecondAnswerTextBox.Clear();
                EnterThirdAnswerTextBox.Clear();
                FirstAnswerCorrectCheckbox.IsChecked = false;
                SecondAnswerCorrectCheckbox.IsChecked = false;
                ThirdAnswerCorrectCheckbox.IsChecked = false;
                   
                }
                else
                {
                    MessageBox.Show("Please choose a checkbox indicating the correct answer");
                }
            }
            else
            {
                MessageBox.Show("All fields must be filled out");
            }

            
        }
        public int GetCorrectAnswer()
        {
            if (FirstAnswerCorrectCheckbox.IsChecked == true ) 
            {
                return 0;
            }
            if (SecondAnswerCorrectCheckbox.IsChecked == true) 
            {
                return 1;
            }
            if (ThirdAnswerCorrectCheckbox.IsChecked == true)
            {
                return 2;
            }
            else 
            {
                MessageBox.Show("Please check a box.");
                return -1;
            }
        }

        private void FirstAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            SecondAnswerCorrectCheckbox.IsChecked = false;
            ThirdAnswerCorrectCheckbox.IsChecked = false;
        }

        private void SecondAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            FirstAnswerCorrectCheckbox.IsChecked = false;
            ThirdAnswerCorrectCheckbox.IsChecked = false;
        }

        private void ThirdAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            FirstAnswerCorrectCheckbox.IsChecked = false;
            SecondAnswerCorrectCheckbox.IsChecked = false;
        }
    }
}
