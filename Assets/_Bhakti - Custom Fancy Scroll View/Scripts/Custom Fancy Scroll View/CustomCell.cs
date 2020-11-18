using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Bhakti.CustomFancyScrollView
{
	class CustomCell : FancyCell<ItemData, Context>
	{
		[Header("References")]
		[SerializeField] Animator animator;
		[SerializeField] Text message;
		[SerializeField] Image icon;
		[SerializeField] Image image;
		[SerializeField] Button button;

		[Header("Current")]
		[SerializeField] bool isSelected;
		[SerializeField] ItemData itemData;

		static class AnimatorHash
		{
			public static readonly int Scroll = Animator.StringToHash("scroll");
		}

		public override void Initialize()
		{
			button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
		}

		public override void UpdateContent(ItemData itemData)
		{
			this.itemData = itemData;
			message.text = itemData.itemName;
			icon.sprite = itemData.itemIcon;

			var selected = Context.SelectedIndex == Index;
			//image.color = selected ? new Color32(0, 255, 255, 100) : new Color32(255, 255, 255, 77);

			isSelected = selected;
		}

		public override void UpdatePosition(float position)
		{
			currentPosition = position;

			if (animator.isActiveAndEnabled)
			{
				animator.Play(AnimatorHash.Scroll, -1, position);
			}

			animator.speed = 0;
		}

		// GameObject が非アクティブになると Animator がリセットされてしまうため
		// 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
		float currentPosition = 0;

		void OnEnable() => UpdatePosition(currentPosition);

		public void OnClickCell()
		{
			if (isSelected)
			{
				itemData.SendOnSelectedEvent();
			}
		}
	}
}
