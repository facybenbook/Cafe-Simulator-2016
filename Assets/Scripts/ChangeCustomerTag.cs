using UnityEngine;
using System.Collections;


public class ChangeCustomerTag : MonoBehaviour {
	
	public int deathInt = 0;
	public Vector3 firstNpcTp = new Vector3(0, 0, 0);
	
	public void ChangeTagToTakeOrder()
	{
		gameObject.tag = "TakeOrder";
	}
	
	public void ChangeTagToGiveOrder()
	{
		gameObject.tag = "GiveOrder";
	}
	public void Destruction()
	{
		if (deathInt == 0) {
			deathInt++;
			transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		}
		if (deathInt > 0){
			GameObject.Destroy(gameObject
			                   );
		}
	}
}