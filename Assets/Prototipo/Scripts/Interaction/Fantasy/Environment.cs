using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Library;

namespace Library {
    public class Environment {

        private Stages stages;              // Game stages
        private Player player;              // Player properties and current stats

        public Environment() {
            this.stages = new Stages();
            this.player = new Player();
        }

        public int getCurrentStage() {
            return this.stages.getCurrentStage();
        }

        public Stages getStages() {
            return this.stages;
        }

        public List<Stage> getStageList() {
            return this.stages.getStageList();
        }

        public void setStages(Stages stages) {
            this.stages = stages;
        }

        public Stage getStage(int index) {
            return this.stages.getStage(index);
        }

        public Step getStageStep(int stageIndex, int stepIndex) {
            return this.stages.getStage(stageIndex).getStep(stepIndex);
        }

        public string getStageName(int index) {
            return this.stages.getStage(index).getName();
        }

        public string getStageDescription(int index) {
            return this.stages.getStage(index).getDescription();
        }

        public int getStagesSize() {
            return this.stages.getStagesSize();
        }

        // Adding stages to the game

        public void addStage(Stage stage) {
                this.stages.addStage(stage);
        }

        public void addStage(string name, string description) {
            this.stages.addStage(name, description);
        }

        public Stage removeStage(int index) {
            return this.stages.removeStage(index);
        }

        public bool isDoneStage(int stageIndex) {
            if(stageIndex >= 0) {
                return this.stages.isDoneStage(stageIndex);
            } else {
                return true;
            }
        }

        // Adding steps to certain stage

        public void addStepToStage(int index, string title, string description) {
            stages.getStage(index).addStep(title, description);
        }

        public Step removeStepFromStage(int stageIndex, int stepIndex) {
            return stages.getStage(stageIndex).removeStep(stepIndex);
        }

        public void setStageStepTotem(int stageIndex, int stepIndex, GameObject totem) {
            stages.getStage(stageIndex).setTotemOnStep(stepIndex, totem);
        }

        public GameObject getTotemFromStep(int stageIndex, int stepIndex) {
            return stages.getStage(stageIndex).getStep(stepIndex).getTotem();
        }

        // Sets "stepIndex" step done from "stageIndex" stage.
        public void setStepStatus(int stageIndex, int stepIndex, bool done) {
            this.stages.setStepStatus(stageIndex, stepIndex, done);
        }

        // Returns status of a "stepIndex" step from "stageIndex" stage.
        public bool getStepStatus(int stageIndex, int stepIndex) {
            return this.stages.getStepStatus(stageIndex, stepIndex);
        }
        
        public int getStepSize(int stageIndex) {
            return this.stages.getStepSize(stageIndex);
        }

        // Score methods

        public void updateScore() {
            this.stages.calculateScoreValue();
        }
        
        public void calculateFinalScore() {
            this.stages.calculateFinalScore();
        }

        public int getTotalScore() {
            return this.stages.getTotalScore();   
        }

        public int getScoreValue() {
            return this.stages.getScoreValue();
        }

        // Sets the score goal of a step, this method is usually called after a new step is created
        public void setStepScoreValue(int stageIndex, int stepIndex, int scoreValue) {
            this.getStage(stageIndex).setStepScoreValue(stepIndex, scoreValue);
            this.updateScore();
        }

        // Sets the score of a step, this method is usually called after the player finished the step
        public void setStepTotalScore(int stageIndex, int stepIndex, int totalScore) {
            this.getStage(stageIndex).setStepTotalScore(stepIndex, totalScore);
            this.calculateFinalScore();
        }

        // Player stuff

        public void setPlayer(Player player) {
            this.player = player;
        }

        public Player getPlayer() {
            return this.player;
        }

        // Step Question stuff

        // Getters

        public List<Question> getQuestions(int stageIndex, int stepIndex) {
            return this.stages.getQuestions(stageIndex,stepIndex);
        }

        public List<Question> getCorrectQuestions(int stageIndex, int stepIndex) {
            return this.stages.getCorrectQuestions(stageIndex,stepIndex);
        }

        public Question getQuestion(int stageIndex, int stepIndex, int questionIndex) {
            return this.stages.getQuestion(stageIndex, stepIndex, questionIndex);
        }

        public bool isCorrect(int stageIndex, int stepIndex, int questionIndex) {
            return this.stages.isCorrect(stageIndex, stepIndex, questionIndex);
        }

