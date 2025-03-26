using Godot;
using System;

public partial class game_state : Node
{
	int[] timesHungout = new int[7];	// by character.
	string curScene = "";
	int curDay = 0;			// What day is this? (out of 3)
	int curHangout = 0;		// What hangout of the day is this? (out of 2)
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	// h = hangouts
	// s = story events
	public void ToNextScene(string scene)
	{
		if (curScene[0] == 'h')
		{
			int character = (int)((curScene[1]) - '0');	// who were you hanging out with?
			timesHungout[character]++;
			curScene = scene;
		}
		else if (curScene[0] == 's')
		GetTree().ChangeSceneToFile("res://scenes/cutscene.tscn");
	}
	public string GetCurScene()
	{
		return curScene;
	}
}
