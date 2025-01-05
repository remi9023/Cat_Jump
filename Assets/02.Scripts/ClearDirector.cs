using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 로드 씬을 사용하는데 필요한 네임스페이스

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
