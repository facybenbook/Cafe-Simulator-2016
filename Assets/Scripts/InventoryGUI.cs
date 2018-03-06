/*
Created by Riley Carson
This is the GUI for the inventory system
Should be assigned to camera
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour {
	
	private Rect inventoryWindowRect = new Rect(750, 0, 400, 115);
	public double moneyAmount = 0;

	// dictionary
	static public Dictionary<int, string> InventoryNameDictionary = new Dictionary<int, string> ()
	{
		{0, ""},
		{1, ""}
	};

	ItemClass ItemAccess = new ItemClass();

	// opens GUI immediately
	void OnGUI ()
	{
		string curCulture = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
		System.Globalization.NumberFormatInfo currencyFormat = new System.Globalization.CultureInfo(curCulture).NumberFormat;
		currencyFormat.CurrencyNegativePattern = 1;
		inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindowMethod, "Inventory");
		GUI.Label (new Rect (10, 10, 150, 20), "Money: " + moneyAmount.ToString("c", currencyFormat));
	}

	// generates the icons in the inventory GUI
	void InventoryWindowMethod (int windowId)
	{
		// GUI Layout
		GUILayout.BeginArea (new Rect (0, 50, 400, 115));

		GUILayout.BeginHorizontal ();
		GUILayout.Button (InventoryNameDictionary[0], GUILayout.Height (50), GUILayout.Width(200));
		GUILayout.Button (InventoryNameDictionary[1], GUILayout.Height (50), GUILayout.Width(200));
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}
}