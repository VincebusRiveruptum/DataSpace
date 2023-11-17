using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;

namespace Library {
    public class Question{

        private string question;
        private bool value;
    
        public Question(string question, bool isCorrect) {
            this.question = question;
            this.value = isCorrect;
        }

        public string getQuestion() { 
            return this.question; 
        }

        public bool isCorrect() { 
            return this.value;
        }

        public void setQuestion(string question) {
            this.question = question;
        }

        public void setCorrect(bool isCorrect) {
            this.value = isCorrect;
        }
    }
    
}
