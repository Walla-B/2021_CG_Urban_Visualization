using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // on Awake(), init all manager classes
    void Awake() {
        PlanetManager.Instance.enabled = true;
        BalloonManager.Instance.enabled = true;
        InputManager.Instance.enabled = true;
        CameraManager.Instance.enabled = true;
    }

    // Initialize data
    void Start() {
        InitializeData.InitializePlanetData();

        /* TESTCODE
        
        GameObject samplePlanetMesh = Resources.Load("Prefabs/Sphere") as GameObject;
        GameObject sampleBalloontMesh = Resources.Load("Prefabs/Cube") as GameObject;

        var sampleBalloonList1 = new List<Balloon>();

        var sampleballoon1 = BalloonManager.Instance.CreateBalloon(new Vector3(5f,0f,0f), 3.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon1);
        var sampleballoon2 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,5f,0f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon2);
        var sampleballoon3 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,0f,5f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon3);

        sampleBalloonList1.Add(sampleballoon1);
        sampleBalloonList1.Add(sampleballoon2);
        sampleBalloonList1.Add(sampleballoon3);

        var samplePlanet1 = PlanetManager.Instance.CreatePlanet("samplePlanet1",new Vector3(10f,0f,0f), samplePlanetMesh,sampleBalloonList1);
        PlanetManager.Instance.AddPlanetToMap(samplePlanet1);


        var sampleBalloonList2 = new List<Balloon>();
        
        var sampleballoon4 = BalloonManager.Instance.CreateBalloon(new Vector3(5f,0f,0f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon4);
        var sampleballoon5 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,5f,0f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon5);
        var sampleballoon6 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,0f,5f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon6);

        sampleBalloonList2.Add(sampleballoon4);
        sampleBalloonList2.Add(sampleballoon5);
        sampleBalloonList2.Add(sampleballoon6);

        var samplePlanet2 = PlanetManager.Instance.CreatePlanet("samplePlanet2",new Vector3(0f,10f,0f), samplePlanetMesh,sampleBalloonList2);
        PlanetManager.Instance.AddPlanetToMap(samplePlanet2);


        var sampleBalloonList3 = new List<Balloon>();

        var sampleballoon7 = BalloonManager.Instance.CreateBalloon(new Vector3(5f,0f,0f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon7);
        var sampleballoon8 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,5f,0f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon8);
        var sampleballoon9 = BalloonManager.Instance.CreateBalloon(new Vector3(0f,0f,5f), 1.0f, true, sampleBalloontMesh, Color.red);
        BalloonManager.Instance.AddBalloonToMap(sampleballoon9);

        sampleBalloonList3.Add(sampleballoon7);
        sampleBalloonList3.Add(sampleballoon8);
        sampleBalloonList3.Add(sampleballoon9);

        var samplePlanet3 = PlanetManager.Instance.CreatePlanet("samplePlanet3",new Vector3(0f,0f,10f), samplePlanetMesh,sampleBalloonList3);
        PlanetManager.Instance.AddPlanetToMap(samplePlanet3);
        
        // Instantiate all planets
        PlanetManager.Instance.InstantiateAllPlanets();

        // Access Instantiated Planets / Balloons
        PlanetManager.Instance.GetPlanet_GameObjectWithName("samplePlanet1").GetComponent<MeshRenderer>().material.color = Color.red;

        */
    }

    // Handle Project Logics
    void Update(){
    }
}