//QuestionAnswer.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_4
{
    class QuestionAnswer
    {
        //private question, answer
        private String question;
        private String answer;

        //constructor
        public QuestionAnswer()
        {
            question = "None";
            answer = "None";
        }

        //parameterized constructor
        public QuestionAnswer(String question, String answer)
        {
            this.question = question;
            this.answer = answer;
        }

        //getter and setter for question
        public String Question
        {
            get
            {
                return question;
            }
            set
            {
                this.question = value;
            }
        }

        //getter and setter for answer
        public String Answer
        {
            get
            {
                return answer;
            }
            set
            {
                this.answer = value;
            }
        }
    }
}
