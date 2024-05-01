using UnityEngine;
using UnityEngine.AI;

public class RagdollControl : MonoBehaviour
{
    public Animator mainAnimator;
    public GameObject ragdollRig;
    public BoxCollider boxCollider;
    public static bool isRagdoll;
    public Enemy enemy;
    void Start()
    {
        GetRagdoll();
        RagdollOff();
        enemy = GetComponent<Enemy>();
    }


    void Update()
    {
        if (enemy.health <= 0)
        {
            RagdollOn();
        }
        else
        {
            RagdollOff();
        }
    }

    Collider[] colliders;
    Rigidbody[] rigidbodies;
    void GetRagdoll()
    {
        colliders = ragdollRig.GetComponentsInChildren<Collider>();
        rigidbodies = ragdollRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollOff()
    {
        isRagdoll= false;
        if (!isRagdoll)
        {
            mainAnimator.enabled = true;
            foreach (Collider ragdollCollider in colliders)
            {
                ragdollCollider.enabled = false;
            }
            foreach (Rigidbody ragdollRigidbody in rigidbodies)
            {
                ragdollRigidbody.isKinematic = true;
            }

            boxCollider.enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
    void RagdollOn()
    {
        isRagdoll = true;
        if (isRagdoll)
        {
            mainAnimator.enabled = false;
            foreach (Collider ragdollCollider in colliders)
            {
                ragdollCollider.enabled = true;
            }
            foreach (Rigidbody ragdollRigidbody in rigidbodies)
            {
                ragdollRigidbody.isKinematic = false;
            }

            boxCollider.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshAgent>().isStopped = true;

        }
        
        
    }
}
