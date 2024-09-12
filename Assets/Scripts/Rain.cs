using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    /* 기본적인 사이즈와 스코어 변수선언 */
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer; // 이친구는 변수를 선언해서 만들어줘야한다.

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        
        /* 값 추출하기 */
        float x = Random.Range(-2.4f, 2.4f); // x값 범위를 적고, 변수 x를 생성한다.
        float y = Random.Range(3f, 5f); // y값 범위를 적고, 변수 y를 생성한다.

        /* 추출값을 벡터에 넣어주기*/
        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4); //여기는 type1,2,3인 정수이기 때문에 int를 사용한다.
                                       //4라고 쓴 이유는 최댓값은 숫자 -1값까지만 범위에 포함된다. 1,3 으로 쓰면 1,2 만되기때문에
                                       //1,4 라고 써야지만 1,2,3이 된다.

        if (type == 1)
        {   
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100/255f, 100/255f, 1f, 1f);
            //색은 f 값으로 들어가고 최댓값으로 나누어주어야한다.
            //유니티에서는 150을 하드코딩했지만, 여기서는 255로 나누어줘야한다.
        }
        else if (type == 2) // else if를 해주지 않고 다 따로따로 if문을 만들면 별개기 때문에 하나씩 다 검사하게 된다.
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        } 
        else if (type == 3) 
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }

        /* 이 사이즈가 로컬스케일에 들어간다. */
        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 태그를 달아준 곳에서 만 동작하도록 실행한다.
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            //게임메니저에 아까 만든 instance 라는 변수를 통해 가져오고 거기에있는 add로 score를 가져온다.
            //GameManger AddScore에 가보면 public로 선언했다. 외부에서 가져올 수 있다는 뜻을 가지고있다.
            //public를 쓰지 않거나 private로 쓰면 접근이 안된다. MakeRain은 가져올 수 없다.
            GameManager.instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}