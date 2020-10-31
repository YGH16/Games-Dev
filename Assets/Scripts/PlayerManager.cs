using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public bool keyCount = false;
	public bool Paper = false;
	
	public void PickupItem()
	{
		keyCount = true;
	}
	public void PickupPaper()
	{
		Paper = true;
	}
}
