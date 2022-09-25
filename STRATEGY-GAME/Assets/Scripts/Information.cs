using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Information : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject clikObj;
    public bool isProduct;
    private Spawn spawn;
    public string buildName;
    public Sprite image;
    [Header("for Product")]
    public string pNamee;
    public Sprite pImage;
    public Transform spawnPoint;
    public GameObject prefab;
    public bool touch;
    private Information information;

    private void Start()
    {
        information = GetComponent<Information>();
    }
    private void OnMouseDown()
    {
        if (touch)
        {
            clikObj.SetActive(true);
            spawn = transform.parent.GetComponent<Spawn>();
            spawn.information = information;
            Invoke("Info", 0.25f);
            spawn.InfoFalse();
        }
       

    }
    void Info()
    {
        spawn.informationPanel.DOAnchorPosX(0,0.3f).SetEase(Ease.OutExpo);
        spawn.namee.text = buildName;
        spawn.Image.sprite = image;
        if (isProduct)
        {
            spawn.product.SetActive(true);
            spawn.pNamee.text = pNamee;
            spawn.pImage.sprite = pImage;
        }
        else
        {
            spawn.product.SetActive(false);
            spawn.pNamee.text = null;
            spawn.pImage.sprite = null;
        }
      
       
    }
    public void Spawn()
    {
        
       Instantiate(prefab, spawnPoint.transform.position,transform.rotation);
        
    }
    public void CloseClickObj()
    {
        clikObj.SetActive(false);
    }
}