        public string getQuestionString(int stageIndex, int stepIndex, int questionIndex) {
            return this.stages.getQuestionString(stageIndex, stepIndex, questionIndex);
        }

        public bool isMultiple(int stageIndex, int stepIndex) {
            return this.stages.isMultiple(stageIndex,stepIndex);
        }

        // Methods

        public void setQuestions(int stageIndex, int stepIndex, List<Question> questions) {
            this.stages.setQuestions(stageIndex, stepIndex, questions);
        }

        public void addQuestion(int stageIndex, int stepIndex, string question, bool isCorrect) {
            this.stages.addQuestion(stageIndex, stepIndex, question, isCorrect);
        }

        public void removeQuestion(int stageIndex, int stepIndex, int questionIndex) {
            this.stages.removeQuestion(stageIndex, stepIndex, questionIndex);
        }

        //======================================================
        // Receptionist and Tips stuff
        //
        // Getters

        public int getRQsize(int stageIndex) {
            return this.stages.getRQsize(stageIndex);
        }

        public List<SelectCorrect> getRQList(int stageIndex) {
            return this.stages.getRQList(stageIndex);
        }

        public List<Question> getRQItems(int stageIndex, int listIndex) {
            return this.stages.getRQItems(stageIndex, listIndex);
        }

        public List<Question> getCorrectRQs(int stageIndex, int listIndex) {
            return this.stages.getCorrectRQs(stageIndex, listIndex);
        }

        public string getRQTitle(int stageIndex, int listIndex) {
            return this.stages.getRQTitle(stageIndex, listIndex);
        }

        public Question getRQ(int stageIndex, int listIndex, int questionIndex) {
            return this.stages.getRQ(stageIndex, listIndex, questionIndex);
        }

        public bool isRQCorrect(int stageIndex, int listIndex, int questionIndex) {
            return this.stages.isRQCorrect(stageIndex, listIndex, questionIndex);
        }

        public string getRQString(int stageIndex, int listIndex, int questionIndex) {
            return this.stages.getRQString(stageIndex, listIndex, questionIndex);
        }

        public bool isRQMultiple(int stageIndex, int listIndex) {
            return this.stages.isRQMultiple(stageIndex, listIndex);
        }

        // Setters

        public void setRQs(int stageIndex, int listIndex, List<Question> questions) {
            this.stages.setRQs(stageIndex, listIndex, questions);
        }

        public void setRQValue(int stageIndex, int listIndex, int index, bool value) {
            this.stages.setRQValue(stageIndex, listIndex, index, value);
        }
        public void setRQ(int stageIndex, int listIndex, int index, string question) {
            this.stages.setRQ(stageIndex, listIndex, index, question);
        }

        // Methods

        public void setRQTitle(int stageIndex, int listIndex, string title) {
            this.stages.setRQTitle(stageIndex, listIndex, title);
        }

        public void addRQ(int stageIndex, int listIndex, string question, bool isCorrect) {
            this.stages.addRQ(stageIndex, listIndex, question, isCorrect);
        }

        public void removeRQ(int stageIndex, int listIndex, int index) {
            this.stages.removeRQ(stageIndex, listIndex, index);
        }

        //===========================================================
        // TIPS

        public void setTips(int stageIndex, List<Tips> list) {
            this.stages.setTips(stageIndex, list);
        }

        public List<Tips> getTips(int stageIndex) {
            return this.stages.getTips(stageIndex);
        }

        public Tips getTip(int stageIndex, int index) {
            return this.stages.getTip(stageIndex, index);
        }

        public void addTip(int stageIndex, Tips tip) {
            this.stages.addTip(stageIndex, tip);
        }

        public void removeTip(int stageIndex, int index) {
            this.stages.removeTip(stageIndex, index);
        }

        // Setters and getters

        public int getTipId(int stageIndex, int index) {
            return this.stages.getTipId(stageIndex, index);
        }

        public string getTipTitle(int stageIndex, int index) {
            return this.stages.getTipTitle(stageIndex, index);
        }

        public string getTipString(int stageIndex, int index) {
            return this.stages.getTipString(stageIndex, index);
        }

        public void setTipId(int stageIndex, int index, int id) {
            this.stages.setTipId(stageIndex, index, id);
        }

        public void setTipTitle(int stageIndex, int index, string title) {
            this.stages.setTipTitle(stageIndex, index, title);
        }

        public void setTipString(int stageIndex, int index, string tipString) {
            this.stages.setTipString(stageIndex, index, tipString);
        }
    }
}
