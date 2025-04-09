using Godot;
using System;
using DialogueManagerRuntime;

public partial class cutscene : Node2D
{
	game_state gameState;
	Sprite2D character;
	[Export] public Resource Hangouts, Story;	// Set in editor
	[Export] string scene;
	AudioStreamPlayer2D music;
	
	Texture2D[] characterImages = new Texture2D[6]{
		GD.Load("res://art/Man1.jpg") as Texture2D,
		GD.Load("res://art/tumblr_sexyman.png") as Texture2D,
		GD.Load("res://art/Man3.jpg") as Texture2D,
		GD.Load("res://art/Man4.jpg") as Texture2D,
		GD.Load("res://art/DILF.png") as Texture2D,
		GD.Load("res://art/Man6.jpg") as Texture2D
	};
	Texture2D[] guyImages = new Texture2D[7]{
		GD.Load("res://art/Man1.jpg") as Texture2D,
		GD.Load("res://art/Man2.jpg") as Texture2D,
		GD.Load("res://art/Man3.jpg") as Texture2D,
		GD.Load("res://art/Man4.jpg") as Texture2D,
		GD.Load("res://art/Man5.jpg") as Texture2D,
		GD.Load("res://art/Man6.jpg") as Texture2D,
		GD.Load("res://art/Man7.jpg") as Texture2D
	};
	AudioStream[] hangoutMusic = new AudioStream[7]{
		GD.Load("res://audio/Character 1 (Tmblr Man).mp3") as AudioStream,
		GD.Load("res://audio/Character 2 (Discord Mod).wav") as AudioStream,
		GD.Load("res://audio/Character 3 (furrybait character avery girl) (stolen royalty free youtube music edited and cursed).mp3") as AudioStream,
		GD.Load("res://audio/Character 4 (Car) Main Theme.wav") as AudioStream,
		GD.Load("res://audio/Character 5 (CowboyDILF).wav") as AudioStream,
		GD.Load("res://audio/Character 6 (Normal Guy).wav") as AudioStream,
		GD.Load("res://audio/Character 7 (TextBox).wav") as AudioStream
	};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameState = GetNode<game_state>("/root/GameState");
		scene = gameState.GetCurScene();
		character = GetNode<Sprite2D>("Foreground/Character");
		music = GetNode<AudioStreamPlayer2D>("Music");
		Random rand = new Random();
		
		if (scene == "s0")
			GetNode<Sprite2D>("Beach").Visible = false;
		if (scene[0] == 's')
		{
			DialogueManager.ShowDialogueBalloon(Story, scene);
			if (scene == "s3x")			// maidenless ending
				music.Stream = GD.Load("res://audio/End of World (Maiden Failed).mp3") as AudioStream;
			else if (scene[1] == '3')	// good ending
				music.Stream = GD.Load("res://audio/End of World (Maiden Achieved).wav") as AudioStream;
			else						// default music?
				music.Stream = GD.Load("res://audio/Crisp 20 Seconds of Absolute Silence.wav") as AudioStream;
			music.Play();
		}
		else if (scene[0] == 'h')
		{
			DialogueManager.ShowDialogueBalloon(Hangouts, scene);
			int curChar = (int)((scene[1]) - '0');
			if (curChar == 5)										// Random guy image
				character.Texture = (guyImages[(int) (rand.Next() % 7)]);
			else if (curChar != 6)
				character.Texture = (characterImages[curChar]);		// No image for textbox hangout
			if (curChar != 6)
			{
				float x_scale = character.Texture.GetWidth(), y_scale = character.Texture.GetHeight();
				character.Scale = new Vector2(600/x_scale, 500/y_scale);
				character.Visible = true;
			}	
			
			music.Stream = hangoutMusic[curChar];
			music.Play();
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



