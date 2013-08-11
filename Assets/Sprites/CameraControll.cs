using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + offset;
	}
}
