using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
	[SerializeField]
	private TakeFinishJungle finishJungle;
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
	Transform squaresContaner;
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
		BoardData boardData = FindObjectOfType<BoardData> ();
		if(boardData != null)
		{
			StartGame ();
			GetBoardData (boardData);
		}
		else
			gameState = GameState.Dialog;
	}

	public void StartGame ()
	{
		gameState = GameState.StartingTurn;
		squares = GetSquares ();
		dice.Throw ();
	}

	private List<Square> GetSquares ()
	{
		List<Square> squaresList = new List<Square>();
		Square [] squaresArray = squaresContaner.GetComponentsInChildren<Square> ();
		foreach(Square square in squaresArray)
			squaresList.Add(square);
		return squaresList;
	}

	private void GetBoardData (BoardData boardData)
	{
		currentIndexSquare = boardData.currentSquare;
		gameState = boardData.gameState;
		character.PositionTo (boardData.currentCharacterPosition + (Vector3.up*2));
		MiniGamesManager.SetMiniGameByIndex (boardData.indexMiniGame,boardData.miniGameState,boardData.minigamesViewed);
		boardData.Unload ();
	}

	private void SetBoardData ()
	{
		BoardData boardData = Instantiate(prefabBoardData) as BoardData;
		boardData.SetData ( currentIndexSquare,gameState,character.Position);
		boardData.SetMiniGamesData( miniGamesManager.MiniGamesViewed,miniGamesManager.CurrentGameIndex);
	}

	public void LoadSpecialGame ()
	{
		LoadScene (miniGamesManager.specialLevel.miniGameName);
	}

	public void LoadMiniGame ()
	{
		string miniGameName = miniGamesManager.GetMiniGame ();
		LoadScene (miniGameName);
	}

	private void LoadScene (string miniGameName)
	{
		SetBoardData ();
		LevelLoader.Instance.LoadScene (miniGameName);
	}

	public void GoBackward (int range , Square square)
	{
		character.PositionTo(square.Position + (Vector3.up));
		currentIndexSquare -= range;
		gameState = GameState.EndTurn;
	}

	public void GoForward (Square square , int range)
	{
		List<Square> nextSquares = new List<Square>();
		nextSquares.Add (square);
		squaresToSteps = nextSquares;
		currentIndexSquare += range;
		gameState = GameState.MovingTurn;
	}

	private void Update()
	{
		dice.UpdateGameState (gameState);
		dice.Position (character.Position + (Vector3.up * 3));
		if(miniGamesManager.CurrentMiniGame == null )
			BoardData ();
		else if(gameState == GameState.GiveRewards)
			miniGamesManager.GetRewards (character , StartNewTurn);
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

	private void StartNewTurn ()
	{
		gameState = GameState.StartingTurn;
		miniGamesManager.EndMiniGame ();
	}

	private void ExecuteAction ()
	{
		if(CurrentSquare.IsLast)
			FinishBoard ();
		else
			CurrentSquare.Execute ();
	}

	private void FinishBoard ()
	{
		character.StartCelebrationLoop ();
		Invoke(Helpers.NameOf ( LoadDialogStartRunner ), 3F);
	}

	private void LoadDialogStartRunner ()
	{
		finishJungle.Play ();
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
		if(miniGamesManager.CurrentMiniGame != null || gameState == GameState.Dialog)
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
		bool isBiggerThanCount = currentIndexSquare+moveSteps > squares.Count;
		int maxRange =  isBiggerThanCount? squares.Count : moveSteps ; 
		squaresToSteps = GetSquareRange (currentIndexSquare, maxRange);
		SetCurrentSquare (moveSteps, isBiggerThanCount);
		this.gameState = GameState.MovingTurn;
	}

	private void SetCurrentSquare (int moveSteps, bool isBiggerThanCount)
	{
		if (isBiggerThanCount)
			currentIndexSquare = squares.Count;
		else
			currentIndexSquare += moveSteps;
	}

	private List<Square> GetSquareRange ( int min, int count)
	{
		return squares.GetRange (min, count);
	}
}