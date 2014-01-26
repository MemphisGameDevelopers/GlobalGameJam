using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    private Transform p1cam;
    private Transform p2cam;
    private Transform p3cam;
    private Transform p4cam;

    public GameObject ball;

    public float speed = 30.0f;
    public float jump = 10.0f;

    public float smooth = 2.0F;
    public float tiltAngle = 3.0F;
    private float tiltAroundX;
    private Transform p1target;
    

	// Use this for initialization
	void Start () 
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

	    p1cam = player1.transform.Find("P1 Camera");
        p2cam = player2.transform.Find("P2 Camera");
        p3cam = player3.transform.Find("P3 Camera");
        p4cam = player4.transform.Find("P4 Camera");

        p1target = player1.transform.Find("P1 Target");


    }
	
	// Update is called once per frame
    void Update()
    {
        for (int i = 1; i < 5; i++)
        {
           
                switch (i)
                {
                    case 1:
                     player1.rigidbody.AddForce(player1.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player1.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     //p1target.position += new Vector3(0, Input.GetAxis("Xbox360Controller" + i + "RightY"));
                     p1target.position = Vector3.ClampMagnitude(p1target.transform.position, tiltAngle);
                     p1cam.LookAt(p1target);
                     if (Input.GetKeyDown("joystick 1 button 0")) player1.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     player1.rigidbody.angularVelocity = Vector3.zero;
                     break;

                    case 2:
                     player2.rigidbody.AddForce(player2.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player2.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetKey("joystick 2 button 0")) player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     player2.rigidbody.angularVelocity = Vector3.zero;
                     break;
                    
                    case 3:
                     player3.rigidbody.AddForce(player3.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player3.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetKey(KeyCode.Joystick3Button1)) player3.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     player3.rigidbody.angularVelocity = Vector3.zero;
                     break;

                    case 4:
                     player4.rigidbody.AddForce(player4.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player4.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetKey(KeyCode.Joystick4Button0)) player4.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     player4.rigidbody.angularVelocity = Vector3.zero;
                     break;

                    
                }

               
            

        }
    }
}
