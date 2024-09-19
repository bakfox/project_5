using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_upgrade_data : MonoBehaviour
{
    public int get_upgrade_left_id = 0;
    public int get_upgrade_right_id = 0;
    public bool check_get_upgrade = false;//획득시 true;
    public float get_up_cooltime = 1f;//획득쿨타임
    

    public Sprite[] get_upgrade_sp = new Sprite[6];//물검 불검 불활 물활 공격력 회복 순. 검 0  활 1 불 2 물 3 업그레이드
    public int[] get_upgrade_value(int itemp)
    {
        int[] i_temp_s = new int[2];
        switch (itemp)
        {
            case 0:
                i_temp_s[0] = 0;
                i_temp_s[1] = 3;
                break;
            case 1:
                i_temp_s[0] = 0;
                i_temp_s[1] = 2;
                break;
            case 2:
                i_temp_s[0] = 1;
                i_temp_s[1] = 3;
                break;
            case 3:
                i_temp_s[0] = 1;
                i_temp_s[1] = 2;
                break;

        }
        return i_temp_s;
    }
}
