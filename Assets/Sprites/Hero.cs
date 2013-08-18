using UnityEngine;
using System.Collections;

public enum PlayerAction{
	None,
	Run,
	Jump,
	Glide,
	SpeedUp,
	Dive
}

public class Hero : IActor
{
	

	public GameView gameView;
	public PlayerAction curControllAction;
	public GameObject gobjPrefabBullet;
	
	void Start(){
		// default state
//		state = new HeroActorState_Idle(this);

	}
	
	void Update(){
			// action handle
//			if(gameView.IsCurInput(InputType.SlideUp)){
//				SetAction(PlayerAction.Jump);
//			}
//			else{
//				SetAction(PlayerAction.None);
//			}
//			
//			// state update
//			this.state.DoUpdate();
//			
//		
//			gameView.ResetInput();
		
	}
	
	#region FSM
	public override void OnEnterAttackedByUFO ()
	{
		
	}
	
	public override void DoUpdateAttackedByUFO ()
	{
		
	}
	#endregion
	
	private void SetAction(PlayerAction action){
		this.curControllAction = action;
	}
	
	public void TurnControll(Vector2 axis){
//		float angle = Vector2.Angle(Vector2.right, axis);
//		transform.eulerAngles = 
		Vector3 lookTarget = new Vector3(axis.x, 0, axis.y) + transform.position;
		transform.LookAt(lookTarget);
	}
	
	
	public void Fire(){
		GameObject gobjBullet = Instantiate(gobjPrefabBullet) as  GameObject;
		gobjBullet.transform.position = transform.position;
		gobjBullet.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, 0);
		Bullet bullet = gobjBullet.GetComponent<Bullet>();
		bullet.speed = 30f;
	}
}
