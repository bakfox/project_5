using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_statuse : MonoBehaviour
{
    public int player_hp = 0;//체력
    public int player_atck = 0;//공격력

    [SerializeField] GameObject atck_obj;
    main_data_manager main_temp;
    player_data player_data_temp;
    Animator player_anim_temp;

    [SerializeField] bool arrow_unlock = false;//활 1개 있으면 활성화 
    [SerializeField] int now_arrow_int = 0;//지금 쏘는 화살 갯수
    
    private void Start()
    {
        player_data_temp = GetComponent<player_data>();
        player_anim_temp = GetComponent<Animator>();
        main_temp = main_data_manager.GetInstance();

        player_hp = player_data_temp.defolt_hp + (player_data_temp.defolt_hp / 10) * main_temp.save_data_temp.upgrade_value[0];
        player_atck = player_data_temp.defolt_atck + (player_data_temp.defolt_atck /10)* main_temp.save_data_temp.upgrade_value[1];
    }

    public void upgrade_check()//업그레이드 그런거 적용
    {
        player_upgrade_data player_upgrade_data = main_temp.get_player_upgrade_data();
        player_atck += (player_atck *player_upgrade_data.atck_upgrade)/ 5;
        if (player_upgrade_data.upgrage_values[0] >= 1)//검 범위
        {
            player_data_temp.swod_scope += player_data_temp.swod_scope / 2;
        }
        if (player_upgrade_data.upgrage_values[1] >= 1)//활 갯수
        {
            arrow_unlock = true;
            now_arrow_int = 1;
            if (player_upgrade_data.upgrage_values[1] >= 3)
            {
                now_arrow_int = 3;
            }else if (player_upgrade_data.upgrage_values[1] >= 6)
            {
                now_arrow_int = 6;
            }

        }
        if (player_upgrade_data.upgrage_values[2] >= 1)//불 검 공격력 증가 3개 이상 검기 
        {
            player_data_temp.atck_swod += (player_data_temp.atck_swod* player_upgrade_data.upgrage_values[2]/2);
            if (player_upgrade_data.upgrage_values[2] >= 3)
            {
                player_data_temp.fire_swod = true;
            }
        }
        if (player_upgrade_data.upgrage_values[3] >= 1)//물 활 공격력 증가 관통
        {
            player_data_temp.atck_arrow += (player_data_temp.atck_arrow * player_upgrade_data.upgrage_values[3]/2);
            if (player_upgrade_data.upgrage_values[3] >= 3)
            {
                player_data_temp.water_arrow = true;
            }   
        }
    }
    void idle_defolt()//기본 
    {

    }
    public void heal_player()
    {
        player_hp += player_hp / 5;
        if (player_hp > player_data_temp.defolt_hp + (player_data_temp.defolt_hp / 10) * main_temp.save_data_temp.upgrade_value[0])
        {
            player_hp = player_data_temp.defolt_hp + (player_data_temp.defolt_hp / 10) * main_temp.save_data_temp.upgrade_value[0];
        }
    }
    void dmg_defolt()//데미지 입음
    {
        player_data_temp.player_stause = 0;
        if (!player_data_temp.check_hit_ghost)
        {
            player_data_temp.check_hit_ghost = true;
            player_hp -= player_data_temp.hit_dmg;
            if (player_hp <= 0)
            {
                player_data_temp.player_stause = 4;
                player_statuse_check();
            }
            GameObject effect_temp = main_temp.dmg_mkaer.get_dmg_ui_effect();
            effect_temp.GetComponent<dmg_ui_data>().dmg_temp = player_data_temp.hit_dmg;
            effect_temp.GetComponent<dmg_ui_data>().now_postion = transform.position;
            effect_temp.GetComponent<dmg_ui_data>().check_monster = true;
            effect_temp.SetActive(true);
            player_anim_temp.SetTrigger("dmg");
            StartCoroutine("check_unbeatable");
        }
        
    }
    void die_defolt()//죽음
    {
        player_data_temp.player_stause = 0;
        player_anim_temp.SetTrigger("die");
        main_temp.save_data_temp.boos_miss = true;
    }
    void atck_swod()//검으로 공격
    {
        if (player_data_temp.check_swod_cooltime)
        {
            player_data_temp.player_stause = 0;
            player_data_temp.check_swod_cooltime = false;
            player_anim_temp.SetTrigger("swod");
            atck_obj.SetActive(true);
            StartCoroutine("checked_swod_cooltime");
        }
        if (player_data_temp.fire_swod)
        {
            Debug.Log("검기 발사");
            swod_aura_atck();
        }
        if (arrow_unlock)
        {
            Debug.Log("활 발사");
            atck_arrow();
        }
        
    }
    void atck_arrow()//활공격 모션
    {
        if (player_data_temp.check_arrow_cooltime)
        {
            if (now_arrow_int >= 3)
            {
                for (int i_tmep = 0; i_tmep < 3; i_tmep++)
                {
                    float f_temp = 25f;

                    GameObject arrow_temp = main_temp.player_atck_maker.get_arrow_obj();
                    arrow_temp.GetComponent<atck_ad_data>().water_arrow = player_data_temp.water_arrow;
                    arrow_temp.GetComponent<atck_ad_data>().atck_dmg = player_atck;
                    arrow_temp.GetComponent<atck_ad_data>().atck_value = player_data_temp.atck_arrow;
                    player_data_temp.check_arrow_cooltime = false;
                    player_anim_temp.SetTrigger("arrow");
                    arrow_temp.SetActive(true);
                    StartCoroutine("checked_arrow_cooltime");
                }
            }
            else
            {
                GameObject arrow_temp = main_temp.player_atck_maker.get_arrow_obj();
                arrow_temp.GetComponent<atck_ad_data>().atck_dmg = player_atck;
                arrow_temp.GetComponent<atck_ad_data>().atck_value = player_data_temp.atck_arrow;
                player_data_temp.check_arrow_cooltime = false;
                player_anim_temp.SetTrigger("arrow");
                arrow_temp.SetActive(true);
                StartCoroutine("checked_arrow_cooltime");
                player_data_temp.player_stause = 0;
            }
            
        }       
    }
    
    void swod_aura_atck()//소드오러 공격
    {
        if (player_data_temp.check_atck_swoad_aura_cooltime)
        {
            Debug.Log("검기 실행");
            GameObject swoad_aura_temp = main_temp.player_atck_maker.get_swoad_aura_obj();
            swoad_aura_temp.GetComponent<atck_ad_data>().atck_dmg = player_atck;
            swoad_aura_temp.GetComponent<atck_ad_data>().atck_ad_value = 1;
            swoad_aura_temp.GetComponent<atck_ad_data>().atck_value = player_data_temp.atck_sword_aura;
            player_data_temp.check_atck_swoad_aura_cooltime = false;
            player_anim_temp.SetTrigger("swod");
            swoad_aura_temp.SetActive(true);
            StartCoroutine("check_swoad_aura");
        }
    }
    public void player_statuse_check()
    {
        switch (player_data_temp.player_stause)
        {
            case 0:
                idle_defolt();
                break;
            case 1:
                dmg_defolt();
                break;
            case 2:
                atck_swod();
                break;
            case 3:
                atck_arrow();
                break;
            default:
                die_defolt();
                break;
        }
    }
    IEnumerator checked_swod_cooltime()//기본 무기 
    {

        float f_temp = 0f;
        while (player_data_temp.atck_sp_swod > f_temp)
        {
            if (main_data_manager.GetInstance().get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        atck_obj.SetActive(false) ;
        player_data_temp.check_swod_cooltime = true;
        StopCoroutine("checked_swod_cooltime");
    }
    IEnumerator checked_arrow_cooltime()//활전용
    {
        float f_temp = 0f;
        while (player_data_temp.atck_sp_arrow>f_temp)
        {
            if (main_data_manager.GetInstance().get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        player_data_temp.check_arrow_cooltime = true;
        StopCoroutine("checked_arrow_cooltime");
    }
    IEnumerator check_unbeatable()
    {
        float f_temp = 0;
        while (player_data_temp.hit_ghost > f_temp)
        {
            if (main_data_manager.GetInstance().get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        player_data_temp.check_hit_ghost = false;
        StopCoroutine("check_unbeatable");
    }
    IEnumerator check_swoad_aura()
    {
        float f_temp = 0;
        while (player_data_temp.atck_sp_sword_aura > f_temp)
        {
            if (main_data_manager.GetInstance().get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp += Time.deltaTime;
            }
            yield return new WaitForFixedUpdate();
        }
        player_data_temp.check_atck_swoad_aura_cooltime = true;
        StopCoroutine("check_unbeatable");
    }
}
