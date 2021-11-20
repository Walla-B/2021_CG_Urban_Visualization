using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeData
{
    public static void InitializePlanetData() {
        /* psudocode
        const List<string> data_names = new List<string> { "Transport", "Pollution", "Card_Usage" ...}

        foreach ( data_name in data_names ) {
            
            // Make new List<Balloon> for Planet
            List<Balloons> temp_balloonlist = new List<Balloon>();

            // Load Planet's Mesh from Prefab with data_name
            GameObject temp_planetMesh = Resources.Load("Prefabs/Planet_" + data_name) as GameObject;

            // If Balloon's mesh does not differ by planet, Option 1 can be used outside this foreach loop
            // [Opt1] GameObject temp_balloonMesh = Resources.Load("Prefabs/Balloon") as GameObject;
            // [Opt2] GameObject temp_balloonMesh = Resources.Load("Prefabs/Balloon_" + data_name) as GameObject;

            // Calculate each Planet's position with Number of Planets (data_names.Count)
            Vector3 temp_planetPosition = ...
            
            // open csv file with data_name and attach it to Stringreader

            // then, use stringreader to read each line
            while (!EOF) {
                // Read line by line
                string eachline;
                Balloon temp_balloon = InitializeBalloonData(eachline, temp_balloonMesh);

                temp_balloonlist.Add(temp_balloon);
            }

            // Create planet
            Planet temp_planet = PlanetManager.Instance.CreatePlanet( data_name, temp_planetPosition, temp_planetMesh, temp_balloonlist );
            PlanetManager.Instance.AddPlanetToMap( Planet temp_planet );
        }
        */
    }

    //private Balloon InitializeBalloonData(string line, GameObject balloonMesh) {
        /* psudocode
        // split line with ','
        string[] data_array = line.Split(',');

        // with data_array[n], calculate arguments needed for CreateBalloon().

        temp_balloonPosition = ...
        temp_sizeOffset = ...
        temp_isBeforeCovid = ...
        temp_balloonColor = new Color(r,g,b);
        
        Balloon temp_balloon = BalloonManager.Instance.CreateBalloon( ... , balloonMesh , ... );
        BalloonManager.Instance.AddBalloonToMap(temp_balloon);

        return temp_balloon;
        */
    //}
    
}
