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
	

	
	
	void Start(){
		// default state
		state = new HeroActorState_Idle(this);

	}
	
	void Update(){
			// action handle
			if(gameView.IsCurInput(InputType.SlideUp)){
				SetAction(PlayerAction.Jump);
			}
			else{
				SetAction(PlayerAction.None);
			}
			
			// state update
			this.state.DoUpdate();
			
		
			gameView.ResetInput();
		
	}
	
	#region FSM
	public override void OnEnterAttackedByUFO ()
	{
		
	}
	
	public override void DoUpdateAttackedByUFO ()
	{
		
	}
	
	
	
	#endregion

}
