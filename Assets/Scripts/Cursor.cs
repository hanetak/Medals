using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : Token
{
    //表示スプライト
    //四角
    public Sprite sprRect;
    //ばってん
    public Sprite sprCross;

    //カーソルにあるオブジェクト
    GameObject _selObj = null;
    public GameObject SelObj
    {
        get { return _selObj; }
    }

    //配置可能かどうか
    bool _bPlaceable = true;
    public bool Placeable
    {
        get { return _bPlaceable; }
        set
        {
            if (value)
            {
                //配置できるので四角
                SetSprite(sprRect);
            }
            else
            {
                //配置できないのでばってん
                SetSprite(sprCross);
            }
            _bPlaceable = value;
        }
    }
    public void Proc()
    {
        //マウス座標を取得する
        Vector3 posScreen = Input.mousePosition;

        //ワールド座標に変換する
        Vector2 posWorld = Camera.main.ScreenToWorldPoint(posScreen);
        X = (int)Mathf.Round(posWorld.x);
        Y = (int)Mathf.Round(posWorld.y);

        //画面外に出たら非表示
        if (Y < 0.0f)
        {

            SetSprite(null);
            return;
        }
        SetSprite(sprRect);

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Atk"){
            return;
        }
        _bPlaceable = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _bPlaceable = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
