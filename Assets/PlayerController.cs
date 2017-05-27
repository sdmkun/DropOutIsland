using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidMe;
	public float constantSpeed = 5;
  public float dashSpeed = 100;
	public float rayDistance = 5.0f;
	public int floorLayer = 8;

	// Use this for initialization
	void Start (){
    rigidMe = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    // rigidbodyのx軸（横）とz軸（縦）に力を加える
    //rigidMe.AddForce(x * constantSpeed, 0, z * constantSpeed);
		transform.position += new Vector3(x * constantSpeed * Time.deltaTime, 0, z * constantSpeed * Time.deltaTime);
		if(x != 0 || z != 0){
			transform.rotation = Quaternion.LookRotation(new Vector3(x, 0, z));
		}

		if(Input.GetButtonDown("Fire1")){
			Vector3 digPosition = transform.position + new Vector3(0, -0.75f, 0) + transform.forward;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			foreach(RaycastHit hit in Physics.RaycastAll(digPosition, fwd, rayDistance, 1 << floorLayer)){
				Destroy(hit.transform.gameObject);
			}
		}

		//抵抗、停止
//		rigidMe.AddForce(-rigidMe.velocity / 2.0f);
//		if(rigidMe.velocity.magnitude < 0.1){
//			rigidMe.velocity = new Vector3(0, 0, 0);
//		}
	}
}
