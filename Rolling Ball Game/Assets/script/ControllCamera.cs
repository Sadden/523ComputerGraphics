using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllCamera : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	public Text timeText;
	private float time;
	public Text runTime;
	public GameObject player1;
	public GameObject player2;
	public int c1;
	public int c2;
	// Use this for initialization
	void Start () {


		time = 120;
		timeText.text = "120";
		runTime.text = "";

		offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = offset + player.transform.position+ new Vector3(0f,5f, 0f );
		if (time > 0) {
			time = time - Time.deltaTime;
		}
		timeText.text = time.ToString();
		if (time < 30) {
			runTime.text = "running out of time!!!!";
		}
		if(time<0 || time == 0)
		{
			runTime.text = "Game Over";
		}
	}
}
