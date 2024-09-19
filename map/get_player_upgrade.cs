using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_player_upgrade : MonoBehaviour
{
    [SerializeField] bool check_left= true;
    [SerializeField]Sprite[] swild_sprit;
    [SerializeField] SpriteRenderer sprit_render_temp;

    [SerializeField] int id_temp = 0;//이 벽이 가지고 있는 id 이걸 기준으로 업그레이드 시켜줌 
    main_data_manager main_temp;
    [SerializeField] get_upgrade_data get_upgrade_temp;// 업그레이드 하는 오브젝트 데이터 받아오기
    [SerializeField] player_statuse player_statuse_temp;
    player_upgrade_data player_upgrade_temp;
    void OnEnable()
    {
        first_setting();
    }
    void first_setting()
    {
        if (check_left)
        {
            id_temp = get_upgrade_temp.get_upgrade_left_id;
        }
        else
        {
            id_temp = get_upgrade_temp.get_upgrade_right_id;
        }
        main_temp = main_data_manager.GetInstance();
        player_upgrade_temp = main_temp.get_player_upgrade_data();
        if (id_temp == get_upgrade_temp.get_upgrade_sp.Length - 1)
        {
            GetComponent<SpriteRenderer>().sprite = swild_sprit[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = swild_sprit[0];
        }
        sprit_render_temp.sprite = get_upgrade_temp.get_upgrade_sp[id_temp];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!get_upgrade_temp.check_get_upgrade)//체크 
            {
                get_upgrade_temp.check_get_upgrade = true;
                add_upgrade();
            }
        }    
        
    }
    public void add_upgrade()//업그레이드 용 
    {
        foreach(int i_tmep in get_upgrade_temp.get_upgrade_value(id_temp))
        {
            if (id_temp==4)
            {
                player_upgrade_temp.atck_upgrade++;
            }
            else if (id_temp == 5)
            {
                player_statuse_temp.heal_player();
            }
            else
            {
                Debug.Log(player_upgrade_temp.upgrage_values[i_tmep]);
                player_upgrade_temp.upgrage_values[i_tmep]++;
                get_upgrade_ui_manager.get_upgrade_ui_instance().get_upgrade_ui_make(i_tmep);
                
            }
            
        }
        player_statuse_temp.upgrade_check();
        StartCoroutine("get_upgrade_cooltime_check");
    }
    IEnumerator get_upgrade_cooltime_check()//쿨타임 중복 먹기 방지 
    {
        float f_temp = 0f;
        while (get_upgrade_temp.get_up_cooltime >f_temp)
        {
            f_temp += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        get_upgrade_temp.check_get_upgrade = false;
        StopCoroutine("get_upgrade_cooltime_check");
    }
}
