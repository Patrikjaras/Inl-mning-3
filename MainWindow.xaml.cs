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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inlämning_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player CurrentPlayer;
        
        public MainWindow()
        {
            InitializeComponent();
            
            Quiz quiz = new Quiz();
            quiz.GenerateFolder();
            CurrentPlayer = new Player("");
            quiz.LoadQuestionsFromFile();
            quiz.LoadQuizezFromFile();
        }

        private void SubmitNameButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPlayer.Name = EnterNameTextBox.Text;

            if (EnterNameTextBox.Text != "" && EnterNameTextBox.Text != "Enter Name")
            {
                Page2StartWindow page2StartWindow = new Page2StartWindow(CurrentPlayer);
                page2StartWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
            


        }
    }
}
