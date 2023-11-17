using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Interactor : MonoBehaviour {
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = .5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private IInteractable interactable;

    void OnInteract() {

        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if (numFound > 0) {

            interactable = colliders[0].GetComponent<IInteractable>();

            // Shows above player an indicator that there is an interactable object around.
            if (interactable != null) {

                // Player freezes and the input system changes for the totem interaction until the question is answered
                interactable.Interact(this);

                // When the player answered the question then the camera view is on the player.
            }
        } else {
            if (interactable != null) interactable = null;
            //if(interactionPromptUI.isDisplayed) interactionPromptUI.Close();
        }

    }
    /*
    void OnFinishInteraction() {
        Debug.Log("Finish selection keys!");
    }
    */
    /*
    void OnCancelInteraction() {
        Debug.Log("Cancel selection keys!");
        interactable.getBack(this);
    }
    */
    public void OnOptionSelection(InputValue value) { 
        //interactable.selectOptions(value.Get<Vector2>());
    }


    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
