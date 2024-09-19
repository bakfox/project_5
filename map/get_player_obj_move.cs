using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_player_obj_move : MonoBehaviour
{
    main_data_manager main_temp;
    map_data map_temp;
    void OnEnable()
    {
        main_temp = main_data_manager.GetInstance();
        map_temp = main_temp.get_map_data();
        transform.position = new Vector3(0, main_temp.get_upgrade_obj_data().start_tr, 0);
        StartCoroutine("map_mv");
    }
    IEnumerator map_mv()//움직이는 로직
    {
        float f_temp = map_temp.player_spead * Time.deltaTime;
        while (transform.position.y > main_temp.get_upgrade_obj_data().get_y_max)
        {
            if (map_temp.go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp = map_temp.player_spead * Time.deltaTime;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, map_temp.map_recool_y, 0), f_temp);
            map_temp.go_road_m += f_temp;
            yield return new WaitForFixedUpdate();
           
        }
        gameObject.SetActive(false);
    }
}
