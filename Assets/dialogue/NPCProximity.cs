using UnityEngine;

public class NPCProximity : MonoBehaviour
{
    [SerializeField] private GameObject speechBubble; // Drag & drop SpeechBubble di Inspector
    private bool isPlayerNearby = false;

    void Start()
    {
        // Pastikan speech bubble diawal tidak aktif
        if (speechBubble != null)
            speechBubble.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (speechBubble != null)
                speechBubble.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (speechBubble != null)
                speechBubble.SetActive(false);
        }
    }

    public bool IsPlayerNearby()
    {
        return isPlayerNearby;
    }
}
