using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                inventory.specialItemCount += 1;
                Debug.Log("Picked up item. Total: " + inventory.specialItemCount);

                Destroy(gameObject);
            }
        }
    }
}