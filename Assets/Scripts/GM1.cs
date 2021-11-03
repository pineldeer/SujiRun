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
    public int[] order=new int[14];
    //public float[] scores= new float[10]{ 0,};
    int[] between = new int[20];
    int[] sumtween = new int[20];
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

        for(int i=0;i<7;i++)
        {
            order[i*2]=i;
            order[i*2+1]=i;
        }
        for(int i=0;i<13;i++) between[i]=1;
        for(int i=0;i<32;i++) between[Random.Range(0,13)]++;
        sumtween[0]=5;
        for(int i=0;i<13;i++) sumtween[i+1]=sumtween[i]+between[i];
        //for(int i=0;i<14;i++) Debug.Log(sumtween[i]);
        for(int i=0;i<13;i++)
        {
            int temp;
            int target=Random.Range(i,14);
            temp=order[target];
            order[target]=order[i];
            order[i]=temp;
        }
        for (int i = 0; i < 14; i++) Debug.Log(order [i]);
        for(int i=0;i<14;i++) Invoke("SummP",sumtween[i]);
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
    void SummP()
    {
        GameObject.Find("PerformanceLocation").GetComponent<Main_Performance>().Summon_Per();
    }
}
