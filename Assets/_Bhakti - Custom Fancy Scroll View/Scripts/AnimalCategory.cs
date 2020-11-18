﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterAR.Plugin;
using Bhakti.CustomFancyScrollView;

namespace PUSDATIN.FloraFauna
{
	public class AnimalCategory : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] CanvasShower canvasShower;
		[SerializeField] CustomScrollView customScrollView;
		[SerializeField] Button buttonPrev;
		[SerializeField] Button buttonNext;

		[Header("Attributes")]
		[SerializeField] List<ItemData> itemDatas;

		private void OnEnable()
		{
			foreach (ItemData itemData in itemDatas)
			{
				itemData.OnSelected += OnSelected;
			}
		}

		private void OnDisable()
		{
			foreach (ItemData itemData in itemDatas)
			{
				itemData.OnSelected -= OnSelected;
			}
		}

		void Start()
		{
			buttonPrev.onClick.AddListener(customScrollView.SelectPrevCell);
			buttonNext.onClick.AddListener(customScrollView.SelectNextCell);
			customScrollView.OnSelectionChanged(OnSelectionChanged);

			for (int i = 0; i < itemDatas.Count; i++)
			{
				itemDatas[i].itemIdx = i;
			}

			customScrollView.UpdateData(itemDatas);
			customScrollView.SelectCell(0);
		}

		void OnSelectionChanged(int index)
		{
			// TODO: SET ANIMATION FOR SELECTED ITEM DATA
		}

		void OnSelected(int itemIdx)
		{
			// TODO: SEND EVENT TO MENU MANAGER
		}

		public void ShowCategory(System.Action callback = null)
		{
			canvasShower.Show(delegate
			{
				callback();
			});
		}

		public void HideCategory(System.Action callback = null)
		{
			canvasShower.Hide(delegate
			{
				callback();
			});
		}
	}
}
