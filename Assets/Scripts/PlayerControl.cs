using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    int horMove;
    float speed=7.5f;
    bool isJumping;
    bool isShooting;
    Rigidbody2D rbody;
    float jumpPower=20.0f;
    float flashPower=7.5f; 
    public int jumpCount;
    int flash_direction;
    //결국 입력이 들어온건지 확인
    bool left; 
    bool right;
    bool jump;
    bool shoot;
    float invinTime;
    Color alpha;
    float shootingTime;
    public GameObject prefab;
    public Button Btn;  
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        jumpCount = 2;
        invinTime=1;
        shootingTime=1;
    }

    // Update is called once per frame
    void Update()
    {
        left=false;
        right=false;
        jump=false;
        shoot=false;
        horMove = 0;
        if (GameObject.Find("GameManager").GetComponent<GM1>().inputLeft ||Input.GetKey(KeyCode.LeftArrow)) left=true;
        if (GameObject.Find("GameManager").GetComponent<GM1>().inputRight || Input.GetKey(KeyCode.RightArrow)) right=true;
        if(GameObject.Find("GameManager").GetComponent<GM1>().inputJump  || Input.GetKey(KeyCode.UpArrow)) jump=true;
        if (GameObject.Find("GameManager").GetComponent<GM1>().inputShoot || Input.GetKey(KeyCode.Space)) shoot = true;
        if (left) horMove--;
        if(right) horMove++;
        if(jump) isJumping=true;
        if(shoot) isShooting=true;
        invinTime+=Time.deltaTime;
        alpha= GameObject.Find("Student").GetComponent<SpriteRenderer>().color;
        if (invinTime>1) alpha.a=1;
        else alpha.a=0.5f;
        GameObject.Find("Student").GetComponent<SpriteRenderer>().color = alpha;
        shootingTime+=Time.deltaTime;
        if(shootingTime>1) Btn.interactable=true;
        else Btn.interactable=false;
    }
    void FixedUpdate()
    {
        Run();
        Jump();
        Shoot();
    }
    void Run ()
    {
        this.transform.Translate(horMove * Time.deltaTime * speed, 0, 0);
        if(jumpCount==0&&horMove*flash_direction==-1) rbody.AddForce(Vector3.right *Time.deltaTime*speed*5 * horMove, ForceMode2D.Impulse);
        if(this.transform.position.x>8.5f) this.transform.position=new Vector3(8.5f, transform.position.y, transform.position.z);
        if (this.transform.position.x < -8.5f) this.transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);

    }
    void Jump()
    {
        if(jumpCount<1||!isJumping||!GameObject.Find("GameManager").GetComponent<GM1>().canJump)
        {
            isJumping=false;
            return;
        }
        rbody.velocity=new Vector2(0.0f, 0.0f);
        flash_direction = 0;
        if (jumpCount==2||horMove==0) rbody.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        else
        {
            rbody.AddForce(Vector3.right * flashPower*horMove, ForceMode2D.Impulse);
            rbody.AddForce(Vector3.up * jumpPower*0.7f, ForceMode2D.Impulse);
            flash_direction=horMove;
        }
        jumpCount--;
        isJumping=false;
        GameObject.Find("GameManager").GetComponent<GM1>().canJump = false;
        GameObject.Find("GameManager").GetComponent<GM1>().jumpTime = 0;
    }
    void Shoot()
    {
        if(!isShooting||shootingTime<1)
        {
            isShooting=false;
            return ;
        }
        Debug.Log("발사");
        shootingTime=0;
        GameObject.Find("BulletLocation").GetComponent<Main_Bullet>().NewShoot(this.transform.position.x,this.transform.position.y,this.transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Floor")
        {
            jumpCount=2;
            GameObject.Find("GameManager").GetComponent<GM1>().jumpTime=99;
            rbody.velocity = new Vector2(0.0f, 0.0f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")&&invinTime>1)
        {
            GameObject.Find("GameManager").GetComponent<GM1>().MHP_Change(-1);
            GameObject.Find("GameManager").GetComponent<GM1>().MHP_Display();
            invinTime=0;

        }
    }
}
