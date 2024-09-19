using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_ui_presenter : MonoBehaviour
{
    [SerializeField] GameObject clear_ui;
    [SerializeField] GameObject faild_ui;
    main_data_manager main_temp;

    // Update is called once per frame
    private void Start()
    {
        main_temp = main_data_manager.GetInstance();
    }
    void Update()
    {

        if (main_temp.save_data_temp.boss_die)
        {
            clear_ui.SetActive(true);
        }
        else if (main_temp.save_data_temp.boos_miss)
        {
            faild_ui.SetActive(true);
        }   
    }
}
