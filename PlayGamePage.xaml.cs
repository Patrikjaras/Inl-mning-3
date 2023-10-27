using Inlämning_3.Models;
using Newtonsoft.Json;
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
    /// Interaction logic for PlayGamePage.xaml
    /// </summary>
    
    public partial class PlayGamePage : Window
    {
        private Player CurrentPlayer;
        Quiz myQuiz = new Quiz();
        Question currentQuestion = null;
        int CorrectQuestions = 0;
        double ProgessBarQuestionvalue = 0;

        public PlayGamePage(Player player)
        {
            InitializeComponent();
        //  myQuiz.LoadQuestionsFromFile();
            GetRandomQuestion();
            CurrentPlayer = player;
            UserNameAndTotalCorrectQ.Text = $"{CurrentPlayer.Name} you have answerd {CorrectQuestions} questions correct";
            GetProgressBarQuestionvalue();
            ProgessBarQuestionvalue = GetProgressBarQuestionvalue();
            
        }
     
        public int UppdateCorrectQuestions()
        {
            CorrectQuestions++;
            return CorrectQuestions;
        }
        public void UppdateLabel()
        {
            UserNameAndTotalCorrectQ.Text = $"{CurrentPlayer.Name} you have answerd {UppdateCorrectQuestions()} questions correct";
        }
        public double GetProgressBarQuestionvalue()
        {
            double totalQuestions = Quiz.AllQuestions.Count();
            double questionValue = 100 / totalQuestions;
            return questionValue;
            
        }
        public void UppdateProgressbar(double questionValue)
        {
            ProgressbarPercent.Value += questionValue;
        }
        public void GetRandomQuestion() 
        {
            currentQuestion = myQuiz.GetRandomQuestion();
            
            QuestionTextBox.Text = currentQuestion.Statement;
            AwnserButton1.Content = currentQuestion.Answers[0];
            AwnserButton2.Content = currentQuestion.Answers[1];
            AwnserButton3.Content = currentQuestion.Answers[2];

        }

        private void ReturnToHeadPageButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page2StartWindow = new Page2StartWindow(CurrentPlayer);
            page2StartWindow.Show();
            this.Close();
        }

        private void ReturnToStartButton_Click(object sender, RoutedEventArgs e)
        {
            Page2StartWindow page = new Page2StartWindow(CurrentPlayer);    
            page.Show();
            this.Close();
        }

        private void AwnserButton1_Click(object sender, RoutedEventArgs e)
        {
            var RandomQuestion = currentQuestion;
            if (RandomQuestion.CorrectAnswer == 0 && RandomQuestion != null) 
            {
                MessageBox.Show("Correct answer!");
                UppdateLabel();
                UppdateProgressbar(ProgessBarQuestionvalue);
                myQuiz.RemoveQuestion(RandomQuestion.Id);
                GetRandomQuestion();
            }
            else
            {
                MessageBox.Show("Wrong answer, better lucky next time!");
                GetRandomQuestion();
            }
        }

        private void AwnserButton2_Click(object sender, RoutedEventArgs e)
        {
            var RandomQuestion = currentQuestion;
            if (RandomQuestion.CorrectAnswer == 1 && RandomQuestion != null)
            {
                MessageBox.Show("Correct answer!");
                UppdateLabel();
                UppdateProgressbar(ProgessBarQuestionvalue);
                myQuiz.RemoveQuestion(RandomQuestion.Id);
                GetRandomQuestion();
            }
            else
            {
                MessageBox.Show("Wrong answer, better lucky next time!");
                GetRandomQuestion();
            }

        }

        private void AwnserButton3_Click(object sender, RoutedEventArgs e)
        {
            var RandomQuestion = currentQuestion;
            if (RandomQuestion.CorrectAnswer == 2 && RandomQuestion != null)
            {
                MessageBox.Show("Correct answer!");
                UppdateLabel();
                UppdateProgressbar(ProgessBarQuestionvalue);
                myQuiz.RemoveQuestion(RandomQuestion.Id);
                GetRandomQuestion();
            }
            else
            {
                MessageBox.Show("Wrong answer, better lucky next time!");
                GetRandomQuestion();
            }
        }
        
    }
}
