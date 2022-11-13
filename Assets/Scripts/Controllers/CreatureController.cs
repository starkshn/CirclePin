using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using static Define;

public class CreatureController : MonoBehaviour
{
	protected Animator _animator;

	protected Define.WorldObject _objectType { get; set; } = Define.WorldObject.Unknown;

	public Define.WorldObject WorldObjectType => _objectType;

	protected CreatureState _state = CreatureState.Idle;
	public virtual CreatureState State
	{
		get { return _state; }
		set
		{
			_state = value;
			UpdateAnimation();
		}
	}

	void Start()
	{
		Init();
	}

	void Update()
	{
		UpdateController();
	}

	protected virtual void Init()
	{ 
		_animator = GetComponent<Animator>();
	}

	protected virtual void UpdateAnimation()
	{
		if (State == CreatureState.Idle)
		{
			_animator.CrossFade("IDLE", 0.2f);
		}
		else if (State == CreatureState.Walk)
		{
			_animator.CrossFade("WALK", 0.2f);
		}
		else if (State == CreatureState.Moving)
		{
			_animator.CrossFade("MOVE", 0.2f);
		}
		else if (State == CreatureState.Dead)
		{
			_animator.CrossFade("DIE", 0.2f);
		}
	}

	protected virtual void UpdateController()
	{
		switch (State)
		{
			case CreatureState.Idle:
				UpdateIdle();
				break;
			case CreatureState.Walk:
				UpdateWalking();
				break;
			case CreatureState.Moving:
				UpdateMoving();
				break;
			case CreatureState.Dead:
				UpdateDead();
				break;
			case CreatureState.Rotate:
				UpdateRotate();
				break;
		}
	}

	protected virtual void UpdateIdle()
	{

	}
	protected virtual void UpdateMoving()
	{

	}
	protected virtual void UpdateWalking()
	{

	}

	protected virtual void OnDamaged()
	{

	}

	protected virtual void UpdateSkill()
	{

	}
	protected virtual void UpdateDead()
	{

	}

	protected virtual void UpdateRotate()
	{ 
	}
}
