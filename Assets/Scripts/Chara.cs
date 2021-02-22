using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chara : Token
{
    //仮置き
    public int _hp;
    int max_hp;
    public int _atk;
    public int _cost;
    public int _weight;
    //Hpスライダー
    public Slider hpSlider;


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
        max_hp = _hp;
        hpSlider.value = (float)_hp;
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
            child.GetComponent<AtkRange>().IsDmg = true;           
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }
        /// ダメージを受けた
    public void DamageC(int val)
    {
        // HPを減らす
        _hp -= val;
        hpSlider.value =  (float)max_hp / (float)_hp;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            // HPがなくなったので死亡
            Vanish();
        }
    }
}
