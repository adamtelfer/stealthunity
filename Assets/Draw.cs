using UnityEngine;

using System.Collections;



public class Draw : MonoBehaviour {
	
	
	
	private Route line_route;
	
	public bool ran;
	
	public Vector3 toPoint;
	
	public float distanceFromCamera = 10f;
	
	// Use this for initialization
	
	void Start () {
		
		
		
	}
	
	
	
	// Update is called once per frame
	
	void Update () {
		
		if(Input.GetMouseButton(0)){
			
			// hack to get a point in world space.
			
			RaycastHit hit;
			
			Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(new Vector3 (Input.mousePosition.x, Input.mousePosition.y,0));
			
			toPoint = ray.GetPoint (distanceFromCamera);
			
			if (ran ==false){
				
				LineInitialize();
				
				ran = true;
				
			}
			
			else{
				
				line_route.connect_data (toPoint, 0);
				
				// smooth and connect
				
				line_route.smooth_all ();
				
				line_route.connect_line (0, line_route.data.Count);
				
			}
			
		}
		
		else{
			
			// mouse isnt held down, reset,
			
			ran = false;    
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	private void LineInitialize(){
		
		GameObject line_object = Instantiate (Resources.Load("LineObject"),  toPoint, Quaternion.identity) as GameObject;
		
		line_route = new Route ();
		
		line_route.initialize (line_object,toPoint );
		
		
		
	}
	
	
	
}