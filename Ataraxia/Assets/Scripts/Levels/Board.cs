using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
	[SerializeField]
	private float minDistanceLastSquare = 1.51F;
	[SerializeField]
	private float minDistance = 1.51F;
	[SerializeField]
	private BoardData prefabBoardData;
	[SerializeField]
	private Character character;
	[SerializeField]
	private Dice dice;
	[SerializeField]
	private List<Square> squares = new List<Square>();
	[SerializeField]
	private MiniGamesManager miniGamesManager;
	private int currentIndexSquare = 0;
	private List<Square> squaresToSteps;
	private GameState gameState = GameState.StartingTurn;

	public MiniGamesManager MiniGamesManager
	{
		get {return miniGamesManager;}
	}

	public GameState GameState
	{
		get{ return gameState;}
	}

	public static Board Instance
	{
		get;
		private set;
	}

	private Square CurrentSquare
	{
		get { return squares[currentIndexSquare - 1]; }
	}

	private void Awake ()
	{
		if(Instance == null)
			Instance = this;
	}

	private void Start ()
	{
		dice.Throw ();
		BoardData boardData = FindObjectOfType<BoardData> ();
		if(boardData != null)
			GetBoardData (boardData);
	}

	private void GetBoardData (BoardData boardData)
	{
		currentIndexSquare = boardData.currentSquare;
		gameState = boardData.gameState;
		character.PositionTo (boardData.currentCharacterPosition);
		MiniGamesManager.SetMiniGameByIndex (boardData.indexMiniGame,boardData.miniGameState,boardData.minigamesViewed);
		boardData.Unload ();
	}

	private void SetBoardData ()
	{
		BoardData boardData = Instantiate(prefabBoardData) as BoardData;
		boardData.SetData ( currentIndexSquare,gameState,character.Position);
		boardData.SetMiniGamesData( miniGamesManager.MiniGamesViewed,miniGamesManager.CurrentGameIndex);
	}

	public void LoadMiniGame ()
	{
		string miniGameName = miniGamesManager.GetMiniGame ();
		SetBoardData ();
		LevelLoader.Instance.LoadScene (miniGameName);
	}

	public void GoBackward (int range)
	{
		List<Square> steps = GetSquareRange (currentIndexSquare - (range +1) , range);
		steps.Reverse ();
		squaresToSteps = steps;
		currentIndexSquare -= range;
		gameState = GameState.MovingTurn;
	}

	public void GoForward (int range)
	{
		squaresToSteps = GetSquareRange (currentIndexSquare, range);
		currentIndexSquare += range;
		gameState = GameState.MovingTurn;
	}

	private void Update()
	{
		dice.Position (character.Position + (Vector3.up * 3));
		if(!miniGamesManager.CurrentMiniGame )
			BoardData ();
		else if(gameState == GameState.GiveRewards)
			GiveRewardsMiniGame ();
	}

	private void BoardData ()
	{
		if (gameState == GameState.MovingTurn)
			TryToMove ();
		else if (gameState == GameState.EndTurn) 
		{
			character.Stop ();
			Invoke (Helpers.NameOf (ExecuteAction), 1.5F);
			gameState = GameState.ExecuteAction;
		}
	}

	private void GiveRewardsMiniGame ()
	{
		gameState = GameState.StartingTurn;
		miniGamesManager.GetRewards ();
		miniGamesManager.EndMiniGame ();
	}

	private void ExecuteAction ()
	{
		CurrentSquare.Execute ();
	}

	private void TryToMove ()
	{
		if (squaresToSteps != null && squaresToSteps.Count > 0) 
		{
			character.MoveTo (squaresToSteps [0].Position);

			float distance = squaresToSteps.Count == 1 ? minDistanceLastSquare : minDistance;

			if (character.GetDistance(squaresToSteps[0]) < distance)
				squaresToSteps.RemoveAt (0);

			if(squaresToSteps.Count == 0)
				gameState = GameState.EndTurn;
		}
	}

	private void OnGUI ()
	{
		if(miniGamesManager.CurrentMiniGame != null)
			return;

		if(GUI.Button(new Rect(0F,0F,150F,25F),"Throw Dice"))
		{
			dice.Show ();
			dice.Throw ();
		}

		if(GUI.Button(new Rect(0F,50F,150F,25F),"Stop Dice"))
		{
			dice.Stop ();
			Invoke (Helpers.NameOf (StartMovingCharacter), 1F);
		}
	}

	private void StartMovingCharacter ()
	{
		int moveSteps = dice.Value;
		squaresToSteps = GetSquareRange (currentIndexSquare, moveSteps);
		currentIndexSquare+= moveSteps;
		this.gameState = GameState.MovingTurn;
		dice.Hide ();
	}

	private List<Square> GetSquareRange ( int min, int count)
	{
		return squares.GetRange (min, count);
	}
}