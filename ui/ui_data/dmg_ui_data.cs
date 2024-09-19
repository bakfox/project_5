using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg_ui_data : MonoBehaviour
{
    public float dmg_max_time = 1f;// 시간 
    public int dmg_temp = 0;//데미지 
    public Vector3 now_postion;//지금 나와야 하는 오브젝트 위치 
    public bool check_monster = false;//몬스터면 true로 변경
}
