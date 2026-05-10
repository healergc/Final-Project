using UnityEngine;

public class InstatiationInteraction : MonoBehaviour
{
    private GameObject mainCamera;

    [SerializeField]
    private GameObject projectile, projectileSpawn;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = FindFirstObjectByType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
          

            Instantiate(projectile, projectileSpawn.transform.position,
                mainCamera.transform.rotation);
        }
    }
}