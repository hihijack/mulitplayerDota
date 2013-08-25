using UnityEngine;
using System.Collections;

public class NetworkTest : MonoBehaviour {

	public string remoteIp = "192.168.2.102";
	public int port = 25000;
	public bool isNAT = false;
	
	string debuginfo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.Label(new Rect(200, 50, 500, 500), "Network PeerType:" + Network.peerType);
		
		
		if(GUI.Button(new Rect(50, 50, 100, 50),"InitServer")){
			Network.InitializeServer(50, port, isNAT);
		}
		
		remoteIp = GUI.TextField(new Rect(50, 150, 150, 25), remoteIp);
		
		if(GUI.Button(new Rect(50, 250, 100, 50), "Connect")){
			Network.Connect(remoteIp, port);
		}
	}
}
