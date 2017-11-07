using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerManagerScript : MonoBehaviour {

	public LineRenderer laser;
	public float laserWidth = 0.01f;
	public float laserMaxLength = 200f;
	public GameObject ballAndArm;
	public GameObject ballSpawn;
	public Text hudText;

	private Vector3 ballAccel;
	private Vector3 ballLastVelocity;
	// Use this for initialization
	void Start () {
		Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
		laser.SetPositions( initLaserPositions );
		laser.SetWidth( laserWidth, laserWidth );
		ballSpawn.SetActive(false);
		ballAccel = new Vector3 (1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion ori = GvrController.Orientation;
		gameObject.transform.localRotation = ori;
		ballAndArm.transform.localRotation = ori;

		Vector3 v = GvrController.Orientation * Vector3.forward;
		//Debug.DrawRay(gameObject.transform.position, v, Color.green);

		if (GvrController.ClickButtonDown) {
			// show ball as visible to start throw
			ballSpawn.SetActive(true);
		}

		ballAccel = (ballSpawn.transform.position - ballLastVelocity) / Time.fixedDeltaTime;
		ballLastVelocity = ballSpawn.transform.position;

		//ballAccel = (ballSpawn.GetComponent<Rigidbody> ().GetPointVelocity(ballSpawn.transform.position) - ballLastVelocity) / Time.fixedDeltaTime;
		//ballLastVelocity = ballSpawn.GetComponent<Rigidbody> ().GetPointVelocity(ballSpawn.transform.position);
		hudText.text = "x:" + ballAccel.x + " y:" + ballAccel.y + " z:" + ballAccel.z;

		if (GvrController.ClickButtonUp) {
			ThrowBall ();
			ballSpawn.SetActive(false);
		}

		//hudText.text = "x:" + GvrController.Accel.x + " y:" + GvrController.Accel.y + " z:" + GvrController.Accel.z;

	}

	void ThrowBall () {
		GameObject ballObj = (GameObject)Instantiate (Resources.Load ("Ball"));
		ballObj.transform.position = ballSpawn.transform.position;
		Rigidbody rb = ballObj.GetComponent<Rigidbody> ();

		rb.AddForce (ballAccel.x * 2.0f, ballAccel.y * 2.0f, ballAccel.z * 2.0f, ForceMode.Impulse);
	}
}
