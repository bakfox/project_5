using UnityEngine;

public class random_sc
{
    public static int random_gacha(int succes,int failed)//사용 방법 들어간 수만큼 넣음  최대 3개 확률은 먼저 넣은 순서로 정해짐 
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
