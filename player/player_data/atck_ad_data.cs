using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atck_ad_data : MonoBehaviour
{
    public bool water_arrow = false;//관통화살인지 체크 

    public Vector3 conect_position;
    public int atck_ad_value =0 ;//공격에 대한 종류 0화살 1오러 ..
    public player_atck_spawn_manger player_atck_spawn_tmep;//스폰
    public int atck_dmg;//데미지
    public float atck_value;//배율

    public float target_max_y = 56;//목표 위치 
    public float ad_spead = 2f;//날아가는 속도
}
