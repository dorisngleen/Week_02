using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private HashSet<int> scored = new HashSet<int>();  // balls already counted

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Goal triggered by: " + other.name + " tag: " + other.tag);

        if (!other.CompareTag("Ball"))
        {
            Debug.Log("Goal: wrong tag");
            return;
        }
        if (ScoreManager.Instance == null)
        {
            Debug.Log("Goal: ScoreManager.Instance is NULL");
            return;
        }

        GameObject ball = other.attachedRigidbody
            ? other.attachedRigidbody.gameObject
            : other.gameObject;

        int id = ball.GetInstanceID();
        if (scored.Contains(id))
        {
            Debug.Log("Goal: ball already scored, ignoring");
            return;
        }

        scored.Add(id);
        ScoreManager.Instance.AddScore(1);
        Debug.Log("Goal: scored! new total logic ran");
    }
}