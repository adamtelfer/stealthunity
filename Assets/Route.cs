using UnityEngine;



using System.Collections;



public class Route {
	
	// increase for longer lines
	
	public static int   segment_max = 32;
	
	// decrease for smoother lines
	
	public static float segment_spacing = 8;
	
	public bool  is_assigned;
	
	public float timestamp;
	
	public ArrayList data;
	
	
	
	public float lineWidthStart = 0.5f;
	
	public float lineWidthEnd = 0.5f;
	
	LineRenderer line;
	
	Vector3 last;
	
	Vector3 step;
	
	bool first_point;
	
	
	
	
	
	
	
	public void initialize (GameObject line_object, Vector3 startPosition) {
		
		data = new ArrayList ();
		
		line = line_object.GetComponent ("LineRenderer") as LineRenderer;
		
		line.SetWidth (lineWidthStart, lineWidthEnd);
		
		line.useWorldSpace = true;
		
		reset (startPosition);
		
	}
	
	
	
	
	
	
	
	public void reset (Vector3 startPosition) {
		
		data.Clear ();
		
		clear_line ();
		
		// was : 
		
		//  last = Vector3.zero;
		
		last =startPosition;
		
		step = Vector3.up;
		
		first_point = true;
		
	}
	
	
	
	
	
	
	
	public void assign (bool value) {
		
		is_assigned = value;
		
		if (is_assigned){
			
			timestamp = Time.time;
			
		}
		
		else{
			
			timestamp = 0.0f;
			
		}
		
	}
	
	
	
	
	
	
	
	public void set_color (Color color) {       
		
		line.material.color = color;
		
	}
	
	
	
	
	
	
	
	public Vector3 points_to () {   
		
		return step;
		
	}
	
	
	
	
	
	
	
	public Vector3 ends_at () { 
		
		return last;
		
	}
	
	
	
	
	
	
	
	public void connect_data (Vector3 target, int extension) {
		
		first_point = false;
		
		connect_data (last, target, extension);
		
		first_point = true;
		
	}
	
	
	
	
	
	
	
	public void connect_data (Vector3 anchor, Vector3 target, int extension) {
		
		float distance = Vector2.Distance ((Vector2)anchor, (Vector2)target);
		
		
		
		if (first_point) {
			
			last = Vector3.right * anchor.x + Vector3.up * anchor.y;
			
			data.Add (last);
			
		}
		
		
		
		
		
		
		
		step = (Vector2)target - (Vector2)last;
		
		step.Normalize ();
		
		
		
		while (distance >= segment_spacing && data.Count <= segment_max + extension) {
			
			last += step * segment_spacing;         
			
			data.Add (last);
			
			distance = Vector2.Distance (last, (Vector2)target);
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void connect_data_last (Vector3 target) {
		
		
		
		if (0 < data.Count){
			
			data.Add (target);
			
		}
		
	}
	
	
	
	
	
	
	
	public void smooth_front () {
		
		
		
		if (2 < data.Count) {
			
			Vector3 weighted_average;
			
			weighted_average =
				
				
				
				(Vector3)data[0] * 0.3f +
					
					(Vector3)data[1] * 0.4f +
					
					(Vector3)data[2] * 0.3f;
			
			data [1] = weighted_average;
			
			
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void smooth_back () {
		
		
		
		
		
		
		
		if (2 < data.Count) {
			
			Vector3 weighted_average;
			
			weighted_average =
				
				(Vector3)data[data.Count - 3] * 0.3f +
					
					(Vector3)data[data.Count - 2] * 0.4f +
					
					(Vector3)data[data.Count - 1] * 0.3f;
			
			data [data.Count - 2] = weighted_average;
			
			
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void smooth_at (int index) {
		
		
		
		if (4 < data.Count && 0 <= index - 2 && index + 2 < data.Count) {
			
			
			
			Vector3 weighted_average;
			
			weighted_average =
				
				
				
				(Vector3)data[index - 2] * 0.1f +
					
					(Vector3)data[index - 1] * 0.15f +
					
					(Vector3)data[index    ] * 0.5f +
					
					(Vector3)data[index + 1] * 0.15f +
					
					(Vector3)data[index + 2] * 0.1f;
			
			data[index] = weighted_average;
			
			
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void smooth_between (int lo, int hi) {
		
		
		
		
		
		
		
		if (4 < data.Count && 2 <= lo - 2 && hi < data.Count - 2) {  
			
			for (int i = lo; i < hi; i++) smooth_at (i);
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void smooth_all () {
		
		
		
		
		
		
		
		if (4 < data.Count) {
			
			for (int i = 2; i < data.Count - 2; i++) smooth_at (i);
			
			smooth_front ();
			
			smooth_back ();
			
			
			
		}
		
		
		
	}
	
	
	
	
	
	
	
	public void connect_line (int data_range_min, int data_range_max) {
		
		
		
		if (data_range_min > data_range_max)
			
			data_range_min = data_range_max;
		
		
		
		if (data_range_max > data.Count)
			
			data_range_max = data.Count;
		
		
		
		
		
		
		
		int position_count = data_range_max - data_range_min;
		
		line.SetVertexCount (data_range_max - data_range_min);
		
		line.material.SetTextureScale ("_MainTex", Vector2.right * position_count + Vector2.up);
		
		
		
		
		
		
		
		
		
		
		
		for (int i = 0; i < position_count; i++)    
			
			line.SetPosition (i, (Vector3)data[data_range_min + i]);
		
		
		
	}
	
	
	
	
	
	
	
	public void clear_line () {
		
		line.SetVertexCount (0);    
		
		
		
	}
	
	
	
}