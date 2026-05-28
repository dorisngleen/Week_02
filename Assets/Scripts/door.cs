using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator doorAnimator;
    bool isOpen = false;
    bool playerNearby = false;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                doorAnimator.SetTrigger("opendoor");
                isOpen = true;
            }
            else
            {
                doorAnimator.SetTrigger("closedoor");
                isOpen = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("NestedParentCapsule_Unpack"))
        {
            playerNearby = true;
            print("Press E to open door");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("NestedParentCapsule_Unpack"))
        {
            playerNearby = false;
        }
    }
}