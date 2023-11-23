using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NPCInteraction : MonoBehaviour, IInteractable {
    [SerializeField] private string _prompt;
    public GameObject firstView;
    public GameObject mainCamera;
    public DialogueManager _dialogue;

    public string InteractionPrompt => _prompt;

    public void Start() {

    }
    public void Interact(Interactor interactor) {
        //throw new System.NotImplementedException();
        Debug.Log("You're near a NPC");
        _dialogue.StartConversation();
    }

    public void setGUICamera() {
        firstView.SetActive(true);
        mainCamera.SetActive(false);
    }

    public void setCameraBack() {
        firstView.SetActive(false);
        mainCamera.SetActive(true);
    }
    public void getBack(Interactor interactor) {
        return;
    }

    public void selectOptions(float value) {
        return;
    }
    public void finished(Interactor interactor) { }

    public IEnumerator fadeOutCoroutine(CanvasGroup canvsaGroup, float duration) {
        return null; 
    }

    public IEnumerator waitCoroutine(float duration) { return null; }   
}
