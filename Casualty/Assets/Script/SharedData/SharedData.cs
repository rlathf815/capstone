using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shared Data", menuName = "Shared Data", order = 1)]
public class SharedData : ScriptableObject
{
    public string name;
    public List<string> list; //���� �ʿ��� ���� �߰��ؼ� ����ϼ���!
    
    public bool initial = true;                         //�ʾ� ���� �� �ִ��� ����, ó���̸� true

    public bool patient1 = false;                         //�ʱ⿡ patient 3�� óġ
    public bool patient2 = false;                         //���� �ߴ��� Ȯ��
    public bool patient3 = false;                         //

    public int dillemaPatient;      //A ->1, B->2. ���� chooseOne�� ���� �ʾ��� �� �⺻�� 0

    public bool dillemaRunOver= false; // ���������� ���ӿ���(�����̵�ƴϵ�)���� = true
    public bool bodyParked=false;   //��ü �����ٳ�����? (ȣ���� ��ȯ ���� ������)

    public bool HorrorInitial = true;   //ȣ���� ���� �� ������ true
    public bool hasEntered = false;

    public bool horrorPatient = false;

    public bool glitchOn = false;
}