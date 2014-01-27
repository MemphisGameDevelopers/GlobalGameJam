using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float lowX, lowZ, highX, highZ;
	void NewGame() {
		
		Vector3 newPos = new Vector3( 
             Random.Range (lowX, highX),
             transform.position.y,
             Random.Range ( lowZ, highZ)
        );
		
		transform.position = newPos;
	}
}
