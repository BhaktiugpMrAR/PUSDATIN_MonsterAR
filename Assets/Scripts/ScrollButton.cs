using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScrollButton : MonoBehaviour
{
    public GameObject scrollContent;
    public List<float> contentPositionX;
    bool activeEnable;
    int indexContent = 0;

    private void OnEnable()
    {
        if (!activeEnable)
        {
            float x = 0;
            for (float i = 0; i < transform.GetChild(0).GetChild(0).childCount; i++)
            {
                x += 973f;
                contentPositionX.Add(x);
            }
        }

        activeEnable = true;
    }
    // Start is called before the first frame update
    public void MoveContent_Left()
   {
        scrollContent.transform.DOLocalMoveX(scrollContent.transform.localPosition.x - 973, 0.5f);
   }

    public void MoveContent_Right()
    {
        scrollContent.transform.DOLocalMoveX(scrollContent.transform.localPosition.x + 973, 0.5f);
    }

}
