using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : Token
{
    SpriteRenderer spriteRenderer;
    //キャラ管理
    public static TokenMgr<Chara> parent;
    public  Sprite[] faces;
    //タワー生成
    public static Token Add(float px, float py, int n)
    {
        Chara c = parent.Add(px, py);
        if(c == null)
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

    private void Init(int n)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = faces[n];
        
    }

    //キャラを移動させる
    public void MoveChara()
    {
        X = X + 1;
    }

    void  OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}
