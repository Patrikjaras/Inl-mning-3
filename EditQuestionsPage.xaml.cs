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
    /// Interaction logic for EditQuestionsPage.xaml
    /// </summary>
    public partial class EditQuestionsPage : Window
    {
        private Player CurrentPlayer;

        Quiz myQuiz = new Quiz();

        public EditQuestionsPage(Player player)
        {
            CurrentPlayer = player;
            InitializeComponent();
            StatementListBox.ItemsSource = Quiz.AllQuestions;
        }
        private void RetunToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page2StartWindow = new Page2StartWindow(CurrentPlayer);
            page2StartWindow.Show();
            this.Close();
        }
        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditQuestionTextBox.Text != "" && EditFirstAnswerTextBox.Text != "" && EditSecondAnswerTextBox.Text != "" && EditThirdAnswerTextBox.Text != "")
            {
                if (EditFirstAnswerCorrectCheckbox.IsChecked == true || EditSecondAnswerCorrectCheckbox.IsChecked == true || EditThirdAnswerCorrectCheckbox.IsChecked == true)
                { 
                    try
                    {
                          int input = int.Parse(EnterQNumberToEditTextBox.Text);
                          var question = myQuiz.GetEditQuestion(input);
                          question.Statement = EditQuestionTextBox.Text;
                          question.Answers[0] = EditFirstAnswerTextBox.Text;
                          question.Answers[1] = EditSecondAnswerTextBox.Text;
                          question.Answers[2] = EditThirdAnswerTextBox.Text;
                          question.CorrectAnswer = EditCorrectAwnser();
                          question.ImagePath = EditUrlTextBox.Text;

                          myQuiz.CorrectQuizezWhenQuestionEditet(question);
                          myQuiz.SaveNewQuestionsToFile();
                          MessageBox.Show("Question has been edited.");
                         
                          EditUrlTextBox.Clear();
                          EnterQNumberToEditTextBox.Clear();
                          EditQuestionTextBox.Clear();
                          EditFirstAnswerTextBox.Clear();
                          EditSecondAnswerTextBox.Clear();
                          EditThirdAnswerTextBox.Clear();
                          EditCategoryTextBox.Clear();
                          EditFirstAnswerCorrectCheckbox.IsChecked = false;
                          EditSecondAnswerCorrectCheckbox.IsChecked = false;
                          EditThirdAnswerCorrectCheckbox.IsChecked = false;
                              
                          StatementListBox.ItemsSource = Quiz.AllQuestions.ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Input is not a number4312");
                    }
                }
                else
                {
                    MessageBox.Show("A checkbox indicating the correct answer must be checked");
                }

            }
            else
            {
                MessageBox.Show("All fields must be filled out");
            }


        }

        private void GetQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int input = int.Parse(EnterQNumberToEditTextBox.Text);
                var question = myQuiz.GetEditQuestion(input);
                EditQuestionTextBox.Text = question.Statement;
                EditFirstAnswerTextBox.Text = question.Answers[0];
                EditSecondAnswerTextBox.Text = question.Answers[1];
                EditThirdAnswerTextBox.Text= question.Answers[2];
                EditCategoryTextBox.Text = question.Category;
                EditUrlTextBox.Text = question.ImagePath;
                if (question.CorrectAnswer == 0)
                {
                    EditFirstAnswerCorrectCheckbox.IsChecked = true;
                }
                if (question.CorrectAnswer == 1)
                {
                    EditSecondAnswerCorrectCheckbox.IsChecked = true;   
                }
                if (question.CorrectAnswer == 2)
                {
                    EditThirdAnswerCorrectCheckbox.IsChecked = true;    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("input is not a valid number");
            }
        }
        public int EditCorrectAwnser()
        {
            if (EditFirstAnswerCorrectCheckbox.IsChecked == true) 
            {
                return 0;
            }
            if (EditSecondAnswerCorrectCheckbox.IsChecked == true)
            {
                return 1;
            }
            if (EditThirdAnswerCorrectCheckbox.IsChecked == true)
            {
                return 2;
            }
            else 
            {
                MessageBox.Show("A box must be checked");
                return -1;
            }

        }

        private void EditFirstAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            EditSecondAnswerCorrectCheckbox.IsChecked = false;
            EditThirdAnswerCorrectCheckbox.IsChecked = false;
        }

        private void EditSecondAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            EditFirstAnswerCorrectCheckbox.IsChecked = false;
            EditThirdAnswerCorrectCheckbox.IsChecked = false;
        }

        private void EditThirdAnswerCorrectCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            EditFirstAnswerCorrectCheckbox.IsChecked = false;
            EditSecondAnswerCorrectCheckbox.IsChecked = false;
        }

        private void StatementListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatementListBox.SelectedItems != null) 
            {
                var selectedQuiz = (Question)StatementListBox.SelectedItem;
                string ID = selectedQuiz.Id.ToString();
                EnterQNumberToEditTextBox.Text = ID;
                EditQuestionTextBox.Text = selectedQuiz.Statement;
                EditFirstAnswerTextBox.Text = selectedQuiz.Answers[0];
                EditSecondAnswerTextBox.Text = selectedQuiz.Answers[1];
                EditThirdAnswerTextBox.Text = selectedQuiz.Answers[2];
                EditCategoryTextBox.Text = selectedQuiz.Category;
                EditUrlTextBox.Text = selectedQuiz.ImagePath;

                if (selectedQuiz.CorrectAnswer == 0)
                {
                    EditFirstAnswerCorrectCheckbox.IsChecked = true;
                }
                if (selectedQuiz.CorrectAnswer == 1)
                {
                    EditSecondAnswerCorrectCheckbox.IsChecked= true;
                }
                if (selectedQuiz.CorrectAnswer == 2)
                {
                    EditThirdAnswerCorrectCheckbox.IsChecked= true;
                }
                
            }
          
        }
    }
}
