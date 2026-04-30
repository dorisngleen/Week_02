using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    Vector3 newPosition = new Vector3(0.005f, 0.005f, 0.005f);


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
        transform.Rotate(0, 100, 0);

        if(transform.position.x > 0.5)
        {
            newPosition.x = -0.005f;
            newPosition.y = -0.005f;
            newPosition.z = -0.005f;

            transform.Rotate(0, 100, 0);
        }

    }
}
