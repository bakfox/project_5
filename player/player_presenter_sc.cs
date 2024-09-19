using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class player_presenter_sc : MonoBehaviour
{
    public static player_presenter_sc player_presen_temp;
    [SerializeField] GameObject player_obj_temp;
    [SerializeField] TextMeshProUGUI player_hp_tex;
    [SerializeField] Image player_hp_img;//이미지
    bool first_check = true;
    [SerializeField]float max_hp_temp;
    private void Start()
    {
        player_presen_temp = this;
        Invoke("player_hp_setting", 0.1f);
    }
    public static player_presenter_sc get_player_presenter()
    {
        if (player_presen_temp ==null)
        {
            player_presen_temp = GameObject.FindGameObjectWithTag("player_pre").GetComponent<player_presenter_sc>();
        }
        return player_presen_temp;
    }
    public void player_hp_setting()//불러오면 이미지랑 체력 셋팅
    {
        player_data player_data_temp = player_obj_temp.GetComponent<player_data>();
        player_statuse player_statuse_temp = player_obj_temp.GetComponent<player_statuse>();
        if (first_check)
        {
            first_check = false;
            max_hp_temp = player_statuse_temp.player_hp;
        }
        player_hp_tex.SetText(main_data_manager.GetInstance().change_unit(player_statuse_temp.player_hp.ToString()));
        player_hp_img.fillAmount = ((float)player_statuse_temp.player_hp / max_hp_temp);
    }
}
