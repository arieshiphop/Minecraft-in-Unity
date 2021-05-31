using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour 
{
	public CharacterController controller;
	public float speed = 12f;
	public float gravedad = -9.81f;
	public Transform CheckSuelo;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public float jumpHeight;
	
	Vector3 velocidad;
	bool isGrounded;
	void Update () 
	{
		isGrounded =  Physics.CheckSphere(CheckSuelo.position, groundDistance, groundMask);

		if(isGrounded && velocidad.y <0)
		{
			velocidad.y = -2f;
		}
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		controller.Move(move * speed * Time.deltaTime);
		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			velocidad.y =Mathf.Sqrt(jumpHeight * -2f * gravedad);

		}

		velocidad.y += gravedad * Time.deltaTime;

		controller.Move(velocidad * Time.deltaTime);
	}
}
