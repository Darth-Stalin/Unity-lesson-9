using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exposion : MonoBehaviour
{
    public float Radius;
    public float Force;
    public AudioSource aus;
    public GameObject particalExplosion;
    public GameObject textureExplosion;
    public Transform transTexture;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Explos();
        }
    }

    public void Explos()
        {
            ExplosForce();
            aus.Play();
            Destroy(gameObject);
            Instantiate(particalExplosion, transform.position, transform.rotation); //создаем частицы взрыва
            Instantiate(textureExplosion, transTexture.position, transform.rotation); //создаеи текстуры взрыва
        }

    public void ExplosForce()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, Radius); //радиус проверки взрыва
        foreach (Collider hit in col)
        {
            Rigidbody rg = hit.GetComponent<Rigidbody>(); //задаем переменную компонента rigibody
            if(rg)
            {
                rg.AddExplosionForce(Force, transform.position, Radius, 3f); // для всех в заданном радиусе с ribody приеняется сила
            }
        }
    }
    
}
