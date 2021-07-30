using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thistle", menuName = "Inventory/Thistle")]
public class Thistle : Item
{
    private string bird = "goldFinch";
	private PlayerController player;


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
