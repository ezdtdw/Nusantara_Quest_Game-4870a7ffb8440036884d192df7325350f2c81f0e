using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //fields

     //windows
    public GameObject window;
    //indicator
    public GameObject indicator;
    //text component
    public TMP_Text dialogueText;
    //dialogue
    public List<string> dialogues;
    //writing speed
    public float writingSpeed;
    //index on dialogue
    private int index;
    //character index
    private int charIndex;
    //started bolean
    private bool started;
    //wait for next bolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show) {
        //toggle the window
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show) {
    //toggle the window
    indicator.SetActive(show);
    }

    //start dialog
    public void StartDialogue() {
        if(started) return; 

        //bolean to idcated taht we have starte
        started = true;
        //show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //start with first dialogue
        GetDialogue(0);
    }

    //end dialogue
    private void GetDialogue(int i){
        //start index at zero
        index = i;
        //reset the character index
        charIndex = 0;
        //clear the dialogue componene text
        dialogueText.text = string.Empty;
        //start writeing
        StartCoroutine(writing());
    }
    public void EndDialogue() {
        //hide the window
        ToggleWindow(false);


    }


    //writing logic
    IEnumerator writing(){
        String currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //make sure yoy have reach the end of jthe sentenses
         if (charIndex < currentDialogue.Length) {
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart the same process
            StartCoroutine(writing());
        } else {
            // End this sentence and wit for the next one
            waitForNext = true;
        }
    }

    private void Update() {
        if(!started) return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E)) {
            waitForNext = false;
            index++;
            if (index < dialogues.Count) {
                GetDialogue(index);
            } else {
                EndDialogue();
            }
        }
    }
}
