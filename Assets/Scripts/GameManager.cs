using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Prefabs는 일종의 GameObject이기 때문에
    public GameObject rain;
    public GameObject endPanel;

    //나 하나밖에 없다!! 그래서 여러 친구들이 나를 접근해줘야한다! 라는 의미의 함수 작성
    public static GameManager instance;
    //Text고 전체점수를 가져올거라 변수이름은 이렇게 설정
    public Text totalScoreTxt;
    //전체 타이머 시간 30초, 자료형은 실수
    float totalTime = 30.0f;
    //시간을 가져오기위해 변수설정, Text로 지정
    public Text timeTxt;

    //전체점수 변수
    int totalScore;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)
        {
            //기기마다 프레임차이가 있듯 시간도 차이가 있다고 한다.
            //그래서 프레임 대비로 시간이 줄어들게 맞추는것을 deltaTime이라고 한다.
            //그래서 전체시간 30에서 지속적으로 deltaTime을 빼주어야한다.
            totalTime -= Time.deltaTime; // 굳이 숫자를 넣지않아도 된다.
        }
        else
        {
            //시간의 크기를 0으로 만들어준다 라는 뜻
            //즉, 다음프레임과 지금 프레임의 차이가 없다는 뜻, 크기가 0이기 때문
            //그래서 시간이 멈춘것처럼 표현이 가능!
            Time.timeScale = 0f; //미세한 오차가 발생할 수 있음, 표현만 하는거라
            totalTime = 0f; // 그래서 시간도 0으로 맞춘다.
            endPanel.SetActive(true); //활성화를 세팅 해주겠다!, 게임오브젝트를 켜주겠다! 라는 뜻
        }

        //text컴포넌트 안에 있는 text에다가 토탈타임이라는 숫자데이터를 문자열로 넣어준다.
        timeTxt.text = totalTime.ToString("N2");
    }

    // 함수란, 반복적으로 실행되는 로직을 하나로 묶어놓은 단위
    // 우리는 이 작업을 반복적으로 수행할 것이기 때문에 함수를 만들어 놓는다.
    void MakeRain()
    {
        //( 게임오브젝트를) 생성하는 함수
        Instantiate(rain);
    }

    public void AddScore(int score) // 괄호 안에 있는 친구는 매개변수이다.
                                    // 나중에 AddScore를 사용할건데 그때 쓸 변수를 미리 넣어둬서
                                    // 여기에 데이터가 있어요 이거 쓸거에요! 라고 알려준다고 생각하자.
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        

    }
}
