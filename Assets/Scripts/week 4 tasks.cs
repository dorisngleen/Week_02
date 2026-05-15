using UnityEngine;

public class playerScript : MonoBehaviour
{
    GameObject Cylinder;
    int collCount = 0;
    int score = 0;

    void OnInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.gameObject.tag == "Collectable")
            {
                Cylinder = hit.collider.gameObject;
                collCount++;
                score++;
                print("Player has collected " + collCount + " collectables");
                Destroy(Cylinder);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FinishZone" && collCount >=3)
        {
            print("Player entered trigger zone with " + collCount + "collectables");
        }
    }
}