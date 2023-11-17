using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Library;

public class Main : MonoBehaviour
{
    public Environment environment;
    // Start is called before the first frame update
    void Start()
    {
        environment = new Environment();

        // Level 0 //////////////////
        addStage("Introduction", "Brief introduction about the game and their challenges.");
        addStepToStage(0, "Welcome", "First totem greeting the player");                            // Add steps to the stage
        setStageStepTotem(0, 0, GameObject.Find("Welcome"));                                       // Add totem to the stage
        setStepScoreValue(0, 0, 10);

        addStepToStage(0, "DataSpace Library", "Totem about the library");                          // Add steps to the stage
        setStageStepTotem(0, 1, GameObject.Find("DataSpace"));                                     // Add totem to the stage
        setStepScoreValue(0, 1, 10);

        addStepToStage(0, "Challenges", "Totem about player's challenges during the game");         // Add steps to the stage
        setStageStepTotem(0, 2, GameObject.Find("Challenges"));                                    // Add totem to the stage
        setStepScoreValue(0, 2, 10);

        addStepToStage(0, "Book Loans", "Totem about the book loan information");                   // Add steps to the stage
        setStageStepTotem(0, 3, GameObject.Find("Loans"));                                         // Add totem to the stage
        setStepScoreValue(0, 3, 10);
        // Level 1 //////////////////
        addStage("First-Level", "Player has to do certain tasks...");
        addStepToStage(1, "Generic Step 1", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 0, GameObject.Find("Generic 1-1"));
        setStepScoreValue(1, 0, 10);
        loadQuestionsToStep(1, 0, GameObject.Find("Generic 1-1"));

        addStage("First-Level", "Player has to do certain tasks...");
        addStepToStage(1, "Generic Step 2", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 1, GameObject.Find("Generic 1-2"));
        setStepScoreValue(1, 1, 10);
        loadQuestionsToStep(1, 1, GameObject.Find("Generic 1-2"));

        addStage("First-Level", "Player has to do certain tasks...");
        addStepToStage(1, "Generic Step 3", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 2, GameObject.Find("Generic 1-3"));
        setStepScoreValue(1, 2, 10);
        loadQuestionsToStep(1, 2, GameObject.Find("Generic 1-3"));
        // Add totem to the stage

        // Level 2 //////////////////
        //   environment.addStage("Last-Level", "Player has to do certain tasks...");
        //   environment.addStepToStage(0, "Welcome", "First totem greeting the player");                            // Add steps to the stage
        //   environment.setStageStepTotem(0, 0, GameObject.Find("Welcome"););                                       // Add totem to the stage

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(environment.getPlayer().getCurrentStep());
        Debug.Log(environment.getTotemFromStep(0,0).name);
        Debug.Log(environment.getTotemFromStep(0, 1).name);
        Debug.Log(environment.getTotemFromStep(0, 2).name);
        Debug.Log(environment.getTotemFromStep(0, 3).name);
        */
        Debug.Log("Step 0 from stage status : " + getStepStatus(0,0));
        logStagesTotems();
        logScores();
    }

    /* Environment Methods */

    /* Testing Only */

    public void logStagesTotems() {

        // use foreach instead of the index later...
        int i, j;
        for (i = 0; i < environment.getStagesSize(); i++) {
            Debug.Log("Stage " + i + " Name: " + environment.getStageName(i) + "\t" + "Description: " + environment.getStageDescription(i) + "Status : " + environment.isDoneStage(i) + "\n");
            for (j=0; j < environment.getStepSize(i); j++) {
                Debug.Log("\t" + "Step " + j + "\t" + "Title : " + environment.getStageStep(i,j).getTitle() + "\t" + "Status: " + environment.getStageStep(i,j).getStatus() ) ;
            }
        }
    }


    public void logScores() {
        int i = 0, j = 0;      
        foreach(Stage stage in environment.getStageList()) {
            Debug.Log("Stage " + i + " total score : " + stage.getFinalScore() + "/" + stage.getScoreValue()) ;
            foreach(Step step in stage.getStepList()) {
                Debug.Log("\tStep " + j + "'" + step.getTitle() + "'" + "\tScore: " + step.getTotalScore() + "/" + step.getScoreValue()) ;
                j++;
            }
            j = 0;
            i++;
        }
    }

    public void setStepStatus(int stageIndex, int stepIndex, bool done) {
        environment.setStepStatus(stageIndex, stepIndex, done);
    }

    public bool getStepStatus(int stageIndex, int stepIndex) {
        return environment.getStepStatus(stageIndex, stepIndex);
    }

    public Stages getStages() {
        return this.environment.getStages();
    }

    public Player getPlayer() {
        return this.environment.getPlayer();
    }

    public void setStages(Stages stages) {
        this.environment.setStages(stages);
    }

    public void setPlayer(Player player) {
        this.environment.setPlayer(player);
    }

    // Getting stages

    public Stage getStage(int index) {
        return this.environment.getStage(index);
    }

