using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer mySR;
    Rigidbody2D myRB2D;
    public InputSystem inputs;
    public bool IsInColor = false;
    public float velocityPlayer = 1;
    public float jumpInpulse = 1;
    public int maxJumps = 2;
    public LayerMask myLayers;
    [SerializeField] private int saltos = 0;
    private void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        myRB2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MovePlayer();
        OnValidateJump();
    }
    public void JumpPlayer()
    {
        if (saltos > 0)
        {
            myRB2D.AddForce(Vector2.up * jumpInpulse, ForceMode2D.Impulse);
            saltos -= 1;
        }
    }
    public void UpdateColor(int ColorIndex)
    {
        if(IsInColor == false)
        {
            switch (ColorIndex)
            {
                case 0:
                    mySR.color = Color.red;
                    break;
                case 1:
                    mySR.color = Color.green;
                    break;
                case 2:
                    mySR.color = Color.blue;
                    break;
            }
        }
    }
    private void MovePlayer()
    {
        transform.position = new Vector3(transform.position.x + (velocityPlayer * inputs.GetAxis() * Time.deltaTime), transform.position.y, transform.position.z);
    }
    private void OnValidateJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.75f, myLayers);
        Debug.DrawRay(transform.position, Vector2.down * 0.75f, Color.green);

        if (hit.collider != null)
        {
            saltos = maxJumps;
        }
    }
}
