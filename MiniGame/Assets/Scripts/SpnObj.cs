using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpnObj : MonoBehaviour
{
	// 움직이기
	protected void move(float moveSpeed)
	{
		transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
	}

	// 지나가면 삭제 -- 최적화
	protected void deletePass()
	{
		if (transform.position.x < -10) Destroy(gameObject);
	}

}
