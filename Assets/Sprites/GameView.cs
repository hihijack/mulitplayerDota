using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using SimpleJSON;

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
	
	
	
	public int VCInput_Axis;
	public int VCInput_BtnA;
	public int VCInput_BtnB;
//	public GameObject gobjHero;
	GUIText uiScore;
	
	
	public double timeLastClick;
	public Vector3 posLastTouch;
	
	private InputType inputType = InputType.None;
	
	public Hero hero;
	
//	public Hero[] vsHeros;
	
	public CameraControll mCameraControll;
	
	public SonicCameraControll mSonicCameraCon;
	
	public Dictionary<string, Hero> dicVsHeros;
	
	public int score;
	
	
	public static int timeCost;
	public static int levelScore;
	public double levelStartTime;
	public double levelEndTime;
	
	bool isLevelStart = false; 
	
	public Camera cameraMain;
	public Camera camera2D;
	
	public UFO ufo;
	
	
	public UIPanel uiPanel;
	
	// cash
	public UILabel g_Lab_CashVal;
	
	
	// distance
	public UILabel g_Lab_Distance;
	
	
	public GameObject g_GObj_Pause_Window;
	public GameObject g_GObj_Score_Window;
	
	public int distance = 0;
	
	
	// road order
	private int curRoadIndex = 0;
	
	public GameObject[] gobjRoadOrder;
	public int[] indexRoadOrder;
	
	public GameObject curRoadGobj;
	
	
	// speedup distance
	public int[] speedupDistances;
	
//	public BNTest bnTest;
	
	public int gameStartFrameCount;
	
	public GameObject g_GobjPreHpAddAnim;
	
	private AudioManager audioManager;
	
	public float[] ufoWarnDiss; 
	
	public GameObject ufoWarnIcon;
	public UILabel labelUfoWarnDis;
	public UISprite spriteUfoWarn;
	
	
	public Color[] skyColors;
	private int skyColorIndex = 0;
	
	public AudioListener audioListener;
	
	public GameObject gobjMask;
	
	public GameObject gobjPrefbCash2d;
	
	void Awake(){
		
	}
	
	void Start ()
	{
		
	}
	
	
	
	
	// Update is called once per frame
	void Update ()
	{
			
		// gesture controll
		if(Input.GetMouseButtonDown(0)){
			posLastTouch = cameraMain.ScreenToViewportPoint(Input.mousePosition);
		}
		if(Input.GetMouseButtonUp(0)){
			Vector2 touchOffst = cameraMain.ScreenToViewportPoint(Input.mousePosition) - posLastTouch;
			float x = touchOffst.x;
			float y = touchOffst.y;
			if(Mathf.Abs(x) > Mathf.Abs(y)){
				if(x > 0){
					SetCurInput(InputType.SlideRight);
				}else if(x < 0){
					SetCurInput(InputType.SlideLeft);
				}
			}else{
				if(y > 0){
					SetCurInput(InputType.SlideUp);
				}else if(y < 0){
					SetCurInput(InputType.SlideDown);
				}
			}
		}
			
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
	
//	public void HurtHero(Hero hero){
//		if(!hero.IsInLifeState(LifeState.HurtInvincible) && !hero.IsInLifeState(LifeState.Invincible)){
//			ReduceHeroHp();
//			// slow for 0.5s
//			hero.Slow();
//			// invin for 1.5s
//			hero.Invincible_Hurt();	
//		}
//	}
	

	
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
	
}