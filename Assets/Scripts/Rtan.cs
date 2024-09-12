using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour // 하나의스크립트 안에는 하나의 클래스가 있다.
{
    float direction = 0.05f; // 변수 설정, 변수는 맨 위에 쓰세요!  밑에 벡터에서 반복적으로 빼준다..!!

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 프레임을 60으로 고정한다.
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       //외부입력 장치는 Input으로 시작한다. ( 대문자 주의 )
        if (Input.GetMouseButtonDown(0)) // 클릭 했을때! , 0 은 왼쪽버튼 1은 오른쪽 버튼
        {
            direction *= -1; // *곱해서 넣는다는 뜻, 즉 음수는 양수가 되고 양수는 음수가 된다. 
            renderer.flipX = !renderer.flipX;//앞에 느낌표를 통해 반대 라는 뜻을 가지게 된다. 그래서 반대값이 들어가게 된다.
        }


        /*오른쪽 벽에 닿으면 dir을 - , 왼쪽에 닿으면 dir +로 바뀌는 조건문 작성*/

        if(transform.position.x > 2.6f) // 만약에 르탄hier에서 insp안에 trans 안에 position 에서 x값 이라는 뜻 
        {                               // 2.6보다 숫자가 커지면= 오른쪽 벽에 닿으면
            renderer.flipX = true;  //왼쪽으로 얼굴을 돌려주고
            direction = - 0.05f;    //왼쪽으로 조금씩 이동하라
        }
        if (transform.position.x < -2.6f) // .은 안으로 들어간다라는 의미
        {                                 // -2.6보다 작아지면 = 왼쪽 벽에 닿으면
            renderer.flipX = false; //오른쪽으로 얼굴을 돌리고
            direction = 0.05f;      //오른쪽으로 조금씩 이동해라
        }

        transform.position += Vector3.right * direction ; //f는 소수점자리이다. 1 * 0.05, 0 * 0.05, 0 * 0.05 
            // transform.position.x 는 쓸 수 없다. x를 우리가 따로 값을 넣을수 없기 때문이다.
            // position 자체가 값을 하나하나 넣어주는 친구가 아닌것이다. 
            // 그래서 벡터를 이용해서 x y z 값을 하나하나 넣어준다. transform.position += new Vector3(1f,0,0);
            // Vector을 괄호열고 굉장히 불편하니까 쉽게 쓴 것이 위에 이다.
        
    }
}
