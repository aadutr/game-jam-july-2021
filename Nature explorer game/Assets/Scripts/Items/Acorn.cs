using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Acorn", menuName = "Inventory/Acorn")]
public class Acorn : Item
{
    private string bird = "blueJay";
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
