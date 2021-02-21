using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : Token
{
    SpriteRenderer spriteRenderer;
    //キャラ管理
    public static TokenMgr<Chara> parent;

    //キャラの画像
    public Sprite[] faces;

    //キャラの種類
    int _charaNum;
    //タワー生成
    public static Token Add(float px, float py, int n)
    {
        Chara c = parent.Add(px, py);
        if (c == null)
        {
            return null;
        }
        c.Init(n);
        return c;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //キャラを初期化

    private void Init(int n)
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = faces[n];
        _charaNum = n;

    }

    //キャラを移動させる
    public void MoveChara()
    {
        X = X + 1;
        //削除予定
        ShowAtkRange(_charaNum);
    }

    public void ShowAtkRange(int n)
    {
        //charaの攻撃範囲種類を取得
        GameObject obj = transform.GetChild(n - 1).gameObject;
        foreach (Transform child in obj.transform)
        {
            child.GetComponent<AtkRange>().CanVisible();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }
}
