using UnityEngine;
using System.Collections;

// ----- Low Poly FPS Pack Free Version -----
public class GrenadeScript : MonoBehaviour {

	

	[Header("Timer")]
	//Time before the grenade explodes
	[Tooltip("Time before the grenade explodes")]
	public float grenadeTimer = 5.0f;

	[Header("Explosion Prefabs")]
	//Explosion prefab
	public Transform explosionPrefab;

	[Header("Explosion Options")]
	//Radius of the explosion
	[Tooltip("The radius of the explosion force")]
	public float radius = 40.0F;
	//Intensity of the explosion
	[Tooltip("The intensity of the explosion force")]
	public float power = 350.0F;

	[Header("Throw Force")]
	[Tooltip("Minimum throw force")]
	public float minimumForce = 1000.0f;
	[Tooltip("Maximum throw force")]
	public float maximumForce = 1500.0f;
	private float throwForce;

	[Header("Audio")]
	public AudioSource impactSound;

	private void Awake () 
	{
		//Generate random throw force
		//based on min and max values
		throwForce = Random.Range
			(minimumForce, maximumForce);

		//Random rotation of the grenade
		GetComponent<Rigidbody>().AddRelativeTorque 
		   (Random.Range(500, 1500), //X Axis
			Random.Range(0,0), 		 //Y Axis
			Random.Range(0,0)  		 //Z Axis
			* Time.deltaTime * 5000);
	}

	private void Start () 
	{
		GetComponent<Rigidbody>().gameObject.GetComponent<Collider>().enabled = false;
		//Launch the projectile forward by adding force to it at start
		GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 700);

		//Start the explosion timer
		StartCoroutine (ExplosionTimer ());
	}

	private void OnCollisionEnter (Collision collision) 
	{
		//Play the impact sound on every collision
		impactSound.Play ();
	}

	private IEnumerator ExplosionTimer () 
	{
		//Wait set amount of time
		yield return new WaitForSeconds(0.05f);
		GetComponent<Rigidbody>().gameObject.GetComponent<Collider>().enabled = true;

		yield return new WaitForSeconds(grenadeTimer);
		
		//Raycast downwards to check ground
		RaycastHit checkGround;
		if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
		{
			//Instantiate metal explosion prefab on ground
			Instantiate (explosionPrefab, checkGround.point, 
				Quaternion.FromToRotation (Vector3.forward, checkGround.normal)); 
		}
		
		
		//Explosion force
		Vector3 explosionPos = transform.position;
		//Use overlapshere to check for nearby colliders
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			if (hit.tag != "Knife")
			{
				Rigidbody rb = hit.GetComponent<Rigidbody>();

				//Add force to nearby rigidbodies
				if (rb != null)
				{
					rb.AddExplosionForce(power * 5, explosionPos, radius, 3.0F);
					Debug.Log("rb = " + rb);
					HealthBar healthBar = rb.GetComponentInChildren<HealthBar>();
					if (healthBar != null)
					{
						
						healthBar.setFlag(true);
						
						Debug.Log("healthBar = " + healthBar);

						float dist = Vector3.Distance(explosionPos, rb.transform.position);
						healthBar.setExplDist(dist);
						
						Debug.Log(healthBar.flag);

						GameObject obj = rb.gameObject.GetComponentInChildren<HealthBar>().gameObject;//GameObject.Find(rb.gameObject.name + "/Sphere/HealthBar(Clone)");

						Debug.Log("yes"+obj.GetComponentInChildren<HealthBar>().healthSystem);

						healthBar.Setup(obj.GetComponentInChildren<HealthBar>().healthSystem);

						
						
						Debug.Log(healthBar.explDist);
					}
				}
			}
			//If the explosion hits "Target" tag and isHit is false
			if (hit.GetComponent<Collider>().tag == "Target" 
			    	&& hit.gameObject.GetComponent<TargetScript>().isHit == false) 
			{
				//Animate the target 
				hit.gameObject.GetComponent<Animation> ().Play("target_down");
				//Toggle "isHit" on target object
				hit.gameObject.GetComponent<TargetScript>().isHit = true;
				
			}

			//If the explosion hits "ExplosiveBarrel" tag
			if (hit.GetComponent<Collider>().tag == "ExplosiveBarrel") 
			{
				//Toggle "explode" on explosive barrel object
				hit.gameObject.GetComponent<ExplosiveBarrelScript> ().explode = true;
			}
		}

		//Destroy the grenade object on explosion
		Destroy (gameObject);
	}

	

}
// ----- Low Poly FPS Pack Free Version -----