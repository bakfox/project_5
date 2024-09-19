using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_upgrade_manager : MonoBehaviour
{
    main_data_manager main_temp;
    map_data map_temp;
    get_upgrade_obj_data get_up_obj_temp;
    [SerializeField] float f_temp = 0;//시간 잘가는지 확인용 
    private void Start()
    {
        main_temp = main_data_manager.GetInstance();
        map_temp = main_temp.get_map_data();
        get_up_obj_temp = main_temp.get_upgrade_obj_data();
        StartCoroutine("check_cooltime");
    }
    IEnumerator check_cooltime()//소환용 쿨타임 오브젝트 재활용 
    {
        f_temp = 0;
        while (f_temp < get_up_obj_temp.spawn_get_upgrade_obj_time)
        {
            if (map_temp.go_destination)
            {
                f_temp += 0;
            }
            else
            {
                f_temp += map_temp.player_spead * Time.deltaTime*2;
            }
            yield return new WaitForFixedUpdate();
        }
        if (map_temp.go_road_m >= map_temp.stop_max_m)
        {
            StopCoroutine("check_cooltime");//완료 
        }
        int left_i = Random.Range(0, get_up_obj_temp.swap_get_upgrade_obj_temp.GetComponent<get_upgrade_data>().get_upgrade_sp.Length);
        int right_i = Random.Range(0, get_up_obj_temp.swap_get_upgrade_obj_temp.GetComponent<get_upgrade_data>().get_upgrade_sp.Length);
        get_up_obj_temp.spawn_get_upgrade_obj_time += get_up_obj_temp.spawn_get_upgrade_obj_time / 2;
        get_up_obj_temp.swap_get_upgrade_obj_temp.GetComponent<get_upgrade_data>().get_upgrade_left_id = left_i;
        get_up_obj_temp.swap_get_upgrade_obj_temp.GetComponent<get_upgrade_data>().get_upgrade_right_id = right_i;
        get_up_obj_temp.swap_get_upgrade_obj_temp.SetActive(true);
        StartCoroutine("check_cooltime");//제귀함수
    }
}
