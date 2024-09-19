using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_monster_atck_check : MonoBehaviour
{
    [SerializeField]List<GameObject> monster_temp  = new List<GameObject>();
    [SerializeField] GameObject player_obj;//스테이터스 
    player_data player_data_temp;
    public void OnEnable()
    {
        if (player_data_temp == null)
        {
            player_data_temp = player_obj.GetComponent<player_data>();
        }

        this.transform.localScale = new Vector3(player_data_temp.swod_scope,player_data_temp.swod_scope,1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("monster"))
        {
            monster_temp.Add(collision.gameObject);
            foreach (GameObject obj_teemp in monster_temp)
            {
                obj_teemp.GetComponent<monster_data>().hit_dmg = player_obj.GetComponent<player_statuse>().player_atck;

                if (player_data_temp.check_timing_m <= player_data_temp.best_timing_max && player_data_temp.check_timing_m >= player_data_temp.best_timing_min)
                {
                    obj_teemp.GetComponent<monster_data>().hit_value =player_data_temp.timing_value;
                    obj_teemp.GetComponent<monster_data>().monster_statuse = 1;
                    obj_teemp.GetComponent<monster_statuse>().check_statuse();
                    comber_presenter.get_comber_presenter().set_comber_presenter();
                }
                else
                {
                    obj_teemp.GetComponent<monster_data>().hit_value = 1;
                    obj_teemp.GetComponent<monster_data>().monster_statuse = 1;
                    obj_teemp.GetComponent<monster_statuse>().check_statuse();
                    comber_presenter.get_comber_presenter().set_comber_presenter();
                }
            }
        }
        monster_temp.Clear();
    }
}
