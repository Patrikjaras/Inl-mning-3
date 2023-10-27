using Inlämning_3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Inlämning_3
{
    /// <summary>
    /// Interaction logic for ChooseSpecificQuizPage.xaml
    /// </summary>
    public partial class ChooseSpecificQuizPage : Window
    {
        private Player CurrentPlayer;
        private Quiz CurrentQuiz;
        private Question CurrentQuestion;
       
        public ChooseSpecificQuizPage(Player player)
        {
            CurrentPlayer = player; 
            InitializeComponent();
            
            QuizezListBox.ItemsSource = Quiz.AllQuizez;
            QuestionsNotInQuizListBox.ItemsSource = Quiz.AllQuestions;


        }

        private void RetunToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page2StartWindow = new Page2StartWindow(CurrentPlayer);
            page2StartWindow.Show();
            this.Close();
        }
        private void QuizezListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuizezListBox.SelectedItem is Quiz slectedQuiz )
            {
                CurrentQuiz = slectedQuiz;
                this.DataContext = CurrentQuiz;
            }
            SpecificQuizQuestionsListBox.ItemsSource = CurrentQuiz._questions;
            
        }

        private void SpecificQuizQuestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void QuestionsNotInQuizListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddQuestionToQuizButton_Click(object sender, RoutedEventArgs e)
        {
            
            var questionToAdd = QuestionsNotInQuizListBox.SelectedItem as Question;
            var quizToAddQuestionToo = QuizezListBox.SelectedItem as Quiz;
            
            if (questionToAdd != null && quizToAddQuestionToo != null)
            {
                quizToAddQuestionToo.AddQuestionToQuiz(questionToAdd);
                SpecificQuizQuestionsListBox.ItemsSource = CurrentQuiz._questions.ToList();
            }
            else
            {
                MessageBox.Show("Both a quiz and a question must be chosen");
            }
            
            
        }
        private void RemoveQuestionFromQuizButton_Click(object sender, RoutedEventArgs e)
        {
            var quizToRemoveFrom = QuizezListBox.SelectedItem as Quiz;
            var index = SpecificQuizQuestionsListBox.SelectedIndex;
            if (index != -1 && quizToRemoveFrom != null) 
            {
                quizToRemoveFrom.RemoveQuestionFromQuiz(index);
                SpecificQuizQuestionsListBox.ItemsSource = CurrentQuiz._questions.ToList();
            }
            else
            {
                MessageBox.Show("Both a quiz and a question must be chosen");
            }
        }

        private void ButtonCreateNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            string NewQuiz = TextBoxCreateNewQuiz.Text;
            Quiz quiz = new Quiz(NewQuiz);
            Quiz.AllQuizez.Add(quiz);
            MessageBox.Show($"New Quiz {quiz.Title} has been created");
            QuizezListBox.ItemsSource = Quiz.AllQuizez.ToList();
            TextBoxCreateNewQuiz.Clear();   
        }
    }
}
