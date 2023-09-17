using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    float hAxis;
    float vAxis;
    float jumpPower;
    float speed;

    bool isJump = false;

    Vector3 moveVec;

    void Start()
    {
        anim = null;

        jumpPower = 10;
        speed = 10;
    }

    void Update()
    {
        input();
        reSpawn();
    }

	private void OnCollisionEnter(Collision collision)
	{
        isJump = false;
	}

	void input()
	{
		// มกวม
		if (Input.GetButtonDown("Jump") && !isJump)
		{
            isJump = true;
            if (anim == null) anim = GetComponent<Animator>();
            else anim.SetTrigger("Next");

            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);
    }

    void reSpawn()
	{
        if (transform.position.y < -50f) transform.position = new Vector3(0f, 0f, 0f);
	}
}
