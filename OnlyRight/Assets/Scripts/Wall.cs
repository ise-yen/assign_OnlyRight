using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	private void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            Destroy(gameObject);
		}
	}
}
