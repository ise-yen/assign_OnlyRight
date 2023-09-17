using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] wallPrefabs; // 스폰될 벽들
    float posRange = 1f;
    float scaleRange;

    void Start()
    {
        scaleRange = 3f;
        posRange = scaleRange * 3;
    }

    void Update()
    {
    }

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player")
		{
            Spawn();
            MoveSpawnPos();
            Spawn();
        }
    }

    void MoveSpawnPos()
	{
        transform.position += new Vector3 (Random.Range(0, posRange), Random.Range(-posRange, posRange), Random.Range(-posRange, posRange));
        Debug.Log("스폰 위치 이동" + transform.position);
    }

    void Spawn()
	{
        Debug.Log("스폰");
        int type = Random.Range(0, wallPrefabs.Length);
        wallPrefabs[type].transform.localScale = new Vector3(Random.Range(1, scaleRange) * 2, Random.Range(1, scaleRange), Random.Range(1, scaleRange) * 2);
        Instantiate(wallPrefabs[type], transform.position, transform.rotation);
    }
}
