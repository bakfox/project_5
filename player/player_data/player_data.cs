using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data : MonoBehaviour
{
    public int defolt_hp = 50;
    public int defolt_atck = 10;

    public int hit_dmg = 0;//���� ������ 
    public float hit_ghost = 1f;//������ 1�� 
    public bool check_hit_ghost = false;//üũ�� 

    public int player_stause = 0;//0 �⺻,1 �ǰ�  ,2 ���� 
    public float drage_spead = 120f;//�ӵ� 
    public float drage_max = 3.7f;

    //���� ���� 
    public bool fire_swod = false;//�� 3��  �˱� Ȱ��ȭ
    public bool water_arrow = false;//�� 3�� Ȱ��ȭ�� ����

    //���� ����
    public float atck_swod = 2;//������ ���ݽ� 2��
    public float atck_sp_swod = 0.4f;//�˰��� 0.5�� ������ 
    public bool check_swod_cooltime = true;//�� ���� 
    public float swod_scope = 0.5f;//�⺻ 

    public float atck_sword_aura = 2.5f;// �˱� ������
    public float atck_sp_sword_aura = 10f;//10�� ������ 
    public bool check_atck_swoad_aura_cooltime = true;//�˱� ��

    public float atck_arrow = 3;//Ȱ���� ���ݽ� 3��
    public float atck_sp_arrow = 2;//��Ÿ�� 2�� 
    public bool check_arrow_cooltime = true;//Ȱ ���� 

    public int atck_glove = 2;//�۷���� ���ݽ� 2��
    public float atck_sp_glove = 0.5f;//��Ÿ�� ���� 

    //Ÿ�̹�
    public int timing_value = 2;//2������
    public float check_timing_m = 0;//Ÿ�̹� m_check
    public float best_timing_min = 18.5f;
    public float best_timing_max = 19.5f;

}
