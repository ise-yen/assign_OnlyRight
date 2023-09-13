using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;

    void Start()
    {
        
    }

	void Update()
    {
        if (Input.GetButtonDown("Jump"))
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
    }
	private void OnCollisionEnter(Collision collision)
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
