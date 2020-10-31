using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
	public Text objective2;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerManager manager = collision.GetComponent<PlayerManager>();
		if(manager)
		{
			manager.PickupItem();
			gameObject.SetActive(false);
			objective2.text = "Find The Key to Open the Door - DONE";
		}
	}
}
