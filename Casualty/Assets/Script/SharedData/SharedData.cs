using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shared Data", menuName = "Shared Data", order = 1)]
public class SharedData : ScriptableObject
{
    public string name;
    public List<string> list; //공유 필요한 변수 추가해서 사용하세요!
    
    public bool initial = false;                         //맵씬 업로드된적 있는지 여부

    public bool patient1 = false;                         //초기에 patient 3명 처치
    public bool patient2 = false;                         //전부 했는지 확인
    public bool patient3 = false;                         //

    public int dillemaPatient;      //A ->0, B->1

    public bool dillemaRunOver= false; // 딜레마씬의 게임오버(성공이든아니든)조건 = true

}