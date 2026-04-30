using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    void Update()
    {
        if (!isOpen && Input.GetKeyDown(KeyCode.K))
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        isOpen = true;

        Debug.Log("Door opened!");

        gameObject.SetActive(false); // simple version
    }
}