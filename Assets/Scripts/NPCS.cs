using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private PlayerInventory playerInventory;

    public GameObject normalDialogue;
    public GameObject specialDialogue;
    public GameObject interactPrompt;

   


    private bool dialogueOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        if (specialDialogue == null)
            Debug.LogError("specialDialogue is NOT assigned in Inspector!");

        if (normalDialogue == null)
            Debug.LogError("normalDialogue is NOT assigned in Inspector!");

        if (interactPrompt == null)
            Debug.LogError("interactPrompt is NOT assigned in Inspector!");

        normalDialogue.SetActive(false);
        specialDialogue.SetActive(false);
        interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            specialDialogue.SetActive(true);
            Debug.Log("FORCED UI OPEN");
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueOpen)
            {
                OpenDialogue();
            }
            else
            {
                CloseDialogue();
            }
        }
    }

    void OpenDialogue()
    {
        if (playerInventory == null) return;

        interactPrompt.SetActive(false);
        dialogueOpen = true;

        if (playerInventory.specialItemCount >= 3)
        {
            Debug.Log("SHOWING SPECIAL DIALOGUE");

            normalDialogue.SetActive(false);
            specialDialogue.SetActive(true);
        }
        else
        {
            Debug.Log("SHOWING NORMAL DIALOGUE");

            specialDialogue.SetActive(false);
            normalDialogue.SetActive(true);
        }
    }

    void CloseDialogue()
    {
        normalDialogue.SetActive(false);
        specialDialogue.SetActive(false);

        dialogueOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<PlayerInventory>();

            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            interactPrompt.SetActive(false);
            normalDialogue.SetActive(false);
            specialDialogue.SetActive(false);

            dialogueOpen = false;
        }
    }
}
 
