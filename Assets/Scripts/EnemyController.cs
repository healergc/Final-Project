using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float playerDistance;

    [SerializeField] private float chaseRange = 5f, attackRange = 1f, speed = 2.5f;

    private GameObject player;

    private Vector3 idlePos = Vector3.zero;

    [SerializeField] private int damage = 10;

    [SerializeField] private float attackCooldown = 1.5f;
    private float attackTimer = 0f;

    private PlayerHealth playerHealth;

    [SerializeField] private int maxHealth = 50;

    private int currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("NO PLAYER FOUND. Check Player tag or if object is active.");
            enabled = false;
            return;
        }

        playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth missing on Player.");
        }

        idlePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null) return;

        attackTimer += Time.deltaTime;

        var playerLoc = player.transform.position;
        playerDistance = Vector3.Distance(playerLoc, transform.position);

       

        if (playerDistance < attackRange)
        {
            transform.LookAt(player.transform);

            if (attackTimer >= attackCooldown)
            {
                Attack();
                attackTimer = 0f;
            }

        }

        else if (playerDistance < chaseRange)
        {
            Debug.Log("Chasing Player");
            transform.LookAt(playerLoc, transform.up);

            var moveVector = transform.forward * Time.deltaTime * speed;

            var correctedVector = new Vector3(moveVector.x, 0f, moveVector.z);

            transform.position += correctedVector;
        }

        else if (Vector3.Distance(transform.position, idlePos) > .25f)
        {
            Debug.Log("Going To Idle");

            transform.LookAt(idlePos);

            var moveVector = transform.forward * Time.deltaTime * speed;
            transform.position += moveVector;
        }


    }

    void Attack()
    {
        Debug.Log("Enemy hits Player!");

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy took damage: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        if (GameManager.instance != null)
        {
            GameManager.instance.EnemyKilled();
        }

        Destroy(transform.root.gameObject);
    }
}