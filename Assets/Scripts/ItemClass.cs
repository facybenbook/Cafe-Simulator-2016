/* Created by Riley Carson
 * This is the Item Class. Also instanciates every possible item.
*/
using UnityEngine;
using System.Collections;

public class ItemClass : MonoBehaviour {
	//  ingredient items
	public ItemCreatorClass sugarItem = new ItemCreatorClass(0, "Sugar");
	public ItemCreatorClass milkItem = new ItemCreatorClass(1, "Milk");
	public ItemCreatorClass creamItem = new ItemCreatorClass(2, "Cream");
	public ItemCreatorClass cocoaPowderItem = new ItemCreatorClass(3, "Cocoa Powder");
	public ItemCreatorClass espressoBeansItem = new ItemCreatorClass(4, "Espresso Beans");
	public ItemCreatorClass waterItem = new ItemCreatorClass(5, "Water");
	public ItemCreatorClass orangeJuiceItem = new ItemCreatorClass(6, "Orange Juice");
	public ItemCreatorClass coffeeBeansItem = new ItemCreatorClass(7, "Coffee Beans");
	public ItemCreatorClass earlGreyTeaBagItem = new ItemCreatorClass(8, "Earl Grey Tea Bag");
	
	// crafted items
	public ItemCreatorClass earlGreyTeaItem = new ItemCreatorClass(9, "Earl Grey Tea");
	public ItemCreatorClass hotCocoaItem = new ItemCreatorClass(10, "Hot Cocoa");
	public ItemCreatorClass espressoItem = new ItemCreatorClass (11, "Espresso");
	public ItemCreatorClass cappuccinoItem = new ItemCreatorClass(12, "Cappuccino");
	public ItemCreatorClass orangeCoffeeItem = new ItemCreatorClass(13, "Orange Coffee");
	public ItemCreatorClass regularCoffeeItem = new ItemCreatorClass(14, "Regular Coffee");
	public ItemCreatorClass cafeAuLaitItem = new ItemCreatorClass(15, "Cafe au Lait");

	// item class
	public class ItemCreatorClass
	{
		public int itemID;
		public string itemName;
		
		//constructor
		public ItemCreatorClass (int id, string name)
		{
			itemID = id;
			itemName = name;
		}
	}
}