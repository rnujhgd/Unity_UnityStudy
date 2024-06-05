using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float movePower = 10f;
    public int NextMove = 0; 
    Rigidbody2D rd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Invoke("nextMove", 2);
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }
    void Move() {
        rd.velocity = new Vector2(movePower * NextMove, rd.velocity.y);
        Vector2 front = new Vector2(rd.position.x + 1f * NextMove, rd.position.y);
        Debug.DrawRay(front, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycastHit2D = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if(!raycastHit2D) {
            NextMove = NextMove * -1;

        }
    }
    void nextMove() {
        NextMove = Random.Range(-1, 2);
        Invoke("nextMove", 2);
        
    }
}
