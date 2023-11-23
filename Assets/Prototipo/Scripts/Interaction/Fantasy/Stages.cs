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
            return this.finalScore;
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

        public int getCurrentStage() {
            int i = 0;

            while(this.stageList[i].isDone()) {
                i++;
            }
            return i;
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
                stage.calculateScoreValue();                                        // Update score value of all steps on the stages
                scoreValue = scoreValue + stage.getScoreValue();                    // sum with previous sum
            }
            this.scoreValue = scoreValue;
        }

        // get final score sum of the stages,this method is called when the game ended
        public void calculateFinalScore() {
            int finalScore = 0, doneStages = 0;
            foreach (Stage stage in stageList) {
                if (stage.isDone() == true) {                                       // true is "stage done"
                    finalScore = finalScore + stage.getFinalScore();
                    doneStages++;
                }

            }
            this.doneStages = doneStages;
            this.finalScore = finalScore;
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

        // Step Question stuff

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

        //======================================================
        // Receptionist and Tips stuff
        //
        // Setters

        public int getRQsize(int stageIndex) {
            return this.stageList[stageIndex].getRQsize();
        }
        
        public List<SelectCorrect> getRQList(int stageIndex) {
            return this.stageList[stageIndex].getRQList();
        }

        public List<Question> getRQItems(int stageIndex, int listIndex) {
            return this.stageList[stageIndex].getRQItems(listIndex);
        }

        public List<Question> getCorrectRQs(int stageIndex, int listIndex) {
            return this.stageList[stageIndex].getCorrectRQs(listIndex);
        }

        public string getRQTitle(int stageIndex, int listIndex) {
            return this.stageList[stageIndex].getRQTitle(listIndex);
        }

        public Question getRQ(int stageIndex, int listIndex, int questionIndex) {
            return this.stageList[stageIndex].getRQ(listIndex, questionIndex);
        }

        public bool isRQCorrect(int stageIndex, int listIndex, int questionIndex) {
            return this.stageList[stageIndex].isRQCorrect(listIndex, questionIndex);
        }

        public string getRQString(int stageIndex, int listIndex, int questionIndex) {
            return this.stageList[stageIndex].getRQString(listIndex, questionIndex);
        }

        public bool isRQMultiple(int stageIndex, int listIndex) {
            return this.stageList[stageIndex].isRQMultiple(listIndex);
        }

        // Setters

        public void setRQs(int stageIndex, int listIndex, List<Question> questions) {
            this.stageList[stageIndex].setRQs(listIndex, questions);
        }

        public void setRQValue(int stageIndex, int listIndex, int index, bool value) {
            this.stageList[stageIndex].setRQValue(listIndex, index, value);
        }
        public void setRQ(int stageIndex, int listIndex, int index, string question) {
            this.stageList[stageIndex].setRQ(listIndex, index, question);
        }

        // Methods

        public void setRQTitle(int stageIndex, int listIndex, string title) {
            this.stageList[stageIndex].setRQTitle(listIndex, title);
        }

        public void addRQ(int stageIndex, int listIndex, string question, bool isCorrect) {
            this.stageList[stageIndex].addRQ(listIndex, question, isCorrect);
        }

        public void removeRQ(int stageIndex, int listIndex, int index) {
            this.stageList[stageIndex].removeRQ(listIndex, index);
        }

        //===========================================================
        // TIPS

        public void setTips(int stageIndex, List<Tips> list) {
            this.stageList[stageIndex].setTips(list);
        }

        public List<Tips> getTips(int stageIndex) {
            return this.stageList[stageIndex].getTips();
        }

        public Tips getTip(int stageIndex, int index) {
            return this.stageList[stageIndex].getTip(index);
        }

        public void addTip(int stageIndex, Tips tip) {
            this.stageList[stageIndex].addTip(tip);
        }

        public void removeTip(int stageIndex, int index) {
            this.stageList[stageIndex].removeTip(index);
        }

        // Setters and getters

        public int getTipId(int stageIndex, int index) {
            return this.stageList[stageIndex].getId(index);
        }

        public string getTipTitle(int stageIndex, int index) {
            return this.stageList[stageIndex].getTitle(index);
        }

        public string getTipString(int stageIndex, int index) {
            return this.stageList[stageIndex].getTipString(index);
        }

        public void setTipId(int stageIndex, int index, int id) {
            this.stageList[stageIndex].setId(index, id);
        }

        public void setTipTitle(int stageIndex, int index, string title) {
            this.stageList[stageIndex].setTitle(index, title);
        }

        public void setTipString(int stageIndex, int index, string tipString) {
            this.stageList[stageIndex].setTipString(index, tipString);
        }

    }
}
