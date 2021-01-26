using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float movimentox, movimentoz; //Varia
    public Vector3 movimento;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movimentox = Input.GetAxis("Horizontal");
        movimentoz = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        movimento = new Vector3(movimentox, 0, movimentoz);
        
    }
}
