using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public GameObject preview;
    public Transform boxCast;
    public Vector3 boxSize;
    public GameObject warningText;
    public bool touch;

    [Header("Infformation")]
    public Information information;
    public RectTransform informationPanel;
    public TextMeshProUGUI namee;
    public Image Image;
    public GameObject product;
    public TextMeshProUGUI pNamee;
    public Image pImage;
    private void Update()
    {
        if (touch)
        {
           
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = Mathf.Round(world.x / 0.32f) * 0.32f; //Yuvarlama
            float y = Mathf.Round(world.y / 0.32f) * 0.32f;
            preview.transform.position = new Vector3(x, y);
            RaycastHit2D hit = Physics2D.BoxCast(boxCast.position, boxSize, 0, Vector2.zero);

            if (Input.GetMouseButtonUp(0) && !hit)
            {

                GameObject obj = Instantiate(prefab, transform.position, transform.rotation, transform);
                obj.transform.position = new Vector2(x, y);
                AstarPath.active.Scan();
                touch = false;
                InfoTrue();
            }
           
          

            if (!hit) Avaible();
            if (Input.GetMouseButtonUp(0) && hit) Warning();
        }


        



    }

    public void InfoTrue()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Information>().touch=true;
        }
    }
    public void InfoFalse()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<Information>().touch = false;
        }
    }

    void Warning()
    {
        warningText.SetActive(true);
        for (int i = 0; i < preview.transform.GetChild(1).childCount; i++)
        {
            preview.transform.GetChild(1).GetChild(i).GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    void Avaible()
    {
        warningText.SetActive(false);
        for (int i = 0; i < preview.transform.GetChild(1).childCount; i++)
        {
            preview.transform.GetChild(1).GetChild(i).GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    public void CloseInformation()
    {
        InfoTrue();
        information.CloseClickObj();
        informationPanel.DOAnchorPosX(800, 0.3f).SetEase(Ease.OutExpo);
    }
   
    public void Produce()
    {
        CloseInformation();
        information.Spawn();
       
    }
}
