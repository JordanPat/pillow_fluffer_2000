﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	Animator anim;
	public GameObject[] waypoints;
	public int num = 0;

	public float minDist;
	public float speed;

	public bool rand = false;
	public bool go = true;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (gameObject.transform.position, waypoints [num].transform.position);
		//Debug.Log ("distance to waypoint "+num+": "+dist+"\nmindist: "+minDist);
		if (go) {
			if (dist > minDist) {
				Move ();

			} else {
				anim.SetBool("moving",false);
				if (!rand) {
					if (num + 1 == waypoints.Length) {
						num = 0;
					} else {
						num++;
					}
				}else
					{
						num = Random.Range(0, waypoints.Length);	
				}
			}

		}
	}

	public void Move()
	{
		gameObject.transform.LookAt (waypoints [num].transform.position);
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
		anim.SetBool("moving",true);
	}
	
}