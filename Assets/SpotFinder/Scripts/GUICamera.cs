using UnityEngine;
using System.Collections;

public class GUICamera : MonoBehaviour {

	public GameObject winPlane;
	public GameObject num1;
	public GameObject num2;
	public GameObject num3;
	public GameObject num4;
	public GameObject num5;
	
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void timer(int seconds){
		Debug.Log("Timer: " + seconds);
		switch(seconds){
			case 1:
			punchOne ();
				break;
			case 2:
			punchTwo ();
				break;
			case 3:
			punchThree ();
				break;
			case 4:
			punchFour ();
				break;
			case 5:
			punchFive ();
				break;
		default:
		break;
		}
	
	}
	
	public void punchOne(){
		Debug.Log ("1...");
		num1.SetActive(true);
		iTween.PunchScale( num1, iTween.Hash (
			"name", "1Punch",
			"amount", new Vector3(0.5f, 0.5f, 0.5f),
			"time", 0.8f,
			"oncompletetarget", this.gameObject,
			"oncomplete", "punchOneDone"));
	}
	public void punchOneDone(){
		num1.SetActive(false);
	}	// I'm tired don't judge me
	public void punchTwo(){
		Debug.Log ("2...");
		num2.SetActive(true);
		iTween.PunchScale( num2, iTween.Hash (
			"name", "2Punch",
			"amount", new Vector3(0.5f, 0.5f, 0.5f),
			"time", 0.8f,
			"oncompletetarget", this.gameObject,
			"oncomplete", "punchTwoDone"));
	}
	public void punchTwoDone(){
		num2.SetActive(false);
	}	
	public void punchThree(){
		Debug.Log ("3...");
		num3.SetActive(true);
		iTween.PunchScale( num3, iTween.Hash (
			"name", "3Punch",
			"amount", new Vector3(0.5f, 0.5f, 0.5f),
			"time", 0.8f,
			"oncompletetarget", this.gameObject,
			"oncomplete", "punchThreeDone"));
	}
	public void punchThreeDone(){
		num3.SetActive(false);
	}	
	public void punchFour(){
		Debug.Log ("4...");
		num4.SetActive(true);
		iTween.PunchScale( num4, iTween.Hash (
			"name", "4Punch",
			"amount", new Vector3(0.5f, 0.5f, 0.5f),
			"time", 0.8f,
			"oncompletetarget", this.gameObject,
			"oncomplete", "punchFourDone"));
	}
	public void punchFourDone(){
		num4.SetActive(false);
	}	
	public void punchFive(){
		Debug.Log ("5...");
		num5.SetActive(true);
		iTween.PunchScale( num5, iTween.Hash (
			"name", "5Punch",
			"amount", new Vector3(0.5f, 0.5f, 0.5f),
			"time", 0.8f,
			"oncompletetarget", this.gameObject,
			"oncomplete", "punchFiveDone"));
	}
	public void punchFiveDone(){
		num5.SetActive(false);
	}
	
	
	
	public void Win(){
		Debug.Log ("Win GUI");
		winPlane.SetActive(true);
		iTween.PunchScale( winPlane, iTween.Hash (
		"name", "WinPunch",
		"amount", new Vector3(1.5f, 1.5f, 1.5f),
		"time", 1.5f));
	}
	
	public void NewGame(){
		winPlane.SetActive (false);
		
		
		
	}
	
	
}
