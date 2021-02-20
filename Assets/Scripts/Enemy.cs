using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Token
{
    //管理オブジェクト
    public static TokenMgr<Enemy> parent = null;

    //プレハブから敵を生成
    public static Enemy Add(Vec2D path)
    {
        Enemy e = parent.Add(0, 0);
        if (e == null)
        {
            return null;
        }
        e.Init(path);
        return e;
    }

    public void Init(Vec2D path)
    {
        //座標に配置
        X = path.x;
        Y = 4 - path.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other) {

        //陣地に敵が到着した時
        if(other.gameObject.tag == "DeadLine"){
        MyCanvas.SetActive("TextGameover", true);     
        }
    }
}
