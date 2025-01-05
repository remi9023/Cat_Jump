using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 마찬가지로 로드씬을 사용하는데 필요함

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    public float jumpForce = 500f;
    public float moveSpeed = 30f;
    public float maxMoveSpeed = 2.0f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>(); //this 빼도 괜찮을듯
        anim = GetComponent<Animator>(); // 애님은 에니메이터를 가져온다 겟 컴포넌트를 활용해서
     
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space)&& rigid2D.velocity.Equals(0)) //Y축 속도가 0일때만 점프가 가능하게
        {
            this.rigid2D.AddForce(transform.up*this.jumpForce);//업 방향으로 포스만큼 곱하기
            print("점프!");
        }   
        //좌우 이동
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = 1;

        //플레이어 속도
        float speedX = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한

          if (speedX < moveSpeed)
        {
            rigid2D.AddForce(transform.right*key*moveSpeed);
        }


        //이미지 반전
        if (key != 0)
        {
            transform.localScale = new Vector3 (key,1,1);
        }

        //애니메이션 속도 (플레이어 속도에 따라)
        anim.speed = speedX / 2.0f;
        
        //플레이어가 화면밖으로 나가면 처음부터.
        if(transform.position.y<-10)
        {
            SceneManager.LoadScene("GameScene");
        }
        if (transform.position.x < -3 || transform.position.x>3)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("골인");
        SceneManager.LoadScene("ClearScene");
    }
}
