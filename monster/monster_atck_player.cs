using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_atck_player : MonoBehaviour
{
    monster_statuse monoster_st_temp;
    private void Start()
    {
        monoster_st_temp = GetComponent<monster_statuse>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_data player_temp = collision.GetComponent<player_data>();
            player_temp.player_stause = 1;
            player_temp.hit_dmg = monoster_st_temp.monster_atck;
            collision.GetComponent<player_statuse>().player_statuse_check();
            comber_presenter.get_comber_presenter().reset_comber_presenter();
            player_presenter_sc.get_player_presenter().player_hp_setting();
        }
    }
}
