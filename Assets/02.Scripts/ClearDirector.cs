using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �ε� ���� ����ϴµ� �ʿ��� ���ӽ����̽�

public class ClearDirector : MonoBehaviour
{
 
  
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
