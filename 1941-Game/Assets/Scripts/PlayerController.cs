using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float speed; 
    public Rigidbody2D rb;
    public Rigidbody2D rb_g;
    Vector2 movement;
    private bool running = false;
    private int maxStamina = 100;
    private float currentStamina;
    public Camera cam;
    Vector2 mousePos;
    public GameObject Gun;
    public WeaponController weapon;
    //public HealthBar healthBar;
    private int maxHealth = 100;
    private int currentHealth;

    bool canRechangeStamina;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        canRechangeStamina = true;
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb_g.rotation = angle;

        
        if(angle < 89 && angle > -89) {
            Gun.transform.localScale = new Vector3(1, 1, 1);
        }
        else{
            Gun.transform.localScale = new Vector3(1, -1, 1);
        }
    } 
    void Update() // Update is called once per frame
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetKeyDown("left shift"))
        {
            running = true;
        }
        else if(Input.GetKeyUp("left shift"))
        {
            running = false;
        }

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        if(running && currentStamina > 0)
        {
            speed = 6f;
            if((direction.x != 0 || direction.y != 0))
            {
                currentStamina -= (Time.deltaTime);
                canRechangeStamina = false;
            }
        }
        else
        {
           speed = 3f;
        
           if(!canRechangeStamina)
           {
               StartCoroutine(RechargeStamina());
           }
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //else if(Gun.transform.rotation.z < 90){
        //    Gun.transform.localScale = new Vector3(1, 1, 1);
        //}

        currentHealth = Mathf.Clamp(currentHealth, -1, maxHealth);
        currentStamina = Mathf.Clamp(currentStamina, -1, maxStamina);

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(10);
        }
        Vector3 newCameraPos = rb.transform.position;
        newCameraPos.z = cam.transform.position.z;
        cam.transform.position = newCameraPos;
    }
    private IEnumerator RechargeStamina()
    {
            yield return new WaitForSeconds(2f);
            canRechangeStamina = true;
            //while(currentStamina < maxStamina)
            //{
               //yield return new WaitForSeconds(.1f);
               //currentStamina += (Time.deltaTime);
            //}
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public Vector2 GetHealth()
    {
        return new Vector2(currentHealth, maxHealth);
    }

    void StaminaDrain(int cost)
    {
        currentStamina -= cost;

        
    }

    void StaminaRecharge(int charge)
    {

    }

    public Vector2 GetStamina()
    {
        return new Vector2(currentStamina, maxStamina);
    }
}
