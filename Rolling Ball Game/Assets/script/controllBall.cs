using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllBall : MonoBehaviour {
	private Rigidbody rb;
	public int count1;
	public Text countText;
	public Text winText;
	public float y;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count1 = 0;
		countText.text = "Count: " + count1.ToString();
		winText.text = "";
		Vector3 pos = gameObject.transform.position;
		y = pos.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
	{
		Vector3 pos = gameObject.transform.position;
		y = pos.y;
		float movehorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movehorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*10);
		if (y < -3) {
			count1--;
			Vector3 pos2 = new Vector3 (0f,2f,0f);
			gameObject.transform.position = pos2;
		}
		if (Input.GetKeyDown(KeyCode.Space) && y<2) {
			Vector3 movement2 = new Vector3 (0.0f, 10, 0.0f);
			rb.AddForce (movement2*30);

		}


	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			count1++;
			countText.text = "Count: " + count1.ToString();
			if (count1 == 9) {
				winText.text = "You Win";
			}
		}
		if (other.gameObject.CompareTag ("wall")) {
			if (count1 > 0) {
				count1--;
			}
			countText.text = "Count: " + count1.ToString();
		}
	}
}
