using Godot;
using System;
using DialogueManagerRuntime;

public partial class cutscene : Node2D
{
	game_state gameState;
	Sprite2D character;
	[Export] public Resource Hangouts, Story;	// Set in editor
	[Export] string scene;
	
	Texture2D[] characterImages = new Texture2D[6]{
		GD.Load("res://art/Man1.jpg") as Texture2D,
		GD.Load("res://art/Man2.jpg") as Texture2D,
		GD.Load("res://art/Man3.jpg") as Texture2D,
		GD.Load("res://art/Man4.jpg") as Texture2D,
		GD.Load("res://art/Man5.jpg") as Texture2D,
		GD.Load("res://art/Man6.jpg") as Texture2D
	};
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameState = GetNode<game_state>("/root/GameState");
		scene = gameState.GetCurScene();
		character = GetNode<Sprite2D>("Foreground/Character");
		
		if (scene == "s0")
			GetNode<Sprite2D>("Beach").Visible = false;
		if (scene[0] == 's')
			DialogueManager.ShowDialogueBalloon(Story, scene);
		else if (scene[0] == 'h')
		{
			DialogueManager.ShowDialogueBalloon(Hangouts, scene);
			character.Texture = (characterImages[ (int)((scene[1]) - '0') ] );		// Who are we hanging out with?
			float x_scale = character.Texture.GetWidth(), y_scale = character.Texture.GetHeight();
			character.Scale = new Vector2(600/x_scale, 500/y_scale);
		}
	}
	
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void toNextScene()
	{
	}
		
	public void ExitGame() { GetTree().Quit(); }
	
	public void LoadBeachImage(string image) 
	{
		GetNode<Sprite2D>("Beach").Visible = true;
		switch (image)
		{
			case "beach":
				GetNode<Sprite2D>("Beach").Texture = GD.Load("res://art/backgroundvisnov1.png") as Texture2D;
			break;
			case "crash":
				GetNode<Sprite2D>("Beach").Texture = GD.Load("res://art/PlaneCrash2_Zach.png") as Texture2D;
			break;
			case "fall":
				GetNode<Sprite2D>("Beach").Texture = GD.Load("res://art/PlaneCrash_Zach.png") as Texture2D;
			break;
		}
		return;
		
	}
	public void HidePlane() { GetNode<Sprite2D>("Plane").Visible = false; }
}



