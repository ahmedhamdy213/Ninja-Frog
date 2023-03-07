using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedoffire : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float distance;
    public int damage;
    public LayerMask WhatIsSoild;
    public GameObject DesrtoyEffect;

    private void Start()
    {
        Invoke("DestroyProjecTile", LifeTime);
    }
   


    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.up, distance, WhatIsSoild);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("ENEMY MUST TAKE DAMAGE!");
                hitInfo.collider.GetComponent<BossHealth>().TakeDamage(damage);
            }
            DestroyProjecTile();
        }
        transform.Translate(transform.up*Speed*Time.deltaTime);
    }
    void DestroyProjecTile()
    {
    
        Instantiate(DesrtoyEffect, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
