using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Pathfinding;

public class GameManager : MonoBehaviour
{

    public LayerMask obstacleLayer;
    public Spawn spawn;
    public GameObject[] previewObj;
    public GameObject[] spawnsObj;
    public Vector3[] spawnsObjRate;
    [Header("Menu")]
    public RectTransform productMenu;

    [Obsolete]
    private void Awake()
    {
        NewGrid(Screen.width/30,Screen.height/30);
    }

    private void Preview(int index)
    {
        GameObject obj = Instantiate(spawnsObj[index]);
        spawn.preview = obj ;
        spawn.boxCast = spawn.preview.transform.GetChild(0);
        spawn.boxSize = spawnsObjRate[index];
        obj.GetComponent<BoxCollider2D>().enabled = false;

    }

    public void ChangeSpawnObj(int index)
    {

      
        productMenu.DOAnchorPosX(-800, 0.1f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            
            spawn.touch = true;
            Destroy(spawn.preview.gameObject);
            spawn.prefab = spawnsObj[index];
            Preview(index);
       
        });
       
     
       
    }

    public void ProductionMenuOpen()
    {
        
        spawn.touch = false;
        Destroy(spawn.preview.gameObject);
        productMenu.DOAnchorPosX(0, 0.1f).SetEase(Ease.OutExpo);
        spawn.InfoFalse();
    }
    public void ProductionMenuClose()
    {
        productMenu.DOAnchorPosX(-800, 0.1f).SetEase(Ease.OutExpo);
        spawn.InfoTrue();
    }

    public void Restart()
    {
         SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    [Obsolete]
    void NewGrid(int width,int depth)
    {
        AstarData data = AstarPath.active.astarData;
       
        GridGraph gg = data.AddGraph(typeof(GridGraph)) as GridGraph;
        
        gg.width = width;
        gg.depth = depth;
        gg.nodeSize = 0.2f;
        gg.is2D = true;
        gg.center = new Vector3(0, 0, 0);
        gg.collision.diameter = 1.25f;
        gg.collision.use2D = true;
        gg.collision.mask = obstacleLayer;
        gg.UpdateSizeFromWidthDepth();
       
        AstarPath.active.Scan();
    }
  
}
