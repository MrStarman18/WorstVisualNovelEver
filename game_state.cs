using Godot;
using System;

public partial class game_state : Node
{
	int[] timesHungout = new int[7];	// by character.
	string curScene = "s0";
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
	// Expected usage: Called with () to load next scene in a sequence, i.e. next day after hangout.
	//					or called with a number to load that character's hangout.
	public void ToNextScene(int toChar = 0)
	{
		if (curScene[0] == 'h')	// if coming from a hangout
		{
			int character = (int)((curScene[1]) - '0');	// who were you hanging out with?
			timesHungout[character]++;
			curDay++;
			if (curDay < 3)
				curScene = $"s{curDay}";
			else						// 
			{
				curScene = "s3";				// default ending cutscene.
				for (int i = 0; i < timesHungout.Length; i++) {
					if (timesHungout[i] >= 3) {				// If you hungout with anyone 3 times you get to fuck!!
						curScene = $"s3{i}";
						break;
					}
				}
			}
		}
		else if (curScene[0] == 's')	// if coming from a story event
		{
			curScene = $"h{toChar}{timesHungout[toChar]}";
		}
		GetTree().ChangeSceneToFile("res://scenes/cutscene.tscn");
	}
	public string GetCurScene()
	{
		return curScene;
	}
}
