using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inputLeft;
    public bool inputRight;
    public bool inputJump;
    public bool inputShoot;
    public bool canJump=true;
    public float jumpTime;
    public float speed_Background=5.0f;
    public Text RemainingTime;
    float timer;
    string currentEvent;
    public int MHP;
    //public Image myImage;
    //public float currentTime;
    void Start()
    {
        canJump = true;
        jumpTime=0;
        timer=0;
        //GameObject.Find("MentalHealth").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Lifes/Life5") as Sprite;
        currentEvent="중간고사";
        MHP=6;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(!inputJump&& !Input.GetKey(KeyCode.UpArrow))
        {
            if(jumpTime > 0.03f) canJump=true;
        }
        else jumpTime=0;
        
        //currentTime+=Time.deltaTime;
        jumpTime+=Time.deltaTime;

        RemainingTime.text=currentEvent+" "+(60-(int)timer)+"일 전";
    }
    public void LeftDown(){ inputLeft=true; }
    public void LeftUp() { inputLeft = false; }
    public void RightDown() { inputRight = true; }
    public void RightUp() { inputRight = false; }
    public void JumpDown() { inputJump = true; }
    public void JumpUp()
    {
        inputJump = false;
        jumpTime=0; 
        Debug.Log("dd");
    }
    public void ShootDown() { inputShoot = true; }
    public void ShootUp() { inputShoot = false; }
    public void MHP_Display()
    {
        GameObject.Find("MentalHealth").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lifes/Life"+MHP) as Sprite;
    }
    public void MHP_Change(int num)
    {
        MHP+=num;
    }
}
