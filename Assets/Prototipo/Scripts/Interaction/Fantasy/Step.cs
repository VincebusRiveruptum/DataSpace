using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library {
    public class Step {
        private string title;
        private string description;

        private int scoreValue;     // Score goal value of this totem 
        private int totalScore;     // Total gotten score

        private GameObject totem;
        /*
            Totems at the moment have hardcoded challenges or questions 
            In the future, will be possile to add questions by an external file thus 
            by the model layer.

         */

        private SelectCorrect questions;

        private bool done;

        public Step(string title, string description) {
            this.title = title;
            this.description = description;
            this.done = false;
            this.questions = new SelectCorrect();
            this.totem = null;
            this.scoreValue = 0;
        }

        public Step() {
            this.title = null;
            this.description = null;
            this.done = false;
            this.questions = new SelectCorrect();
            this.totem = null;
            this.scoreValue = 0;
        }

        public string getTitle() {
            return this.title;
        }

        public string getDescription() {
            return this.description;
        }

        public bool getStatus() {
            return this.done;
        }

        public void setTitle(string title) {
            this.title = title;
        }

        public void setDescription(string description) {
            this.description = description;
        }

        public void setDone(bool done) {
            this.done = done;
        }

        public void setTotem(GameObject totem) {
            this.totem = totem;
        }

        public void setScoreValue(int scoreValue) {
            this.scoreValue = scoreValue;
        }

        public void setTotalScore(int totalScore) {
                this.totalScore = totalScore;
        }

        public int getScoreValue() { 
            return this.scoreValue;        
        }

        public int getTotalScore() {
            return this.totalScore;
        }

        public GameObject getTotem() {
            return this.totem;
        }

        // Methods about questions

        // Setters

        public void setQuestionValue(int index, bool value) {
           this.questions.getQuestion(index).setCorrect(value);
        }

        public void setQuestion(int index, string question) {
            this.questions.getQuestion(index).setQuestion(question);
        }

        public void setCorrect(int index, bool isCorrect) {
            this.questions.getQuestion(index).setCorrect(isCorrect);
        }

        // Getters

        public List<Question> getQuestions() {
            return this.questions.getQuestions();
        }

        public List<Question> getCorrectQuestions() {
            return this.questions.getCorrectQuestions();
        }

        public Question getQuestion(int index) {
            return this.questions.getQuestion(index);
        }

        public bool isCorrect(int index) {
            if (this.questions.getQuestion(index) != null) {
                return this.getQuestion(index).isCorrect();
            } else {
                return false;
            }
        }

        public string getQuestionString(int index) {
            return this.getQuestion(index).getQuestion();
        }

        public bool isMultiple() {
            return this.questions.isMultiple();
        }

        // Methods


        public void setQuestions(List<Question> questions) {
            this.questions.setQuestions(questions);
        }

        public void addQuestion(string question, bool isCorrect) {
            this.questions.addQuestion(question,isCorrect);
        }

        public void removeQuestion(int index) {
            this.questions.removeQuestion(index);
        }

    }
}