using UnityEngine;

public class random_sc
{
    public static int random_gacha(int succes,int failed)//��� ��� �� ����ŭ ����  �ִ� 3�� Ȯ���� ���� ���� ������ ������ 
    {
        int i_r_temp = Random.Range(1,101);
        int i_temp = 3;

        Debug.Log(i_r_temp);
        Debug.Log(i_temp);

        if (i_r_temp <= succes)
        {
            i_temp = 0;
            return i_temp;
        } else if(i_r_temp <= (failed+succes))
        {
            i_temp = 1;
            return i_temp;
        }
        else
        {
            i_temp = 2;
            return i_temp;
        }
    }
}
