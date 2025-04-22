using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{
    public DialogueTrigger kakekDialogue; // drag komponen DialogueTrigger si kakek ke sini di Inspector
    public string sceneToLoad = "Scene2";
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (kakekDialogue.dialogFinished)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Selesaikan ngobrol dulu sama kakekmu, dasar grusa-grusu!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}