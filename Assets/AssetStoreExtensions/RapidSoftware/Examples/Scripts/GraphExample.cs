
using UnityEngine;
using Rapid.Tools;

public class GraphExample : MonoBehaviour
{
	public Texture2D descriptionImage;
	
	float _oldDeltaTime = 0f;
	
	
	void Awake()
	{
		// Do a default setup. You can customize things such as where the log files should go if wanted.
		Graph.Initialize();
		
		
		// Just for fun, lets add a nice blue style:
		Graph.Instance.AddStyle(
			new GraphLogStyle("blue", new Color(0.5f, 0.5f, 1f), Color.cyan,
				new []{new Color(0.5f, 0.2f, 0.92f,1f), new Color(0.2f, 0.1f, 0.86f, 1f)} )
		);
		
		// Create a log using the style:
		Graph.Instance.CreateLog("sin_cos", new []{"sin", "cos"}, "blue");
		
		
		// Create a log with labels and default style:
		Graph.Instance.CreateLog("deltatime_times_100", new []{"delta", "smooth delta"});
	}
	
	
	void OnApplicationQuit()
	{
		// This will free up any memory that's been allocated and close all file streams etc.
		Graph.Dispose();
	}
	
	
	void Update()
	{
		// Graph logging is usually usefull for debugging things such as:
		// Physics, animation, AI, state machines, timers, math calculations etc.
		// 
		// Any standard variable type can be logged by the Graph.Log(name, variable) method.
		// These include: byte, int, float, bool, Vector2, Vector3, Quaternion, Color, Color32, Rect.
		// 
		// You can use Graph.LogEvent(graph_name, message_string) to have text messages appear in the timeline.
		// 
		// If a log has not been created it will automatically be created the first Graph.Log() call that happens.
		//
		// Just log a few variables here as an example:
		
		
		
		// Let's see what the user is doing with the mouse and when the mouse clicks:
		Graph.Log("mouse", (Vector2)Input.mousePosition);
		
		if(Input.GetMouseButtonDown(0))
		{
			// Events will appear alongside the graph lines in the editor window as small dots,
			// which you can hover over with the mouse to see the exact time and message.
			Graph.LogEvent("mouse", "Clicked LEFT mouse button!");
		}
		if(Input.GetMouseButtonDown(1))
		{
			// You can color-code events to make them easily distinguishable:
			Graph.LogEvent("mouse", "Clicked RIGHT mouse button!", Color.yellow);
		}
		
		
		
		// Let's keep an eye on the delta time (time between updates)
		// This can give us a rough overview on how fast the game is running and if and when any sudden
		// framerate spikes occurs:
		
		var deltaClamped = System.Math.Min(Time.deltaTime * 100f, 10f);
		
		Graph.Log("deltatime_times_100", deltaClamped, Time.smoothDeltaTime*100f);
		
		if((deltaClamped - _oldDeltaTime) >= 5f) Graph.LogEvent("deltatime_times_100", "A framerate spike occured.");
		
		_oldDeltaTime = deltaClamped;
		
		
		
		// A nice way of gaining a better understanding of how certain mathematical functions work
		// is to log them and observe how they change over time:
		
		// But only do this the first 20 seconds
		if(Time.timeSinceLevelLoad < 20f)
		{
			Graph.Log("sin_cos", Mathf.Sin(Time.time), Mathf.Cos(Time.time));
		}
	}
	
	
	void OnGUI()
	{
		GUILayout.Space(40f);
		
		GUILayout.Label("    Please open the Graph editor window by clicking the menu item \"Window->Graph Debugger\" to see the debugger in action (while the application is running).");
		
		GUILayout.Space(40f);
		
		GUILayout.Box(new GUIContent(descriptionImage));
		
		GUILayout.Space(40f);
		
		GUILayout.Label("    By default, all variables recorded gets streamed to different log files to your \"Project\\Logs\" folder with the .graphlog extension.");
		GUILayout.Label("    After you stop running the application, you will be able to load in the graphs to look at them closer by zooming in with the mouse wheel and dragging the timeline with the left mouse button.");
		GUILayout.Label("    The code that logs the variables in this example is inside the script called \"GraphExample.cs\" inside the Examples folder.");
		
		GUILayout.Space(40f);
		
		GUILayout.Label("    Please email me at rapidgamedev@gmail.com if you experience any bugs or issues, or for general feedback & questions.");
		
		if(GUILayout.Button("Email me", GUILayout.Width(100f)))
			Application.OpenURL("mailto:rapidgamedev@gmail.com");
		
	}
};