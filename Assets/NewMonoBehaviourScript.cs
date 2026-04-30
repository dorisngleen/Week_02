using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    Vector3 newPosition = new Vector3(1.0f, 5.0f, 0.05f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(transform.position.x);
        print(transform.position.y);
        print(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += newPosition;
    }
}
