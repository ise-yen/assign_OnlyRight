using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Player player;

    public float speed = -10f;

    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    void Update()
    {
		move();
		deletePass();
	}


	// 움직이기
	void move()
	{
		transform.Translate(speed * Time.deltaTime, 0, 0);
	}

	// 지나가면 삭제 -- 최적화
	void deletePass()
	{
		if (transform.position.x < -10)
		{
			Destroy(gameObject);
		}
	}
}
