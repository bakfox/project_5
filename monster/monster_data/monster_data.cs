using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_data : MonoBehaviour
{
    public int monster_hp = 20;
    public int atck_dmg = 5;
    public int monster_statuse = 0;

    public int hit_dmg = 0;//���� ���� ������ 
    public float hit_value = 0;//ġ��Ÿ���� �ƴ���

    public bool nuck_back = false;//�˹� �鿪����?
    public float nuck_bakc_m = 1f;// �˹� ��ġ 

    public bool boss_check_pls = false;//������ üũ üũ�ҽ� boss_ui_data���� �޾ƿ� 
}
