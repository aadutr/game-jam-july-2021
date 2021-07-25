using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sunflower seeds", menuName = "Inventory/Sunflower")]
public class Sunflower : Item
{
    // When pressed in inventory
	public override void Use()
	{
		base.Use();
        // Some usage
		RemoveFromInventory();					// Remove it from inventory
	}
}
