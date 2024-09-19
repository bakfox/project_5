using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_data : MonoBehaviour
{
    public int monster_hp = 20;
    public int atck_dmg = 5;
    public int monster_statuse = 0;

    public int hit_dmg = 0;//공격 받은 데미지 
    public float hit_value = 0;//치명타인지 아닌지

    public bool nuck_back = false;//넉백 면역인지?
    public float nuck_bakc_m = 1f;// 넉백 수치 

    public bool boss_check_pls = false;//보스면 체크 체크할시 boss_ui_data에서 받아옴 
}
