using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dmg_preseter : MonoBehaviour
{
    public TextMeshProUGUI text_temp;//ÀÚ½Å text
    main_data_manager main_temp;
    dmg_ui_data dmg_data_temp;

    public void OnEnable()
    {
        main_temp = main_data_manager.GetInstance();
        dmg_data_temp = GetComponent<dmg_ui_data>();
        transform.position = dmg_data_temp.now_postion;
        text_temp.SetText(main_temp.change_unit(dmg_data_temp.dmg_temp.ToString()));
        StartCoroutine("up_effect");
    }
    IEnumerator up_effect()
    {
        
        float time_temp = 0;
        while (dmg_data_temp.dmg_max_time > time_temp)
        {
            time_temp += Time.deltaTime;
            text_temp.color = new Color(text_temp.color.r, text_temp.color.g, text_temp.color.b, (1 - (time_temp )) );
            gameObject.transform.position = new Vector3(dmg_data_temp.now_postion.x, (dmg_data_temp.now_postion.y + (time_temp * 1f)+1), dmg_data_temp.now_postion.z);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log(gameObject.name);
        main_temp.dmg_mkaer.add_list(gameObject);
        gameObject.SetActive(false);
        StopCoroutine("up_effect");
    }
}
