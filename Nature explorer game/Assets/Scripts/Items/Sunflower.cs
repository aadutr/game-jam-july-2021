using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sunflower seeds", menuName = "Inventory/Sunflower")]
public class Sunflower : Item
{
    string bird = "cardinal";
	PlayerController player;


	public void OnEnable(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
        // Some usage
		player.AttractBirdsWithFood(bird);

		// RemoveFromInventory();					// Remove it from inventory
	}
}
