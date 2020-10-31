using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
	public GameObject Door;
	public Text objective3;
	
	void OnTriggerEnter2D(Collider2D door)
	{
		PlayerManager manager = door.GetComponent<PlayerManager>();
		if(manager){
			if(manager.keyCount == true && manager.Paper == true)
			{
				Door.SetActive(false);
				objective3.text = "Escape the Premise Undetected - DONE";
			}
		}
	}
}
