using UnityEngine;

public class Doors : MonoBehaviour
{
    public float detectionRadius = 5f;
    public string playerTag = "Player";

    [Header("Object 1")]
    public GameObject object1;
    public Vector3 axis1 = Vector3.right;
    public float distance1 = 3f;
    public float speed1 = 2f;

    [Header("Object 2")]
    public GameObject object2;
    public Vector3 axis2 = Vector3.right;
    public float distance2 = 3f;
    public float speed2 = 2f;

    Vector3 obj1Start;
    Vector3 obj2Start;
    Vector3 obj1Target;
    Vector3 obj2Target;

    void Start()
    {
        if (object1 != null)
        {
            obj1Start = object1.transform.position;
            obj1Target = obj1Start + axis1.normalized * distance1;
        }

        if (object2 != null)
        {
            obj2Start = object2.transform.position;
            obj2Target = obj2Start + axis2.normalized * distance2;
        }
    }

    void Update()
    {
        bool playerDetected = false;

        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag(playerTag))
            {
                playerDetected = true;
                break;
            }
        }

        if (object1 != null)
        {
            Vector3 dest1 = playerDetected ? obj1Target : obj1Start;
            object1.transform.position = Vector3.MoveTowards(
                object1.transform.position,
                dest1,
                speed1 * Time.deltaTime
            );
        }

        if (object2 != null)
        {
            Vector3 dest2 = playerDetected ? obj2Target : obj2Start;
            object2.transform.position = Vector3.MoveTowards(
                object2.transform.position,
                dest2,
                speed2 * Time.deltaTime
            );
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
