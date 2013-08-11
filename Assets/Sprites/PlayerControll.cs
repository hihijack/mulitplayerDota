using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void TurnControll(Vector2 axis){
//		float angle = Vector2.Angle(Vector2.right, axis);
//		transform.eulerAngles = 
		Vector3 lookTarget = new Vector3(axis.x, 0, axis.y) + transform.position;
		transform.LookAt(lookTarget);
	}
}
