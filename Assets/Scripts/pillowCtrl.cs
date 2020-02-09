using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class pillowCtrl : MonoBehaviour {

	int featherCount = 0;
	public int featherMax = 10;
	featherPickup f;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("Character");

		f = player.GetComponent<featherPickup> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void featherHandler()
	{
		if(featherCount > featherMax/4)
		{
			if(gameObject.gameObject.tag == "pillow_sm")
			{
				gameObject.gameObject.SetActive (false);	
			}
			if(gameObject.gameObject.tag == "pillow_md")
			{
				gameObject.gameObject.SetActive (true);	
			}
		}
		else if(featherCount > featherMax-2)
		{
			if(gameObject.gameObject.tag == "pillow_md")
			{
				gameObject.gameObject.SetActive (false);	
			}
			if(gameObject.gameObject.tag == "pillow_lg")
			{
				gameObject.gameObject.SetActive (true);	
			}
		}

	}
	void onCollisionEnter(Collision hit)
	{
		if (f.NumOfFeathers > 1) 
		{
			featherCount += f.NumOfFeathers;
			featherHandler ();
		}	
	}
		
}
