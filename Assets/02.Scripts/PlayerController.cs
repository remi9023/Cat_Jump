using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���������� �ε���� ����ϴµ� �ʿ���

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
        this.rigid2D = GetComponent<Rigidbody2D>(); //this ���� ��������
        anim = GetComponent<Animator>(); // �ִ��� ���ϸ����͸� �����´� �� ������Ʈ�� Ȱ���ؼ�
     
    }

    // Update is called once per frame
    void Update()
    {
        //����
        if (Input.GetKeyDown(KeyCode.Space)&& rigid2D.velocity.Equals(0)) //Y�� �ӵ��� 0�϶��� ������ �����ϰ�
        {
            this.rigid2D.AddForce(transform.up*this.jumpForce);//�� �������� ������ŭ ���ϱ�
            print("����!");
        }   
        //�¿� �̵�
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = 1;

        //�÷��̾� �ӵ�
        float speedX = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����

          if (speedX < moveSpeed)
        {
            rigid2D.AddForce(transform.right*key*moveSpeed);
        }


        //�̹��� ����
        if (key != 0)
        {
            transform.localScale = new Vector3 (key,1,1);
        }

        //�ִϸ��̼� �ӵ� (�÷��̾� �ӵ��� ����)
        anim.speed = speedX / 2.0f;
        
        //�÷��̾ ȭ������� ������ ó������.
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
        print("����");
        SceneManager.LoadScene("ClearScene");
    }
}
