using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform player;

    public int enemyScoreValue = 100;

    public LayerMask isPlayer;

    public Shooting shooting;

    List<Transform> points;
    int destPoint = 0;
    NavMeshAgent agent;

    public float sightRange, attackRange;
    private bool inSightRange, inAttackRange;

    public GameObject particleEffect;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("XRPlayerController").transform;

        agent = GetComponent<NavMeshAgent>();

        points = EnemySpawner.spawnPoints;

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (!inSightRange && !inAttackRange) Patrol();

        else if (inSightRange && !inAttackRange) Chase();

        else if (inSightRange && inAttackRange) Attack();

        if (GetComponent<Health>().health <= 0)
        {
            EnemyDeath();
            scoreManager.AddPoints(enemyScoreValue);
        }
        
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (points.Count == 0)
                return;

            agent.destination = points[destPoint].position;

            destPoint = (destPoint + 1) % points.Count;
        }
    }

    void Chase()
    {
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        shooting.Shoot();
    }

    public void EnemyDeath()
    {
        particleEffect.SetActive(true);
        particleEffect.transform.SetParent(null);
        Destroy(gameObject);
    }
}
