using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected;

    // 🟢 Tambahan: Flag untuk tandai kalau dialog sudah selesai
    [HideInInspector] public bool dialogFinished = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            // Kalau belum selesai, mulai dialog
            if (!dialogFinished)
            {
                dialogueScript.StartDialogue();
            }
        }
    }

    // 🟢 Fungsi ini akan dipanggil dari Dialogue.cs saat dialog benar-benar selesai
    public void OnDialogueFinished()
    {
        dialogFinished = true;
        Debug.Log("Dialog selesai. Pintu sekarang bisa digunakan~");
    }
}