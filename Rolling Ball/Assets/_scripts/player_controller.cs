using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countTxt;
	public Text winText;



	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
			
	}

	void SetCountText(){
		countTxt.text = "Count: " + count.ToString ();

		if(count >= 15){
			winText.text = "You Win Nerd!!!!";
		}
	}

}
