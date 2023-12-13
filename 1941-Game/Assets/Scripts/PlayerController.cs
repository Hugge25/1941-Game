using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : Entity
{

    public GameObject Kar98k;
    public GameObject AK47;
    private float speed;

    private float maxStamina = 100;
    private float currentStamina; 
    public Rigidbody2D rb;
    Rigidbody2D rb_g;

    public HingeJoint2D gunhinge;
    Vector2 movement;
    private bool running = false;
    public Camera cam;
    Vector2 mousePos;
    GameObject Gun;
    //public WeaponController weapon;
    //public HealthBar healthBar;
    private float timer;
    private float nextAction = 0f;
    private float period = 0.5f;



    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb_g.rotation = angle;

        
        //if(angle < 89 && angle > -89) {
          //  Gun.transform.localScale = new Vector3(1, 1, 1);
        //}
        //else{
         //   Gun.transform.localScale = new Vector3(1, -1, 1);
       // }
    } 
    void Update() // Update is called once per frame
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Kar98k.SetActive(true);
            AK47.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Kar98k.SetActive(false);
            AK47.SetActive(true);
        }

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
                currentStamina -= 10 * Time.deltaTime;
            }
        }
        else
        {
            speed = 3f;
            currentStamina += 5 * Time.deltaTime;
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //else if(Gun.transform.rotation.z < 90){
        //    Gun.transform.localScale = new Vector3(1, 1, 1);
        //}

        currentHealth = Mathf.Clamp(currentHealth, -1, maxHealth);
        currentStamina = Mathf.Clamp(currentStamina, -1, maxStamina);

        //if(Input.GetMouseButtonDown(0))
        //{
            //weapon.Fire();
        //}

        if(Input.GetKeyDown(KeyCode.Space)){
            currentHealth -= 10;
        }
        Vector3 newCameraPos = rb.transform.position;
        newCameraPos.z = cam.transform.position.z;
        cam.transform.position = newCameraPos;

        if(currentHealth <= 0){
            SceneManager.LoadScene(5);
        }
    }

    public Vector2 GetHealth()
    {
        return new Vector2(currentHealth, maxHealth);
    }

    public void UpdateGunRB(Rigidbody2D gunrigidbody, GameObject gun)
    {
        rb_g = gunrigidbody;
        gunhinge.connectedBody = gunrigidbody;
        Gun = gun;
    }

    /// <summary>
    /// X is current 
    /// Y is maximum
    /// </summary>
    /// <returns></returns>
    public Vector2 GetStamina()
    {
        return new Vector2(currentStamina, maxStamina);
    }

}
