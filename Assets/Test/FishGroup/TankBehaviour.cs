//write by shadow
using UnityEngine;
using System.Collections;

public class TankBehaviour : MonoBehaviour
{
	private const float minMoveCheck = 0.2f;

	//组 id
	public int groupId = 0;
	//移动旋转速度
	public float moveSpeed = 5, rotateSpeed = 20;

	public Vector3 position {
		get{ return transform.position; }
	}

	public Vector3 movement {
		get{ return myMovement; }
	}

	private Vector3 myMovement = Vector3.zero;
	private TankGroup myGroup;
	private float tgtSpeed = 0, speed = 0, currentSpeed;

	public void SetGroup (int index)
	{
		myGroup = TankGroup.GetTankGroup (index);
	}
	
	// Use this for initialization
	void Start ()
	{
		SetGroup (groupId);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 displacement = myGroup.targetPosition - position;//获取目标距离
		Vector3 direction = displacement.normalized * myGroup.targetWeight;//方向*权重
		
		if (displacement.magnitude < myGroup.targetCloseDistance)//重新计算目的地距离权重
			direction *= displacement.magnitude / myGroup.targetCloseDistance;
		
		direction += GetGroupMovement ();//获取周围组的移动
		
		if ((myGroup.targetPosition - position).magnitude < minMoveCheck)//计算移动速度
			tgtSpeed = 0;
		else
			tgtSpeed = moveSpeed;
		
		speed = Mathf.Lerp (speed, tgtSpeed, 2 * Time.deltaTime);
		
		Drive (direction, speed);//移动
	}

	private Vector3 GetGroupMovement ()
	{
		Collider[] c = Physics.OverlapSphere (position, myGroup.keepDistance, myGroup.mask);//获取周围成员
		Vector3 dis, v1 = Vector3.zero, v2 = Vector3.zero;
		for (int i = 0; i < c.Length; i++) {
			TankBehaviour otherTank = c [i].GetComponent<TankBehaviour> ();
			dis = position - otherTank.position;//距离
			v1 += dis.normalized * (1 - dis.magnitude / myGroup.keepDistance);//查看与周围单位的距离
			v2 += otherTank.movement;//查看周围单位移动方向
			
			Debug.DrawLine (position, otherTank.position, Color.yellow);
		}
		
		return v1.normalized * myGroup.keepWeight + v2.normalized * myGroup.moveWeight;//添加权重因素
	}

	private void Drive (Vector3 direction, float spd)
	{
		Vector3 finialDirection = direction.normalized;
		float finialSpeed = spd, finialRotate = 0;
		float rotateDir = Vector3.Dot (finialDirection, transform.right);
		float forwardDir = Vector3.Dot (finialDirection, transform.forward);
		
		if (forwardDir < 0)
			rotateDir = Mathf.Sign (rotateDir);
			
		if (forwardDir < -0.2f)
			finialSpeed = Mathf.Lerp (currentSpeed, -spd * 8, 4 * Time.deltaTime);
		
		if (forwardDir < 0.98f)//防抖
			finialRotate = Mathf.Clamp (rotateDir * 180, -rotateSpeed, rotateSpeed);
		
		finialSpeed *= Mathf.Clamp01 (direction.magnitude);
		finialSpeed *= Mathf.Clamp01 (1 - Mathf.Abs (rotateDir) * 0.8f);
		
		transform.Translate (Vector3.forward * finialSpeed * Time.deltaTime);
		transform.Rotate (Vector3.up * finialRotate * Time.deltaTime);
		
		currentSpeed = finialSpeed;
		myMovement = direction * finialSpeed;
	}
	
}
