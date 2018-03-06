/* Made by: Riley Carson
 * For: Cafe Simulator 2016 (ICS3U Final Project
 * Made on: 2015 Jan. 5 -
 * Script for accessing objects that hold items: shelves, customers. This script deals with anything involving the
 * moving of inventory items, and how that affects the GUI: taking items, giving items, mixing ingredients,
 * receiving/losing money
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loot : MonoBehaviour {

	enum Outcomes
	{
		Correct,
		Incorrect
	};

	//variables
	private Rect shelfInventoryWindowRect = new Rect(400, 100, 600, 250);
	private Rect makerWindowRect = new Rect (500, 100, 400, 115);
	private Rect messageWindowRect = new Rect (575, 300, 275, 115);
	private bool shelfInventoryWindowShow = false;
	private bool makerShow = false;
	private bool messageShow = false;
	private bool noItemsShow = false;
	private bool takeOrderShow = false;
	private bool giveOrderShow = false;
	private bool loopCheckItemSet = false;
	private bool orderTaken = false;
	private bool isCorrect = false;

	int itemNum = 0;
	string orderItemName;

	private Dictionary<int, string> lootDictionary = new Dictionary<int, string>()
	{
		{0, ""},
		{1, ""},
		{2, ""},
		{3, ""},
		{4, ""},
		{5, ""},
		{6, ""},
		{7, ""},
		{8, ""},
	};

	ItemClass ItemObject = new ItemClass();


	private Ray mouseRay;
	private RaycastHit rayHit;

	// Use this for initialization
	void Start () {
	// display dictionary
		lootDictionary [0] = ItemObject.sugarItem.itemName;
		lootDictionary [1] = ItemObject.milkItem.itemName;
		lootDictionary [2] = ItemObject.creamItem.itemName;
		lootDictionary [3] = ItemObject.cocoaPowderItem.itemName;
		lootDictionary [4] = ItemObject.espressoBeansItem.itemName;
		lootDictionary [5] = ItemObject.waterItem.itemName;
		lootDictionary [6] = ItemObject.orangeJuiceItem.itemName;
		lootDictionary [7] = ItemObject.coffeeBeansItem.itemName;
		lootDictionary [8] = ItemObject.earlGreyTeaBagItem.itemName;
		lootDictionary [9] = ItemObject.earlGreyTeaItem.itemName;
		lootDictionary [10] = ItemObject.hotCocoaItem.itemName;
		lootDictionary [11] = ItemObject.espressoItem.itemName;
		lootDictionary [12] = ItemObject.cappuccinoItem.itemName;
		lootDictionary [13] = ItemObject.orangeCoffeeItem.itemName;
		lootDictionary [14] = ItemObject.regularCoffeeItem.itemName;
		lootDictionary [15] = ItemObject.cafeAuLaitItem.itemName;
	}
	
	// Update is called once per frame
	void Update () 
	{
		mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetKey(KeyCode.Escape)) 
		{ 
			Application.Quit(); 
		}
		
		// click
		if (Input.GetButtonDown ("Fire1")) 
		{
			Physics.Raycast(mouseRay, out rayHit);
			{
				if(rayHit.collider.transform.tag == "Shelf")
				{
					Cursor.visible = true;
					shelfInventoryWindowShow = true;
					Debug.Log("Hit");
				}
				else if(rayHit.collider.transform.tag == "Maker")
				{
					Cursor.visible = true;
					makerShow = true;
					Debug.Log("Hit");
				}
				else if(rayHit.collider.transform.tag== "TakeOrder")
				{
					Cursor.visible = true;
					SetItemName();
					takeOrderShow = true;
					Debug.Log("Hit");
				}
				else if(rayHit.collider.transform.tag== "GiveOrder")
				{
					Debug.Log("Hit");
					Cursor.visible = true;
					if((InventoryGUI.InventoryNameDictionary[0]).ToString() == orderItemName || (InventoryGUI.InventoryNameDictionary[1]).ToString() == orderItemName)
					{
						isCorrect = true;
					}
				}
			}
		}
	}

	void SetItemName()
	{
		if (loopCheckItemSet == false)
		{
		itemNum = Random.Range(9,16);
		orderItemName = (lootDictionary[itemNum]).ToString();
		loopCheckItemSet = true;
		}
	}
	
	// checks which windows should be open
	void OnGUI()
	{
		if (shelfInventoryWindowShow) 
		{
			shelfInventoryWindowRect = GUI.Window(1, shelfInventoryWindowRect, ShelfInventoryWindowMethod, "Storage Shelf");
		}
		if (makerShow)
		{
			makerWindowRect = GUI.Window(2, makerWindowRect, MakerWindowMethod , "Would you like to make a drink with your ingredients?");
		}
		if(messageShow)
		{
			messageWindowRect = GUI.Window(3, messageWindowRect, MessageWindowMethod, "Those ingredients don't work together.");
		}
		if (noItemsShow) 
		{
			messageWindowRect = GUI.Window(4, messageWindowRect, NoItemWindowMethod, "Two ingredients are required.");
		}
		if (takeOrderShow) 
		{
			if (orderTaken == false)
			{
				messageWindowRect = GUI.Window(6, messageWindowRect, TakeOrderMethod, "I would like " + orderItemName + ".");
			}
			else if (orderTaken == true)
			{
				messageWindowRect = GUI.Window(5, messageWindowRect, DidNotTakeOrderMethod, "You can only take one order at a time");
			}
		}
		if(isCorrect)
		{
			messageWindowRect = GUI.Window(6, messageWindowRect, GiveCorrectOrderMethod, "Thank you. This is exactly what I wanted.");
		}
	}

	// shelf window
	void ShelfInventoryWindowMethod(int windowID)
	{
		// GUI Layout
		GUILayout.BeginArea (new Rect(0,50,600,250));

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button (lootDictionary [1], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[1];
		}
		if (GUILayout.Button (lootDictionary [2], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[2];
		}
		if (GUILayout.Button (lootDictionary [3], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[3];
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button (lootDictionary [4], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[4];
		}
		if (GUILayout.Button (lootDictionary [5], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[5];
		}
		if (GUILayout.Button (lootDictionary [6], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[6];
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button (lootDictionary [7], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[7];
		}
		if (GUILayout.Button (lootDictionary [8], GUILayout.Height (50), GUILayout.Width(200))) 
		{
			InventoryGUI.InventoryNameDictionary[1] = InventoryGUI.InventoryNameDictionary[0];
			InventoryGUI.InventoryNameDictionary[0] = lootDictionary[8];
		}
		if (GUILayout.Button ("Close", GUILayout.Height (50), GUILayout.Width(200))) 
		{
			shelfInventoryWindowShow = false;
		}
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	// drink maker window (crafting items)
	void MakerWindowMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect (0, 50, 400, 115));

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Yes", GUILayout.Height (50), GUILayout.Width (200))) 
		{
			switch (InventoryGUI.InventoryNameDictionary [0]) 
			{

			case "Sugar":
				if (InventoryGUI.InventoryNameDictionary [1] == "") {noItemsShow = true;} 
				else {messageShow = true;}
				break;
			case "Milk":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.espressoBeansItem.itemName) {
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.cappuccinoItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = "";
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.coffeeBeansItem.itemName) {
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.cafeAuLaitItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = "";
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.cocoaPowderItem.itemName){
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.hotCocoaItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = "";
				}
				else if (InventoryGUI.InventoryNameDictionary [1] == ""){					
					noItemsShow = true;
				} 
				else {
					messageShow = true;
				}
				break;

			case "Cream":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.coffeeBeansItem.itemName) 
				{	
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.regularCoffeeItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				} 
				else 
				{
					messageShow = true;
				}
				break;
			
			case "Cocoa Powder":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.milkItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.hotCocoaItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				} 
				else 
				{
					messageShow = true;
				}			
				break;

			case "Espresso Beans":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.waterItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.espressoItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.milkItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.cappuccinoItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;	
				}
				else
				{
					messageShow = true;		
				}
				break;

			case "Water":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.earlGreyTeaBagItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.earlGreyTeaItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;

				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.espressoBeansItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.espressoItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				}
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;	
				} 
				else 
				{					
					messageShow = true;
				}	
				break;
			
			case "Orange Juice":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.coffeeBeansItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.orangeCoffeeItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				} 
				else 
				{
					messageShow = true;
				}

				break;
			
			case "Coffee Beans":
								
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.orangeJuiceItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.orangeCoffeeItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.creamItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.regularCoffeeItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				}
				else if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.milkItem.itemName)
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.cafeAuLaitItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				}
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{				
					noItemsShow = true;		
				} 
				else
				{
					messageShow = true;
				}
				break;
		
			case "Earl Grey Tea Bag":
				if (InventoryGUI.InventoryNameDictionary [1] == ItemObject.waterItem.itemName) 
				{
					InventoryGUI.InventoryNameDictionary [0] = ItemObject.earlGreyTeaItem.itemName;
					InventoryGUI.InventoryNameDictionary [1] = string.Empty;
				} 
				else if (InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				} 
				else 
				{
					messageShow = true;
				}
				break;
			case "Earl Grey Tea":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Hot Cocoa":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Espresso":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Cappuccino":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Orange Coffee":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Regular Coffee":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "Cafe au Lait":
				if(InventoryGUI.InventoryNameDictionary [1] == "") 
				{
					noItemsShow = true;
				}
				else
				{
					messageShow = true;
				}
				break;
			case "":			
				noItemsShow = true;		
				break;	
			}
				
		}
			
		if (GUILayout.Button ("No", GUILayout.Height (50), GUILayout.Width (200)))
		{
			makerShow = false;
		}
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	// "Ingredients don't work together"
	void MessageWindowMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect(0, 50, 275, 115));

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Okay", GUILayout.Height (50), GUILayout.Width (275))) 
		{
			messageShow = false;
		}
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	// "You need two items to mix"
	void NoItemWindowMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect(0, 50, 275, 115));
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Okay", GUILayout.Height (50), GUILayout.Width (275))) 
		{
			noItemsShow = false;
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.EndArea ();
	}

	// taking customer order
	void TakeOrderMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect(0, 50, 275, 115));
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Okay", GUILayout.Height (50), GUILayout.Width (275))) 
		{
			takeOrderShow = false;
			GameObject.Find("Customer").GetComponent<ChangeCustomerTag>().ChangeTagToGiveOrder();
			orderTaken = true;
			loopCheckItemSet = false;
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.EndArea ();
	}

	// when trying to take more than one order
	void DidNotTakeOrderMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect(0, 50, 275, 115));
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Okay", GUILayout.Height (50), GUILayout.Width (275))) 
		{
			takeOrderShow = false;
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.EndArea ();
	}

	// gave correct order to customer
	void GiveCorrectOrderMethod (int windowID)
	{
		GUILayout.BeginArea (new Rect(0, 50, 275, 115));
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Okay", GUILayout.Height (50), GUILayout.Width (275))) 
		{
			giveOrderShow = false;
			InventoryGUI.InventoryNameDictionary[0] = "";
			InventoryGUI.InventoryNameDictionary[1] = "";
			GameObject.Find("Customer").GetComponent<ChangeCustomerTag>().ChangeTagToTakeOrder();
			GameObject.Find("Main Camera").GetComponent<InventoryGUI>().moneyAmount++;
			orderTaken = false;
			loopCheckItemSet = false;
			isCorrect = false;
			GameObject.Find("Customer").GetComponent<ChangeCustomerTag>().Destruction();
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.EndArea ();
	}
}