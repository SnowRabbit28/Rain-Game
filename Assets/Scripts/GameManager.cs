using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Prefabs�� ������ GameObject�̱� ������
    public GameObject rain;
    public GameObject endPanel;

    //�� �ϳ��ۿ� ����!! �׷��� ���� ģ������ ���� ����������Ѵ�! ��� �ǹ��� �Լ� �ۼ�
    public static GameManager instance;
    //Text�� ��ü������ �����ðŶ� �����̸��� �̷��� ����
    public Text totalScoreTxt;
    //��ü Ÿ�̸� �ð� 30��, �ڷ����� �Ǽ�
    float totalTime = 30.0f;
    //�ð��� ������������ ��������, Text�� ����
    public Text timeTxt;

    //��ü���� ����
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
            //��⸶�� ���������̰� �ֵ� �ð��� ���̰� �ִٰ� �Ѵ�.
            //�׷��� ������ ���� �ð��� �پ��� ���ߴ°��� deltaTime�̶�� �Ѵ�.
            //�׷��� ��ü�ð� 30���� ���������� deltaTime�� ���־���Ѵ�.
            totalTime -= Time.deltaTime; // ���� ���ڸ� �����ʾƵ� �ȴ�.
        }
        else
        {
            //�ð��� ũ�⸦ 0���� ������ش� ��� ��
            //��, ���������Ӱ� ���� �������� ���̰� ���ٴ� ��, ũ�Ⱑ 0�̱� ����
            //�׷��� �ð��� �����ó�� ǥ���� ����!
            Time.timeScale = 0f; //�̼��� ������ �߻��� �� ����, ǥ���� �ϴ°Ŷ�
            totalTime = 0f; // �׷��� �ð��� 0���� �����.
            endPanel.SetActive(true); //Ȱ��ȭ�� ���� ���ְڴ�!, ���ӿ�����Ʈ�� ���ְڴ�! ��� ��
        }

        //text������Ʈ �ȿ� �ִ� text���ٰ� ��ŻŸ���̶�� ���ڵ����͸� ���ڿ��� �־��ش�.
        timeTxt.text = totalTime.ToString("N2");
    }

    // �Լ���, �ݺ������� ����Ǵ� ������ �ϳ��� ������� ����
    // �츮�� �� �۾��� �ݺ������� ������ ���̱� ������ �Լ��� ����� ���´�.
    void MakeRain()
    {
        //( ���ӿ�����Ʈ��) �����ϴ� �Լ�
        Instantiate(rain);
    }

    public void AddScore(int score) // ��ȣ �ȿ� �ִ� ģ���� �Ű������̴�.
                                    // ���߿� AddScore�� ����Ұǵ� �׶� �� ������ �̸� �־�ּ�
                                    // ���⿡ �����Ͱ� �־�� �̰� ���ſ���! ��� �˷��شٰ� ��������.
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        

    }
}
