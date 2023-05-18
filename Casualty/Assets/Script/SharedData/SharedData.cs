using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shared Data", menuName = "Shared Data", order = 1)]
public class SharedData : ScriptableObject
{
    public string name;
    public List<string> list; //���� �ʿ��� ���� �߰��ؼ� ����ϼ���!
    
    public bool initial = false;                         //�ʾ� ���ε���� �ִ��� ����

    public bool patient1 = false;                         //�ʱ⿡ patient 3�� óġ
    public bool patient2 = false;                         //���� �ߴ��� Ȯ��
    public bool patient3 = false;                         //

    public int dillemaPatient;      //A ->0, B->1

    public bool dillemaRunOver= false; // ���������� ���ӿ���(�����̵�ƴϵ�)���� = true

}