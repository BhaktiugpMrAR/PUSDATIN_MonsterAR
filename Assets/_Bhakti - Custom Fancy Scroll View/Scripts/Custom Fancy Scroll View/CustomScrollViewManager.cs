using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bhakti.CustomFancyScrollView
{
	public class CustomScrollViewManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] CustomScrollView customScrollView;
		[SerializeField] Button buttonPrev;
		[SerializeField] Button buttonNext;
		[SerializeField] Text selectedItemInfo;

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
			selectedItemInfo.text = $"Selected item info: index {index}";
		}

		void OnSelected(int itemIdx)
		{
			Debug.Log(itemDatas[itemIdx].itemName);
		}
	}
}
