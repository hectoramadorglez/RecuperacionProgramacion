using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Transform pies;
    [SerializeField]private float radio;
    [SerializeField] public float vida;
    [SerializeField]private LayerMask layerMask;
    [SerializeField] private int fuerzaMovimiento;
    [SerializeField] private int fuerzaSalto;
    [SerializeField] private Rigidbody2D rb;

    private int hInput;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        // hInput = Input.GetAxisRaw("Horizontal");
        if (hInput !=0) 
        {
            anim.SetBool("correr", true);
        
        }
        else 
        {
            anim.SetBool("correr", false);

        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && Ensuelo() == true) 
        {
           rb.AddForce(new Vector2(0, 1) * fuerzaSalto, ForceMode2D.Impulse);
        }
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(hInput,1) * fuerzaMovimiento, ForceMode2D.Force);
    }
    private bool Ensuelo() 
    {
       Collider2D Resultado = Physics2D.OverlapCircle(pies.transform.position, radio,layerMask);

        if (Resultado != null) 
        {
            return true;
        
        }
        else 
        { 
            return false;
        
        }

    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pies.transform.position, radio);    
    }
    void RecibirDanho(float danho) 
    {
        vida -= danho;
       

    }
}
