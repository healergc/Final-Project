using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer = 5f;

    [SerializeField] private int damage = 20;
    [SerializeField] private float speed = 20f;

    private void Update()
    {
        // Move projectile forward
        transform.position += transform.forward * speed * Time.deltaTime;

        // Destroy after time
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        // Find all enemies
        EnemyController[] enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None);

        foreach (EnemyController enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // If close enough, damage enemy
            if (distance < 1.5f)
            {
                enemy.TakeDamage(damage);

                Debug.Log("Enemy Hit!");

                Destroy(gameObject);
                break;
            }
        }
    }
}