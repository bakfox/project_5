using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_data_manager : save_sc
{
    public static main_data_manager main_temp;
    map_data map_data_temp;
    monster_spwan_data spawn_temp;
    comber_data comber_data_tmep;
    player_upgrade_data player_upgrade_temp;
    get_upgrade_obj_data get_up_obj_data;
    monster_boss_data monster_boss_ui_data_temp;
    public dmg_ui_maker dmg_mkaer;
    public player_atck_spawn_manger player_atck_maker;
    public static main_data_manager GetInstance()//메인 받아오기 
    {
        if (main_temp == null)
        {
            main_temp = GameObject.FindGameObjectWithTag("mainmanager").GetComponent<main_data_manager>();
            Debug.Log(main_temp.name);
        }
        return main_temp;
    }
    // Start is called before the first frame update
    void Start()
    {
        main_temp
            = this;
    }

    public map_data get_map_data()
    {
        if (map_data_temp == null)
        {
            map_data_temp = GetComponent<map_data>();
        }
        return map_data_temp;
    }
    public monster_spwan_data get_spawn_data()
    {
        if (spawn_temp == null)
        {
            spawn_temp = GetComponent<monster_spwan_data>();
        }
        return spawn_temp;
    }
    public comber_data get_comber_data()
    {
        if (comber_data_tmep == null)
        {
            comber_data_tmep = GetComponent<comber_data>();
        }
        return comber_data_tmep;
    }
    public player_upgrade_data get_player_upgrade_data()
    {
        if (player_upgrade_temp == null)
        {
            player_upgrade_temp = GetComponent<player_upgrade_data>();
        }
        return player_upgrade_temp;
    }
    public get_upgrade_obj_data get_upgrade_obj_data()
    {
        if (get_up_obj_data == null)
        {
            get_up_obj_data = GetComponent<get_upgrade_obj_data>();
        }
        return get_up_obj_data;
    }
    public monster_boss_data get_boss_ui_data()
    {
        if (monster_boss_ui_data_temp == null)
        {
            monster_boss_ui_data_temp = GetComponent<monster_boss_data>();
        }
        return monster_boss_ui_data_temp;
    }
}
