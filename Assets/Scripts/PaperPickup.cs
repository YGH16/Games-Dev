using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperPickup : MonoBehaviour
{
	public Text objective1;
	
	private void OnTriggerEnter2D(Collider2D paper)
	{
		PlayerManager manager = paper.GetComponent<PlayerManager>();
		if(manager)
		{
			manager.PickupPaper();
			gameObject.SetActive(false);
			objective1.text = "Find and Steal the Documents - DONE";
		}
	}
}