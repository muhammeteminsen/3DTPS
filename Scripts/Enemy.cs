using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Objects")]
    NavMeshAgent navMesh;
    public Animator enemyAnimator;
    public GameObject destination;
    public GameObject[] rounds;
    public GameObject[] rounds1;
    public GameObject firePoint;
    public GameObject gunTec9;
    [Header("Values")]
    float suspicionDistance = 12;
    float shootDistance = 6;
    int totalpoint;
    int totalpoint1;
    public int health;
    [Header("Bools")]
    bool shootArea;
    bool suspicionArea;
    bool backReturn;
    bool defaultReturn;
    bool backReturn1;
    bool defaultReturn1;
    bool isLookAt;
    public bool isRounds;
    public bool isDedect;
    [Header("Effects")]
    public ParticleSystem MuzzleEffect;
    public ParticleSystem BloodEffect;
    [Header("HitSettings")]
    public float hitTime = 1.2f;
    float hitCount;
    public int hitPower;
    public AudioSource hitSound;
   
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        StartCoroutine(RoundsControl());
        health = 100;
        
    }


    void Update()
    {

        Shoot();
        Suspicion();
        if (health<=0)
        {
            navMesh.isStopped = true;
            enemyAnimator.enabled = false;
            GetComponent<Rigidbody>().mass = 1;
            Destroy(gameObject, 10f);
            isLookAt = false;
           
        }

    }
    
    IEnumerator RoundsTechnich()
    {   
        enemyAnimator.SetBool("isWalk", true);
        int roundsValue = 1;


        if (!backReturn)
        {
            totalpoint = rounds.Length - 1;
        }

        while (isRounds)
        {

            if (roundsValue >= rounds.Length - 1 && !suspicionArea && !shootArea && isRounds)
            {
                defaultReturn = false;
                backReturn = true;

                if (Vector3.Distance(transform.position, rounds[rounds.Length - 1].transform.position) <= 1f)
                {
                    if (suspicionArea)
                    {
                        Suspicion();
                    }
                    enemyAnimator.SetBool("isWalk", false);
                    yield return new WaitForSecondsRealtime(5f);
                    yield return true;
                }
                enemyAnimator.SetBool("isWalk", true);
                navMesh.SetDestination(rounds[roundsValue].transform.position);

            }
            if (Vector3.Distance(transform.position, rounds[roundsValue].transform.position) <= .5f && !backReturn && !suspicionArea && !shootArea && isRounds)
            {
                defaultReturn = true;
                ++roundsValue;
                navMesh.SetDestination(rounds[roundsValue].transform.position);

            }
            else
            {
                if (!suspicionArea && !shootArea && isRounds)
                {
                    navMesh.SetDestination(rounds[roundsValue].transform.position);
                }

            }

            if (roundsValue <= 0 && !suspicionArea && !shootArea && isRounds)
            {
                backReturn = false;
                defaultReturn = true;
                if (Vector3.Distance(transform.position, rounds[0].transform.position) <= 1f)
                {
                    if (suspicionArea)
                    {
                        Suspicion();
                    }
                    enemyAnimator.SetBool("isWalk", false);
                    yield return new WaitForSecondsRealtime(5f);
                    yield return true;
                }
                enemyAnimator.SetBool("isWalk", true);
                navMesh.SetDestination(rounds[roundsValue].transform.position);




            }
            if (roundsValue >= totalpoint && !defaultReturn && !suspicionArea && !shootArea && isRounds)
            {
                backReturn = true;

                if (Vector3.Distance(transform.position, rounds[roundsValue].transform.position) <= .5f)
                {
                    roundsValue--;
                    totalpoint = roundsValue - 1;
                    navMesh.SetDestination(rounds[roundsValue].transform.position);
                }
                else
                {
                    if (!suspicionArea && !shootArea)
                    {
                        navMesh.SetDestination(rounds[roundsValue].transform.position);
                    }
                }

            }


            yield return null;
        }
    }
    IEnumerator RoundsTechnich1()
    {
        enemyAnimator.SetBool("isWalk", true);
        int roundsValue1 = 1;

        if (!backReturn1)
        {
            totalpoint1 = rounds1.Length - 1;

        }

        while (isRounds)
        {
            if (roundsValue1 >= rounds1.Length - 1 && !suspicionArea && !shootArea && isRounds)
            {
                defaultReturn1 = false;
                backReturn1 = true;
                if (Vector3.Distance(transform.position, rounds1[rounds1.Length - 1].transform.position) <= 1f)
                {
                    if (suspicionArea)
                    {
                        Suspicion();
                    }
                    enemyAnimator.SetBool("isWalk", false);
                    yield return new WaitForSecondsRealtime(5f);
                    yield return true;
                }
                enemyAnimator.SetBool("isWalk", true);
                navMesh.SetDestination(rounds1[roundsValue1].transform.position);


            }
            if (Vector3.Distance(transform.position, rounds1[roundsValue1].transform.position) <= .5f && !backReturn1 && !suspicionArea && !shootArea && isRounds)
            {
                defaultReturn1 = true;
                ++roundsValue1;
                navMesh.SetDestination(rounds1[roundsValue1].transform.position);

            }
            else
            {
                if (!suspicionArea && !shootArea)
                {
                    navMesh.SetDestination(rounds1[roundsValue1].transform.position);
                }
            }

            if (roundsValue1 <= 0 && !suspicionArea && !shootArea && isRounds)
            {
                backReturn1 = false;
                defaultReturn1 = true;
                if (Vector3.Distance(transform.position, rounds1[0].transform.position) <= 1f)
                {
                    if (suspicionArea)
                    {
                        Suspicion();
                    }
                    enemyAnimator.SetBool("isWalk", false);
                    yield return new WaitForSecondsRealtime(5f);
                    yield return true;
                }
                enemyAnimator.SetBool("isWalk", true);
                navMesh.SetDestination(rounds1[roundsValue1].transform.position);


            }
            if (roundsValue1 >= totalpoint1 && !defaultReturn1 && !suspicionArea && !shootArea && isRounds)
            {
                backReturn1 = true;

                if (Vector3.Distance(transform.position, rounds1[roundsValue1].transform.position) <= .5f)
                {
                    roundsValue1--;
                    totalpoint1 = roundsValue1 - 1;
                    navMesh.SetDestination(rounds1[roundsValue1].transform.position);
                    Debug.Log(roundsValue1);
                }
                else
                {
                    if (!suspicionArea && !shootArea)
                    {
                        navMesh.SetDestination(rounds1[roundsValue1].transform.position);
                    }
                }

            }


            yield return null;
        }
    }
    IEnumerator RoundsControl()
    {
        if (isRounds)
        {
            yield return new WaitForSeconds(5f);
            int roundsRandomize = Random.Range(0, 2);

            switch (roundsRandomize)
            {

                case 0:
                    StartCoroutine(RoundsTechnich());
                    break;

                case 1:
                    StartCoroutine(RoundsTechnich1());
                    break;
            }
            yield break;
        }
        

        
    }
    void Suspicion()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) <= suspicionDistance)
        {

            suspicionArea = true;
            isDedect = true;
            if (suspicionArea && !RagdollControl.isRagdoll)
            {

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, suspicionDistance);

                foreach (Collider collider in hitColliders)
                {
                    if (collider.gameObject.CompareTag("MainCharacter") && !shootArea)
                    {
                        isRounds = false;
                        destination = collider.gameObject;
                        enemyAnimator.SetBool("isWalk", true);
                        enemyAnimator.SetBool("isRun", false);
                        navMesh.SetDestination(destination.transform.position);
                    }

                }
            }


        }

        else
        {
            suspicionArea = false;
            if (isDedect && !isRounds)
            {
                navMesh.SetDestination(destination.transform.position);
                enemyAnimator.SetBool("isWalk", false);
                enemyAnimator.SetBool("isRun", true);
            }

        }
    }
    void Shoot()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) <= shootDistance)
        {

            suspicionArea = false;
            shootArea = true;
            if (shootArea && !RagdollControl.isRagdoll)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, shootDistance);

                foreach (Collider collider in hitColliders)
                {

                    if (collider.gameObject.CompareTag("MainCharacter"))
                    {
                        destination = collider.gameObject;
                        Fire(collider.gameObject);
                        navMesh.stoppingDistance = 6;


                    }
                    else
                    {
                        if (!isRounds && shootArea)
                        {
                            navMesh.SetDestination(destination.transform.position);
                        }
                        if (isLookAt)
                        {
                            enemyAnimator.SetBool("isWalk", false);
                            enemyAnimator.SetBool("isFire", true);
                            isLookAt = false;
                        }
                    }

                }
            }
        }

        else
        {
            shootArea = false;
            navMesh.isStopped = false;
            enemyAnimator.SetBool("isFire", false);
        }


    }
    void Fire(GameObject boss)
    {
        isLookAt = true;
        Vector3 distance = boss.transform.position - transform.position;
        if (!RagdollControl.isRagdoll && health>0)
        {
            
            Quaternion rotation = Quaternion.LookRotation(distance, Vector3.up);
            transform.rotation = rotation;
            
        }
        navMesh.isStopped = true;
        enemyAnimator.SetBool("isWalk", false);
        enemyAnimator.SetBool("isFire", true);

        RaycastHit hit;

        if (Physics.Raycast(firePoint.transform.position, distance, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(firePoint.transform.position, distance, Color.blue);
            if (hit.transform.gameObject.CompareTag("MainCharacter") && Time.time > hitCount)
            {
                MuzzleEffect.Play();
                hitSound.Play();
                Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hitCount = Time.time + hitTime;
                hit.transform.gameObject.GetComponent<PlayerMovement>().HealthControl(hitPower);
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, suspicionDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, shootDistance);
    }
}
