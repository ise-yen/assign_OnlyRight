using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : SpnObj
{
    Player player;

    public float moveSpeed = -10f;

    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    void Update()
    {
		move(moveSpeed);
		deletePass();
	}
}
