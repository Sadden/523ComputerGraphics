using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllBall2 : MonoBehaviour {
	private Rigidbody rb;
	public int count2;
	public Text countText;
	public Text winText;
	public float y;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count2 = 0;
		countText.text = "Count: " + count2.ToString();
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
		float movehorizontal = Input.GetAxis ("Horizontal2");
		float moveVertical = Input.GetAxis ("Vertical2");
		Vector3 movement = new Vector3 (movehorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*10);
		if (y < -3) {
			count2--;
			Vector3 pos2 = new Vector3 (0f,2f,0f);
			gameObject.transform.position = pos2;
		}
		if (Input.GetMouseButtonDown (0) && y<2) {
			Vector3 movement2 = new Vector3 (0.0f, 10, 0.0f);
			rb.AddForce (movement2*30);

		}


	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			count2++;
			countText.text = "Count: " + count2.ToString();
			if (count2 == 9) {
				winText.text = "You Win";
			}
		}
		if (other.gameObject.CompareTag ("wall")) {
			if (count2 > 0) {
			count2--;
			}
			countText.text = "Count: " + count2.ToString();
		}
	}
}
