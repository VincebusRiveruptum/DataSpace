using System.Collections;
using System.Collections.Generic;

using UnityEngine.InputSystem;
using UnityEngine.UIElements;

using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour{
    public NPCDialog npc;
    bool isTalking = false;
    float distance;
    float curResponseTracker;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    void Start()
    {
        dialogueUI.SetActive(false);    
    }

    public void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];

    }

    public void EndConversation()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
