using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Facing : NetworkBehaviour {
	Animator animator;

	public int direction;

	void Start ()
	{
		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		if (!isLocalPlayer) return;
		UpdateAnimator();
	}

	public void ReceiveInput (float horizontal, float vertical)
	{
		if (vertical == 1) direction = 0;
		if (horizontal == 1) direction = 1;
		if (vertical == -1) direction = 2;
		if (horizontal == -1) direction = 3;
	}

	void UpdateAnimator ()
	{
		animator.SetInteger("direction", direction);
	}

	public Vector2 GetFacingVector ()
	{
		if (direction == 0) return new Vector2(0, 1);
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 2) return new Vector2(0, -1);
		if (direction == 3) return new Vector2(-1, 0);
		else return Vector2.zero;
	}
}
