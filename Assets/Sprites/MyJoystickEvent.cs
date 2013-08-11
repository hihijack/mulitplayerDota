using UnityEngine;
using System.Collections;

/// <summary>
/// Joystick event
/// </summary>
public class MyJoystickEvent : MonoBehaviour {

	public GameObject joystick;
	public PlayerControll playerControll;
	
	void OnEnable(){
		EasyJoystick.On_JoystickMove += On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
	}
	
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove	;
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
		
	void OnDestroy(){
		EasyJoystick.On_JoystickMove -= On_JoystickMove;	
		EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
	}
	
	
	void On_JoystickMoveEnd(MovingJoystick move){
//		if (move.joystickName == Joystick.name){
//			animation.CrossFade("idle");
//		}
	}
	void On_JoystickMove( MovingJoystick move){
		
		if (move.joystickName == joystick.name){
//			if (Mathf.Abs(move.joystickAxis.y)>0 && Mathf.Abs(move.joystickAxis.y)<0.5){
//				animation.CrossFade("walk");
//				
//			}	
//			else if (Mathf.Abs(move.joystickAxis.y)>=0.5){
//				animation.CrossFade("run");	
//			}
			playerControll.TurnControll(move.joystickAxis);
		}
	}
}
