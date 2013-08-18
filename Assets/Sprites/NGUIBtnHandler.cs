using UnityEngine;
using System.Collections;

public class NGUIBtnHandler : MonoBehaviour {

	private GameView gameView;
	// Use this for initialization
	void Start () {
		gameView = GameObject.Find("CPU").GetComponent<GameView>();
	}
	
	void OnClick(){
		gameView.OnBtnClick(name);
	}
}
