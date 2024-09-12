using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    /* �⺻���� ������� ���ھ� �������� */
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer; // ��ģ���� ������ �����ؼ� ���������Ѵ�.

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        
        /* �� �����ϱ� */
        float x = Random.Range(-2.4f, 2.4f); // x�� ������ ����, ���� x�� �����Ѵ�.
        float y = Random.Range(3f, 5f); // y�� ������ ����, ���� y�� �����Ѵ�.

        /* ���Ⱚ�� ���Ϳ� �־��ֱ�*/
        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4); //����� type1,2,3�� �����̱� ������ int�� ����Ѵ�.
                                       //4��� �� ������ �ִ��� ���� -1�������� ������ ���Եȴ�. 1,3 ���� ���� 1,2 ���Ǳ⶧����
                                       //1,4 ��� ������� 1,2,3�� �ȴ�.

        if (type == 1)
        {   
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100/255f, 100/255f, 1f, 1f);
            //���� f ������ ���� �ִ����� �������־���Ѵ�.
            //����Ƽ������ 150�� �ϵ��ڵ�������, ���⼭�� 255�� ����������Ѵ�.
        }
        else if (type == 2) // else if�� ������ �ʰ� �� ���ε��� if���� ����� ������ ������ �ϳ��� �� �˻��ϰ� �ȴ�.
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

        /* �� ����� ���ý����Ͽ� ����. */
        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �±׸� �޾��� ������ �� �����ϵ��� �����Ѵ�.
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            //���Ӹ޴����� �Ʊ� ���� instance ��� ������ ���� �������� �ű⿡�ִ� add�� score�� �����´�.
            //GameManger AddScore�� ������ public�� �����ߴ�. �ܺο��� ������ �� �ִٴ� ���� �������ִ�.
            //public�� ���� �ʰų� private�� ���� ������ �ȵȴ�. MakeRain�� ������ �� ����.
            GameManager.instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}