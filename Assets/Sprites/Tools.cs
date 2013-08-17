using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public static class Tools{
	
	public static Material LoadResourceMaterial(string path){
		Material material = UnityEngine.Object.Instantiate(Resources.Load(path)) as Material;
		return material;
	}
	
	public static GameObject LoadResourcesGameObject(string path){
//		Debug.Log("LoadResourceGameObject:"+path);
		UnityEngine.Object obj = Resources.Load(path);
		if(obj == null) return null;
		return path != null ? UnityEngine.Object.Instantiate(obj) as GameObject : null;
	}
	
	public static GameObject LoadResourcesGameObject(string path, GameObject gobjParent, float x, float y, float z){
		GameObject gobj = null;
		gobj = LoadResourcesGameObject(path);
		if (gobj != null) {
			gobj.transform.parent = gobjParent.transform;
			gobj.transform.localPosition = new Vector3(x, y, z);
		}
		return gobj;
	}
	
	public static GameObject LoadResourcesGameObject(string path, GameObject gobjParent){
		GameObject gobj = null;
		gobj = LoadResourcesGameObject(path);
		if (gobj != null) {
			gobj.transform.parent = gobjParent.transform;
		}
		return gobj;
	}
//	
//	public static void AddGameMenuState(int mGameState,JsonData mResponseData){
//		GameStateObj mResponse = new GameStateObj(mGameState,mResponseData);
//		GameMenu.quGameState.Enqueue(mResponse);
//	}
//	
//	public static void AddGameViewState(int mGameState,JsonData mResponseData){
//		GameStateObj mResponse = new GameStateObj(mGameState,mResponseData);
//		GameView.gameStateQueue.Enqueue(mResponse);
//	}
	
	public static string[] StringSplit(string txt,string character){
		return Regex.Split(txt,character,RegexOptions.IgnoreCase);
	}
	
	public static string FormatTime(int seconds){
		string strTime;
		if(seconds < 0){
			strTime = "00:00:00";
		}else{
			int intH = seconds / 3600;
			string strH = intH < 10 ? "0" + intH.ToString() : intH.ToString();
			int intM = (seconds % 3600) / 60;
			string strM = intM < 10 ? "0" + intM.ToString() : intM.ToString();
			int intS = seconds % 3600 % 60;
			string strS = intS < 10 ? "0" + intS.ToString() : intS.ToString();
			strTime = strH + ":" + strM + ":" + strS;
		}
		return strTime;
	}
	
	public static int TimeTxtToSeconds(string timeTxt){
		int seconds = 0;
		if(!string.IsNullOrEmpty(timeTxt)){
			string[] timeItems = timeTxt.Split(':');
			int hourCount = int.Parse(timeItems[0]);
			int minuteCount = int.Parse(timeItems[1]);
			int secondCount = int.Parse(timeItems[2]);
			seconds = hourCount * 60 * 60 + minuteCount * 60 + secondCount;
		}
		return seconds;
	}

	public static float StrToFloat(object FloatString)
    {
	    float result;
	    if (FloatString != null)
	    {
	        if (float.TryParse(FloatString.ToString(), out result))
	            return result;
	        else
	        {
	           return (float)0.00;
	        }
	    }
	    else
	    {
	        return (float)0.00;
	    }
    }
	
	public static int MathfRound(float num){
		return (int)Mathf.Floor(num + 0.5f);
	}
	
	public static int CashToDiamon(int cash){
		int rate = 1000;
		return (int)Mathf.Ceil(cash / rate) + 1;
	}
	
	
	public static int GetMax(int[] nums){
		int r = 0;
		if (nums == null || nums.Length == 0){
			return r;
		}
		r = nums[0];
		foreach (int item in nums) {
			if (item > r) {
				r = item;
			}
		}
		return r;
	}
	
	public static T GetComponentInChildByPath<T> (GameObject gobjParent, string path) where T : Component{
		Component r = null;
		if (gobjParent == null){
			return null;
		}
//		Transform tf = GetTransformInChildByPath(gobjParent, path);
		Transform tf = GetTransformInChildByPathSimple(gobjParent, path);
		if (tf != null){
			r = tf.gameObject.GetComponent<T>();
		}else{
			Debug.Log("!!!Can't get transform by path: " + path + " in GetComponentInChildByPath");
		}
		return r as T;
	}
	
	// path , split by "/"
	public static Transform GetTransformInChildByPath(GameObject gobjParent, string path){
		Transform r = null;
		if (gobjParent == null){
			return r;
		}
		string[] strArr = path.Split('/');
		r = gobjParent.transform;
		foreach (string strPathItem in strArr) {
			if (r == null) {
				continue;
			}
			r = r.FindChild(strPathItem);
		}
		if (r == null) {
			Debug.Log("!!!Can't get transform by path : " + path +". in Tools.GetTransformInChildByPath");
		}
		return r;
	}
	
	public static Transform GetTransformInChildByPathSimple(GameObject gobjParent, string path){
		Transform r = null;
		if(gobjParent != null){
			r = gobjParent.transform.FindChild(path);
		}
		return r;
	}
	
	public static GameObject GetGameObjectInChildByPathSimple(GameObject gobjParent, string path){
		GameObject gobj = null;
		Transform tf = GetTransformInChildByPathSimple(gobjParent, path);
		if(tf != null){
			gobj = tf.gameObject;
		}
		return gobj;
	}
	
	public static int GetIntLength(int i){
		int length = 0;
		length = i.ToString().Length;
		return length;
	}
	
	public static void ChangeLayersRecursively(Transform trans, string name)
	{
		try {
			trans.gameObject.layer = LayerMask.NameToLayer(name);
			foreach (Transform child in trans)
		    {
		        child.gameObject.layer = LayerMask.NameToLayer(name);
		        ChangeLayersRecursively(child, name);
		    }
		} catch (Exception ex) {
			Debug.Log(ex.ToString());	
		}
	}
	
	public static void ChangeLayersRecursively(GameObject gobj, string name){
		try {
			if(gobj != null){
				gobj.layer = LayerMask.NameToLayer(name);
				foreach (Transform child in gobj.transform)
			    {
			        child.gameObject.layer = LayerMask.NameToLayer(name);
			        ChangeLayersRecursively(child, name);
			    }
			}else {
				Debug.Log("======================ChangeLayersRecursively null!");
			}
		} catch (Exception ex) {
			Debug.Log(ex.ToString());	
		}
	}
	
	/// <summary>
	/// Finds the int value in arr.Return the index in arr.
	/// </summary>
	/// <returns>
	/// The index in arr.
	/// </returns>
	/// <param name='arr'>
	/// Arr.
	/// </param>
	/// <param name='ivalue'>
	/// Ivalue.
	/// </param>
	public static int FindIntValInArr(int[] arr, int ivalue){
		int r = -1;
		for (int i = 0; i < arr.Length; i++) {
			if (arr[i] == ivalue) {
				r = i;
				break;
			}
		}
		return r;
	}
	
//	public static void SetHeadIconTextureByURL(GameObject gobjHeadicon, string url, bool isGray = false){
//		Texture2D texture2d = Loader.LoadTexture(url,true);
//		if(texture2d != null){
//			gobjHeadicon.renderer.material.mainTexture = texture2d;
//			if(isGray){
//				gobjHeadicon.renderer.material.shader = Shader.Find("GrayscaleLol");
//			}
//		}
//	}
	
	
	public static string FloatToPercent(float fVal){
		string per = "";
//		per = Mathf.Round(fVal * 100).ToString("F2") + "%";
		per = (fVal * 100).ToString("F0") + "%";
		return per;
	}
	
	public static Hashtable Hash(params object[] args){
		Hashtable hashTable = new Hashtable(args.Length/2);
		if (args.Length %2 != 0) {
			return null;
		}else{
			int i = 0;
			while(i < args.Length - 1) {
				hashTable.Add(args[i], args[i+1]);
				i += 2;
			}
			return hashTable;
		}
	}
	
	private static System.Random random = new System.Random();
	
	public static Vector3 GetRandmonPosInRect(Rect rect){
		float x = 0f;
		float y = 0f;
		float z = 0f;
		x = random.Next((int)rect.xMin, (int)rect.xMax);
		y = random.Next((int)rect.yMin, (int)rect.yMax);
		return new Vector3(x, y, z);
	}
	
	public static Vector3 GetRandmonPosInRect(Rect rect, Camera camera){
		Vector3 pos = camera.ScreenToWorldPoint(GetRandmonPosInRect(rect));
		pos.z = 0f;
		return pos;
	}
	
	public static GameObject CreateGameObject(GameObject gobjPrefab, GameObject gobjPos){
		GameObject gobjDanger = UnityEngine.Object.Instantiate(gobjPrefab, gobjPos.transform.position, Quaternion.identity) as GameObject;
		return gobjDanger;
	}
	
	public static void SetUILabelText(GameObject gobj, string text){
		if(gobj != null){
			UILabel label = gobj.GetComponent<UILabel>();
			if(label != null){
				label.text = text;
			}
		}
	}
	
	public static string FormatTimeText(int seconds){
		string strR;
		int min = 0;
		int second = 0;
		min = seconds / 60;
		second = seconds % 60;
		strR = min + "'" + second + "''";
		return strR;
	}
	
	public static void  CreateEffectAtGameObj(string effectName, GameObject objParent, Vector3 pos, float scale = 1.0f){
		if (objParent != null) {
			GameObject gObjEff = Tools.LoadResourcesGameObject("Preafabs/Effect/" + effectName);
			gObjEff.name = effectName;
			gObjEff.transform.parent = objParent.transform;
			gObjEff.transform.localPosition = pos;
			if (scale != 1.0f) {
				gObjEff.transform.localScale = new Vector3(scale, scale, scale);
			}
		}
	}
	
	public static void SceneFadeInOut(GameObject gobjMask, bool isFadeIn, float dur){
		if(gobjMask != null){
			TweenAlpha ta = gobjMask.GetComponent<TweenAlpha>();
			if(ta != null){
				if(isFadeIn){
					ta.from = 1;
					ta.to = 0;
					ta.duration = dur;
					ta.Reset();
					ta.Play(true);
				}else{
					ta.from = 0;
					ta.to = 1;
					ta.duration = dur;
					ta.Reset();
					ta.Play(true);
				}
			}
		}
	}
	
	public static void SetUIPosBy3DGameObj(GameObject gobj2d, GameObject gobj3d, Camera camer3d, Camera camera2d){
		Vector3 v1 = camer3d.WorldToViewportPoint(gobj3d.transform.position);
		Vector3 v2 = camera2d.ViewportToWorldPoint(v1);
		v2.z = 0;
		gobj2d.transform.position = v2;
	}
}

