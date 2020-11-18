using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoomInZoomOut : MonoBehaviour
{
	float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

	Vector2 firstTouchPrevPos, secondTouchPrevPos;

	public float rotatespeed = 10f;
	private float _startingPosition;
	public float zoomModifierSpeed = 0.1f;
	public Text text;
	public TextMeshProUGUI nameObject, jenisHewan;

	// TARGET AR scan marker
	private GameObject target;

	private void Start()
	{
		GlobalVariable.interactiveAR = true;
	}

	public void AddTarget(GameObject obj)
	{
		GlobalVariable.interactiveAR = true;
		target = obj;
		nameObject.text = obj.GetComponent<ObjectManager>().characterName;
		jenisHewan.text = obj.GetComponent<ObjectManager>().jenisAnimal;
	}

	public void RemoveTarget()
	{
		target = null;
		nameObject.text = "";
		jenisHewan.text = "";
	}

	// Update is called once per frame
	void Update()
	{
		if (GlobalVariable.interactiveAR)
		{
			if (Input.touchCount == 2 && target != null)
			{
				Touch firstTouch = Input.GetTouch(0);
				Touch secondTouch = Input.GetTouch(1);

				firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
				secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

				touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
				touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

				zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

				if (touchesPrevPosDifference > touchesCurPosDifference)
				{
					target.transform.localScale -= new Vector3(zoomModifier, zoomModifier, zoomModifier);
				}

				if (touchesPrevPosDifference < touchesCurPosDifference)
				{
					target.transform.localScale += new Vector3(zoomModifier, zoomModifier, zoomModifier);
				}
			}

			if (Input.touchCount == 1 && target != null)
			{
				Touch touch = Input.GetTouch(0);
				switch (touch.phase)
				{
					case TouchPhase.Began:
						_startingPosition = touch.position.x;
						break;
					case TouchPhase.Moved:
						if (_startingPosition > touch.position.x)
						{
							target.transform.Rotate(new Vector3(0, 1, 0), rotatespeed * Time.deltaTime);
						}
						else if (_startingPosition < touch.position.x)
						{
							target.transform.Rotate(new Vector3(0, 1, 0), -rotatespeed * Time.deltaTime);
						}
						break;
					case TouchPhase.Ended:
						Debug.Log("Touch Phase Ended.");
						break;
				}
			}

			//mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 10f);
			text.text = zoomModifier.ToString();

		}
	}
}