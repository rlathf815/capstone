using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shared Data", menuName = "Shared Data", order = 1)]
public class SharedData : ScriptableObject
{
    public string name;
    public List<string> list; //공유 필요한 변수 추가해서 사용하세요!
    
    public bool initial = true;                         //맵씬 열린 적 있는지 여부, 처음이면 true

    public bool patient1 = false;                         //초기에 patient 3명 처치
    public bool patient2 = false;                         //전부 했는지 확인
    public bool patient3 = false;                         //

    public int dillemaPatient;      //A ->1, B->2. 아직 chooseOne씬 보지 않았을 땐 기본값 0

    public bool dillemaRunOver= false; // 딜레마씬의 게임오버(성공이든아니든)조건 = true
    public bool bodyParked=false;   //시체 가져다놨는지? (호러씬 전환 위한 데이터)

    public bool HorrorInitial = true;   //호러씬 열린 적 있으면 true
    public bool hasEntered = false;

    public bool horrorPatient = false;

    public bool glitchOn = false;
}