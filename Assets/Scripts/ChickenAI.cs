using UnityEngine;
using System.Collections;

public class ChickenAI : MonoBehaviour {

	public GameObject projectile;
	public GameObject feather;
	Vector3 fspawn;
	public int health = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		fspawn = transform.position;
	}
		
	private void OnCollisionEnter(Collision hit){
		//Debug.Log ("collision");
		if (hit.gameObject.tag == "bullet") {
			health--;
			Debug.Log ("bullet hit\nhealth: "+ health);
			if (health < 1) {	
				fspawn.y = 2;
				feather = Instantiate (feather,fspawn,Quaternion.identity) as GameObject;
				Destroy (gameObject);
			}
		}
	}
	private void OnTriggerEnter()
	{


	}

}
