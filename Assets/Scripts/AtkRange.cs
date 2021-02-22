using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRange : Token
{
    //攻撃時間
    const float ATK_TIMER = 1;

    float _tAtk = 1;
    public Sprite atkR;
    bool _isDmg = false;
    public bool IsDmg;
    // Start is called before the first frame update
    void Start()
    {
        atkR = Resources.Load<Sprite>("Sprites/UI/SelUIR");
        NonVisible();
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
        SetSprite(atkR);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        _isDmg = IsDmg;
        if(_isDmg);
        //味方の攻撃範囲内いる時
        if (other.gameObject.tag == "Enemy"||other.gameObject.tag == "Boss")
        {
            RaycastHit2D[] allHit = Physics2D.BoxCastAll(transform.position, new Vector2(3, 1), 0, Vector2.zero);
            _tAtk -= Time.deltaTime;
            if (_tAtk < 0)
            {
                if(allHit.Length >= 2){
                    for(int i = allHit.Length;i > 0 ;i --){
                        if(allHit[i -1].collider.gameObject.tag == "Enemy"){
                        allHit[i -1].collider.gameObject.GetComponent<Enemy>().Damage(1);
                        _tAtk = ATK_TIMER;
                        return;
                        }
                        if(allHit[i -1].collider.gameObject.tag == "Boss"){
                        allHit[i -1].collider.gameObject.GetComponent<Boss>().Damage(1);
                        _tAtk = ATK_TIMER;
                        return;
                        }

                    }

                }
                else
                {
                    other.gameObject.GetComponent<Enemy>().Damage(3);
                }
                 _tAtk = ATK_TIMER;
            }

        }

    }

}
