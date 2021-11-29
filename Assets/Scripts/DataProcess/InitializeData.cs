using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InitializeData
{
    public static void InitializePlanetData() {
        List<string> data_names = new List<string> { "일별 교통량", "일별 대중교통 이용량", "따릉이 이용현황", "대기오염도", "일별 카드 결제건수", "골목상권 업소별 매출", "주요상권 일별 유동인구", "인천공항 출입 화물갯수" };
        List<string> metadata = new List<string> {
         "데이터 : 일별 교통량,단위 - 일별,색상 - 지점 코드 A~F,크기 - 교통량,경도 - 일자,위도 - 시간대,거리 - 지점,기간(코로나 이전) : 2019/6/1 ~ 2019/11/30,기간(코로나 이후) - 2020/7/1 ~ 2021/1/30,출처 - 서울 교통정보 센터"
        ,"데이터 : 일별 대중교통 이용량,단위 - 일별,색상 - 교통수단,크기 - 이용량,경도 - 일자,위도 - 시간대,거리 - 구,기간(코로나 이전) : 2019/6/1 ~ 2019/11/30,기간(코로나 이후) - 2020/7/1 ~ 2021/1/30,출처 - 교통카드 빅데이터 시스템"
        ,"데이터 : 따릉이 이용현황,단위 - 건수별,색상 - 이동거리,크기 - 사용시간,경도 - 일자,위도 - 시간대,거리 - ?,기간(코로나 이전) : 2019/6/1 ~ 2019/11/30,기간(코로나 이후) - 2020/7/1 ~ 2021/1/30,출처 - 서울시 열린 데이터 광장"
        ,"데이터 : 대기오염도,단위 - 일별&측정소별,색상 - 오염원 구분,크기 - 오염원양,경도 - 일자,위도 - ?,거리 - ?,기간(코로나 이전) : 2019년 전체,기간(코로나 이후) - 2020년 전체,출처 - 서울시 열린 데이터 광장"
        ,"데이터 : 일별 카드 결제건수,단위 - 일별,색상 - 업종,크기 - 매출액,경도 - 일자,위도 - ?,거리 - ?,기간(코로나 이전) : 2019/1/1 ~ 2019/6/30,기간(코로나 이후) - 2020/1/1 ~ 2021/6/30,출처 - 한국 데이터 거래소"
        ,"데이터 : 골목상권 업소별 매출,단위 - 상권별&업종별,색상 - 업종,크기 - 매출액,경도 - 일자,위도 - ?,거리 - ?,기간(코로나 이전) : 2019/1/1 ~ 2019/6/30,기간(코로나 이후) - 2020/1/1 ~ 2020/6/30,출처 - 서울시 우리 마을가게 상권 분석"
        ,"데이터 : 주요상권 일별 유동인구,단위 - 일별&상권별,색상 - 상권,크기 - 유동인구수,경도 - 일자,위도 - ?,거리 - ?,기간(코로나 이전) : 2019/12/1 ~ 2019/12/31,기간(코로나 이후) - 2020/1/1 ~ 2020/2/8,출처 - 한국 데이터 거래소"
        ,"데이터 : 인천공항 출입 화물갯수,단위 - 일별,색상 - 구분,크기 - 운항수,경도 - 일자,위도 - 시간대,거리 - 지점,기간(코로나 이전) : 2019/1/1 ~ 2019/3/31,기간(코로나 이후) - 2021/1/1 ~ 2021/3/31,출처 - 인천공항" };
        
        for ( int planetNo = 0; planetNo < data_names.Count; planetNo++) {
            // Make new List<Balloon> for Planet
            List<Balloon> temp_balloonlist = new List<Balloon>();

            // Load Planet's Mesh from Prefab with data_name
            GameObject temp_planetMesh = Resources.Load("Prefabs/Planet_" + data_names[planetNo]) as GameObject;

            // If Balloon's mesh does not differ by planet, Option 1 can be used outside this foreach loop
            // [Opt1] GameObject temp_balloonMesh = Resources.Load("Prefabs/Balloon") as GameObject;
            // [Opt2] GameObject temp_balloonMesh = Resources.Load("Prefabs/Balloon_" + data_names[i]) as GameObject;
            GameObject temp_balloonMesh = Resources.Load("Prefabs/Balloon") as GameObject;

            // Calculate each Planet's position with Number of Planets (data_names.Count)
            const float radius = 10.0f;
            float angle = (2 * Mathf.PI * planetNo) / data_names.Count;
            float x = Mathf.Sin(angle) * radius;
            float z = Mathf.Cos(angle) * radius;

            Vector3 temp_planetPosition = new Vector3(x,0f,z);
            Debug.Log(temp_planetPosition);
            
            // open csv file with data_names[i] and attach it to Stringreader
            TextAsset sourcefile = Resources.Load<TextAsset>(data_names[planetNo]);
            StringReader sr = new StringReader(sourcefile.text);
            
            string line;
            bool endOfFile = false;
            // then, use stringreader to read each line
            while (!endOfFile) {
                // Read line by line
                line = sr.ReadLine();

                if( line==null ){
                    endOfFile = true;
                    break;
                }

                Balloon temp_balloon = InitializeBalloonData(line, temp_balloonMesh);
                temp_balloonlist.Add(temp_balloon);
            }

            // Create planet
            Planet temp_planet = PlanetManager.Instance.CreatePlanet( data_names[planetNo], temp_planetPosition, temp_planetMesh, temp_balloonlist );
            temp_planet.SetPlanetMetaData(metadata[planetNo].Split(','));
            PlanetManager.Instance.AddPlanetToMap(temp_planet);
        }
    }

    private static Balloon InitializeBalloonData(string line, GameObject balloonMesh) {
        // split line with ','
        string[] data_array = line.Split(',');

        // with data_array[n], calculate arguments needed for CreateBalloon().
        /*
        temp_balloonPosition = ...
        temp_sizeOffset = ...
        temp_isBeforeCovid = ...
        temp_balloonColor = new Color(r,g,b);
        
        Balloon temp_balloon = BalloonManager.Instance.CreateBalloon( ... , balloonMesh , ... );
        BalloonManager.Instance.AddBalloonToMap(temp_balloon);
        */
        Balloon temp_balloon = BalloonManager.Instance.CreateBalloon(new Vector3(0f,0f,0f), 1.0f, true, balloonMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(temp_balloon);

        return temp_balloon;
    }
    
}
