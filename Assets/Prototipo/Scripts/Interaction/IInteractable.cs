using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable{
    //public string InteractionPrompt{get;}

    public void Interact(Interactor interactor);
    public void getBack(Interactor interactor);
    public void setGUICamera();
    public void setCameraBack();
    public void finished(Interactor interactor);
}
