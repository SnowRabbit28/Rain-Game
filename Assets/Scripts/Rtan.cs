using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour // �ϳ��ǽ�ũ��Ʈ �ȿ��� �ϳ��� Ŭ������ �ִ�.
{
    float direction = 0.05f; // ���� ����, ������ �� ���� ������!  �ؿ� ���Ϳ��� �ݺ������� ���ش�..!!

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // �������� 60���� �����Ѵ�.
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {       //�ܺ��Է� ��ġ�� Input���� �����Ѵ�. ( �빮�� ���� )
        if (Input.GetMouseButtonDown(0)) // Ŭ�� ������! , 0 �� ���ʹ�ư 1�� ������ ��ư
        {
            direction *= -1; // *���ؼ� �ִ´ٴ� ��, �� ������ ����� �ǰ� ����� ������ �ȴ�. 
            renderer.flipX = !renderer.flipX;//�տ� ����ǥ�� ���� �ݴ� ��� ���� ������ �ȴ�. �׷��� �ݴ밪�� ���� �ȴ�.
        }


        /*������ ���� ������ dir�� - , ���ʿ� ������ dir +�� �ٲ�� ���ǹ� �ۼ�*/

        if(transform.position.x > 2.6f) // ���࿡ ��źhier���� insp�ȿ� trans �ȿ� position ���� x�� �̶�� �� 
        {                               // 2.6���� ���ڰ� Ŀ����= ������ ���� ������
            renderer.flipX = true;  //�������� ���� �����ְ�
            direction = - 0.05f;    //�������� ���ݾ� �̵��϶�
        }
        if (transform.position.x < -2.6f) // .�� ������ ���ٶ�� �ǹ�
        {                                 // -2.6���� �۾����� = ���� ���� ������
            renderer.flipX = false; //���������� ���� ������
            direction = 0.05f;      //���������� ���ݾ� �̵��ض�
        }

        transform.position += Vector3.right * direction ; //f�� �Ҽ����ڸ��̴�. 1 * 0.05, 0 * 0.05, 0 * 0.05 
            // transform.position.x �� �� �� ����. x�� �츮�� ���� ���� ������ ���� �����̴�.
            // position ��ü�� ���� �ϳ��ϳ� �־��ִ� ģ���� �ƴѰ��̴�. 
            // �׷��� ���͸� �̿��ؼ� x y z ���� �ϳ��ϳ� �־��ش�. transform.position += new Vector3(1f,0,0);
            // Vector�� ��ȣ���� ������ �����ϴϱ� ���� �� ���� ���� �̴�.
        
    }
}
