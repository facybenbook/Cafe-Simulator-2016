/*
 * Made by Jared
 */
using UnityEngine;
using System.Collections;

public class NPCSpawn : MonoBehaviour {

	public GameObject[] spawnObject;
	public GameObject[] targetObject;
	public float radius = 1.0f;
	public float spawnTime = 15.0f;
	public Transform spawnPosition;
	public Vector3 npcPosition;

	void FixedUpdate(){
		Invoke("SpawnNPC", spawnTime);
	}

	void SpawnNPC(){

		float spawnRadius = radius;
		int spawnObjectIndex = Random.Range(0,spawnObject.Length);
		
		transform.position = Random.insideUnitSphere * spawnRadius;
		
		Instantiate(spawnObject[spawnObjectIndex],spawnPosition.position,spawnObject[spawnObjectIndex].transform.rotation);

	}
}
