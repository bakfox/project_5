using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgrade_presenter : MonoBehaviour
{
    [SerializeField] int this_id;//�̰��� ���̵� 
    public int this_upgrade;//���׷��̵� ��ġ
    [SerializeField] Image upgrade_image_temp;
    [SerializeField] TextMeshProUGUI upgrade_text_temp;

    main_data_manager main_temp;
    player_upgrade_data player_upgrade;
    private void Start()
    {
        main_temp = main_data_manager.GetInstance();
        player_upgrade = main_temp.get_player_upgrade_data();
        set_upgrade_img();
    }
    public void set_upgrade_img()//�̹��� ���ű׷��뵵 
    {
        if (main_temp == null)
        {
            main_temp = main_data_manager.GetInstance();
            player_upgrade = main_temp.get_player_upgrade_data();
        }
        upgrade_image_temp.sprite = GetComponent<upgrade_ui_data>().upgrade_sp[this_id];
        this_id = GetComponent<upgrade_ui_data>().upgrade_id;
        this_upgrade = player_upgrade.upgrage_values[this_id];
        upgrade_text_temp.SetText(this_upgrade+" x");
    }
}
