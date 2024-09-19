using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_drag_move : MonoBehaviour ,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject player_obj_temp;//플레이어 오브젝트
    [SerializeField] player_data player_data_temp;//플레이어 데이터 
    [SerializeField] RectTransform player_controller_tr;//컨트롤러 tr;
    main_data_manager main_temp;

    public bool check_drage = false;//드래그 클릭 구별 위해 
    void Start()
    {
        start_setting();
    }
    void start_setting()//시작시 초기화 
    {
        main_temp = main_data_manager.GetInstance();
        player_data_temp = player_obj_temp.GetComponent<player_data>();
        player_controller_tr = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)//드래그 시작
    {
        //클릭이랑 구분하는 용도
        check_drage = true;
    }
    public void OnDrag(PointerEventData eventData)//드래그 중 
    {
        //드래그 로직 최대 수치랑 같거나 크면 멈추고 반대방향 드래그만 먹음 
        if (player_obj_temp.transform.position.x >= player_data_temp.drage_max )
        {
            if (eventData.delta.x < 0)
            {
                player_obj_temp.transform.position = new Vector3(player_obj_temp.transform.position.x + (eventData.delta.x / player_data_temp.drage_spead), player_obj_temp.transform.position.y, 0);
            }
        }
        else if (player_obj_temp.transform.position.x <= -player_data_temp.drage_max)
        {
            if (eventData.delta.x > 0)
            {
                player_obj_temp.transform.position = new Vector3(player_obj_temp.transform.position.x + (eventData.delta.x / player_data_temp.drage_spead), player_obj_temp.transform.position.y, 0);
            }
        }
        else
        {
            player_obj_temp.transform.position = new Vector3(player_obj_temp.transform.position.x + (eventData.delta.x / player_data_temp.drage_spead), player_obj_temp.transform.position.y, 0);
        }
        
        if (main_temp.get_map_data().stop_max_m < main_temp.get_map_data().go_road_m)
        {
            end_check_darge();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        check_drage = false;
        player_controller_tr.anchoredPosition = new Vector3(0, 0, 0);
    }

    void end_check_darge()
    {
        float f_temp = 0;
        while (transform.position.x == 0)
        {
            if (main_temp.get_map_data().go_destination)
            {
                f_temp = 0;
            }
            else
            {
                f_temp += Time.deltaTime;
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, 0), f_temp);
        }
    }
}
