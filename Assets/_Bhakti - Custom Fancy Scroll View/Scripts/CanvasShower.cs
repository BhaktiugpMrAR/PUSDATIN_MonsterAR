using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MonsterAR.Plugin
{
	public class CanvasShower : MonoBehaviour
	{
		[Header("Shower References")]
		[SerializeField] CanvasGroup canvasGroup;

		[Header("Shower Attributes")]
		[SerializeField] float fadeDuration;
		[SerializeField] bool isShowedOnStart;

		private void Awake()
		{
			canvasGroup.alpha = isShowedOnStart? 1 : 0;
			canvasGroup.interactable = isShowedOnStart;
			canvasGroup.blocksRaycasts = isShowedOnStart;
		}

		public void SetIsShowedOnStart()
		{
			isShowedOnStart = true;
		}

		public void Show(Action callback = null, bool isForced = false)
		{
			canvasGroup.blocksRaycasts = true;

			canvasGroup.DOFade(1, isForced ? 0 : fadeDuration).OnComplete(delegate
			{
				canvasGroup.interactable = true;

				callback?.Invoke();
			});
		}

		public void Hide(Action callback = null, bool isForced = false)
		{
			canvasGroup.interactable = false;

			canvasGroup.DOFade(0, isForced? 0 : fadeDuration).OnComplete(delegate
			{
				canvasGroup.blocksRaycasts = false;

				callback?.Invoke();
			});
		}
	}
}
