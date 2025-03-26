using Godot;
using System;
using DialogueManagerRuntime;

public partial class cutscene : Node2D
{
	game_state gameState;
	[Export] public Resource DialogueResource;	// Set in editor
	[Export] string scene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameState = GetNode<game_state>("/root/game_state");
		scene = gameState.GetCurScene();
		DialogueManager.ShowDialogueBalloon(DialogueResource, scene);
	}
	
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void toNextScene()
	{
	}

}