    public string getStageName(int index) {
        return this.environment.getStage(index).getName();
    }

    public string getStageDescription(int index) {
        return this.environment.getStage(index).getDescription();
    }

    public int getStagesSize() {
        return this.environment.getStagesSize();
    }

    public bool isDoneStage(int stageIndex) {
        if(stageIndex >= 0) {
            return this.environment.isDoneStage(stageIndex);
        } else {
            return true;
        }
    }

    // Adding stages to the game

    public void addStage(Stage stage) {
        this.environment.addStage(stage);
    }

    public void addStage(string name, string description) {
        this.environment.addStage(name, description);
    }

    public Stage removeStage(int index) {
        return this.environment.removeStage(index);
    }
    // Adding steps to certain stage

    public void addStepToStage(int index, string title, string description) {
        environment.getStage(index).addStep(title, description);
    }

    public Step removeStepFromStage(int stageIndex, int stepIndex) {
        return environment.getStage(stageIndex).removeStep(stepIndex);
    }

    public void setStageStepTotem(int stageIndex, int stepIndex, GameObject totem) {
        environment.getStage(stageIndex).setTotemOnStep(stepIndex, totem);
    }

    public GameObject getTotemFromStep(int stageIndex, int stepIndex) {
        return environment.getStage(stageIndex).getStep(stepIndex).getTotem();
    }

    // Score methods

    public void updateScore() {
        this.environment.updateScore();
    }

    public void calculateFinalScore() {
        this.environment.calculateFinalScore();
    }

    // Sets the score goal of a step, this method is usually called after a new step is created
    public void setStepScoreValue(int stageIndex, int stepIndex, int scoreValue) {
        this.environment.getStage(stageIndex).setStepScoreValue(stepIndex, scoreValue);
        this.environment.updateScore();
    }

    // Sets the score of a step, this method is usually called after the player finished the step
    public void setStepTotalScore(int stageIndex, int stepIndex, int totalScore) {
        this.environment.getStage(stageIndex).setStepTotalScore(stepIndex, totalScore);
        this.environment.calculateFinalScore();
    }

    // Question Methods

    // Question stuff

    // Getters

    public List<Question> getQuestions(int stageIndex, int stepIndex) {
        return this.environment.getQuestions(stageIndex, stepIndex);
    }

    public List<Question> getCorrectQuestions(int stageIndex, int stepIndex) {
        return this.environment.getCorrectQuestions(stageIndex, stepIndex);
    }

    public Question getQuestion(int stageIndex, int stepIndex, int questionIndex) {
        return this.environment.getQuestion(stageIndex, stepIndex, questionIndex);
    }

    public bool isCorrect(int stageIndex, int stepIndex, int questionIndex) {
        return this.environment.isCorrect(stageIndex, stepIndex, questionIndex);
    }

    public string getQuestionString(int stageIndex, int stepIndex, int questionIndex) {
        return this.environment.getQuestionString(stageIndex, stepIndex, questionIndex);
    }

    public bool isMultiple(int stageIndex, int stepIndex) {
        return this.environment.isMultiple(stageIndex, stepIndex);
    }

    // Methods

    public void setQuestions(int stageIndex, int stepIndex, List<Question> questions) {
        this.environment.setQuestions(stageIndex, stepIndex, questions);
    }

    public void addQuestion(int stageIndex, int stepIndex, string question, bool isCorrect) {
        this.environment.addQuestion(stageIndex, stepIndex, question, isCorrect);
    }

    public void removeQuestion(int stageIndex, int stepIndex, int questionIndex) {
        this.environment.removeQuestion(stageIndex, stepIndex, questionIndex);
    }


    // Loads questions from the totem to the model

    public bool loadQuestionsToStep(int stageIndex, int stepIndex, GameObject totem) {
        Transform contents, options;
        List<Question> questionList;
        OptionProperty status;
        int i;

        if(totem != null) {
            // Go to 'Options' child gameObject inside the contents gameObject.
            contents = totem.transform.Find("Contents");

            if(contents != null) {
                options = contents.transform.Find("Options");

                // Then we get each toggle option and get its attributes to save to the model.
                questionList = new List<Question>();

                for (i = 0; i < options.transform.childCount; i++) {
                    // "he-he, what a mess" , this needs to be optimized, because we could reuse the child object call, as it is being called two times...

                    status = options.transform.GetChild(i).gameObject.GetComponent<OptionProperty>();

                    if (status) {
                        questionList.Add( new Question(options.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text, status.isCorrect));
                        //Debug.Log(options.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text + " " + status.isCorrect);
                    } else {
                        questionList.Add(new Question(options.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text, false));
                        //Debug.Log(options.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text + " False");
                    }
                }   

                // We got the question list, then we save it on the model

                environment.setQuestions(stageIndex, stepIndex, questionList);

                return true;

            } else {
                return false;
            }
        } else {
            return false;
        }
    }

}
