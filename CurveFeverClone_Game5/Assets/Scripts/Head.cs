using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Head : MonoBehaviour
{
	public float speed;
	public float turnSpeed;
	float horizontal;
	public string inputName;
	public string otherPlayerName;

	public Text winText;

	private void Start()
	{
		winText.gameObject.SetActive(false);
	}

	void Update()
    {
		horizontal = Input.GetAxisRaw(inputName);
    }

	private void FixedUpdate()
	{
		transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
		transform.Rotate(Vector3.forward * -horizontal * turnSpeed * Time.fixedDeltaTime); // 0,0,1
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Finish"))
		{
			speed = 0;
			turnSpeed = 0;
			GameObject.FindObjectOfType<GameManager>().GameOver();
			
			if(winText.gameObject.activeSelf == false)
			{
				winText.text = otherPlayerName + " Wins!";
			}
			winText.gameObject.SetActive(true);
						
		}
	}
}
