using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public static int cylindersLeft = 4;

    void OnCollisionEnter(Collision collision)
    {
      print("Collision detected with" + collision.gameObject.name);

      if(collision.gameObject.name == "NestedParent_Unpack")
      {
        Destroy(gameObject);
      }

      if(collision.gameObject.name.Contains("Cylinder"))
      {
        cylindersLeft--;
        print("Cylinder collected! Remaining: " + cylindersLeft);
        //Destroy(collision.gameObject);
      } 

      if (collision.gameObject.name == "FinishZone")
        {
            if (cylindersLeft <= 0)
            {
                print("You collected everything! Well done!");
            }
            else
            {
                print("Still " + cylindersLeft + " cylinders left!");
            }
        }

    }

    void OnCollisionExit(Collision collision)
    {
      print("Colliding ended with" + collision.gameObject.name);
      Destroy(gameObject);
    }

    void OnCollisionStay(Collision collision)
    {
      print("Colliding with" + collision.gameObject.name);
    }
}