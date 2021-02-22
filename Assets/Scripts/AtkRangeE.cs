using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRangeE : Token
{
    //攻撃時間
    const float ATK_TIMER = 1;

    float _tAtk = 1;
    public Sprite atkB;
    // Start is called before the first frame update
    void Start()
    {
        //NonVisible();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NonVisible()
    {
        SetSprite(null);
    }

    public void CanVisible()
    {
        SetSprite(atkB);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //敵の攻撃範囲内いる時
        if (other.gameObject.tag == "Chara")
        {
            _tAtk -= Time.deltaTime;
            if (_tAtk < 0)
            {
                RaycastHit2D[] allHit = Physics2D.BoxCastAll(transform.position, new Vector2(2, 1), 0, Vector2.zero);
                if(allHit.Length >= 2){
                    for(int i = allHit.Length -1;i > 0 ;i --){
                        if(allHit[i].collider.gameObject.tag == "Chara"){
                        allHit[i].collider.gameObject.GetComponent<Chara>().DamageC(3);
                        Debug.Log("敵からダメージを受けた");
                        _tAtk = ATK_TIMER;
                        return;
                        }

                    }

                }
                else
                {
                    other.gameObject.GetComponent<Chara>().DamageC(3);
                    Debug.Log("敵から3ダメージを受けた");
                }
                 _tAtk = ATK_TIMER;
            }

        }

    }
}