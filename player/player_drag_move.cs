using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_drag_move : MonoBehaviour ,IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject player_obj_temp;//�÷��̾� ������Ʈ
    [SerializeField] player_data player_data_temp;//�÷��̾� ������ 
    [SerializeField] RectTransform player_controller_tr;//��Ʈ�ѷ� tr;
    main_data_manager main_temp;

    public bool check_drage = false;//�巡�� Ŭ�� ���� ���� 
    void Start()
    {
        start_setting();
    }
    void start_setting()//���۽� �ʱ�ȭ 
    {
        main_temp = main_data_manager.GetInstance();
        player_data_temp = player_obj_temp.GetComponent<player_data>();
        player_controller_tr = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)//�巡�� ����
    {
        //Ŭ���̶� �����ϴ� �뵵
        check_drage = true;
    }
    public void OnDrag(PointerEventData eventData)//�巡�� �� 
    {
        //�巡�� ���� �ִ� ��ġ�� ���ų� ũ�� ���߰� �ݴ���� �巡�׸� ���� 
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
