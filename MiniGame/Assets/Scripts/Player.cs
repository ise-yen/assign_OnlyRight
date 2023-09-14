using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float jumpPower = 5;
	public float lowWarn = -4;
	public float jumpBoost = 2.5f;

	TextMesh scoreOutput;
	int score = 0;

	void Start()
	{
		// 이름으로 게임 오브젝트를 찾고, 그 중 TextMesh 컴포넌트를 얻기
		scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
	}

	void Update()
	{
		jump();
	}

	private void OnCollisionEnter(Collision collision)
	{
		//if(collision.gameObject.name == "Wall")
		//	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void jump()
	{
		// 점프키를 누르면 점프하거나 점프 부스트
		if (Input.GetButtonDown("Jump"))
		{
			if (transform.position.y < lowWarn)
			{
				GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower * jumpBoost, 0);
			}
			else
			{
				GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
			}
		}
	}

	// 점수 더하기
	public void addScore(int s)
	{
		score += s;
		scoreOutput.text = "점수 : " + score;

	}
}
