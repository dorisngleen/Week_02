using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallKick : MonoBehaviour
{
    public Transform player;
    public float interactRange = 4f;
    public float kickForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 1f;   // drag -> ball slows to a stop after a while
        // Older Unity versions: use  rb.drag = 1f;  instead of linearDamping

        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= interactRange && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 dir = transform.position - player.position; // push away from player
            dir.y = 0f;
            rb.AddForce(dir.normalized * kickForce, ForceMode.Impulse);
        }
    }
}