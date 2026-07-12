using UnityEngine;

public class GiftBox : MonoBehaviour
{
    public Transform player;
    public GameObject ballPrefab;
    public float interactRange = 15f;
    public int pressesNeeded = 3;

    private int presses = 0;

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
            else Debug.LogError("GiftBox: no player assigned and no object tagged 'Player'!");
        }
    }

    void Update()
    {
        if (player == null) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;

        float dist = Vector3.Distance(transform.position, player.position);
        Debug.Log("GiftBox: E pressed, distance = " + dist);   // shows if you're in range

        if (dist <= interactRange)
        {
            presses++;
            Debug.Log("GiftBox opened " + presses + "/" + pressesNeeded);

            if (presses >= pressesNeeded)
            {
                if (ballPrefab != null)
                    Instantiate(ballPrefab, transform.position + Vector3.up, Quaternion.identity);
                else
                    Debug.LogError("GiftBox: ballPrefab not assigned!");

                Destroy(gameObject);
            }
        }
    }
}