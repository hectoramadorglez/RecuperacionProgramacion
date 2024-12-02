using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] private float velocidad;
    [SerializeField] public float danho;
    private Transform destinoActual;
     private SpriteRenderer  SpriteRenderer;
    void Start()
    {
        destinoActual = puntoB;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position, destinoActual.position, velocidad * Time.deltaTime);
       
        
            
        if( transform.position == puntoA.position) 
        {
            SpriteRenderer.flipX = true;
                destinoActual = puntoB;
        
        }
        
        if(transform.position == puntoB.position) 
        {
            SpriteRenderer.flipX = false;
            destinoActual = puntoA;

        }
         
       
        
        
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player") ) 
        {
            collision.gameObject.GetComponent<Player>().RecibirDanho(danho); 
        
        }
    }
}
