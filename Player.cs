using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 10;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private BoxCollider2D _boxcollider;

    private bool isGrounded = true;
    [SerializeField] private LayerMask GroundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxcollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        Vector3 characterScale = transform.localScale;
        if (movement > 0)
            characterScale.x = 5;
        else if (movement < 0)
            characterScale.x = -5;

        if(isGrounded)
            transform.localScale = characterScale;


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            _animator.SetBool("isWalking", true);
        else
            _animator.SetBool("isWalking", false);

        isGrounded = GroundCheck();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _animator.SetBool("isJumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }
        else if (isGrounded)
            _animator.SetBool("isJumping", false);
    }

    private bool GroundCheck()
    {
        float extraSpace = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_boxcollider.bounds.center, Vector2.down, _boxcollider.bounds.extents.y + extraSpace, GroundLayerMask);

        //Debug.DrawRay(_boxcollider.bounds.center, Vector2.down * (_boxcollider.bounds.extents.y + extraSpace));
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}
