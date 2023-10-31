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
    /// Interaction logic for PlaySpecificQuizPage.xaml
    /// </summary>
    public partial class PlaySpecificQuizPage : Window
    {
        private Player CurrentPlayer;
        private Quiz CurrentQuiz;
        private Question randomQuestion;
        double CorrectQuestions = 0;
        double TotalGuesses = 0;
        
        public PlaySpecificQuizPage(Player Player, int index)
        {
            InitializeComponent();
            CurrentPlayer = Player;
            CurrentQuiz = Quiz.AllQuizez[index];

            QuizName.Content = CurrentQuiz.Title;
            UserNameAndTotalCorrectQuestions.Text = $"{CurrentPlayer.Name} you have answerd {CorrectQuestions} questions correct  ";

            GetRandomQuestionQuizPage();
           
        }
        public void UppdateLabel()
        {
            UserNameAndTotalCorrectQuestions.Text = $"{CurrentPlayer.Name} you have answerd {UppdateCorrectQuestionsMethod()} questions correct  ";
        }
        public double UppdateCorrectQuestionsMethod()
        {
            CorrectQuestions++;
            return CorrectQuestions;
        }
    
        public Question GetRandomQuestionForSpecificQuiz()
        {
            
            Random random = new Random();
            var randomIndex = random.Next(0, CurrentQuiz._questions.Count);
            randomQuestion = CurrentQuiz._questions[randomIndex];
            return randomQuestion;  
        }
        public void OutOfQuestions()
        {
            CurrentQuiz.LoadQuizezFromFile();
            Page2StartWindow page = new Page2StartWindow(CurrentPlayer);
            page.Show();
            this.Close();

        }
        public double TotalPercentCorrect()
        {
            double guesses = CorrectQuestions / TotalGuesses ;
            double percent = guesses * 100;
            return percent;
        }
        public void GetRandomQuestionQuizPage()
        {
            if (CurrentQuiz._questions.Count == 0)
            {
                MessageBox.Show($"You answerd all questions! You guessed correctly {TotalPercentCorrect()}% of the time well done, try to make a new quiz");
                OutOfQuestions();
            }
            else
            {
                randomQuestion = GetRandomQuestionForSpecificQuiz();

                QuestionID.Content = randomQuestion.Id;
                QuestionTextBox.Text = randomQuestion.Statement;
                AwnserButton1.Content = randomQuestion.Answers[0];
                AwnserButton2.Content = randomQuestion.Answers[1];
                AwnserButton3.Content = randomQuestion.Answers[2];
                if (randomQuestion.ImagePath != null) 
                {
                    string? imagePath = randomQuestion.ImagePath;
                    Uri imageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

                    if (imagePath.StartsWith("http://") || imagePath.StartsWith("https://"))
                    {
                        ImageWindow.Source = new BitmapImage(imageUri);
                        return;
                    }
                    else
                    {
                        ImageWindow.Source = null;
                    }
                }
                if (randomQuestion.ImagePath == "" || randomQuestion.ImagePath == "null")
                {

                    string? imagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtIpc5OCgEWtPeDNNrQLBbcx7kHRFAIDXjfCehUzfDl41jFin3laL6PXiDEkOFIwB7nZI&usqp=CAU";
                    Uri ImageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                    ImageWindow.Source = new BitmapImage(ImageUri);
                }
            }
            
        }
        public void RemoveQuestionFromQuiz(int ID)
        {
            var removeQuestion = CurrentQuiz._questions.FirstOrDefault(question => question.Id == ID);
            
            if (removeQuestion != null) 
            { 
                CurrentQuiz._questions.Remove(removeQuestion);
            }
            else
            {
                MessageBox.Show("asdasdasdasdasdasdasdasdasdasd");
            }
            
        }

        private void RetunToStartButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentQuiz.LoadQuizezFromFile();
            Page2StartWindow page = new Page2StartWindow(CurrentPlayer);
            page.Show();
            this.Close();

        }

        private void AwnserButton1_Click(object sender, RoutedEventArgs e)
        {

            var currentQuestion = randomQuestion;
            if (currentQuestion.CorrectAnswer == 0 && currentQuestion != null)
            { 
                MessageBox.Show("Correct answer!");
                TotalGuesses++;
                UppdateLabel();
                RemoveQuestionFromQuiz(currentQuestion.Id);
                GetRandomQuestionQuizPage();
                
                

            }
            else
            {
                TotalGuesses++;
                MessageBox.Show("Wrong answer but so very close!");
                GetRandomQuestionQuizPage();
            }
        }

        private void AwnserButton2_Click(object sender, RoutedEventArgs e)
        {
            var currentQuestion = randomQuestion;
            if (currentQuestion.CorrectAnswer == 1 && currentQuestion != null)
            {
                MessageBox.Show("Correct answer!");
                TotalGuesses++;
                UppdateLabel();
                RemoveQuestionFromQuiz(currentQuestion.Id);
                GetRandomQuestionQuizPage();
                
                
            }
            else
            {
                TotalGuesses++;
                MessageBox.Show("Wrong answer but so very close!");
                GetRandomQuestionQuizPage();
            }
        }

        private void AwnserButton3_Click(object sender, RoutedEventArgs e)
        {

            var currentQuestion = randomQuestion;
            if (currentQuestion.CorrectAnswer == 2 && currentQuestion != null)
            {
                TotalGuesses++;
                MessageBox.Show("Correct answer!");
                UppdateLabel();
                RemoveQuestionFromQuiz(currentQuestion.Id);
                GetRandomQuestionQuizPage();
                
                
            }
            else
            {
                TotalGuesses++;
                MessageBox.Show("Wrong answer but so very close!");
                GetRandomQuestionQuizPage();

            }

        }
    }
}
