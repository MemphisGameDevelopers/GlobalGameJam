using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public GameObject _playerCamera;
	public GameObject _projectorObject;
	public GameObject playerObject;
	
	public GameObject[] _particleSystems;
	
	public float stayDuration = 6.0f;
	bool lockedOn;
	bool haveWon;

	public GameObject listener;
	
	public float lowX, lowZ, highX, highZ, yheight;
	Vector3 newPos;

	// Use this for initialization
	void Start () {
		if( ! _playerCamera ){
			_playerCamera = Camera.main.gameObject;
		}
		
		NewPosition ();
		NewTarget ();
	}
	
	void NewPosition(){
		newPos.x = Random.Range (lowX, highX);
		newPos.z = Random.Range(lowZ, highZ);
		newPos.y = yheight;
		
		transform.parent.position = newPos;
	}
	
	void NewTarget(){
		transform.parent.Rotate (
				new Vector3(    
					(Random.value * 90.0f) - 60.0f /* Need a -60 to 30 range */, 
					Random.value * 360.0f, 
					0.0f
				)
		);
	}
	
	// Update is called once per frame
	void Update () {
		if(haveWon && ( Input.GetButton("NewGame")) ){
		
			Debug.Log ("New game!");
			haveWon = false;
			// Stop Confetti particles
			StopConfetti();
			
			// Reset projector
			NewPosition();
			NewTarget();
			
			// Reset player
			playerObject.SendMessage ("NewGame");
			
			// Reset winboard
			listener.SendMessage ("NewGame");
		}
	}
	
	
	void BroadcastWin(){
		listener.SendMessage("Win");
	}
	
	float startTime = Mathf.Infinity;
	void OnTriggerEnter() {
		startTime = Mathf.Infinity;
	}
	void OnTriggerExit() {
		startTime = Mathf.Infinity;
	}
	
	int currentTimerSeconds = 0;
	void OnTriggerStay () {
	
		if(haveWon) return;
		
		
		// Check the rotation to see if the character is facing
		// the right direction to trigger the win condition
		if(
		   Mathf.Abs(Quaternion.Angle( 
		   _playerCamera.transform.rotation, _projectorObject.transform.rotation )) < 20 
		){
			lockedOn = true;
		} else lockedOn = false;		
		
		if(lockedOn == false){
			startTime = Mathf.Infinity; // Blank out the startTime while inside the hotzone and not looking at the right angle
		} else if (startTime == Mathf.Infinity){
			startTime = Time.time; // Set startTime to the current time as soon as you hit the right angle
		}
		
		
		if(startTime != Mathf.Infinity){
		// Update GUI if timer changed
			if( currentTimerSeconds != ((int) (Time.time - startTime))){
				currentTimerSeconds = ((int) (Time.time - startTime));
				listener.SendMessage("timer", currentTimerSeconds);
			}
		}
		
		


//		Debug.Log ("Angle difference is: " + Mathf.Abs(Quaternion.Angle( _playerCamera.transform.rotation, _projectorObject.transform.rotation )) );
		if(	!haveWon && 
			( (Time.time - startTime) > stayDuration)
		){
			Debug.Log ("YOU WIN!!");
			StartConfetti();
			BroadcastWin();
			haveWon = true;
			startTime = Mathf.Infinity;
		}
		
	}
	
	public void StartConfetti(){
		foreach( GameObject go in _particleSystems ){
			go.SetActive(true);
		}	
	}
	
	public void StopConfetti(){
		foreach( GameObject go in _particleSystems ){
			go.SetActive(false);
		}
	}
}
