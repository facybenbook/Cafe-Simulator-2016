using UnityEngine;
using System.Collections;

public class NPCMove : MonoBehaviour {

	public float accel = 0.8f;
	public float inertia = 0.9f;
	public float speedLimit = 10.0f;
	public float minSpeed = 0.0f;
	public float stopTime = 1.0f;
	public float rotationDamping = 1.0f;
	public bool smoothRotation = true;
	public Transform[] waypoints = new Transform[15];


	
	private float currentSpeed = 0.0f;
	private int functionState = 0;
	private bool accelState;
	private bool slowState;
	private Transform waypoint;
	
	void Start(){
		functionState = 0;
		waypoint  = waypoints[Random.Range(0,14)];
	}
	
	void Update(){
		if(functionState == 0){
			Accel();
		}
		
		if(functionState == 1){
			currentSpeed = 0.0f;
			accel = 0.0f;
			inertia = 0.0f;
			rotationDamping = 0.0f;
			//StartCoroutine(Slow());
		}
	}
	
	void Accel(){
		if(accelState == false){
			accelState = true;
			slowState = false;
		}
		
		if(waypoint){
			if(smoothRotation){
				Quaternion rotation = Quaternion.LookRotation(waypoint.position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationDamping * Time.deltaTime);
			}
		}
		
		currentSpeed = currentSpeed + accel * accel;
		transform.Translate(0, 0, currentSpeed * Time.deltaTime);
		
		if(currentSpeed >= speedLimit){
			currentSpeed = speedLimit;
		}

	}
	
	void OnTriggerEnter(){
		functionState = 1;

	}
	
	IEnumerator Slow(){
		if(slowState == false){
			accelState = false;
			slowState = true;
		}
		
		currentSpeed = currentSpeed * inertia;
		transform.Translate(0, 0, currentSpeed * Time.deltaTime);
		
		if(currentSpeed <= minSpeed){
			currentSpeed = 0.0f;
			yield return new WaitForSeconds(stopTime);
			functionState = 0;
		}
	}
}
