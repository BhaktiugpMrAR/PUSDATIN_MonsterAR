using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ColliderForInteraktif : MonoBehaviour
{
    LineRenderer lineRenderer;
    public string nameObject;
    public string description_object;
    GameObject infoBoard;
    GameObject panel_namePart;
    Color colorBlue = Color.green;
    Outline[] allchild;
    public Transform laserPosition, laserposition2;
    public bool laserActive = false;
    public TextMeshPro objectText;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        objectText.text = nameObject;
    }
    private void Start()
    {

    }

    private void Update()
    {
        if (laserActive)
        {
            laserposition2.gameObject.SetActive(true);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserPosition.position);
            lineRenderer.SetPosition(2, laserPosition.position);
            lineRenderer.SetPosition(3, laserposition2.position);
        }
        else
        {
            laserposition2.gameObject.SetActive(false);
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
            lineRenderer.SetPosition(2, Vector3.zero);
            lineRenderer.SetPosition(3, Vector3.zero);
        }
    }

    private void OnMouseDown()
    {
        Interactive();
    }

    public void Interactive()
    {
        if (AddToInfoText.instance.outlineForResetColor.Count > 0)
        {
            for (int i = 0; i < AddToInfoText.instance.outlineForResetColor.Count; i++)
            {
                AddToInfoText.instance.outlineForResetColor[i].OutlineColor = Color.red;
                AddToInfoText.instance.outlineForResetColor[i].OutlineMode = Outline.Mode.OutlineAll;
                AddToInfoText.instance.outlineForResetColor[i].GetComponentInParent<ColliderForInteraktif>().laserActive = false;
            }
        }
        panel_namePart = GameObject.Find("Panel_NamePart");
        Outline[] allchild = GetComponentsInChildren<Outline>();
        AddToInfoText.instance.outlineForResetColor = allchild.ToList();
        for (int i = 0; i < allchild.Length; i++)
        {
            allchild[i].OutlineColor = colorBlue;
            allchild[i].OutlineMode = Outline.Mode.OutlineAndSilhouette;
            allchild[i].GetComponentInParent<ColliderForInteraktif>().laserActive = true;
        }

        if (GlobalVariable.interactiveAR)
        {
            panel_namePart.transform.GetChild(0).gameObject.SetActive(true);
            panel_namePart.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = nameObject;
            GlobalVariable.namepart = nameObject;
            GlobalVariable.descriptionPart = description_object;
            Debug.Log(nameObject);
        }
    }
}
