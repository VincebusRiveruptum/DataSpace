using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library {
    public class Stages {
        private List<Stage> stageList;

        private int doneStages;

        private int scoreValue;             // Score goal of the entire game
        private int finalScore;             // Total score gotten

        private bool done;

        public Stages() {
            this.stageList = new List<Stage>();
            this.scoreValue = 0;
            this.finalScore = 0;
            this.doneStages = 0;
            this.done = false;
        }

        public List<Stage> getStageList() {
            return this.stageList;
        }

        public int getDoneStages() {
            return this.doneStages;
        }

        public int getScoreValue() {
            return this.scoreValue;
        }

        public int getTotalScore() {
            return this.scoreValue;
        }

        public Stage getStage(int index) {
            return this.stageList[index];
        }

        public Step getStageStep(int stageIndex, int stepIndex) {
            return this.stageList[stageIndex].getStep(stepIndex);
        }

        public void setDoneStages(int doneStages) {
            this.doneStages = doneStages;
        }

        public int getStagesSize() {
            return this.stageList.Count;
        }

        // Stage list methods

        public void addStage(Stage stage) {
            this.stageList.Add(stage);
            this.calculateScoreValue();
        }

        public void addStage(string name, string description) {
            Stage newStage = new Stage(name, description);
            this.stageList.Add(newStage);
            this.calculateScoreValue();
        }

        public Stage removeStage(int index) {
            Stage removedOne = this.stageList[index];

            if(removedOne != null) {
                this.stageList.RemoveAt(index);
                this.calculateScoreValue();
                return removedOne;
            } else {
                return null;
            }          
        }

        // gets total score on the stage, this method is called each time a new stage is added, after being modified or removed.
        public void calculateScoreValue() {
            int scoreValue = 0;
            foreach (Stage stage in stageList) {
                stage.calculateScoreValue();                                // Update score value of all steps on the stages
                scoreValue = scoreValue + stage.getScoreValue();    // sum with previous sum
            }
            this.scoreValue = scoreValue;
        }

        // get final score sum of the stages,this method is called when the game ended
        public void calculateFinalScore() {
            int finalScore = 0, doneStages = 0;
            foreach (Stage stage in stageList) {
                if (stage.isDone() == true) {         // true is "stage done"
                    finalScore = finalScore + stage.getFinalScore();
                    doneStages++;
                }

            }
            this.doneStages = doneStages;
            this.finalScore = finalScore;

            // If the sum of all scores equal to the total value assigned, then the game is done
            /*
            if (this.finalScore >= this.scoreValue) {
                this.done = true;
            } else {
                this.done = false;
            }
            */
        }

        // Returns true if all steps in stage "stageIndex" are done, returns false if not
        public bool isDoneStage(int stageIndex) {
            if(stageIndex >= 0) {
                return this.stageList[stageIndex].isDone();
            } else {
                return true;
            }
        }

        // Sets an i step done from the list of stages.
        public void setStepStatus(int stageIndex, int stepIndex, bool done) {
            this.stageList[(int)stageIndex].setStepStatus(stepIndex, done);

   
        }

        // Returns status of a "stepIndex" step from "stageIndex" stage.
        public bool getStepStatus(int stageIndex, int stepIndex) {
            return this.stageList[((int)stageIndex)].getStepStatus(stepIndex);
        }

        public int getStepSize(int stageIndex) {
            return this.stageList[stageIndex].getStepSize();
        }

        // Sets the score goal of a step, this method is usually called after a new step is created
        public void setStepScoreValue(int stageIndex, int stepIndex, int scoreValue) {
            this.stageList[stageIndex].setStepScoreValue(stepIndex, scoreValue);
            this.calculateScoreValue();
        }

        // Sets the score of a step, this method is usually called after the player finished the step
        public void setStepTotalScore(int stageIndex, int stepIndex, int totalScore) {
            this.stageList[stageIndex].setStepTotalScore(stepIndex, totalScore);
            this.calculateFinalScore();
        }

        // Question stuff

        // Getters

        public List<Question> getQuestions(int stageIndex, int stepIndex) {
            return this.stageList[stageIndex].getQuestions(stepIndex);
        }

        public List<Question> getCorrectQuestions(int stageIndex, int stepIndex) {
            return this.stageList[stageIndex].getCorrectQuestions(stepIndex);
        }

        public Question getQuestion(int stageIndex, int stepIndex, int questionIndex) {
            return this.stageList[stageIndex].getQuestion(stepIndex, questionIndex);
        }

        public bool isCorrect(int stageIndex, int stepIndex, int questionIndex) {
            return this.stageList[stageIndex].getQuestion(stepIndex,questionIndex).isCorrect();
        }

        public string getQuestionString(int stageIndex, int stepIndex, int questionIndex) {
            return this.stageList[stageIndex].getQuestion(stepIndex, questionIndex).getQuestion();
        }

        public bool isMultiple(int stageIndex, int stepIndex) {
            return this.stageList[stageIndex].isMultiple(stepIndex);
        }



        // Methods

        public void setQuestions(int stageIndex, int stepIndex, List<Question> questions) {
            this.stageList[stageIndex].setQuestions(stepIndex, questions);
        }

        public void addQuestion(int stageIndex, int stepIndex, string question, bool isCorrect) {
            this.stageList[stageIndex].addQuestion(stepIndex, question, isCorrect);
        }

        public void removeQuestion(int stageIndex, int stepIndex, int questionIndex) {
            this.stageList[stageIndex].removeQuestion(stepIndex, questionIndex);
        }


    }
}
