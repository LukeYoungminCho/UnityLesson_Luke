using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string ownerTag;

    public float speed = 0.5f;
    public float lifeTime = 3f;
    public float damage = 100;

    private void Awake()
    {
        StartCoroutine(CheckLife());
    }
    IEnumerator CheckLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime; // 상대좌표
        //transform.position += Vector3.right * speed * Time.deltaTime; // 절대좌표
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if ( collision.gameObject.tag == ownerTag)
            return;

        Charactor targetScript = collision.gameObject.GetComponent<Charactor>();

        if (targetScript != null)
        {
            targetScript.Hitted(this);
            Destroy(gameObject);
        }
    }
}
