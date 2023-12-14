using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using StarterAssets;
using Library;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InformationScreen : MonoBehaviour, IInteractable {
    //[SerializeField] private string _prompt;

    //public string InteractionPrompt => _prompt;+

    public Main main;

    public int stepNumber;
    public int stageNumber;

    public int scoreValue;

    public bool watchableAgain = true;

    //Totem content attributes

    public GameObject camera;
    public GameObject prevCamera;

    public GameObject itemsButton;
    public Image stepNumberImage;

    //public ToggleGroup options;
    public GameObject options;

    private GameObject contents;
    private EventSystem eventSystem;
    //public Toggle correctOne;

    private float finishTime;
    private float enterTime;

    public void Start() {
        camera.SetActive(false);
        contents = gameObject.transform.Find("Contents").gameObject;
        clearIndicators();

    }

    public void Update() {
        // Sets the indicator color if done or on
    }

    public void Interact(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();
        eventSystem = EventSystem.current;

        //the player can enter to the totem screen if the previous one was completed
        if(main.isDoneStage(stageNumber - 1) == true) {
            if(main.getStepStatus(stageNumber, stepNumber - 1) == true) {
                // If is not finished, player enters, else if is re-watchable the user could enter again too
                if(main.getStepStatus(stageNumber, stepNumber) == false) {

                    eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

                    // Switch camera with GUI One
                    setGUICamera();

                    // We start counting the timer
                    enterTime = Time.fixedTime;

                    // We switch the input action map to the one for interactingwith totems
                    playerInput.SwitchCurrentActionMap("StepInteraction");
                } else {
                    if(watchableAgain == true) {
                        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

                        // Switch camera with GUI One
                        setGUICamera();

                        // We start counting the timer
                        enterTime = Time.fixedTime;

                        // We switch the input action map to the one for interactingwith totems
                        playerInput.SwitchCurrentActionMap("StepInteraction");
                    }
                }
            } else {
                main.informationMsg("Debes completar el TÓTEM anterior para poder entrar a este :(");
                //Debug.Log("You must complete the previous STEP first to enter to this totem.");
            }
        } else {
            main.informationMsg("Debes completar el NIVEL anterior para entrar a este tótem :(");
            //Debug.Log("You must complete the previous STAGE fist to enter to this totem.");
        }
    }

    public void getBack(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();

        // Set the main camera
        setCameraBack();


        // Sets back the player action map 
        playerInput.SwitchCurrentActionMap("Player");

    }

    public void setGUICamera() {
        CanvasGroup MyRenderer;
        camera.SetActive(true);
        prevCamera.SetActive(false);
    }

    public void setCameraBack() {
        camera.SetActive(false);
        prevCamera.SetActive(true);
    }

    // We call this when the user pressed the ok button
    public void finished(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();

        // Detect if is multiple or single toggle selection, or none
        if(main.getStepStatus(stageNumber, stepNumber) == false) {
            if(options) {
                if(main.isMultiple(stageNumber, stepNumber)) {
                    evaluateMultiple();
                    markDone();
                } else {
                    evaluateSingle();
                    markDone();
                }
            } else {
                markDone();
            }

            // Sets the step number indicator color to yellow
            if(stepNumberImage != null) {
                stepNumberImage.color = new Color(100, 100, 0, 255);
            }
        } else {
            if(!watchableAgain) {
                main.informationMsg("Acabas de completar este totem, no puedes cambiar la respuesta!");
                //Debug.Log("You already completed this step, you can't change your answer!");
            }
        }

        // Detect if is last step or stage 
        verifyIfFinishedGame();

        setTimeStamp();

        // Lock done button

        contents.transform.Find("DoneButton").gameObject.GetComponent<Button>().interactable = false;
        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

        //setCameraBack();
        //playerInput.SwitchCurrentActionMap("Player");
    }

    // We call this when the user pressed the ok button
    public void finishedNoQuestions(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();

        // Detect if is multiple or single toggle selection, or none
        if(main.getStepStatus(stageNumber, stepNumber) == false) {
            markDone();
            main.setStepTotalScore(this.stageNumber, this.stepNumber, scoreValue);

            // Sets the step number indicator color to yellow
            if(stepNumberImage != null) {
                stepNumberImage.color = new Color(100, 100, 0, 255);
            }
        } else {
            if(!watchableAgain) {
                main.informationMsg("Acabas de completar este totem, no puedes cambiar la respuesta!");
                //Debug.Log("You already completed this step, you can't change your answer!");
            }
        }

        // Detect if is last step or stage 
        verifyIfFinishedGame();


        setCameraBack();


        playerInput.SwitchCurrentActionMap("Player");
    }

    public void verifyIfFinishedGame() {
        if(stepNumber == main.getStepSize(stageNumber) - 1) {
            Debug.Log("Current step: " + stepNumber + "| Nivel:" + stageNumber + "| Total niveles : " +( main.getStagesSize() - 1));
            main.informationMsg("Nice, terminaste el nivel! :-)");
            unlockFloor(stageNumber + 1);

            // The player gets a medal
            getStageMedal();

            //Debug.Log("You finished the STAGE!.");
            Debug.Log("Total number of stages: " + main.getStagesSize());

            if(stageNumber == main.getStagesSize() - 1) {
                main.informationMsg("Buena! Terminaste el jueguito B-)");
                main.showScoreboard();
                getFinalMedals();
            }
        }

        // Detect if is last stage
    }

    // This method is for operations about medalsw
    public void getStageMedal() {
        // Medal verificators
        timeStatsMedal();
    }

    public void timeStatsMedal() {
        int i, j;
        float avgAnswerTime;

        avgAnswerTime = getAvgAnswerTime();

        switch(avgAnswerTime) {
            case < 2f:
                //suspicious
                main.addStageMedal(stageNumber, main.getMedal(0));
                getAccuracyMedals();
                break;
            case < 10f:
                main.addStageMedal(stageNumber, main.getMedal(1));
                getAccuracyMedals();
                break;
            case < 30f:
                main.addStageMedal(stageNumber, main.getMedal(2));
                getAccuracyMedals();
                break;
            case < 120f:
                main.addStageMedal(stageNumber, main.getMedal(3));
                getAccuracyMedals();
                break;
            default:
                main.addStageMedal(stageNumber, main.getMedal(3));
                getAccuracyMedals();
                break;
        }
    }

    public void getFinalMedals() {

    }

    public void getAccuracyMedals() {
        // Verify if all questions in the stage are correct, we give a medal if so.
        if(main.isSelectedAnswerCorrect(stageNumber, stepNumber)) {
            switch(stageNumber) {
                case 0:
                    break;
                case 1:
                    main.addStageMedal(stageNumber, main.getMedal(4));
                    break;
                case 2:
                    main.addStageMedal(stageNumber, main.getMedal(5));
                    break;
                case 3:
                    main.addStageMedal(stageNumber, main.getMedal(6));
                    break;
            }
        }
    }
    
    public float getAvgAnswerTime() {
        return main.getAvgAnswerTime(stageNumber);
    }


    public void setTimeStamp() {
        //this.time = Time.fixedTime;
    }

    public void unlockFloor(int stageNumber) {
        main.unlockFloor(stageNumber);
    }

    // We get the multiple selected options
    public List<Toggle> getSelectedOptions() {
        List<Toggle> selectedOptions;
        int i;
        GameObject option;

        if(options) {

            selectedOptions = new List<Toggle>();

            for(i=0;i<options.transform.childCount;i++) {
                option = options.transform.GetChild(i).gameObject;

                if(option.GetComponent<Toggle>().isOn == true) {
                    selectedOptions.Add(option.GetComponent<Toggle>());
                }
            }
            return selectedOptions;

        } else {
            return null;
        }        
    }

    // Evaluate a multiple selection question
    public void evaluateMultiple() {       
        GameObject option;
        int correctCount=0;

        if(options != null) {            
            //List<Question> correctOnes = main.getCorrectQuestions(stageNumber, stepNumber);
            for(int i=0; i < options.transform.childCount; i++) {

                option = options.transform.GetChild(i).gameObject;

                if(option.GetComponent<Toggle>().isOn == true) {
                    // If this is the correct option
                    main.setMarked(stageNumber, stepNumber, i, true);

                    if(option.GetComponent<OptionProperty>().isCorrect == true) {
                        markCorrectOne(option, true);
                        correctCount++;
                            
                    } else {
                        markCorrectOne(option, false);
                    }
                } else {
                    if(option.GetComponent<OptionProperty>().isCorrect == true) {
                        markCorrectOne(option, true);
                    } 
                }
            }
                    
            if(correctCount == countIsCorrect()) {
                main.setStepTotalScore(this.stageNumber, this.stepNumber, scoreValue);                                          // We save the score
            } else {
                // We mark the incorrect ones with a 'x' then mark the correct ones the user didn't selected.
                main.setStepTotalScore(this.stageNumber, this.stepNumber, 0);
            }                
        }
    }

    public int countIsCorrect() {
        int count=0;
        GameObject option;
        for(int i = 0; i < options.transform.childCount; i++) {
            option = options.transform.GetChild(i).gameObject;

            if(option.GetComponent<OptionProperty>().isCorrect == true) {
                count++;
            } 
        }
        return count;
    }

    // Evaluates a single selection question
    public void markDone() {
        main.setStepStatus(stageNumber, stepNumber, true);

        // We start counting the timer
        finishTime = Time.fixedTime - enterTime;

        main.setAnswerTime(stageNumber, stepNumber, finishTime);

        Debug.Log("Time elapsed : " +  finishTime);

        
    }


    public void evaluateSingle() {
        ToggleGroup optionGroup = options.GetComponent<ToggleGroup>();
        Toggle selectedOption;

        // TODO : Validate if ToggleGroup Script is enabled

        if (optionGroup != null) {
            selectedOption = optionGroup.ActiveToggles().FirstOrDefault();

            List<Question> correctOnes = main.getCorrectQuestions(stageNumber, stepNumber);

            if(correctOnes != null) {


                if(correctOnes[0].getQuestion().Equals(selectedOption.GetComponentInChildren<Text>().text)) {
                    main.setStepTotalScore(this.stageNumber, this.stepNumber, scoreValue);                                          // We save the score
                    main.setMarkedOnes(stageNumber, stepNumber, correctOnes, true);
                    // We mark the correct answer with a tick
                    markCorrectOne(selectedOption.gameObject, true);
                } else {
                    // We mark the incorrect ones with a 'x' then mark the correct ones the user didn't selected.
                    main.setStepTotalScore(this.stageNumber, this.stepNumber, 0);
                    main.setMarkedOnes(stageNumber, stepNumber, correctOnes, true);

                    markCorrectOne(selectedOption.gameObject, false);
                    markCorrectOnes();
                    // We save the score
                }                
            } else {
                Debug.Log("ERROR, NO CORRECT ONES TO COMPARE!");
            }
        }
    }

    public void markCorrectOnes() {
        int i;
        GameObject option;
        GameObject indicator;

        if(options != null) {
            for(i=0;i<options.transform.childCount;i++) {                                       // We retrive each option
                option = options.transform.GetChild(i).gameObject;
                indicator = option.transform.Find("indicator").gameObject;

                if(option.GetComponent<OptionProperty>() != null && option.GetComponent<OptionProperty>().isCorrect == true)  {                   // We verify if the retrieved option is the correct one

                    if (indicator != null) {
                        indicator.transform.GetChild(0).gameObject.SetActive(false);
                        indicator.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    public void clearIndicators() {
        int i;
        GameObject option;
        GameObject indicator;

        if(options != null) {
            for(i = 0; i < options.transform.childCount; i++) {                                       // We retrive each option
                option = options.transform.GetChild(i).gameObject;
                indicator = option.transform.Find("indicator").gameObject;

                if(indicator != null) {
                    indicator.transform.GetChild(0).gameObject.SetActive(false);
                    indicator.transform.GetChild(1).gameObject.SetActive(false);
                }                
            }
        }
    }

    // Sets the indicators for the correct answers
    public void markCorrectOne(GameObject selectedOption, bool correct) {
        GameObject indicator;

        if(selectedOption != null) {
            indicator = selectedOption.transform.Find("indicator").gameObject;
            if(correct == true) {                                                                   // If 'correct' is true/false, then we set visible the option mark indicator.
                indicator.transform.GetChild(0).gameObject.SetActive(false); 
                indicator.transform.GetChild(1).gameObject.SetActive(true);
            } else {
                indicator.transform.GetChild(1).gameObject.SetActive(false);
                indicator.transform.GetChild(0).gameObject.SetActive(true);
            }
        } else {
            return;
        }
    }

    public IEnumerator fadeOutCoroutine(CanvasGroup canvsaGroup, float duration) {
        return null;
    }

    public IEnumerator waitCoroutine(float duration) {  return null; }

    // Sends answer to the model
    public bool sendAnswer() {
        //Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Debug.Log(toggle.name + " _ " + toggle.GetComponentInChildren<Text>().text);
        return true;
    }
}

