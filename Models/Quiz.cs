using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inlämning_3.Models
{
    internal class Quiz
    {
        //private IEnumerable<Question> _iquestions;
        //kolla om denna måste vara private
        public List<Question> _questions;

        private string _title = string.Empty;
        //public IEnumerable<Question> iQuestions => _iquestions;
        public string Title { get { return _title; } set { _title = value; } }
        
        public static List<Question> AllQuestions = new List<Question>();
        public static List <Quiz> AllQuizez = new List<Quiz>();
       
        public Quiz(string title)
        { 
            _title = title;
            _questions = new List<Question>(); 
        }
        public Quiz()
        {
            _questions = new List<Question>();
        }
        public static Task GenerateQuizez()
        {
            Quiz football = new Quiz("football");
            Quiz math = new Quiz("math");
            Quiz geography = new Quiz("geography");
            AllQuizez.Add(football);
            AllQuizez.Add(math);
            AllQuizez.Add(geography);  
            

            foreach (Question question in AllQuestions) 
            { 
                if (question.Category.ToLower() == "football")
                {
                    
                    football.AddQuestionToList(question);   
                }
                if (question.Category.ToLower() == "math")
                {
                    math.AddQuestionToList(question);
                }
                if (question.Category.ToLower() == "geography")
                {
                    geography.AddQuestionToList(question);
                }
            }
           return Task.CompletedTask;
            
        }
        public Question GetRandomQuestion()
        {
            
            _questions = AllQuestions;
            Random random = new Random();
            int randomIndex = random.Next(0, _questions.Count);
            if (_questions.Count == 0)
            {
                MessageBox.Show("Well done you mannaged to answer all questions correct, try to create some new quetions to play more");
                LoadQuestionsFromFile();
                _questions = AllQuestions;
               // ChooseSpecificQuizPage.RetunToStartButton_Click();
            }
            return _questions[randomIndex];
        }
        
        public Question GetEditQuestion(int ID)
        {
            var questionToEdit = AllQuestions.FirstOrDefault(question => question.Id == ID);
            MessageBox.Show(questionToEdit.Statement);

            return questionToEdit;
        }
        public void AddQuestionToList(Question question)
        { 
            if (question != null)
            {
                _questions.Add(question);
            }
            else
            {
                throw new ArgumentNullException(nameof(question), "question cannot be null");
            }
        }
        public async void AddQuestion(int id, string category, string statement, int correctAnswer, params string[] answers)
        {
            var newQuestion = new Question(id, category, statement, correctAnswer, answers);
            AllQuestions.Add(newQuestion);
            await SaveNewQuestionsToFile();
        }
        public void RemoveQuestionFromQuiz(int index)
        {
            _questions.RemoveAt(index);
            MessageBox.Show("Question removed from Quiz");
           // SaveQuizezToFile();

         
        }
        public void AddQuestionToQuiz(Question question)
        {
            _questions.Add(question);
            MessageBox.Show("Question added to Quiz");
            SaveQuizezToFile();

          

        }
        public void RemoveQuestion(int ID)
        {
            var removeQuestion = _questions.FirstOrDefault(question => question.Id == ID);
            if (removeQuestion != null) 
            { 
                _questions.Remove(removeQuestion);
            }
            else
            {
                Console.WriteLine("Question not found");
            }
           
        }
        public int GetNextID()
        {
            int ID = AllQuestions.Count + 1;
            return ID;
        }
        public List<Question> LoadQuestionsFromFile()
        {
            string folderName = "AppDataTest2";
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppDataPath, folderName);
            string textFilePath = Path.Combine(folderPath, "QuestionList.txt");

            var fileContent = File.ReadAllText(textFilePath);
            var Dson = JsonConvert.DeserializeObject<List<Question>>(fileContent);
            if (Dson == null)
            {
                return new List<Question>();
            }
            AllQuestions = Dson;
            return AllQuestions;
        }
        public Task SaveQuizezToFile()
        {
            
            string folderName = "AppDataTest2";
            var localAppDataPath = Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppDataPath, folderName);
            string textFilePath = Path.Combine(folderPath, "AllQuizezList.txt");
            
            var Json = JsonConvert.SerializeObject(AllQuizez, Formatting.Indented);
            File.WriteAllText(textFilePath, Json);  
            return Task.CompletedTask;
        }
        public List<Quiz> LoadQuizezFromFile()
        {
              string folderName = "AppDataTest2";
              var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
              string folderPath = Path.Combine(localAppDataPath, folderName);
              string textFilePath = Path.Combine(folderPath, "AllQuizezList.txt");
              var fileContet = File.ReadAllText(textFilePath);

              var Dson = JsonConvert.DeserializeObject<List<Quiz>>(fileContet);
              if (Dson == null)
              {
                  return new List<Quiz>();
              }

              AllQuizez = Dson;
              return AllQuizez;
        }
        public Task SaveNewQuestionsToFile()
        {
            
            string folderName = "AppDataTest2";
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppDataPath, folderName);
            string textFilePath = Path.Combine(folderPath, "QuestionList.txt");

            var Json = JsonConvert.SerializeObject(AllQuestions, Formatting.Indented);
            File.WriteAllText(textFilePath, Json);
            return Task.CompletedTask;  
        }
        public void GenerateQuestions()
        {
            AddQuestion(1, "football", "What number does Lionel Messi usually wear on his jersey?", 0, new string[] { "10", "7", "14" });
            AddQuestion(2, "football", "Which team won the FIFA World Cup 2018?", 0, new string[] { "France", "Croatia", "Belgium" });
            AddQuestion(3, "football", "Who is the world's most expensive football player in terms of transfer fee?", 2, new string[] { "Neymar", "Lionel Messi", "Cristiano Ronaldo" });
            AddQuestion(4, "football", "Which country is known for the football player Pelé?", 0, new string[] { "Brazil", "Argentina", "Germany" });
            AddQuestion(5, "football", "Who won the Ballon d'Or in 2021?", 0, new string[] { "Lionel Messi", "Robert Lewandowski", "Mohamed Salah" });
            AddQuestion(6, "football", "Which football team is known as 'The Red Devils'?", 0, new string[] { "Manchester United", "AC Milan", "Bayern Munich" });
            AddQuestion(7, "football", "Who is known as 'CR7' in the football world?", 0, new string[] { "Cristiano Ronaldo", "Cesc Fàbregas", "Carlos Tevez" });
            AddQuestion(8, "football", "Which football club is known for playing at Camp Nou stadium?", 0, new string[] { "FC Barcelona", "Real Madrid", "Manchester United" });
            AddQuestion(9, "football", "Who is the world's most famous football coach, known as 'The Special One'?", 0, new string[] { "José Mourinho", "Pep Guardiola", "Jürgen Klopp" });
            AddQuestion(10, "football", "Which national team won Copa America 2021?", 1, new string[] { "Argentina", "Brazil", "Uruguay" });
            AddQuestion(11, "math", "What is the result of 2 + 3?", 2, new string[] { "4", "6", "5" });
            AddQuestion(12, "math", "What is the square root of 49?", 0, new string[] { "7", "6", "8" });
            AddQuestion(13, "math", "What is 9 multiplied by 8?", 0, new string[] { "72", "64", "81" });
            AddQuestion(14, "math", "What is 15 divided by 3?", 1, new string[] { "3", "5", "6" });
            AddQuestion(15, "math", "What is the result of 4 squared?", 1, new string[] { "8", "16", "12" });
            AddQuestion(16, "math", "What is the value of π (pi) to two decimal places?", 0, new string[] { "3.14", "3.16", "3.12" });
            AddQuestion(17, "math", "What is the sum of the angles in a triangle?", 0, new string[] { "180 degrees", "90 degrees", "270 degrees" });
            AddQuestion(18, "math", "What is the next prime number after 29?", 2, new string[] { "27", "33", "31" });
            AddQuestion(19, "math", "What is the area of a square with a side length of 5 units?", 1, new string[] { "20 square units", "25 square units", "15 square units" });
            AddQuestion(20, "math", "What is the perimeter of a rectangle with length 8 units and width 6 units?", 0, new string[] { "28 units", "32 units", "24 units" });
            AddQuestion(21, "geography", "What is the capital city of France?", 0, new string[] { "Paris", "London", "Berlin" });
            AddQuestion(22, "geography", "Which river is the longest in the world?", 1, new string[] { "Nile", "Amazon", "Mississippi" });
            AddQuestion(23, "geography", "In which continent is the Sahara Desert located?", 0, new string[] { "Africa", "Asia", "South America" });
            AddQuestion(24, "geography", "Which mountain range spans across several countries including Nepal and Bhutan?", 0, new string[] { "Himalayas", "Andes", "Alps" });
            AddQuestion(25, "geography", "What is the largest ocean on Earth?", 0, new string[] { "Pacific Ocean", "Atlantic Ocean", "Indian Ocean" });
            AddQuestion(26, "geography", "Which country is known as the Land of the Rising Sun?", 2, new string[] { "South Korea", "China", "Japan" });
            AddQuestion(27, "geography", "What is the smallest country in the world by land area?", 0, new string[] { "Vatican City", "Monaco", "Nauru" });
            AddQuestion(28, "geography", "Which African country is known as the Rainbow Nation?", 0, new string[] { "South Africa", "Nigeria", "Kenya" });
            AddQuestion(29, "geography", "What is the longest river in Europe?", 0, new string[] { "Volga", "Danube", "Thames" });
            AddQuestion(30, "geography", "Which country is the southernmost in Africa?", 0, new string[] { "South Africa", "Namibia", "Botswana" });
            }
        public async void GenerateFolder()
        {
            
            string folderName = "AppDataTest2";
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppDataPath, folderName);

            var Json = JsonConvert.SerializeObject(AllQuestions, Formatting.Indented);

            try
            {
                if(!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    MessageBox.Show("Folder Cretared");
                    
                    string Filepath = Path.Combine(folderPath, "QuestionList.txt");
                    File.WriteAllText(Filepath, Json);
                    GenerateQuestions();
                    await GenerateQuizez();
                    await SaveNewQuestionsToFile();
                    await SaveQuizezToFile();
                }
                else
                {
                    MessageBox.Show("Folder exists");
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
 }
