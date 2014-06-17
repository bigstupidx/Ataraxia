using UnityEngine;
using System.Collections;

public class ProgressPlantLife : MonoBehaviour 
{
	[SerializeField]
	private UIProgressBar progressbar;
	[SerializeField]
	private AtaraxiaText progressBarLabel;
	[SerializeField]
	private SimpleSprite alert;
	[SerializeField]
	private Plant plant;

	private void Start ()
	{
		plant.Deteriorated += OnDeteriorated;
		plant.Healed += OnHealded;
		SetLabelLife ();
	}

	private void OnDeteriorated ()
	{
		SetLabelLife (); 
	}

	private void OnHealded ()
	{
		SetLabelLife ();
	}

	private void Update ()
	{
		progressbar.Value = plant.CurrentLife;
		alert.Hide ( plant.Life > plant.MinLife );
	}

	private void SetLabelLife ()
	{
		progressBarLabel.Text = plant.Life + "/" + plant.MaxLife;
	}
}