using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : SpnObj
{
	Player player;

	public enum eGoodsType { Gold, Diamond };
	public eGoodsType type;

	[SerializeField] private float rotSpeed = 20f;

    void Start()
    {
		// 스크립트 호출
		player = GameObject.Find(name: "Player").GetComponent<Player>();
		
		transform.rotation = Quaternion.Euler(0f, 90f, 90f);
	}

	void Update()
    {
		rotate();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player") getScore();
	}

	// 점수 시스템
	void getScore()
	{
		switch (type)
		{
			case eGoodsType.Gold:
				player.addScore(1);
				break;
			case eGoodsType.Diamond:
				player.addScore(5);
				break;
		}
		Destroy(gameObject);
	}

	// 기본 회전
	void rotate()
	{
		transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime, Space.Self);
	}
}
