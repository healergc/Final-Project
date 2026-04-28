using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueCanvas;

    public GameObject interactPrompt;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            dialogueCanvas.SetActive(true);
            interactPrompt.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactPrompt.SetActive(false);
            dialogueCanvas.SetActive(false);
        }
    }
}