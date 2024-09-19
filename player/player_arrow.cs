using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_arrow : MonoBehaviour
{
    [SerializeField] atck_ad_data ad_data;
    [SerializeField] player_ad_move da_move;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("monster"))
        {
            GameObject obj_temp = collision.gameObject;
            obj_temp.GetComponent<monster_data>().hit_dmg = ad_data.atck_dmg;
            obj_temp.GetComponent<monster_data>().hit_value = ad_data.atck_value;
            obj_temp.GetComponent<monster_data>().monster_statuse = 1;
            obj_temp.GetComponent<monster_statuse>().check_statuse();
            comber_presenter.get_comber_presenter().set_comber_presenter();
            if (!ad_data.water_arrow)
            {
                da_move.end_check();
            }
        }
    }
}
