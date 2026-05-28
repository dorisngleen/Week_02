using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    AudioSource collectibleAudio;
    public static int cylindersLeft = 4;

    void Start()
    {
        cylindersLeft = 4;
        collectibleAudio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if (collectibleAudio != null && collectibleAudio.clip != null)
        {
            AudioSource.PlayClipAtPoint(collectibleAudio.clip, transform.position);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected with " + collision.gameObject.name);

        if (collision.gameObject.name == "NestedParent_Unpack")
        {
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.name.Contains("Cylinder"))
        {
            cylindersLeft--;
            print("Cylinder collected! Remaining: " + cylindersLeft);

            CollisionScript cylinderScript = collision.gameObject.GetComponent<CollisionScript>();
            if (cylinderScript != null)
                cylinderScript.Collect();
            else
                Destroy(collision.gameObject);

            return;
        }

        if (collision.gameObject.name == "FinishZone")
        {
            if (cylindersLeft <= 0)
                print("You collected everything! Well done!");
            else
                print("Still " + cylindersLeft + " cylinders left!");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        print("Colliding ended with " + collision.gameObject.name);
    }

    void OnCollisionStay(Collision collision)
    {
        print("Colliding with " + collision.gameObject.name);
    }
}