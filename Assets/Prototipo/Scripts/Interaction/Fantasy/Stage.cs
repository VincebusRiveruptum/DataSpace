using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Library;
namespace Library {
    public class Stage {
        public string name;
        public string description;
        private List<Step> stepList;

        private int doneSteps;

        private int scoreValue;             // Stage score goal 
        private int finalScore;             // Stage total score gotten

        private ReceptionQuestions rq;      // Receptionist questions according to the current stage
        private ReceptionTips rt;           // Receptionist tips according to the current stage


        private bool done;

        public Stage() {
            this.name = string.Empty;
            this.description = string.Empty;
            this.stepList = new List<Step>();
            this.rq = new ReceptionQuestions();
            this.rt = new ReceptionTips();
            this.scoreValue = 0;
            this.finalScore = 0;
            this.doneSteps = 0;
            this.done = false;
        }

        public Stage(string name, string description) {
            this.name = name;
            this.description = description;
            this.stepList = new List<Step>();
            this.rq = new ReceptionQuestions();
            this.rt = new ReceptionTips();
            this.scoreValue = 0;
            this.finalScore = 0;
            this.doneSteps = 0;
            this.done = false;
        }

        public string getName() {
            return this.name;
        }

        public string getDescription() {
            return this.description;
        }

        public List<Step> getStepList() {
            return this.stepList;
        }

        public int getFinalScore() {
            return this.finalScore;
        }

        public int getScoreValue() {
            return this.scoreValue;
        }

        public void setName(string name) {
            this.name = name;
        }

        public void setDescription(string description) {
            this.description = description;
        }

        public void setStepList(List<Step> list) {
            this.stepList = list;
        }

        public void setDoneSteps(int doneSteps) {
            this.doneSteps = doneSteps;
        }


        // Methods

        public void addStep(Step step) {
            this.stepList.Add(step);
            this.calculateScoreValue();
        }

        public void addStep(string title, string description) {
            Step newStep = new Step(title, description);
            this.stepList.Add(newStep);
            this.calculateScoreValue();
        }

        public Step removeStep(int index) {
            Step removedOne = this.stepList[index];
            if (removedOne != null) {
                this.stepList.RemoveAt(index);
                this.calculateScoreValue();
                return removedOne;
            } else {
                this.calculateScoreValue();
                return null;
            }
        }

        public Step getStep(int index) {
            return this.stepList[index];
        }

        public int getStepSize() {
            return this.stepList.Count;
        }

        // Sets a "index" step done from the list

        public string getStepTitle(int stepIndex) {
            return this.stepList[stepIndex].getTitle();
        }

        public string getStepDescription(int stepIndex) {
            return this.stepList[stepIndex].getDescription();

        }

        public void setStepStatus(int stepIndex, bool stat) {

            // if the last totem is going to be done, then the stage is done
            if (stepIndex == this.stepList.Count - 1) {
                
                if(stat == true) {
                    this.done = true;
                    //Debug.Log("This is the last totem on the stage! - The total steps on this totem are " + (stepIndex + 1) + "/" + (this.stepList.Count) + "Stage done : " + this.done);
                }
            }

            this.stepList[stepIndex].setDone(stat);



            this.calculateFinalScore();
        }

        // Sets the score goal of a step, this method is usually called after a new step is created
        public void setStepScoreValue(int stepIndex, int scoreValue) {
            this.stepList[stepIndex].setScoreValue(scoreValue); 
            this.calculateScoreValue();         
        }

        // Sets the score of a step, this method is usually called after the player finished the step
        public void setStepTotalScore(int stepIndex, int totalScore) {
            this.stepList[stepIndex].setTotalScore(totalScore);
            this.calculateFinalScore();
        }

        public int getDoneSteps() {
            return this.doneSteps;
        }

        public bool getStepStatus(int stepIndex) {
            if(stepIndex >= 0) {
                return this.stepList[((int)stepIndex)].getStatus();
            } else {
                return true;
            }
        }

        public bool isDone() {
            return this.done;
        }

        // Methods about totem GameObjects inside steps

        public void setTotemOnStep(int index, GameObject totem) {
            this.stepList[(int)index].setTotem(totem);
        }

        public GameObject getTotemOnStep(int index) {
            return this.stepList[(int)index].getTotem();
        }

        public GameObject removeTotemOnStep(int index) {
            GameObject removedOne = getTotemOnStep((int)index);
            if (removedOne != null) {
                this.stepList.RemoveAt(index);
                return removedOne;
            } else {
                return null;
            }
        }

        // gets total score of the steps on the stages, this method is called each time a step is added or removed on a stage.
        public void calculateScoreValue() {
            int scoreValue = 0;
            foreach(Step step in stepList) {
                scoreValue = scoreValue + step.getScoreValue();
            }
            this.scoreValue = scoreValue;
        }

