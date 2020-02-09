using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickHead : MonoBehaviour {

	public GameObject chicken;
	ChickenAI h;
	int health = 4;


	// Use this for initialization
	void Start () {
		//GameObject Chicken = GameObject.("Chicken complete (1)");

		h = chicken.GetComponent<ChickenAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health != h.health) {
			Debug.Log ("heath from head: " + h.health);
			health--;
		}
	}
	private void OnCollisionEnter(Collision hit){
		Debug.Log ("headshot");
		if(hit.gameObject.tag == "bullet")
		{
			h.health -= 2;
			Destroy (gameObject);
		}

	}

}
