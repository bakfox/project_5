using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_clicker : MonoBehaviour, IPointerClickHandler
{
    player_drag_move player_drage_temp;
    void Start()
    {
        player_drage_temp = GetComponent<player_drag_move>();
    }

    public void OnPointerClick(PointerEventData eventData)// 클릭
    {

        if (!player_drage_temp.check_drage)
        {
            if (player_drage_temp.player_obj_temp.GetComponent<player_data>().check_swod_cooltime)
            {
                player_drage_temp.player_obj_temp.GetComponent<player_data>().player_stause = 2;
                player_drage_temp.player_obj_temp.GetComponent<player_statuse>().player_statuse_check();
            }
            

        }
        else
            Debug.Log("클릭");
    }
}
