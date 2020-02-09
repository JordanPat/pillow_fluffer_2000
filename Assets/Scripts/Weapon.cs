using UnityEngine;
using System.Collections;
//using Valve.VR;

public class Weapon : MonoBehaviour {

	//private SteamVR_TrackedController controller;
	//private EVRButtonId triggerButton = EVRButtonId.k_EButton_SteamVR_Trigger;
	//private SteamVR_TrackedObject controller;
	//private SteamVR_Controller.Device device;
	private AudioSource audiosource;

	Animator anim;

	public GameObject projectile;
	public float power;
	public float damage = 10f;
	public float range = 100f;
	public int ammo = 10;

	public Camera fpsCam;
	public GameObject wintext;
	public GameObject losetext;

	[SerializeField]
	private GameObject muzzleflashPrefab;

	[SerializeField]
	public Transform muzzlePoint;

	// Use this for initialization
	private void Start () {

		audiosource = GetComponent<AudioSource> ();
		//controller = GetComponentInParent<SteamVR_TrackedObject> ();
		//controller = GetComponentInParent<SteamVR_TrackedController> ();
		//controller.TriggerClicked += FireWeapon;

		anim = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))//device.GetPressDown(triggerButton))
		{
			FireWeapon ();
		}
	}

	private bool FireWeapon()
	{
		ammo--;
		//Debug.Log ("ammo left: " + ammo);
		if (ammo > 0) {
			audiosource.Play ();

			var muzzleflash = Instantiate (muzzleflashPrefab, muzzlePoint.position, muzzlePoint.rotation);
			Destroy (muzzleflash, 0.05f);
			anim.SetBool ("fire", true);

			GameObject proj = (GameObject)Instantiate (projectile, muzzlePoint.position, muzzlePoint.rotation);
			proj.GetComponent<Rigidbody> ().velocity = muzzlePoint.forward * power;

			RaycastHit hit;
			if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
				//Debug.Log (hit.transform.name);
			}
		} 
		if(ammo < 1){
			losetext.SetActive (true);
			Destroy (wintext);
		}

		return true;
	}
}
