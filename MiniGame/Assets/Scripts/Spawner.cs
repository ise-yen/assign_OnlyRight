using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval = 1.5f; // 일정 시간마다
    public float range = 3;
    float term;

    void Start()
    {
        term = interval; // 시작부터 벽이 하나 나오기 위해
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if(term >= interval)
		{
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            Instantiate(wallPrefab, pos, transform.rotation);
            term -= interval;
		}
    }
}
