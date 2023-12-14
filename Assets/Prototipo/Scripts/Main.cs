using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Library;

public class Main : MonoBehaviour {
    public Environment environment;
    public Canvas informationCanvas;
    public List<GameObject> floorBarriers;
    public GameObject scoreBoard;

    public TMP_Text scoreText;
    public TMP_Text completedText;

    // Start is called before the first frame update
    void Start() {
        environment = new Environment();
        floorBarriers = getBarriers();
        scoreBoard.SetActive(false);

        if(informationCanvas != null) {
            scoreText = informationCanvas.transform.Find("scoreText").gameObject.GetComponent<TMP_Text>();
            completedText = informationCanvas.transform.Find("completedText").gameObject.GetComponent<TMP_Text>();
        }


        
        // Level 0 //////////////////
        addStage("Introduction", "Brief introduction about the game and their challenges.");
        addStepToStage(0, "Welcome", "First totem greeting the player");                            // Add steps to the stage
        setStageStepTotem(0, 0, GameObject.Find("Welcome"));                                       // Add totem to the stage
        setStepScoreValue(0, 0, 10);

        addTip(0, new Tips(1, "Generic Tip 1", "This is a testing tip!"));
        addTip(0, new Tips(2, "Generic Tip 2", "This is another testing tip! :-)"));
        addTip(0, new Tips(3, "Generic Tip 3", "And another one..."));

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

        addStage("Primer nivel", "Clases, arreglos y colecciones");

        addStepToStage(1, "Generic Step 1", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 0, GameObject.Find("Generic 1-1"));
        setStepScoreValue(1, 0, 10);
        loadQuestionsToStep(1, 0, GameObject.Find("Generic 1-1"));

        addTip(1, new Tips(1, "Generic Tip 1", "This is a testing tip!"));
        addTip(1, new Tips(2, "Generic Tip 2", "This is another testing tip! :-)"));
        addTip(1, new Tips(3, "Generic Tip 3", "And another one..."));

        addStepToStage(1, "Generic Step 2", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 1, GameObject.Find("Generic 1-2"));
        setStepScoreValue(1, 1, 10);
        loadQuestionsToStep(1, 1, GameObject.Find("Generic 1-2"));

        addStepToStage(1, "Generic Step 3", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 2, GameObject.Find("Generic 1-3"));
        setStepScoreValue(1, 2, 10);
        loadQuestionsToStep(1, 2, GameObject.Find("Generic 1-3"));

        addStepToStage(1, "Generic Step 4", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(1, 3, GameObject.Find("Generic 1-4"));
        setStepScoreValue(1, 3, 10);
        loadQuestionsToStep(1, 3, GameObject.Find("Generic 1-4"));

        // Add totem to the stage

        // Level 2 //////////////////

        addStage("Segundo nivel", "Herencia");

        addStepToStage(2, "Generic Step 1", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(2, 0, GameObject.Find("Generic 2-1"));
        setStepScoreValue(2, 0, 10);
        loadQuestionsToStep(2, 0, GameObject.Find("Generic 2-1"));

        addTip(2, new Tips(1, "Generic Tip 1", "This is a testing tip!"));
        addTip(2, new Tips(2, "Generic Tip 2", "This is another testing tip! :-)"));
        addTip(2, new Tips(3, "Generic Tip 3", "And another one..."));

        addStepToStage(2, "Generic Step 2", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(2, 1, GameObject.Find("Generic 2-2"));
        setStepScoreValue(2, 1, 10);
        loadQuestionsToStep(2, 1, GameObject.Find("Generic 2-2"));

        addStepToStage(2, "Generic Step 3", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(2, 2, GameObject.Find("Generic 2-3"));
        setStepScoreValue(2, 2, 10);
        loadQuestionsToStep(2, 2, GameObject.Find("Generic 2-3"));

        // Level 3 //////////////////

        addStage("Tercer nivel", "Clases Abstractas e Interfaces");

        addStepToStage(3, "Generic Step 1", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(3, 0, GameObject.Find("Generic 3-1"));
        setStepScoreValue(3, 0, 10);
        loadQuestionsToStep(3, 0, GameObject.Find("Generic 3-1"));

        addTip(3, new Tips(1, "Generic Tip 1", "This is a testing tip!"));
        addTip(3, new Tips(2, "Generic Tip 2", "This is another testing tip! :-)"));
        addTip(3, new Tips(3, "Generic Tip 3", "And another one..."));

        addStepToStage(3, "Generic Step 2", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(3, 1, GameObject.Find("Generic 3-2"));
        setStepScoreValue(3, 1, 10);
        loadQuestionsToStep(3, 1, GameObject.Find("Generic 3-2"));

        addStepToStage(3, "Generic Step 3", "Generic Step description.");                               // Add steps to the stage
        setStageStepTotem(3, 2, GameObject.Find("Generic 3-3"));
        setStepScoreValue(3, 2, 10);
        loadQuestionsToStep(3, 2, GameObject.Find("Generic 3-3"));

        //   environment.addStage("Last-Level", "Player has to do certain tasks...");
        //   environment.addStepToStage(0, "Welcome", "First totem greeting the player");                            // Add steps to the stage
        //   environment.setStageStepTotem(0, 0, GameObject.Find("Welcome"););                                       // Add totem to the stage

        // Setting-up medals

        addMedal("Sospechosamente rápido", "El jugador responde las preguntas demasiado rápido (<1 seg entre totems)", 1);
        addMedal("Velóz", "El jugador tiene un promedio de respuesta bastante rápido1", 1);
        addMedal("Lento pero seguro", "El jugador responde de forma paulatina durante el juego", 1);
        addMedal("Tortuga", "El jugador se demoró bastante en responder las preguntas en el nivel ", 1);
        addMedal("Maestro de Clases, Arreglos y colecciones", "El jugador respondió todas las preguntas correctamente del nivel uno a gran velocidad", 2);
        addMedal("Maestro de la Herencia", "El jugador respondió todas las preguntas correctamente del nivel dos a gran velocidad", 2);
        addMedal("Maestro de las Clases abstractas e interfaces", "El jugador respondió todas las preguntas correctamente del nivel tres a gran velocidad", 2);

        addMedal("Buena Base", ("El jugador muestra buen dominio de los contenidos del primer nivel " + this.getStageDescription(1)),3);
        addMedal("Mucho potencial", ("El jugador muestra buen dominio de los contenidos del segundo nivel" + this.getStageDescription(2)),3);
        addMedal("Buen dominio", ("El jugador muestra buen dominio de los contenidos del tercer nivel" + this.getStageDescription(3)),3);
        addMedal("Excelente dominio", "El jugador muestra buen dominio en todos los contenidos",3);

    }

    // Update is called once per frame
    void Update() {
        /*
        Debug.Log(environment.getPlayer().getCurrentStep());
        Debug.Log(environment.getTotemFromStep(0,0).name);
        Debug.Log(environment.getTotemFromStep(0, 1).name);
        Debug.Log(environment.getTotemFromStep(0, 2).name);
        Debug.Log(environment.getTotemFromStep(0, 3).name);
        */

        /* Real-time score feedback */

        setInformationCanvas();

        Debug.Log(this.environment.getCurrentStage());

        Debug.Log("Step 0 from stage status : " + getStepStatus(0, 0));
        //logStagesTotems();
        logScores();
    }

    /* Environment Methods */

    /* Testing Only */

    public void logStagesTotems() {

        // use foreach instead of the index later...
        int i, j;
        for(i = 0; i < environment.getStagesSize(); i++) {
            Debug.Log("Stage " + i + " Name: " + environment.getStageName(i) + "\t" + "Description: " + environment.getStageDescription(i) + "Status : " + environment.isDoneStage(i) + "\n");
            for(j = 0; j < environment.getStepSize(i); j++) {
                Debug.Log("\t" + "Step " + j + "\t" + "Title : " + environment.getStageStep(i, j).getTitle() + "\t" + "Status: " + environment.getStageStep(i, j).getStatus());
            }
        }
    }


    public void logScores() {
        int i = 0, j = 0;
        foreach(Stage stage in environment.getStageList()) {
            Debug.Log("Stage " + i + " total score : " + stage.getFinalScore() + "/" + stage.getScoreValue());
            foreach(Step step in stage.getStepList()) {
                Debug.Log("\tStep " + j + "'" + step.getTitle() + "'" + "\tScore: " + step.getTotalScore() + "/" + step.getScoreValue());
                j++;
            }
            j = 0;
            i++;
        }
    }

    // Updates on-screen stats 
    public void setInformationCanvas() {
        scoreText.text = ("Puntuación : " + environment.getTotalScore() + "/" + environment.getScoreValue());
        completedText.text = ("Tótems completados : " + environment.getTotalDoneSteps() + "/" + environment.getTotalSteps());
    }


    public void setStepStatus(int stageIndex, int stepIndex, bool done) {
        environment.setStepStatus(stageIndex, stepIndex, done);
    }

    public bool getStepStatus(int stageIndex, int stepIndex) {
        return environment.getStepStatus(stageIndex, stepIndex);
    }

    public int getStepSize(int stageIndex) {
        return this.environment.getStepSize(stageIndex);
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

    public void informationMsg(string msg) {

        StartCoroutine(LevelUp(msg));
    }

    public IEnumerator LevelUp(string msg) {
        informationCanvas.GetComponentInChildren<TMP_Text>().text = (msg);

        yield return new WaitForSeconds(4f);
        informationCanvas.GetComponentInChildren<TMP_Text>().text = ("");

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

    public int getTotalScore() {
        return this.environment.getTotalScore();
    }

    public int getScoreValue() {
        return this.environment.getScoreValue();
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

                for(i = 0; i < options.transform.childCount; i++) {
                    // "he-he, what a mess" , this needs to be optimized, because we could reuse the child object call, as it is being called two times...

                    status = options.transform.GetChild(i).gameObject.GetComponent<OptionProperty>();

                    if(status) {
                        questionList.Add(new Question(options.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text, status.isCorrect));
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

    // Get list of floor barrier in the building
    public List<GameObject> getBarriers() {
        List<GameObject> barriers = new List<GameObject>();
        GameObject floors = GameObject.Find("Floors");

        for(int i = 0; i < floors.transform.childCount; i++) {
            barriers.Add(floors.transform.GetChild(i).gameObject);
        }

        return barriers;
    }

    // Floor barrier unlocking
    public void unlockFloor(int stageIndex) {
        if(stageIndex < floorBarriers.Count) {
            floorBarriers[stageIndex].gameObject.SetActive(false);
        }
    }

    //======================================================
    // Receptionist and Tips stuff
    //
    // Setters

    public int getRQsize(int stageIndex) {
        return this.environment.getRQsize(stageIndex);
    }

    public List<SelectCorrect> getRQList(int stageIndex) {
        return this.environment.getRQList(stageIndex);
    }

    public List<Question> getRQItems(int stageIndex, int listIndex) {
        return this.environment.getRQItems(stageIndex, listIndex);
    }

    public List<Question> getCorrectRQs(int stageIndex, int listIndex) {
        return this.environment.getCorrectRQs(stageIndex, listIndex);
    }

    public string getRQTitle(int stageIndex, int listIndex) {
        return this.environment.getRQTitle(stageIndex, listIndex);
    }

    public Question getRQ(int stageIndex, int listIndex, int questionIndex) {
        return this.environment.getRQ(stageIndex, listIndex, questionIndex);
    }

    public bool isRQCorrect(int stageIndex, int listIndex, int questionIndex) {
        return this.environment.isRQCorrect(stageIndex, listIndex, questionIndex);
    }

    public string getRQString(int stageIndex, int listIndex, int questionIndex) {
        return this.environment.getRQString(stageIndex, listIndex, questionIndex);
    }

    public bool isRQMultiple(int stageIndex, int listIndex) {
        return this.environment.isRQMultiple(stageIndex, listIndex);
    }

    // Setters

    public void setRQs(int stageIndex, int listIndex, List<Question> questions) {
        this.environment.setRQs(stageIndex, listIndex, questions);
    }

    public void setRQValue(int stageIndex, int listIndex, int index, bool value) {
        this.environment.setRQValue(stageIndex, listIndex, index, value);
    }
    public void setRQ(int stageIndex, int listIndex, int index, string question) {
        this.environment.setRQ(stageIndex, listIndex, index, question);
    }

    // Methods

    public void setRQTitle(int stageIndex, int listIndex, string title) {
        this.environment.setRQTitle(stageIndex, listIndex, title);
    }

    public void addRQ(int stageIndex, int listIndex, string question, bool isCorrect) {
        this.environment.addRQ(stageIndex, listIndex, question, isCorrect);
    }

    public void removeRQ(int stageIndex, int listIndex, int index) {
        this.environment.removeRQ(stageIndex, listIndex, index);
    }

    //===========================================================
    // TIPS

    public void setTips(int stageIndex, List<Tips> list) {
        this.environment.setTips(stageIndex, list);
    }

    public List<Tips> getTips(int stageIndex) {
        return this.environment.getTips(stageIndex);
    }

    public Tips getTip(int stageIndex, int index) {
        return this.environment.getTip(stageIndex, index);
    }

    public void addTip(int stageIndex, Tips tip) {
        this.environment.addTip(stageIndex, tip);
    }

    public void removeTip(int stageIndex, int index) {
        this.environment.removeTip(stageIndex, index);
    }

    // Setters and getters

    public int getTipId(int stageIndex, int index) {
        return this.environment.getTipId(stageIndex, index);
    }

    public string getTipTitle(int stageIndex, int index) {
        return this.environment.getTipTitle(stageIndex, index);
    }

    public string getTipString(int stageIndex, int index) {
        return this.environment.getTipString(stageIndex, index);
    }

    public void setTipId(int stageIndex, int index, int id) {
        this.environment.setTipId(stageIndex, index, id);
    }

    public void setTipTitle(int stageIndex, int index, string title) {
        this.environment.setTipTitle(stageIndex, index, title);
    }

    public void setTipString(int stageIndex, int index, string tipString) {
        this.environment.setTipString(stageIndex, index, tipString);
    }
    //=============================

    public int getCurrentStage() {
        return this.environment.getCurrentStage();
    }

    public void showScoreboard() {
        this.scoreBoard.SetActive(true);
    }

    // Timer methods

    public float getAnswerTime(int stageIndex, int stepIndex) {
        return this.environment.getAnswerTime(stageIndex, stepIndex);
    }

    public void setAnswerTime(int stageIndex, int stepIndex, float answerTime) {
        this.environment.setAnswerTime(stageIndex, stepIndex, answerTime);
    }

    // Question selected choices

    public void setMarked(int stageIndex, int stepIndex, int questionIndex, bool isMarked) {
        this.environment.setMarked(stageIndex, stepIndex, questionIndex, isMarked);
    }

    public void setMarkedOnes(int stageIndex, int stepIndex, List<Question> markedQuestions, bool isMarked) {
        this.environment.setMarkedOnes(stageIndex, stepIndex, markedQuestions, isMarked);
    }

    public void setMarkedOnes(int stageIndex, int stepIndex, int questionIndex, int[] markedIndexes) {
        this.environment.setMarkedOnes(stageIndex, stepIndex, questionIndex, markedIndexes);
    }

    // We get the marked questions list
    public List<Question> getMarkedOnes(int stageIndex, int stepIndex, int questionIndex) {
        return this.environment.getMarkedOnes(stageIndex, stepIndex, questionIndex);
    }

    public bool isSelectedAnswerCorrect(int stageIndex, int stepIndex) {
        return this.environment.isSelectedAnswerCorrect(stageIndex, stepIndex);
    }

    // ===================
    // Medal stuff

    public List<Medal> getMedalList() {
        return this.environment.getMedalList();
    }

    public void setMedalList(List<Medal> medalList) {
        this.environment.setMedalList(medalList);
    }

    public Medal getMedal(int medalIndex) {
        return this.environment.getMedal(medalIndex);
    }

    public void addMedal(Medal medal) {
        this.environment.addMedal(medal);
    }
    
    public void addMedal(string title, string description, int type) {
        this.environment.addMedal(title, description, type);
    }
    
    public Medal removeMedal(int medalIndex) {
        return this.environment.removeMedal(medalIndex);
    }

    public float getAvgAnswerTime(int stageIndex) {
        return this.environment.getAvgAnswerTime(stageIndex);
    }

    public void setStageMedal(int stageIndex, List<Medal> medals) {
        this.environment.setStageMedal(stageIndex, medals);
    }

    public Medal getStageMedal(int stageIndex, int medalIndex) {
        return this.environment.getStageMedal(stageIndex, medalIndex);
    }

    public void addStageMedal(int stageIndex, Medal medal) {
        this.environment.addStageMedal(stageIndex, medal);
    }

    // Final medals

    public void addFinalMedal(Medal medal) {
        this.environment.addFinalMedal(medal);
    }

    public Medal getFinalMedal(int finalMedalIndex) {
        return this.environment.getFinalMedal(finalMedalIndex);
    }

    public Medal removeFinalMedal(int finalMedalIndex) {
        return this.environment.removeFinalMedal(finalMedalIndex);
    }


    // Save report

    public void saveReport() {
        this.environment.saveReport();
    }

    public void saveMedalReport() {
        this.environment.saveMedalReport();
    }

    public void saveMedalList() {
        this.environment.saveMedalList();    
    }

}
