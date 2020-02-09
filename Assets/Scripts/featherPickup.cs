using UnityEngine;
using System.Collections;

public class featherPickup : MonoBehaviour {

	// Featherstuff
	//************************************************************************************
	// feather variable
	public int NumOfFeathers = 0;
	private int TurnedInFeathers = 0;
	public GameObject porg;
	public int feathers2Win;
	public GameObject wintext;
	Animator anim;

	//***************************************************************************************

	// Use this for initialization
	void Start () {
		anim = porg.GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision hit)
	{
		//Featherstuff - Jacob Knight
		//************************************************************************************************
		Debug.Log("you hit: " + hit.gameObject.name);
		if (hit.gameObject.name == "Feather")
		{
			Destroy(hit.gameObject);
			NumOfFeathers++;
		}
		else if (hit.gameObject.name == "Pillows")
		{
			anim.SetTrigger ("feather_collected");
			TurnedInFeathers += NumOfFeathers;
			NumOfFeathers = 0;
			if (TurnedInFeathers >= feathers2Win)
			{
				Debug.Log("Turned in all of your feathers", gameObject);
				wintext.SetActive (true);
			}
			else
			{
				Debug.Log("Turned in feathers", gameObject);
				NumOfFeathers = 0;
			}

		}
		//************************************************************************************************
	}
}
