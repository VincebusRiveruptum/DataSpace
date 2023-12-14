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
using TMPro;

public class playerSetup : MonoBehaviour{
    public Main main;
    public GameObject nameInput;
    public GameObject lastNameInput;
    public GameObject rutInput;
    public GameObject emailInput;
    public GameObject uiCamera;
    public GameObject mainCamera;
    public PlayerInput playerInput;
    private EventSystem eventSystem;

    void Start() {
        //Disable main camera and enable menu one
        if(mainCamera != null) {            
            mainCamera.SetActive(false);
            uiCamera.SetActive(true);
        }

        //Enable ui controls 
        if(playerInput != null) {
            eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(nameInput, new BaseEventData(eventSystem));
            playerInput.SwitchCurrentActionMap("StepInteraction");
            Debug.Log("Switch input");
        }

        //Input validation
        /*
        nameInput.onEndEdit.AddListener(validateName);
        rutInput.onEndEdit.AddListener(validateRut);
        emailInput.onEndEdit.AddListener(validateEmail);
        */
    }

    //exit game
    public void quit() {
        Application.Quit();
    }

    //start game

    public void startGame() {
        Player newPlayer;
        //Get and save player attributes

        if(nameInput != null && lastNameInput != null && rutInput != null && emailInput != null) {
            if(nameInput.GetComponent<TMP_InputField>() != null && lastNameInput.GetComponent<TMP_InputField>() != null && rutInput.GetComponent<TMP_InputField>() != null && emailInput.GetComponent<TMP_InputField>() != null) {
                newPlayer = new Player(nameInput.GetComponent<TMP_InputField>().text, lastNameInput.GetComponent<TMP_InputField>().text, rutInput.GetComponent<TMP_InputField>().text, emailInput.GetComponent<TMP_InputField>().text);
                main.setPlayer(newPlayer);
                Debug.Log(nameInput.GetComponent<TMP_InputField>().text + " " + lastNameInput.GetComponent<TMP_InputField>().text + " " + rutInput.GetComponent<TMP_InputField>().text + " " + emailInput.GetComponent<TMP_InputField>().text);
            }
        }


        //Switch main camera
        mainCamera.SetActive(true);
        uiCamera.SetActive(false);

        //Switch game controls
        playerInput.SwitchCurrentActionMap("Player");

        gameObject.transform.Find("Menu").gameObject.SetActive(false);
    }


    public void validateName(string input) {
        
    }
    public void validateRut(string input) {

    }
    public void validateEmail(string input) {

    }
}
