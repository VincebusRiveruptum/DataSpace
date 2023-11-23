using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;

namespace Library {
    public class ReceptionQuestions {
        private List<SelectCorrect> rq;

        public ReceptionQuestions() {
            this.rq = new List<SelectCorrect>();
        }

        public int getRQsize() {
            return rq.Count;
        }

        public List<SelectCorrect> getRQList() {
            return this.rq;
        }

        public List<Question> getQuestionItems(int listIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getQuestions();
            } else {
                return null;
            }
        }

        public List<Question> getCorrectQuestions(int listIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getCorrectQuestions();
            } else {
                return null;
            }
        }

        public string getTitle(int listIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getTitle();
            } else {
                return null;
            }
        }

        public Question getQuestion(int listIndex, int questionIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getQuestion(questionIndex);
            } else {
                return null;
            }
        }

        public bool isCorrect(int listIndex, int questionIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getQuestion(questionIndex).isCorrect();
            } else {
                return false;
            }
        }

        public string getQuestionString(int listIndex, int questionIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].getQuestion(questionIndex).getQuestion();
            } else {
                return null;
            }
        }

        public bool isMultiple(int listIndex) {
            if(this.rq[listIndex] != null) {
                return this.rq[listIndex].isMultiple();
            }else { return false; }
        }

        // Setters

        public void setQuestionsList(int listIndex, List<Question> questions) {
            if(this.rq[listIndex] != null) {
                this.rq[listIndex].setQuestionsList(questions);           
            }
        }

        public void setQuestionValue(int listIndex, int index, bool value) {
            if(this.rq[listIndex] != null) {
                this.rq[listIndex].setQuestionValue(index, value);
            }
        }
        public void setQuestion(int listIndex, int index, string question) {
            if(this.rq[listIndex] != null) {
                this.rq[listIndex].setQuestion(index, question);
            }
        }

        // Methods

        public void setTitle(int listIndex, string title) {
            if(this.rq[listIndex] != null) {
                this.rq[listIndex].setTitle(title); 
            }
        }

        public void addQuestion(int listIndex, string question, bool isCorrect) {
            Question newOne = new Question(question, isCorrect);

            if(this.rq[listIndex] != null) {
                this.rq[listIndex].addQuestion(newOne);
            }
        }

        public void removeQuestion(int listIndex, int index) {
            if(this.rq[listIndex] != null) { 
                this.rq[listIndex].removeQuestion(index);
            }
        }
    }
}
 


