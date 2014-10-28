using UnityEngine;
using System.Collections;

public class KillField : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			// Quick and dirty solution to death!
			Application.LoadLevel(0);
		}
	}
}
