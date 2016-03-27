using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {
public float speed =0.1f;
public Vector2 offset = new Vector2(0,0);
Material mat;
	// Use this for initialization
	void Start () {

	mat = GetComponent<Renderer>().material;
	offset= mat.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
	 offset.y += Time.deltaTime * speed;
	 mat.SetTextureOffset("_MainTex",offset);

	}
}
