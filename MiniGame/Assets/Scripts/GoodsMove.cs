using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMove : SpnObj
{
	public float moveSpeed;

	private void Start()
	{
		moveSpeed = -15;
	}

	void Update()
    {
		move(moveSpeed);
		deletePass();
	}
}
