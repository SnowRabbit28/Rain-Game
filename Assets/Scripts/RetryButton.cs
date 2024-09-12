using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
   //게임을 다시 시작하는것은 MainScene를 다시 불러주면 된다!!
   //Scene를 불러오기 위해서는..패키지하나, 함수하나를 추기한다.

    public void Retry()
    {
        //Scene을 불러오기 위해서는 Scene Management (패키지) 에 있는
        //scene manager을 이용해야한다. scene를 가져올땐 get이 아니라 load라고 해야한다.
        SceneManager.LoadScene("MainScene"); 
    }
}
