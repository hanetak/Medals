using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Token
{
    //なにもない
    public const int CHIP_NONE = 0;

    //開始地点
    public const int CHIP_PATH_START = 26;

    public const int CHIP_PATH_ENEMY = 27;

    //パス
    List<Vec2D> _path;
    public List<Vec2D> Path
    {
        get { return _path; }
    }

    Layer2D _charaList;
    public Layer2D CharaList
    {
        get { return _charaList; }
    }

    public void Load()
    {


        //マップ読み込み
        TMXLoader tmx = new TMXLoader();
        tmx.Load("Levels/Sample");

        //経路レイヤーを取得
        Layer2D lPath = tmx.GetLayer("path");

        //敵レイヤーを取得
        Layer2D lEnemy = tmx.GetLayer("enemy");

        //キャラのレイヤー
        _charaList = lEnemy;

        //座標リストを作成
        _path = new List<Vec2D>();

        CreatePath(lEnemy, lEnemy.Width, lEnemy.Height, _path);

    }
    //パスを作る
    void CreatePath(Layer2D layer, int x, int y, List<Vec2D> path)
    {
        for(int i = 0; i < x; i++)
        {
            for(int j = 0;j < y; j++)
            {
                if(layer.Get(i,j) == CHIP_PATH_ENEMY)
                {
                    path.Add(new Vec2D(i, j));
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
