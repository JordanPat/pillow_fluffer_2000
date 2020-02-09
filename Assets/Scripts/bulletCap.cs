using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2f);
	}
	private void OnCollisionEnter()
	{
		Destroy (gameObject);
	}
	

}
