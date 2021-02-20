using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    /// 状態
    enum eState
    {
        Wait, // Wave開始前
        Main, // メイン
        Gameover, // ゲームオーバー
    }
    eState _state = eState.Wait;

    List<Vec2D> _path;
    Layer2D _charaList;
    //カーソル
    Cursor _cursor;

    //カメラ
    Screen _screen;

    //行動タイマー
    const float TIMER_WAIT = 3.0f;
    float _tWait = TIMER_WAIT;


    //画面内のフィールドのx座標
    int _select_start;
    int _select_end;
    //キャラの種類
    int _charNum;
    // Start is called before the first frame update
    void Start()
    {
        //敵生成を管理
        Enemy.parent = new TokenMgr<Enemy>("Enemy", 128);
        //タワー生成を生成
        Chara.parent = new TokenMgr<Chara>("Chara", 64);
        //マップ管理を生成
        //プレハブを取得
        GameObject prefab = null;
        prefab = Util.GetPrefab(prefab, "Field");
        //インスタンスを生成
        Field field = Field.CreateInstance2<Field>(prefab, 0, 0);
        //マップ読み込み
        field.Load();
        //パスを取得
        _path = field.Path;
        //キャラレイヤーを取得
        _charaList = field.CharaList;
        //カーソルを取得
        _cursor = GameObject.Find("Cursor").GetComponent<Cursor>();

        //カメラを取得
        _screen = Camera.main.gameObject.GetComponent<Screen>();

        //選範囲を初期化
        _select_start = 0;
        _select_end = 10;

        //エネミーを出す
        foreach (Vec2D p in _path)
        {
            p.Dump();
            Enemy.Add(p);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //タイマーを更新
        _tWait -= Time.deltaTime;
        if (_tWait < 0)
        {
            //todo
            MoveChara(_select_start, _select_end);
            //カメラを移動させる
            _screen.MoveCam();
            //出撃しているキャラを移動させる
            GameObject[] charas = GameObject.FindGameObjectsWithTag("Chara");
            foreach (GameObject chara in charas)
            {
                chara.GetComponent<Chara>().MoveChara();
            }
            _tWait = TIMER_WAIT;
        }
        //カーソルを更新
        _cursor.Proc();
        if (_cursor.X < -1.0f || _cursor.X > 100.0f)
        {
            return;
        }
        if (_cursor.Y < 0.0f || _cursor.Y > 5.0f)
        {
            return;
        }

        //カーソルの下のキャラを取得
        if(_charaList.Get((int)_cursor.X, (int)_cursor.Y) != 0)
        {
            return;
        }

        //マウスクリック判定
        if (Input.GetMouseButtonDown(0))
        {

            //キャラを生成
            Chara.Add(_cursor.X , _cursor.Y,_charNum);
            _charaList.Set((int)_cursor.X, (int)_cursor.Y, _charNum);
        }
    }

    public void OnClickChara(int n)
    {
        switch (n)
        {
            case 1:
                _charNum = 1;
                Debug.Log(1);
                break;
            case 2:
                _charNum = 2;
                Debug.Log(2);
                break;
            case 3:
                _charNum = 3;
                Debug.Log(3);
                break;
            case 4:
                _charNum = 4;
                Debug.Log(4);
                break;
            case 5:
                _charNum = 5;
                Debug.Log(5);
                break;
            case 6:
                _charNum = 6;
                Debug.Log(6);
                break;
        }

    }

    void MoveChara(int s,int e)
    {

    }
}
