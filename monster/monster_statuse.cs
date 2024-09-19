using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_statuse : MonoBehaviour
{
    [SerializeField] monster_presenter monster_pre_temp;
    [SerializeField] Sprite[] monster_sp_temp;
    [SerializeField] SpriteRenderer monster_sp_render_temp;
    public int monster_hp;
    public int monster_atck;

    bool check_atck = true;//공격 가능한지 체크 

    monster_data monster_temp;
    main_data_manager main_temp;
    Animator anim_temp;
    private void Start()//기본 설정 
    {
        first_setting();
    }
    void first_setting()
    {
        main_temp = main_data_manager.GetInstance();
        anim_temp = GetComponent<Animator>();
        monster_temp = GetComponent<monster_data>();
        monster_hp = monster_temp.monster_hp + monster_temp.monster_hp * main_temp.save_data_temp.now_stage;
        monster_atck = monster_temp.atck_dmg + monster_temp.atck_dmg * main_temp.save_data_temp.now_stage;
        check_statuse();
    }
    public void check_statuse()
    {
        switch (GetComponent<monster_data>().monster_statuse)
        {
            case 0:
                idle_defolt();
                break;
            case 1:
                dmg_defolt();
                break;
            case 2:
                die();
                break;
        }
    }
    void die()
    {
        anim_temp.SetTrigger("dmg");
        if (monster_temp.boss_check_pls) 
        {
            main_temp.save_data_temp.boss_die = true;
        }
        GetComponent<monster_move>().end_check();

    }
    void idle_defolt()//기본
    {
        monster_sp_render_temp.sprite = monster_sp_temp[0];
    }
    void dmg_defolt()//맞을때 발동 
    {
        monster_sp_render_temp.sprite = monster_sp_temp[1];
        transform.position = new Vector3(transform.position.x, transform.position.y+ monster_temp.nuck_bakc_m, transform.position.z);//넉백 적용
        GameObject effect_temp = main_temp.dmg_mkaer.get_dmg_ui_effect();
        int hit_dmg = (int)(monster_temp.hit_dmg * monster_temp.hit_value);//맞은 데미지 
        monster_pre_temp.player_hp_setting();
        monster_hp -= hit_dmg;
        if (monster_hp <= 0)
        {
            monster_temp.monster_statuse = 2;
            check_statuse();
        }
        monster_pre_temp.player_hp_setting();
        effect_temp.GetComponent<dmg_ui_data>().dmg_temp = hit_dmg;
        effect_temp.GetComponent<dmg_ui_data>().now_postion = transform.position;
        effect_temp.GetComponent<dmg_ui_data>().check_monster = false;
        effect_temp.SetActive(true);
        monster_temp.monster_statuse = 0;
        anim_temp.SetTrigger("dmg");
        Invoke("check_statuse", 0.4f);
    }
}
