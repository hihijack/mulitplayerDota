using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 direction;
	public float speed;
	
	public GameObject ownerGboj;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, speed*Time.deltaTime, 0);
	}
	
	void OnCollisionEnter(Collision collision){
		if(ownerGboj != collision.gameObject){
			DestroyObject(this.gameObject);
		}
	}
}
