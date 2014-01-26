using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

    public ball master = null;

    void Update()
    {
        if (transform.childCount > 3) Destroy(transform.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        ball other = collision.gameObject.GetComponent<ball>();
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;
        Vector3 randomAngle = new Vector3(Random.value, Random.value, Random.value);

        if (other != null)
        {
        
            if (other.master == null)                   // No master yet?
            {
                master = this;                          // Make this one master
                other.master = this;                    // Tell the other
                other.rigidbody.isKinematic = true;
                collision.transform.parent = transform; // make the other a child of this one.
            }
            else                                        // We already have a master
            {
                master = other.master;                  // So we also use the master
                rigidbody.isKinematic = true;           // and make us a child of the master
                transform.parent = master.transform;
            }

           
        }

        if (collision.transform.name == "Wall")
        {
            print("Ball collided with Wall");
            rigidbody.AddForceAtPosition((collision.relativeVelocity  + randomAngle + Vector3.up) * 200, pos);
        }
    }
}
