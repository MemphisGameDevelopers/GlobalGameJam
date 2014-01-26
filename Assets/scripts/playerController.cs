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

    public GameObject[] ball;
    public float power = 100.0f;

    public float speed = 30.0f;
    public float jump = 10.0f;

    public float smooth = 2.0F;
    public float tiltAngle = 3.0F;
    private float tiltAroundX;
    private Transform p1target;
    private Transform p2target;
    private Transform p3target;
    private Transform p4target;

    Vector3 target1pos;
    Vector3 target2pos;
    Vector3 target3pos;
    Vector3 target4pos;
    

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
        p2target = player2.transform.Find("P2 Target");
        p3target = player3.transform.Find("P3 Target");
        p4target = player4.transform.Find("P4 Target");

        target1pos = p1target.position;
        target2pos = p2target.position;
        target3pos = p3target.position;
        target4pos = p4target.position;


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
                     p1target.Translate(Vector3.up * Input.GetAxis("Xbox360Controller" + i + "RightY")*Time.deltaTime);
                     target1pos = p1target.position;
                     target1pos.y = Mathf.Clamp(p1target.position.y, -3, 3);
                     p1target.position = target1pos;
                     p1cam.LookAt(p1target);
                     if (Input.GetKeyDown("joystick 1 button 0")) player1.rigidbody.AddForce(player1.transform.up * jump, ForceMode.Impulse);
                     player1.rigidbody.angularVelocity = Vector3.zero;
                     if (Input.GetKeyDown("joystick 1 button 1"))
                     {
                         GameObject bubble = Instantiate(ball[i], p1target.transform.position, Quaternion.identity) as GameObject;
                         bubble.rigidbody.AddForce(p1cam.transform.forward * power);
                     }
                     
                     break;

                    case 2:
                     player2.rigidbody.AddForce(player2.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player2.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     p2target.Translate(Vector3.up * Input.GetAxis("Xbox360Controller" + i + "RightY") * Time.deltaTime);
                     target2pos = p2target.position;
                     target2pos.y = Mathf.Clamp(p2target.position.y, -3, 3);
                     p2target.position = target2pos;
                     p2cam.LookAt(p2target);
                     if (Input.GetKeyDown("joystick 2 button 0")) player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     player2.rigidbody.angularVelocity = Vector3.zero;
                     if (Input.GetKeyDown("joystick 2 button 1"))
                     {
                         GameObject bubble = Instantiate(ball[i], p2target.transform.position, Quaternion.identity) as GameObject;
                         bubble.rigidbody.AddForce(p2cam.transform.forward * power);
                     }
                     break;
                    
                    case 3:
                     player3.rigidbody.AddForce(player3.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player3.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     p3target.Translate(Vector3.up * Input.GetAxis("Xbox360Controller" + i + "RightY") * Time.deltaTime);
                     target3pos = p3target.position;
                     target3pos.y = Mathf.Clamp(p3target.position.y, -3, 3);
                     p3target.position = target3pos;
                     p3cam.LookAt(p3target);
                     if (Input.GetKeyDown("joystick 3 button 0")) player3.rigidbody.AddForce(player3.transform.up * jump, ForceMode.Impulse);
                     player3.rigidbody.angularVelocity = Vector3.zero;
                     if (Input.GetKeyDown("joystick 3 button 1"))
                     {
                         GameObject bubble = Instantiate(ball[i], p3target.transform.position, Quaternion.identity) as GameObject;
                         bubble.rigidbody.AddForce(p3cam.transform.forward * power);
                     }
                     break;

                    case 4:
                     player4.rigidbody.AddForce(player4.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player4.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     p4target.Translate(Vector3.up * Input.GetAxis("Xbox360Controller" + i + "RightY") * Time.deltaTime);
                     target4pos = p4target.position;
                     target4pos.y = Mathf.Clamp(p4target.position.y, -3, 3);
                     p4target.position = target4pos;
                     p4cam.LookAt(p4target);
                     if (Input.GetKeyDown("joystick 4 button 0")) player4.rigidbody.AddForce(player4.transform.up * jump, ForceMode.Impulse);
                     player4.rigidbody.angularVelocity = Vector3.zero;
                     if (Input.GetKeyDown("joystick 4 button 1"))
                     {
                         GameObject bubble = Instantiate(ball[i], p4target.transform.position, Quaternion.identity) as GameObject;
                         bubble.rigidbody.AddForce(p4cam.transform.forward * power);
                     }
                     break;

                    
                }

               
            

        }
    }
}
