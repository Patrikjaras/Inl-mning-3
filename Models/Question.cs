using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning_3.Models
{
    public class Question
    {
        public int Id { get; }
        public string Category { get; set; }
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public string? ImagePath { get; set; }
        


     //   public Question(int id, string category, string statement, int correctanswer, string[] answers)
     //   {
     //       Id = id;
     //       Category = category;
     //       Statement = statement;
     //       CorrectAnswer = correctanswer;
     //       Answers = answers;
     //
     //   }
        public Question(int id, string category, string statement, int correctanswer, string imagePath, string[] answers )
        {
            Id = id;
            Category = category;
            Statement = statement;
            CorrectAnswer = correctanswer;
            ImagePath = imagePath;
            Answers = answers;
           

        }
    }
}