        // get final score sum of the steps,this method is called when the stage is done
        public void calculateFinalScore() {
            int finalScore = 0, doneSteps = 0;
            foreach(Step step in stepList) {
                if(step.getStatus() == true) {         // true is "step done"
                    finalScore = finalScore + step.getTotalScore();
                    doneSteps++;
                }

            }
            this.doneSteps = doneSteps;
            this.finalScore = finalScore;
        }

        // stepList Question stuff

        // Getters

        public List<Question> getQuestions(int stepIndex) {
            return this.stepList[stepIndex].getQuestions();
        }

        public List<Question> getCorrectQuestions(int stepIndex) {
            return this.stepList[stepIndex].getCorrectQuestions();
        }

        public Question getQuestion(int stepIndex, int questionIndex) {
            return this.stepList[stepIndex].getQuestion(questionIndex);
        }

        public bool isCorrect(int stepIndex, int questionIndex) {
            return this.stepList[stepIndex].getQuestion(questionIndex).isCorrect();
        }

        public string getQuestionString(int stepIndex, int questionIndex) {
            return this.stepList[stepIndex].getQuestion(questionIndex).getQuestion();
        }

        public bool isMultiple(int stepIndex) {
            return this.stepList[stepIndex].isMultiple();
        }

        // Methods

        public void setQuestions(int stepIndex, List<Question> questions) {
            this.stepList[stepIndex].setQuestions(questions);
        }

        public void addQuestion(int stepIndex, string question, bool isCorrect) {
            this.stepList[stepIndex].addQuestion(question, isCorrect);
        }

        public void removeQuestion(int stepIndex, int questionIndex) {
            this.stepList[stepIndex].removeQuestion(questionIndex);
        }

        //====================================================================
        // Reception and Tips stuff
        // RECEPTION setters and getters

        // Setters

        public int getRQsize() {
            return this.rq.getRQsize();
        }

        public List<SelectCorrect> getRQList() {
            return this.rq.getRQList();
        }

        public List<Question> getRQItems(int listIndex) {
            return this.rq.getQuestionItems(listIndex);
        }

        public List<Question> getCorrectRQs(int listIndex) {
            return this.rq.getCorrectQuestions(listIndex);
        }

        public string getRQTitle(int listIndex) {
            return this.rq.getTitle(listIndex);
        }

        public Question getRQ(int listIndex, int questionIndex) {
            return this.rq.getQuestion(listIndex, questionIndex);
        }

        public bool isRQCorrect(int listIndex, int questionIndex) {
            return this.rq.isCorrect(listIndex, questionIndex);
        }

        public string getRQString(int listIndex, int questionIndex) {
            return this.rq.getQuestionString(listIndex,questionIndex);
        }

        public bool isRQMultiple(int listIndex) {
            return this.rq.isMultiple(listIndex);
        }

        // Setters

        public void setRQs(int listIndex, List<Question> questions) {
            this.rq.setQuestionsList(listIndex,questions);
        }

        public void setRQValue(int listIndex, int index, bool value) {
            this.rq.setQuestionValue(listIndex, index, value);
        }
        public void setRQ(int listIndex, int index, string question) {
            this.rq.setQuestion(listIndex, index, question);
        }

        // Methods

        public void setRQTitle(int listIndex, string title) {
            this.rq.setTitle(listIndex, title);
        }

        public void addRQ(int listIndex, string question, bool isCorrect) {
            this.rq.addQuestion(listIndex, question, isCorrect);
        }

        public void removeRQ(int listIndex, int index) {
            this.rq.removeQuestion(listIndex, index);
        }

        //===========================================================
        // TIPS

        public void setTips(List<Tips> list) {
            this.rt.setTips(list);
        }

        public List<Tips> getTips() {
            return this.rt.getTips();
        }

        public Tips getTip(int index) {
            return this.rt.getTip(index);   
        }

        public void addTip(Tips tip) {
            this.rt.addTip(tip);
        }

        public void removeTip(int index) {
            this.rt.removeTip(index);
        }

        // Setters and getters

        public int getId(int index) {
            return this.rt.getId(index);
        }

        public string getTitle(int index) {
            return this.rt.getTitle(index);
        }

        public string getTipString(int index) {
            return this.rt.getTipString(index);
        }

        public void setId(int index, int id) {
            this.rt.setId(index, id);
        }

        public void setTitle(int index, string title) {
            this.rt.setTitle(index, title);
        }

        public void setTipString(int index, string tipString) {
            this.rt.setTipString(index, tipString);
        }
    }
}