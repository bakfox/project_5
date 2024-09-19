using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class monster_presenter : MonoBehaviour
{
    [SerializeField] GameObject monster_ui_obj;
    [SerializeField] GameObject monster_obj;
    [SerializeField] TextMeshProUGUI monster_text_hp;
    [SerializeField] Image monster_hp_img;
    bool first_check = true;
    [SerializeField] float max_hp_temp;
    private void Start()
    {
        if (monster_obj.GetComponent<monster_data>().boss_check_pls)
        {
            monster_boss_data boss_ui_temp = main_data_manager.GetInstance().get_boss_ui_data();
            monster_ui_obj = boss_ui_temp.boss_obj;
            monster_text_hp = boss_ui_temp.boss_text;
            monster_hp_img = boss_ui_temp.boss_img;
        }
        
    }

    public void player_hp_setting()//불러오면 이미지랑 체력 셋팅
    {
        monster_ui_obj.SetActive(true);
        monster_data monster_data_temp = monster_obj.GetComponent<monster_data>();
        monster_statuse monster_statuse_temp = monster_obj.GetComponent<monster_statuse>();
        if (first_check)
        {
            first_check = false;
            max_hp_temp = monster_statuse_temp.monster_hp;
        }
        monster_text_hp.SetText(main_data_manager.GetInstance().change_unit(monster_statuse_temp.monster_hp.ToString()));
        monster_hp_img.fillAmount = (monster_statuse_temp.monster_hp / max_hp_temp);
    }
}
