using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg_ui_maker : MonoBehaviour
{
    public GameObject dmg_ui_obj;
    public List<GameObject> dmg_list = new List<GameObject>();
    main_data_manager main_temp;
    // Start is called before the first frame update
    private void Start()
    {
        dmg_setting();
    }
    void dmg_setting()//오브젝트 풀링 위한 셋팅 
    {
        main_temp = main_data_manager.GetInstance();
        main_temp.dmg_mkaer = this;
        for (int i_temp = 0; i_temp < 20; i_temp++)
        {
            GameObject monster_temp_obj = Instantiate(dmg_ui_obj);
            dmg_list.Add(monster_temp_obj);
        }
    }
    public GameObject get_dmg_ui_effect()
    {
        GameObject temp = dmg_list[1];
        dmg_list.Remove(temp);
        return temp;
    }
    public void add_list(GameObject obj_temp)
    {
        Debug.Log("null아님"+ obj_temp);
        dmg_list.Add (obj_temp);
    }
}
