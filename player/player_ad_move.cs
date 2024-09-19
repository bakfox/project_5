using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_ad_move : MonoBehaviour
{
    atck_ad_data player_ad_move_temp ;
    player_atck_spawn_manger player_spawn_temp;
    Vector3 now_tr;
    private void OnEnable()
    {
        player_ad_move_temp= GetComponent<atck_ad_data>();
        player_spawn_temp = player_ad_move_temp.player_atck_spawn_tmep;
        transform.localPosition = player_ad_move_temp.conect_position;
        now_tr = transform.position;
        StartCoroutine("map_mv");
    }
    IEnumerator map_mv()//움직이는 로직
    {
        float f_temp = 0;
        while (transform.localPosition.y < player_ad_move_temp.target_max_y)
        {
            if (main_data_manager.GetInstance().get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp = player_ad_move_temp.ad_spead * Time.deltaTime;
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, player_ad_move_temp.target_max_y, 0), f_temp);
            yield return new WaitForFixedUpdate();
        }
        end_check();
    }
    public void end_check()//화살 오러 분류 따로 해줘야함 
    {
        switch (player_ad_move_temp.atck_ad_value)
        {
            case 0:
                player_spawn_temp.arrow_list.Add(gameObject);
                gameObject.SetActive(false);
                break;
            case 1:
                player_spawn_temp.swod_aura_list.Add(gameObject);
                gameObject.SetActive(false);
                break;
        }
    }
}
