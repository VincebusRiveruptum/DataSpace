using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    public bool isDisplayed = false;

    [SerializeField] private GameObject _uiPanel;

    public void Start(){
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }
    
    public void LateUpdate(){
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
        rotation * Vector3.up);
    }

    public void SetUp(){
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close(){
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
    
}
