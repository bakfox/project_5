using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_move : MonoBehaviour
{
    main_data_manager main_temp;
    map_data map_temp;
    public monster_manager monster_temp;
    monster_data monster_data_temp;
    public float end_x = 0;
    void Start()
    {
        start_chceck();
    }
    public void start_chceck()
    {
        monster_data_temp = GetComponent<monster_data>();  
        gameObject.SetActive(true);
        main_temp = main_data_manager.GetInstance();
        map_temp = main_temp.get_map_data();
        StartCoroutine("monster_mv");
    }

    IEnumerator monster_mv()//움직이는 로직
    {
        float f_temp = map_temp.player_spead * Time.deltaTime;
        while (transform.localPosition.y > map_temp.map_recool_y)
        {
            if (map_temp.go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp = map_temp.player_spead * Time.deltaTime;
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(end_x, map_temp.map_recool_y, 0), f_temp);
            yield return new WaitForFixedUpdate();
        }
        end_check();
    }
    public void end_check()//죽으면 발동 
    {
        if (monster_data_temp.boss_check_pls)
        {
            main_temp.save_data_temp.boos_miss = true;
            gameObject.SetActive(false);
        }
        else
        {
            monster_temp.monster_list.Add(gameObject);
            gameObject.SetActive(false);
        } 
    }
}
