using UnityEngine;
using System.Collections;

public class Cat_Touch_Insu : MonoBehaviour {


	// Animator 지정
	Animator anim;

	// Cat의 상태 
	enum CatState
	{
		Idle,
		Wriggle,
		Stroke,
		Happy,
	};
	CatState state;

	// GameObject 지정 
	// public GameObject Player;

	// Use this for initialization
	void Start()
	{
		// enemy 초기 상태 지정
		state = CatState.Idle;
		anim = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case CatState.Idle:
				Idle();
				break;
			case CatState.Wriggle:
				Wriggle();
				break;
			case CatState.Stroke:
				Stroke();
				break;
			case CatState.Happy:
				Happy();
				break;

		}
	}


	void Idle()
	{
		//Goal(1) - Idle 상태에서 화면에 터치를 하면 Wriggling Trigger를 호출
		// 1. Idle 상태를 계속유지(반복 재생)
		// 2. 화면을 터치하면 (지금은 마우스 클릭) Wriggling
		if (Input.GetButtonDown("Fire1"))
		{
			state = CatState.Wriggle;
			anim.SetTrigger("Wriggle");

		}
		//   - Ray 이용? GetButtonDown이용??************************************
		//   - 터치이외에 쓰다듬기도 가능한지??************************************
		//   - 
		// 3. 5회 터치를 하면 Happy로 전환************************************
		//   - (5회이내터치시) 터치가 없는 상태에서 일정시간이 지나면 Idle 상태로 전환
		//   - 일정시간 지정

		//Goal(2) - Idle 상태에서 고양 이 를 쓰 다 듬 으 면 Stroke Trigger
		// 1. Idle 상태를 계속 유지 (반복 재생)
		if (Input.GetButtonDown("Fire2"))
		{
			state = CatState.Stroke;
			anim.SetTrigger("Stroke");
		}

	}


	public float WriggleDelayTime = 5;
	float currentTime = 0;
	void Wriggle()
	{
		// Goal - Wriggle 상태에서 WriggleDalayTime 동안 유지하다가 Idel상태로 전환
		currentTime += Time.deltaTime;
		if (currentTime > WriggleDelayTime)
		{
			currentTime = 0;
			state = CatState.Happy;
			anim.SetTrigger("Happy");
		}
	}

	public float StrokeDelayTime = 5;

	void Stroke()
	{
		//Goal
				// Goal - Wriggle 상태에서 WriggleDalayTime 동안 유지하다가 Idel상태로 전환
		currentTime += Time.deltaTime;
		if (currentTime > StrokeDelayTime)
		{
			currentTime = 0;
			state = CatState.Happy;
			anim.SetTrigger("Happy");
		}

	}
	

	public float HappyTime = 5;
	void Happy()
	{
		// Goal - 특정 상태가 완료되면 Happy가 실행
		// 1. 특정행동이 끝난뒤에 Happy 상태로 전환되는 시간 지정
		// 2. Happy 상태의 지속시간 지정
		// 3. 시간이 지나면 상태를 Idle로 전환
		currentTime += Time.deltaTime;
		if (currentTime > HappyTime)
		{
			currentTime = 0;
			state = CatState.Idle;
			anim.SetTrigger("Idle");
		}
	}




}
