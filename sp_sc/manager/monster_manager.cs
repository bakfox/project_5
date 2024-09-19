using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class monster_manager : MonoBehaviour
{
    [SerializeField] GameObject[] monster_obj;//몬스터 종류 
    [SerializeField] GameObject boss_obj;//보스몬스터 
    [SerializeField] Transform spwan_monster_tr;//몬스터 스폰위치
    public List<GameObject> monster_list = new List<GameObject>();
    monster_spwan_data monster_temp;
    main_data_manager main_temp;

    private void Start()
    {
        monster_setting();
    }
    void monster_setting()//오브젝트 풀링 위한 셋팅 
    {
        main_temp = main_data_manager.GetInstance();
        monster_temp = main_temp.get_spawn_data();
        for (int i_temp = 0; i_temp < 50; i_temp++)
        {
            GameObject monster_temp_obj = Instantiate(monster_obj[random_sc.random_gacha(100 - monster_temp.monster_upgrade, monster_temp.monster_upgrade)], spwan_monster_tr);
            monster_list.Add(monster_temp_obj);
            monster_temp_obj.GetComponent<monster_move>().monster_temp = this;
            monster_temp_obj.transform.position = spwan_monster_tr.position;

        }
        StartCoroutine("spawn_monster");
    }
    IEnumerator spawn_monster()//스폰 코루틴 
    {
        float time_temp = 0f;
        while (main_temp.get_map_data().stop_max_m > main_temp.get_map_data().go_road_m)//목표 위치 도착까지 반복
        {
            time_temp += Time.deltaTime;
            if (time_temp > monster_temp.spawn_time)
            {
                for (int i_temp = 0; i_temp <5f;i_temp++)
                {
                    GameObject obj_temp = monster_list[i_temp];
                    monster_move move_temp = obj_temp.GetComponent<monster_move>();
                    if (Random.Range(0,2)==1)//2분의 1확률 
                    {
                        switch (i_temp)//스폰 위치 
                        {
                            case 0:
                                obj_temp.transform.localPosition = new Vector3(-monster_temp.mosnter_spawn_interval * 2, 0, 0);
                                move_temp.end_x = -monster_temp.mosnter_spawn_interval * 2;
                                move_temp.start_chceck();
                                monster_list.RemoveAt(i_temp);
                                break;
                            case 1:
                                obj_temp.transform.localPosition = new Vector3(-monster_temp.mosnter_spawn_interval, 0, 0);
                                move_temp.end_x = -monster_temp.mosnter_spawn_interval ;
                                move_temp.start_chceck();
                                monster_list.RemoveAt(i_temp);
                                break;
                            case 2:
                                obj_temp.transform.localPosition = new Vector3(0, 0, 0);
                                move_temp.end_x =0;
                                move_temp.start_chceck();
                                monster_list.RemoveAt(i_temp);
                                break;
                            case 3:
                                obj_temp.transform.localPosition = new Vector3(monster_temp.mosnter_spawn_interval, 0, 0);
                                move_temp.end_x = monster_temp.mosnter_spawn_interval ;
                                move_temp.start_chceck();
                                monster_list.RemoveAt(i_temp);
                                break;
                            case 4:
                                obj_temp.transform.localPosition = new Vector3(monster_temp.mosnter_spawn_interval * 2, 0, 0);
                                move_temp.end_x = monster_temp.mosnter_spawn_interval * 2;
                                move_temp.start_chceck();
                                monster_list.RemoveAt(i_temp);
                                break;

                        }
                    }
                }
                time_temp = 0;
            }
            yield return new WaitForFixedUpdate();
        }//끝나면 보스 소환
        yield return new WaitForSeconds(4f);
        spawn_boss();
    }
    void spawn_boss()
    {
        GameObject obj_temp_boss = Instantiate(boss_obj, spwan_monster_tr);
        monster_move boss_move_temp = obj_temp_boss.GetComponent<monster_move>();
        boss_move_temp.end_x = 0;
        boss_move_temp.start_chceck();
    }
}
