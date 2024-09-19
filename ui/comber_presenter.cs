using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class comber_presenter : MonoBehaviour
{
    public static comber_presenter comber_presenter_temp;

    [SerializeField] GameObject text_obj;
    [SerializeField] GameObject text_ment_obj;
    [SerializeField] TextMeshProUGUI comber_text_int;//숫자용도
    [SerializeField] TextMeshProUGUI comber_text_st;//문자용도
    comber_data comber_temp;
    main_data_manager main_temp;
    // Start is called before the first frame update
    void Start()
    {
        comber_presenter_temp = this;
        first_setting();
    }
    public static comber_presenter get_comber_presenter()
    {
        if (comber_presenter_temp == null)
        {
            comber_presenter_temp = GameObject.FindGameObjectWithTag("main_pre").GetComponent<comber_presenter>();
        }
        return comber_presenter_temp;
    }
    void first_setting()
    {
        main_temp = main_data_manager.GetInstance();
        comber_temp = main_temp.get_comber_data();
    }
    public void set_comber_presenter()//콤버 활성화
    {
        comber_temp.comber_int++;
        if (comber_temp.max_comber_int < comber_temp.comber_int)
        {
            comber_temp.max_comber_int = comber_temp.comber_int;
        }
        switch (comber_temp.comber_int)
        {
            case 20:
                comber_temp.comber_cain_int = 1;
                check_img();
                break;
            case 50:
                comber_temp.comber_cain_int = 2;
                check_img();
                break;
            case 100:
                comber_temp.comber_cain_int = 3;
                check_img();
                break;
             
        }
        text_obj.SetActive(true);
        comber_text_int.SetText(comber_temp.comber_int.ToString());
        
    }
    void check_img()
    {
        
        main_temp.get_map_data().player_spead = main_temp.get_map_data().player_spead +main_temp.get_map_data().player_spead * comber_temp.comber_cain_int * 0.25f;//맵속도 변경
        text_ment_obj.SetActive(true);
        comber_text_st.SetText(comber_temp.cober_ment_st[comber_temp.comber_cain_int]);//맨트 변경 
    }
    public void reset_comber_presenter()//콤버 초기화
    {
        text_obj.SetActive(false);
        text_ment_obj.SetActive(false);
        comber_temp.comber_int = 0;
    }
}
