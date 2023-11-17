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
    //public Toggle correctOne;

    public void Start() {
        camera.SetActive(false);
    } 

    public void Update() {
        // Sets the indicator color if done or on

    }

    public void Interact(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();
        var eventSystem = EventSystem.current;

        //the player can enter to the totem screen if the previous one was completed
        if( main.isDoneStage(stageNumber-1) == true) {
            if (main.getStepStatus(stageNumber, stepNumber - 1) == true)
            {
                // If is not finished, player enters, else if is re-watchable the user could enter again too
                if (main.getStepStatus(stageNumber, stepNumber) == false) {

                    eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

                    // Switch camera with GUI One
                    setGUICamera();

                    // We switch the input action map to the one for interactingwith totems
                    playerInput.SwitchCurrentActionMap("StepInteraction");
                } else {
                    if (watchableAgain == true) {
                        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

                        // Switch camera with GUI One
                        setGUICamera();

                        // Lock UI controls
                        

                        // We switch the input action map to the one for interactingwith totems
                        playerInput.SwitchCurrentActionMap("StepInteraction");
                    }
                }
            } else {
                Debug.Log("You must complete the previous STEP first to enter to this totem.");
            }
        } else {
            Debug.Log("You must complete the previous STAGE fist to enter to this totem.");
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
            if (options) {
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
            if (stepNumberImage != null) {
                stepNumberImage.color = new Color(100, 100, 0, 255);
            }
        } else {
            if(!watchableAgain) {
                Debug.Log("You already completed this step, you can't change your answer!");
            }
        }

        setCameraBack();
        playerInput.SwitchCurrentActionMap("Player");
    }
    public void selectOptions(float value) { }

    // Evaluate a multiple selection question
    public void evaluateMultiple() {
        
        //Toggle selectedOption = options.ActiveToggles().FirstOrDefault();
    }

    // Evaluates a single selection question
    public void markDone() {
        main.setStepStatus(stageNumber, stepNumber, true);
    }

    public void evaluateSingle() {
        ToggleGroup optionGroup = options.GetComponent<ToggleGroup>();
        Toggle selectedOption;
        
        // TODO : Validate if ToggleGroup Script is enabled

        if(optionGroup != null) {
            selectedOption = optionGroup.ActiveToggles().FirstOrDefault();

            List<Question> correctOnes = main.getCorrectQuestions(stageNumber, stepNumber);

            if(correctOnes != null) {
                if (correctOnes[0].getQuestion().Equals(selectedOption.GetComponentInChildren<Text>().text)) {
                    main.setStepTotalScore(this.stageNumber, this.stepNumber, scoreValue);
                } else {
                    main.setStepTotalScore(this.stageNumber, this.stepNumber, 0);
                }
            } else {
                Debug.Log("ERROR, NO CORRECT ONES TO COMPARE!");
            }
        }
    }

    // Sends answer to the model
    public bool sendAnswer() {
        //Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Debug.Log(toggle.name + " _ " + toggle.GetComponentInChildren<Text>().text);
        return true;
    }
}

