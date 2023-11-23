using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using Library;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ScoreTotem : MonoBehaviour, IInteractable{
    public Main main;

    //Totem content attributes

    public GameObject camera;
    public GameObject prevCamera;

    public GameObject itemsButton;
    private GameObject contents;
    
    public Image stepNumberImage;

    public void Start() {
        camera.SetActive(false);
        contents = gameObject.transform.Find("Contents").gameObject;
    }

    public void Update() {
        // Sets the indicator color if done or on
    }

    public void Interact(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();
        var eventSystem = EventSystem.current;
       
        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));
        // Switch camera with GUI One
        setGUICamera();
        setFinalScore();


        // We switch the input action map to the one for interactingwith totems
        playerInput.SwitchCurrentActionMap("StepInteraction");

    }

    public void getBack(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();

        // Set the main camera
        setCameraBack();

        // Sets back the player action map 
        playerInput.SwitchCurrentActionMap("Player");

    }

    public void setFinalScore() {
        GameObject scoreText;

        if(contents != null) {
            scoreText = contents.transform.Find("totalScorePrefab").gameObject;
            scoreText.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = ("" + main.getTotalScore()) + "/" + main.getScoreValue();
        }
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
        setCameraBack();
        playerInput.SwitchCurrentActionMap("Player");
    }
}
