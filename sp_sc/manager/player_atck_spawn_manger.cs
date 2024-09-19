using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_atck_spawn_manger : MonoBehaviour
{
    public List<GameObject> arrow_list = new List<GameObject>();
    public List<GameObject> swod_aura_list = new List<GameObject>();
    [SerializeField] GameObject arrow_obj;//화살 오브젝트 
    [SerializeField] GameObject swoad_aura_obj;//소드오러 오브젝트
    [SerializeField] Transform atck_conect_tr;//연결할 트렌스폼
    main_data_manager main_temp;
    // Start is called before the first frame update
    void Start()
    {
        arrow_setting();
    }
    void arrow_setting()//오브젝트 풀링 위한 셋팅 
    {
        main_temp = main_data_manager.GetInstance();
        main_temp.player_atck_maker = this;
        for (int i_temp = 0; i_temp < 10; i_temp++)
        {
            GameObject monster_temp_obj = Instantiate(arrow_obj, atck_conect_tr);
            monster_temp_obj.GetComponent<atck_ad_data>().conect_position = atck_conect_tr.transform.position;
            monster_temp_obj.GetComponent<atck_ad_data>().player_atck_spawn_tmep = this;
            arrow_list.Add(monster_temp_obj);
        }
        swoad_aura_setting();
    }
    void swoad_aura_setting()//오브젝트 풀링 위한 셋팅 
    {
        for (int i_temp = 0; i_temp < 2; i_temp++)
        {
            GameObject monster_temp_obj = Instantiate(swoad_aura_obj, atck_conect_tr);
            monster_temp_obj.GetComponent<atck_ad_data>().conect_position = atck_conect_tr.transform.position;
            monster_temp_obj.GetComponent<atck_ad_data>().player_atck_spawn_tmep = this;
            swod_aura_list.Add(monster_temp_obj);
        }
    }
    public GameObject get_arrow_obj()
    {
        GameObject obj_temp = arrow_list[0];
        arrow_list.Remove(obj_temp);
        return obj_temp;
    }
    public GameObject get_swoad_aura_obj()
    {
        GameObject obj_temp = swod_aura_list[0];
        Debug.Log(obj_temp.name+"검기요청");
        swod_aura_list.Remove(obj_temp);
        return obj_temp;
    }
}
