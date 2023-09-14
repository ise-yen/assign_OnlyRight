using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Vector3 _rotation;
	[SerializeField] private float _speed;

	public GameObject[] wallPrefabs; // 벽
    public GameObject[] goodsPrefabs; // 재화
	public GameObject dropPrefab; // 낙하물

    public float wallInterval = 3f; // 벽이 스폰되는 일정 시간
    public float goodsInterval = 1f; // 재화가 스폰되는 일정 시간

	float wallTerm; // 벽이 스폰 시간 카운트
    float goodsTerm; // 재화 스폰 시간 카운트

    public float range = 3; // 벽 스폰 위치

	bool isGoodsUp = true; // 재화 스폰 위치가 올라가고 있는지
	Vector3 goodsPos;

	void Start()
    {
		wallTerm = 1.5f; // 시작부터 벽이 하나 나오기 위해
		goodsTerm = 1.5f; // 시작부터 재화가 하나 나오기 위해
		goodsPos = transform.position;
	}

	void Update()
    {
		wallSpawn();
		goodsSpawn();
	}

	void goodsSpawn()
	{
		goodsTerm += Time.deltaTime;
		if (goodsTerm >= goodsInterval)
		{
			if (goodsPos.y >= 5)
			{
				goodsPos.y -= 1;
				isGoodsUp = false;
			}
			else if (goodsPos.y <= -5)
			{
				goodsPos.y += 1;
				isGoodsUp = true;
			}
			else
			{
				if (isGoodsUp) goodsPos.y += 1;
				else goodsPos.y -= 1;
			}
			int goodsType = Random.Range(0, goodsPrefabs.Length);
			Instantiate(goodsPrefabs[goodsType], goodsPos, transform.rotation);

			goodsTerm -= goodsInterval;
		}
	}

	void wallSpawn()
	{
		wallTerm += Time.deltaTime;
		if (wallTerm >= wallInterval)
		{
			Vector3 pos = transform.position;
			pos.y += Random.Range(-range, range);
			int wallType = Random.Range(0, wallPrefabs.Length);
			Instantiate(wallPrefabs[wallType], pos, transform.rotation);

			wallTerm -= wallInterval;
		}
	}

	void dropSpawn()
	{
		if (wallTerm >= wallInterval)
		{
			if (Random.Range(0, 2) == 0) Instantiate(dropPrefab);
			wallTerm -= wallInterval;
		}
	}
}
