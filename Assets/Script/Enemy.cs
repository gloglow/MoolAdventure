using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Monster monster;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        gameObject.layer = 9;

        monster = GetComponent<Monster>();
        monster.defaultLayer = 9;
        monster.nonTargettedLayer = 10;
        foreach(Attack atk in monster.monsterAtkPtns)
        {
            atk.gameObject.layer = 12;
            atk.gameObject.tag = "EnemyAtk";
        }
        monster.targetTag = "Player";
    }

    protected void OnTriggerEnter(Collider other)
    {
        //　プレイヤーに攻撃されたら
        if (other.tag == "PlayerAtk")
        {
            Weapon weapon = other.GetComponent<Weapon>();

            //　ダメージを受ける
            //　攻撃された反対方向のベクトル
            Vector3 reactVec = transform.position - other.transform.position;
            monster.Damaged(weapon.damage * (-1), reactVec);
        }
    }
}
