using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bhakti.CustomFancyScrollView
{
	public class ClassCollection
	{
		//
	}

	#region CUSTOM FANCY SCROLL VIEW

	[Serializable]
	public class ItemData
	{
		public delegate void ItemDataEvent(int itemIdx);
		public event ItemDataEvent OnSelected;

		public string itemName;
		public Sprite itemIcon;
		[HideInInspector] public int itemIdx;

		public void SendOnSelectedEvent()
		{
			OnSelected?.Invoke(itemIdx);
		}
	}

	class Context
	{
		public int SelectedIndex = -1;
		public Action<int> OnCellClicked;
	}

	#endregion CUSTOM FANCY SCROLL VIEW
}
