using UnityEngine;
using System.Collections;

public class IActorState{
    public IActor actor;
    public float time;
    public IActorState() {}
    public virtual IActorState toNextState(EFSMAction action) { return null; }
    public virtual void OnEnter() { }
    public virtual void DoUpdate() { }
	public virtual void OnExit(){ }
}



//public class ActorState_Move : IActorState {
//    public ActorState_Move(IActor actor)
//    {
//        this.actor = actor;
//    }
//
//    public override IActorState toNextState(EFSMAction action)
//    {
//        IActorState result = null;
//        if(action == EFSMAction.ATTACK_PLAYER){
//            result = new ActorState_AttackPlayer(actor);
//        }else if(action == EFSMAction.UNATTACK){
//			result = new ActorState_UnAttack(actor);
//		}else if(action == EFSMAction.UNATTACK_BY_FLASH){
//			result = new ActorState_UnAttack_By_Flash(actor);
//		}
//        return result;
//    }
//
//    public override void OnEnter()
//    {
//        
//    }
//
//    public override void DoUpdata()
//    {
//        actor.DoUpdateMove();
//    }
//}



