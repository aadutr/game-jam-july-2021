using UnityEngine;

/* The base item class. All items should derive from this. */

public class Item : MonoBehaviour {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
	
}