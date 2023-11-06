using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using SysNum = System.Numerics;
using UniEn = UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed; 
    public Rigidbody2D rb;
    public Rigidbody2D rb_g;
    Vector2 movement;
    private bool running = false;
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float RunCost;
    public float ChrageRate;
    private Coroutine rechagre;
    public Camera cam;
    Vector2 mousePos;
    public GameObject Gun;
    public WeaponController weapon;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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

        if(running && (direction.x != 0 || direction.y != 0))
        {
            speed = 6f;
            Stamina -= RunCost * Time.deltaTime;
            if(Stamina < 0){Stamina = 0; running = false;}
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if(rechagre != null) StopCoroutine(rechagre);
            rechagre = StartCoroutine(RechargeStamina());
        }
        else{speed = 3f;}

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //else if(Gun.transform.rotation.z < 90){
        //    Gun.transform.localScale = new Vector3(1, 1, 1);
        //}

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(10);
        }
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(2f);

        while(Stamina < MaxStamina)
        {
            Stamina += ChrageRate / 10f;
            if(Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
