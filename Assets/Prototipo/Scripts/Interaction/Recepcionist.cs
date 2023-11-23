using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using StarterAssets;

public class Recepcionist : MonoBehaviour, IInteractable {
    public Main main;

    public int scoreValue;

    public bool watchableAgain = true;

    //Totem content attributes

    public GameObject camera;
    public GameObject prevCamera;

    public GameObject itemsButton;
    public Image stepNumberImage;

    public GameObject options;
    public GameObject contents;

    private List<GameObject> windows;
    private int currentWindow=0;
    private int currentStage;
    private EventSystem eventSystem;

    private List<GameObject> rt;
    public GameObject tipPrefab;

    public int defaultWindow;


    public void Start() {
        camera.SetActive(false);
        windows = getWindows();
        disableWindows();
        currentStage = main.getCurrentStage();
        rt = new List<GameObject>();
    }

    public void Update() {
        // Sets the indicator color if done or on
    }

    public void Interact(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();
        eventSystem = EventSystem.current;

        // Loading tips
        loadTips();
        // Switch camera with GUI One
        setGUICamera();
        mainWindow();            // Default one

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

    public void setGUICamera() {
        camera.SetActive(true);
        prevCamera.SetActive(false);
    }

    public void setCameraBack() {
        camera.SetActive(false);
        prevCamera.SetActive(true);
        windows[currentWindow].SetActive(false);
    }

    public void finished(Interactor interactor) {
        PlayerInput playerInput = interactor.GetComponent<PlayerInput>();
        setCameraBack();
        playerInput.SwitchCurrentActionMap("Player");
    }

    public List<GameObject> getWindows() {
        List<GameObject> listOfWindows = new List<GameObject>();
        int i;

        if(contents) {
            for(i = 0; i < contents.transform.childCount; i++) {
                //Debug.Log(i);
                listOfWindows.Add(contents.transform.GetChild(i).gameObject);
            }
        } else {
            Debug.Log("Error, no windows to show nor switch beetween");
        }

        return listOfWindows;
    }

    public void disableWindows() {
        int i;

        if(contents) {
            for(i = 0; i < windows.Count; i++) {
                windows[i].SetActive(false);
                windows[i].GetComponent<CanvasGroup>().alpha = 0f;
            }
        } else {
            Debug.Log("Error, no windows to show nor switch beetween");
        }
    }

    public void welcome() {

        if(contents) {

            windows[currentWindow].SetActive(false);
            windows[0].SetActive(true);

            currentWindow = 0;

            StartCoroutine(fades(windows[0].GetComponent<CanvasGroup>(), 1.0f));

            mainWindow();
        }
    }

    public void mainWindow() {
        windows[currentWindow].SetActive(false);
        windows[1].SetActive(true);
        windows[1].GetComponent<CanvasGroup>().alpha = 1f;

        currentWindow = 1;

        // Disable script generated UI

        windows[2].transform.Find("tips").gameObject.SetActive(false);


        itemsButton = windows[1].transform.Find("HelpButton").gameObject;

        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));

    }

    public void help() {
        windows[currentWindow].SetActive(false);
        windows[2].SetActive(true);
        windows[2].GetComponent<CanvasGroup>().alpha = 1f;

        currentWindow = 2;

        windows[2].transform.Find("tips").gameObject.SetActive(true);


        itemsButton = windows[2].transform.Find("BackButton").gameObject;
        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));
    }

    public void destroyRT() {

        if(rt != null) {
            for(int i = 0; i< (rt.Count); i++) {
                Destroy(rt[i]);                
            }
            rt.Clear();
        }
    }

    public void questions() {
        windows[currentWindow].SetActive(false);
        windows[3].SetActive(true);
        windows[3].GetComponent<CanvasGroup>().alpha = 1f;

        currentWindow = 3;

        loadQuestions();

        itemsButton = windows[3].transform.Find("BackButton").gameObject;
        eventSystem.SetSelectedGameObject(itemsButton, new BaseEventData(eventSystem));
    }

    // 

    public void loadTips() {
        int i=0;
        float spacing = 50f;

        // Load rt for the first time or the current stage has changed
        Debug.Log(currentStage + " - " + main.getCurrentStage());
        if(currentStage != main.getCurrentStage() || currentStage == 0 ) {
            if(main.getTips(currentStage).Count > 0) {
                
                // Destroy previous items
                destroyRT();

                currentStage = main.getCurrentStage();
                
                if(tipPrefab != null) {
                    

                    foreach(Tips tip in main.getTips(currentStage)) {
                        rt.Add(Instantiate(tipPrefab, new Vector3(0, (-1) * i * spacing, 0), Quaternion.identity));
                        rt[i].SetActive(true);
                        rt[i].transform.SetParent(windows[2].transform.Find("tips").transform, false);             // Set the generated tip canvas inside the Help window canvas
                        rt[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ("" + (i+1) );
                        rt[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = tip.getTipString();

                        Debug.Log(tip.getTipTitle() + " " + tip.getTipString());
                        i++;
                    }

                } else {
                    Debug.Log("You must set the 'tipPrefab' tip template!");
                }

            } else {
                Debug.Log("No tips stored on this stage");
            }

            
            
        }
    }

    // 

    public void loadQuestions() {
        int i=0, currentStage;

        currentStage = main.getCurrentStage();

        //Debug.Log("Questions of stage #" + currentStage);

        if(main.getRQList(currentStage).Count > 0) {
            foreach(SelectCorrect sc in main.getRQList(currentStage)) {
                i++;
                //Debug.Log(i + " - " + sc.getTitle());
            }
        } else {
            Debug.Log("No Questions stored on this stage");
        }
    }


    //================================================================================
    // Canvas fade effect coroutines

    public IEnumerator switchWindow(int previous, int current) {
        GameObject defaultButton;
        if (contents) {

            yield return StartCoroutine(fadeOutCoroutine(windows[previous].GetComponent<CanvasGroup>(), 1.0f));
            windows[previous].SetActive(false);

            if(current >= 0) {
                windows[current].SetActive(true);
                currentWindow = current;

                defaultButton = windows[current].transform.Find("PointsButton").gameObject;
                eventSystem.SetSelectedGameObject(defaultButton, new BaseEventData(eventSystem));

                yield return StartCoroutine(fadeInCoroutine(windows[current].GetComponent<CanvasGroup>(), 1.0f));
            }
        }
    }

    public IEnumerator fades(CanvasGroup MyRenderer, float duration) {
        yield return StartCoroutine(fadeInCoroutine(MyRenderer, duration));
        yield return StartCoroutine(waitCoroutine(1.0f));
        yield return StartCoroutine(fadeOutCoroutine(MyRenderer, duration));
    }

    public IEnumerator fadeOutCoroutine(CanvasGroup MyRenderer, float duration) {
        float counter = 0;

        if (MyRenderer) {
            while (counter < duration) {
                counter += Time.deltaTime;
                //Fade from 1 to 0
                float alpha = Mathf.Lerp(1, 0, counter / duration);

                //Change alpha only
                MyRenderer.alpha = alpha;
                //Wait for a frame
                yield return new WaitForEndOfFrame();
            }
        } else {
            Debug.Log("No canvasgroup!");
        }
    }

    public IEnumerator fadeInCoroutine(CanvasGroup MyRenderer, float duration) {
        float counter = 0; 

        if (MyRenderer) {
            while (counter < duration) {
                counter += Time.deltaTime;
                //Fade from 0 to 1
                float alpha = Mathf.Lerp(0, 1, counter / duration);

                //Change alpha only
                MyRenderer.alpha = alpha;
                //Wait for a frame
                yield return new WaitForEndOfFrame();
            }
        } else {
            Debug.Log("No canvasgroup!");
        }
    }

    public IEnumerator waitCoroutine( float duration) {
        yield return new WaitForSeconds(duration);
        
    }
}
