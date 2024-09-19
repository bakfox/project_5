using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stop_ui_presenter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] upgrade_ui_text;
    [SerializeField] GameObject stop_ui_obj;

    main_data_manager main_temp;
    private void Start()
    {
        main_temp = main_data_manager.GetInstance();
    }
    public void on_stop_ui()
    {
        stop_ui_obj.SetActive(true);
        main_temp.get_map_data().go_destination = true;
        check_upgrade();
    }
    void check_upgrade()
    {
        int i = -1;
        foreach (TextMeshProUGUI text_temp in upgrade_ui_text)
        {
            i++;
            text_temp.SetText("x " + main_temp.get_player_upgrade_data().upgrage_values[i]);
        }
    }
    public void off_stop_ui()
    {
        stop_ui_obj.SetActive(false);
        main_temp.get_map_data().go_destination = false;
    }
    public void restart_btn()
    {
        load_manager.LoadScene_fast("main_sc");
    }
}
