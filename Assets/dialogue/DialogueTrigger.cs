using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;

    //detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision) {
        //if  on trigger the player unable player detecter and show indicator
        if(collision.tag == "Player") {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if we  lost on trigger with the player disable player detecter and show indicator
        if(collision.tag == "Player") {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    //while detected if we interact start the dialogue
    private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            // Start the dialogue
            dialogueScript.StartDialogue();
        }
    }
}