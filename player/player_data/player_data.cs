using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data : MonoBehaviour
{
    public int defolt_hp = 50;
    public int defolt_atck = 10;

    public int hit_dmg = 0;//맞은 데미지 
    public float hit_ghost = 1f;//맞은후 1초 
    public bool check_hit_ghost = false;//체크용 

    public int player_stause = 0;//0 기본,1 피격  ,2 공격 
    public float drage_spead = 120f;//속도 
    public float drage_max = 3.7f;

    //증강 관련 
    public bool fire_swod = false;//불 3개  검기 활성화
    public bool water_arrow = false;//물 3개 활성화시 관통

    //공격 관련
    public float atck_swod = 2;//검으로 공격시 2배
    public float atck_sp_swod = 0.4f;//검공격 0.5초 내부쿨 
    public bool check_swod_cooltime = true;//검 공격 
    public float swod_scope = 0.5f;//기본 

    public float atck_sword_aura = 2.5f;// 검기 데미지
    public float atck_sp_sword_aura = 10f;//10초 내부쿨 
    public bool check_atck_swoad_aura_cooltime = true;//검기 쿨

    public float atck_arrow = 3;//활으로 공격시 3배
    public float atck_sp_arrow = 2;//쿨타임 2초 
    public bool check_arrow_cooltime = true;//활 공격 

    public int atck_glove = 2;//글러브로 공격시 2배
    public float atck_sp_glove = 0.5f;//쿨타임 없음 

    //타이밍
    public int timing_value = 2;//2배증가
    public float check_timing_m = 0;//타이밍 m_check
    public float best_timing_min = 18.5f;
    public float best_timing_max = 19.5f;

}
