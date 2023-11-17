using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library {
    public class SelectCorrect{
        private List<Question> questions;

        public SelectCorrect() {
            this.questions = new List<Question>();
        }

        // Setters

        public void setQuestionsList(List<Question> questions) { 
            this.questions = questions;            
        }

        public void setQuestionValue(int index,bool value) {
            if (this.questions[index] != null) {
                this.questions[index].setCorrect(value);
            }
        }

        public void setQuestion(int index, string question) {
            if (this.questions[index] != null) {
                this.questions[index].setQuestion(question);
            }
        }

        // Getters

        public List<Question> getQuestions() { 
            return this.questions;
        }

        public List<Question> getCorrectQuestions() {
            List<Question> correctOnes;

            if (questions != null) {
                correctOnes = new List<Question>();
                foreach(Question question in questions) {
                    if(question.isCorrect() == true) {
                        correctOnes.Add(question);
                    }
                }
                return correctOnes;
            } else {
                return null;
            }
        }

        public Question getQuestion(int index) {
            if (this.questions[index] != null) {
                return this.questions[index];
            } else {
                return null;
            }     
        }

        public bool isCorrect(int index) {
            if (this.questions[index] != null) {
                return questions[index].isCorrect();
            }else { 
                return false;
            }
        }

        public string getQuestionString(int index) {
            if (this.questions[index] != null) {
                return this.questions[index].getQuestion();
            } else {
                return null;
            }
        }

        public bool isMultiple() {
            int i, count=0;


                for(i=0;i<this.questions.Count;i++) {
                    if (this.questions[i].isCorrect()) {
                        count++;
                    }
                }

                if (count > 1) {
                    return true;
                } else {
                    return false;
                }

        }

        // Methods
        
        public void setQuestions(List<Question> questions) {
            this.questions = questions;
        }

        public void addQuestion(string question, bool isCorrect) {
            Question newOne = new Question(question, isCorrect);
            this.questions.Add(newOne);
        }

        public void removeQuestion(int index) { 
            this.questions.RemoveAt(index);
        }
    }
}
