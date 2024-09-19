using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_upgrade_ui_manager : MonoBehaviour
{
    public static get_upgrade_ui_manager upgrade_ui_manger_temp;
    
    public List<GameObject> get_upgrade_ui_list = new List<GameObject> ();
    [SerializeField] GameObject get_up_ui_obj_temp;
    [SerializeField] RectTransform get_conect_obj;
    [SerializeField] int check_have_ui = 0;//지금 ui오브젝트 없으면
    private void Start()
    {
        upgrade_ui_manger_temp = this;
    }
    public static get_upgrade_ui_manager get_upgrade_ui_instance()
    {
        if (upgrade_ui_manger_temp ==null)
        {
            upgrade_ui_manger_temp = GameObject.FindGameObjectWithTag("upgrade_maker").GetComponent<get_upgrade_ui_manager>(); 
        }
        return upgrade_ui_manger_temp;
    }

    public void get_upgrade_ui_make(int i_tmep)
    {
        check_have_ui = 0;
        if (get_upgrade_ui_list == null)
        {
            GameObject obj_temp = Instantiate(get_up_ui_obj_temp,get_conect_obj);
            get_upgrade_ui_list.Add(obj_temp);
            obj_temp.GetComponent<upgrade_ui_data>().upgrade_id = i_tmep;
            obj_temp.GetComponent<upgrade_presenter>().set_upgrade_img();
        }
        else
        {
            foreach (GameObject obj_temp_1 in get_upgrade_ui_list)
            {
                if (obj_temp_1.GetComponent<upgrade_ui_data>().upgrade_id == i_tmep)
                {
                    Debug.Log("중복");
                    check_have_ui++;
                    obj_temp_1.GetComponent<upgrade_presenter>().this_upgrade++;
                    obj_temp_1.GetComponent<upgrade_presenter>().set_upgrade_img();
                }
            }
            if (check_have_ui== 0)
            {
                GameObject obj_temp = Instantiate(get_up_ui_obj_temp, get_conect_obj);
                obj_temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, obj_temp.GetComponent<upgrade_ui_data>().obj_pos_y * get_upgrade_ui_list.Count, 0);
                get_upgrade_ui_list.Add(obj_temp);
                obj_temp.GetComponent<upgrade_ui_data>().upgrade_id = i_tmep;
                obj_temp.GetComponent<upgrade_presenter>().set_upgrade_img();
            }

        }
        
    }
}
