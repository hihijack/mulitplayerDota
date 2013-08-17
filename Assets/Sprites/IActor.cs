using UnityEngine;
using System.Collections;

public class IActor : MonoBehaviour{
	public int id;
	public int typeid;
	public bool isEnermy;
	public IActorState state;
	public IActorAction action;

    public void updataState(IActorAction action) {
        if(action.actiontype != EFSMAction.NONE){
//            Debug.Log("updataState - " + this.state + " by action:" + action.actiontype);//########
            IActorState asCur = this.state;
            IActorState asNext = asCur.toNextState(action.actiontype);
            if (asNext != null)
            {
                asCur.OnExit();
				this.state = asNext;
				this.action = action;
                this.state.OnEnter();
            }
        }
    }
	
	public Vector3 GetPos(){
		return gameObject.transform.position;
	}
	
	public void SetPos(float x, float y){
		Vector3 posOld = GetPos();
		gameObject.transform.position = new Vector3(x, y, posOld.z);
	}

    public bool IsInState(System.Type type) {
        return state.GetType() == type;
    }
	
	public virtual void DoUpdateAttack() {
       
    }

    public virtual void DoUpdateIdle() { }
	
	public virtual void DoUpdateMove(){}
	
	
	public virtual void DoUpdateRun(){}
	
	public virtual void OnEnterRun(){}
	
	public virtual void OnEnterAttack(){}
	
	public virtual void OnEnterUnAttack(){}
	
	public virtual void OnEnterIdle(){}
	
	public virtual void OnEnterMove(){}
	
	public virtual void OnEnterHeroFlash(){}
	
	public virtual void DoUpdateHeroFlash(){}
	
	public virtual void OnEnterHeroFlashAttack(){}
	
	public virtual void OnEnterUnAttack_By_Flash(){}
	
	public virtual void OnEnterOnAirDown(){}
	public virtual void DoUpdateOnAirDown(){}
	
	public virtual void OnEnterOnAirUp(){}
	public virtual void DoUpdateOnAirUp(){}
	
	public virtual void OnEnterFlash(){}
	public virtual void DoUpdataFlash(){}
	
	public virtual void OnEnterGlide(){}
	public virtual void DoUpdateGlide(){}
	public virtual void OnExitGlide(){}
	
	public virtual void OnEnterSpeedUp(){}
	public virtual void DoUpdateSpeedUp(){}
	public virtual void OnExitSpeedUp(){}
	
	public virtual void OnEnterDive(){}
	public virtual void DoUpdateDive(){}
	public virtual void OnExiteDive(){}
	
	public virtual void OnEnterDie(){}
	public virtual void DoUpdateDie(){}
	
	public virtual void OnEnterAttackedByUFO(){}
	public virtual void DoUpdateAttackedByUFO(){}
}
