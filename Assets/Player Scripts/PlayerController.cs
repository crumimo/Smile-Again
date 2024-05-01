using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //public float jumpForce;
    private float moveInput;
    
    public KeyCode[] jumpKeys = { KeyCode.Space, KeyCode.W, KeyCode.UpArrow };

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    private bool isRunning = false;
    private float accelerationTimer;
    private float tirednessTimer;
    public float maxRunTime = 10f; 
    private float currentRunTime;
    public float runSpeed;
    public float tirednessDuration = 5f;
    public float accelerationDuration = 3f;

    private Animator anim;

    private InventoryManager inventoryManager;
    
    public GameObject canvas;

   // public VectorValue pos;
    

    private void Start()
    {
        //transform.position = pos.initialValue;
        inventoryManager = InventoryManager.Instance;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    

    private void FixedUpdate()
    {
        
        moveInput = Input.GetAxis("Horizontal");
        
        if (isRunning && tirednessTimer <= 0f)
        {
            float currentSpeed = isRunning ? runSpeed : speed;
            rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);
            currentRunTime += Time.deltaTime;
            
            
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        
        if (currentRunTime >= maxRunTime)
        {
            StopRunning();
            currentRunTime = 0f;
        }

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCanvas();
        }
        
        
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        CheckRunInput();
        
        
            //if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                //rb.velocity = new Vector2(rb.velocity.x, 0f);
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
            }
        
        
        UpdateTimers();
        

        if (rb.velocity.x != 0 && isRunning)
        {
            SetBoolean("isRunning", true);
        }
        else if (rb.velocity.x != 0 && !isRunning )
        {
            //anim.SetTrigger("Walking");
            SetBoolean("isWalking", true);
        }
        else if (!isGrounded)
        {
            SetBoolean("isJumping", true);   
        }
        else
        {
            //anim.SetTrigger("Idle");
            SetBoolean("isIdle", true);
        }
    }
    
    private void ToggleCanvas()
    {
        // Проверяем наличие ссылки на менеджер инвентаря и его канву
        if (inventoryManager != null && inventoryManager.inventoryCanvas != null)
        {
            // Активируем/деактивируем канву инвентаря
            inventoryManager.ToggleInventory();
        }
        else
        {
            Debug.LogWarning("Canvas object is null.");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    void CheckRunInput()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) && !isRunning && tirednessTimer <= 0f)
        {
            StartRunning();
            
        }

        if (!Input.GetKey(KeyCode.LeftShift) && isRunning)
        {
            StopRunning();
            currentRunTime = 0f;
            
        }
    }

    
    void StartRunning()
    {
        isRunning = true;
        accelerationTimer = 0f;
        
    }

    void StopRunning()
    {
        isRunning = false;
        tirednessTimer = tirednessDuration;
    }

    
    void UpdateTimers()
    {
        if (isRunning)
        {
            if (accelerationTimer < accelerationDuration)
            {
                accelerationTimer += Time.deltaTime;
            }
            else
            {
                StopRunning(); 
            }
        }

        if (tirednessTimer > 0f)
        {
            tirednessTimer -= Time.deltaTime;
        }
    }

    

    private void SetBoolean(string animName, bool setBool)
    {
        foreach (var param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Bool)
            {
                anim.SetBool(param.name, false);
            }
            if (param.name == animName)
            {
                anim.SetBool(param.name, setBool);
            }
        }
    }
}
