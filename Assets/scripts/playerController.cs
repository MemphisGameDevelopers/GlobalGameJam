using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;
    private GameObject player5;

    public float speed = 30.0f;
    public float jump = 10.0f;
    public float smooth = 2.0F;
    public float tiltAngle = 360.0F;
    float tiltAroundX;
    Quaternion target;

	// Use this for initialization
	void Start () 
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        player5 = GameObject.Find("Player5");
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (Mathf.Abs(Input.GetAxis("Joy" + i + "X")) > 0.5
                || Mathf.Abs(Input.GetAxis("Joy" + i + "Y")) > 0.5
                || Mathf.Abs(Input.GetAxis("Xbox360Controller" + i + "RightX")) > 0.5)                
            //Debug.Log(Input.GetJoystickNames()[i] + " is moved");
            {

                switch (i)
                {
                    case 0:
                     player1.rigidbody.AddForce(player1.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player1.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetButton("joystick 1 button 0"))
                         {
                             print("player 1 jumped");
                             player1.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                         } 
                     
                     break;

                    case 1:
                     player2.rigidbody.AddForce(player2.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player2.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetButton("joystick 2 button 0"))
                     {
                         print("player 2 jumped");
                         player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     }  
                     break;
                    
                    case 2:
                     player3.rigidbody.AddForce(player3.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player3.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetKey(KeyCode.Joystick3Button1)) player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     break;

                    case 3:
                     player4.rigidbody.AddForce(player4.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player4.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     if (Input.GetKey(KeyCode.Joystick4Button0)) player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     break;

                    case 4:
                     player5.rigidbody.AddForce(player5.transform.forward * -Input.GetAxis("Joy" + i + "Y") * speed);                                      
                     player5.transform.Rotate(Vector3.up, Input.GetAxis("Xbox360Controller" + i + "RightX"));
                     //if (Input.GetKey(KeyCode.Joystick5Button0)) player2.rigidbody.AddForce(player2.transform.up * jump, ForceMode.Impulse);
                     break;

                }

               
            }

        }
    }
}
