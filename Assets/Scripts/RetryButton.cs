using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
   //������ �ٽ� �����ϴ°��� MainScene�� �ٽ� �ҷ��ָ� �ȴ�!!
   //Scene�� �ҷ����� ���ؼ���..��Ű���ϳ�, �Լ��ϳ��� �߱��Ѵ�.

    public void Retry()
    {
        //Scene�� �ҷ����� ���ؼ��� Scene Management (��Ű��) �� �ִ�
        //scene manager�� �̿��ؾ��Ѵ�. scene�� �����ö� get�� �ƴ϶� load��� �ؾ��Ѵ�.
        SceneManager.LoadScene("MainScene"); 
    }
}
