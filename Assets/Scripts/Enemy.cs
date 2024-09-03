using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int speed;
    [SerializeField] int damage;

    private void Start()
    {
        Quaternion rotation = Quaternion.LookRotation
            (GameManager.Instance.generator.transform.position - transform.position, transform.TransformDirection(Vector3.back));

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        //for spe Enemy check distance relative to generator if reach rnd a point in same spawn y or x (or check wich border is closer)
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Generator")
        {
            collision.GetComponent<Generator>().ChangeLife(-damage);
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
