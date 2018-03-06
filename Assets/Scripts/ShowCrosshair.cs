using UnityEngine;
using System.Collections;

public class ShowCrosshair : MonoBehaviour {

	public Texture2D crosshairImage;
	public bool inUI;
	private float xMin;
	private float yMin;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI(){

		xMin = (Screen.width / 2) - (crosshairImage.width / 2);
		yMin = (Screen.height / 2) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}
