using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public enum InputType{
	None,
	Click,
	SlideUp,
	SlideDown,
	SlideLeft,
	SlideRight
}

public class GameView : MonoBehaviour
{
	
	
	
	
	private InputType inputType = InputType.None;
	
	public Hero hero;
	
	private Vector3 posLastTouch;
	
	public Camera cameraMain;
	
	public GameObject joystick;
		
	void Awake(){
		
	}
	
	void Start ()
	{
		
	}
	
	
	
	
	// Update is called once per frame
	void Update ()
	{
			
		// gesture controll
//		if(Input.GetMouseButtonDown(0)){
//			posLastTouch = cameraMain.ScreenToViewportPoint(Input.mousePosition);
//		}
//		if(Input.GetMouseButtonUp(0)){
//			Vector2 touchOffst = cameraMain.ScreenToViewportPoint(Input.mousePosition) - posLastTouch;
//			float x = touchOffst.x;
//			float y = touchOffst.y;
//			if(Mathf.Abs(x) > Mathf.Abs(y)){
//				if(x > 0){
//					SetCurInput(InputType.SlideRight);
//				}else if(x < 0){
//					SetCurInput(InputType.SlideLeft);
//				}
//			}else{
//				if(y > 0){
//					SetCurInput(InputType.SlideUp);
//				}else if(y < 0){
//					SetCurInput(InputType.SlideDown);
//				}
//			}
//		}
			
	}	
	
	
	public void SetCurInput(InputType inputType){
		this.inputType = inputType;
	}
	
		
	
	
	public InputType GetCurInput(){
		return this.inputType;
	}
	
	public bool IsCurInput(InputType type){
		return this.inputType == type;
	}
	
	public void ResetInput(){
		SetCurInput(InputType.None);
	}	
	
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

	}
	void On_JoystickMove( MovingJoystick move){
		
		if (move.joystickName == joystick.name){
			hero.TurnControll(move.joystickAxis);
		}
	}
	
	
	public void Pause(){
		Time.timeScale = 0;	
	}
	
	public void Resume(){
		Time.timeScale = 1;
	}		
	
	public void CreateEffectAtPos(string effectName, float dur, Vector3 pos, GameObject gobjParent){
		GameObject gObjEff = Tools.LoadResourcesGameObject("Preafabs/Effect/" + effectName);
		if(gobjParent != null){
			gObjEff.transform.parent = gobjParent.transform;
			gObjEff.transform.localPosition = pos;
		}else{
			gObjEff.transform.position = pos;
		}
		StartCoroutine(CoEffectTime(gObjEff, dur));
	}
	
	public IEnumerator CoEffectTime(GameObject gobjEff, float durTime){
		yield return new WaitForSeconds(durTime);
		DestroyObject(gobjEff);
	}
	
	
	public void OnBtnClick(string btnName){
		if("BtnFire".Equals(btnName)){
			hero.Fire();
		}
	}
	
}