using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextManager : MonoBehaviour
{
    public static InfoTextManager instance;
    public TextMeshProUGUI infoTextContent, infotextJudul;
    public GameObject contonScrollView, panelInfo;
  //  int pageCount;
  //  Vector3 curPos;
  //  float speed = 0.5f;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       // curPos = transform.localPosition;
    }

    private void OnEnable()
    {
        
    }

    public void CloseButton()
    {
        GlobalVariable.interactiveAR = true;
        panelInfo.SetActive(false);
    }
    
    public void SetContent(string conten, string judul)
    {
        GlobalVariable.interactiveAR = false;
        panelInfo.SetActive(true);
        infoTextContent.text = conten;
        infotextJudul.text = judul;
        StartCoroutine(ResetContent());
    }

    IEnumerator ResetContent()
    {
        yield return new WaitForSeconds(0.1f);
        contonScrollView.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        contonScrollView.SetActive(true);
    }
}
