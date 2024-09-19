using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class target_presenter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI target_m_text;//목표 미터수
    [SerializeField] Image target_m_img; //타겟 img;
    [SerializeField] RectTransform target_move_obj;
    main_data_manager main_temp;
    map_data map_temp;

    Vector3 now_tr;
    private void Start()
    {
        main_temp = main_data_manager.GetInstance();
        map_temp = main_temp.get_map_data();
        StartCoroutine("set_img");
    }
    IEnumerator set_img()//이미지 셋팅 자동 이동 목표 도착시 종료 
    {
        Debug.Log("실행");
        now_tr = target_move_obj.anchoredPosition;
        while (map_temp.go_road_m <= map_temp.stop_max_m)
        {
            target_move_obj.anchoredPosition = new Vector3(now_tr.x, now_tr.y +(map_temp.stop_max_ui_m * (map_temp.go_road_m / map_temp.stop_max_m)), now_tr.z);
            target_m_img.fillAmount = map_temp.go_road_m / map_temp.stop_max_m;
            target_m_text.SetText(main_temp.change_unit(map_temp.go_road_m.ToString("F0")));
            yield return new WaitForFixedUpdate();
        }
    }
}
