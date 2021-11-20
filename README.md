# 2021_CG_Urban_Visualization
Urban data visualization

기본 시스템 구조도
----
![image](https://github.com/Walla-B/2021_CG_Urban_Visualization/blob/main/Markdownimg/Project_Structure_flow.png?raw=true)

Balloon, Planet 클래스 구조도
----
![image](https://github.com/Walla-B/2021_CG_Urban_Visualization/blob/main/Markdownimg/Project_Structure_structure.png?raw=true)

Prefab
----
![image](https://github.com/Walla-B/2021_CG_Urban_Visualization/blob/main/Markdownimg/Project_Structure_prefab.png?raw=true)

Balloon, Planet의 변수 시각화
----
![image](https://github.com/Walla-B/2021_CG_Urban_Visualization/blob/main/Markdownimg/Project_Structure_visualize.png?raw=true)

추가설명
----
> 클래스 구조도 속 xxxMap과 xxx_GameObjectMap의 차이점은?

planetMap, balloonMap은 각각 Planet, Balloon이라는
클래스의 리스트를 가지고 있는 Dictionary이고,

planet_GameObjectMap, balloon_GameObjectMap은
각각 planetMap, balloonMap을 참고하여
런타임에 인스턴스화시킨 (Hierarchy 뷰에 보이는)
게임오브젝트들의 Dictionary이다.

따라서 플레이모드 화면 내의 Planet, Balloon GameObject의
속성을 바꾸고 싶다면

GetPlanetByName( )이 아닌,
GetPlanet_GameObjectWithName( ) 멤버 변수를 사용해야한다.

> Planet, Balloon 클래스의 생성자가 있는데도 직접 호출하지 않고 PlanetManager, BalloonManager의
CreatePlanet( ), CreateBalloon( )을 통해간접적으로 생성하는 이유는?

Balloon 클래스의 생성자를 보면 각 Balloon들을 구분하기 위한
Key값인 BalloonName 프로퍼티가 있으며, 이는 각 Balloon마다
고유한 값이어야 한다.
하지만 이 값을 생성할때마다 직접 인수로 넘겨주게 되면 복잡하므로
이 값의 설정은 CreateBalloon( ) 내에서 나머지 인수만 전달해주면
중복되지 않는 값으로 자동으로 설정해준다.

CreatePlanet( ) 멤버함수의 경우에는 CreateBalloon( )과
통일성을 맞춰주기 위하여 만들었다

또한, Get...ByName( ) 을 사용하기 위해서는 CreatePlanet( ) 후 

반드시 Add...ToMap( ) 을 통해 Dictionary에 넣어주어야 접근이 가능해진다.

> 네번째 이미지 추가설명

해당 값들은 Planet, Balloon을 인스턴스화시키기 위한 값들을
시각화한 것이며,

인스턴스화된 게임오브젝트의 속성을 바꾸고싶다면 (예시-위치 변경)

[잘못된 예]
```csharp
PlanetManager.Instance.GetPlanet(”Transport”).PlanetPosition += new Vector3 offset;
```
[옳은 예]
```csharp
PlanetManager.Instance.GetPlanet_GameObjectByName(”Transport”).transform.position += new Vector3 offset;
```

와 같이 접근해야한다. Planet의 속성들은 모두 읽기 전용으로 설정해두었으므로 변수를
직접 변경하는것은 불가능하다.
