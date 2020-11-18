using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PUSDATIN.FloraFauna
{ 
	public class AnimalCategoryManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] AnimalCategory[] animalCategories;

		[Header("Current")]
		[SerializeField] int currCategoryIdx;

		private void Start()
		{
			currCategoryIdx = 0;

			SetCategory(0);
		}

		void SetCategory(int idx)
		{
			HidePreviousCategory(idx, delegate
			{
				currCategoryIdx = idx;

				animalCategories[idx].ShowCategory();
			});
		}

		void HidePreviousCategory(int idx, System.Action callback)
		{
			if (currCategoryIdx != idx)
			{
				animalCategories[currCategoryIdx].HideCategory(delegate
				{
					callback();
				});
			}
			else
			{
				callback();
			}
		}

		public void OnClickSetCategory(int idx)
		{
			SetCategory(idx);
		}
	}
}