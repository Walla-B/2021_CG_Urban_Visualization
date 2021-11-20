using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon
{   
    // Constructor with minimum equiered informations
    public Balloon(string _balloonName,Vector3 _balloonPosition, float _sizeOffset, bool _isBeforeCovid, GameObject _balloonMesh, Color _balloonColor) {
        this.BalloonName = _balloonName;
        this.BalloonPosition = _balloonPosition;
        this.SizeOffset = _sizeOffset;
        this.IsBeforeCovid = _isBeforeCovid;
        this.BalloonMesh = _balloonMesh;
        this.BalloonColor = _balloonColor;
    }
    
    public string BalloonName {get;}
    public Vector3 BalloonPosition {get;}
    public float SizeOffset {get;}
    public bool IsBeforeCovid {get;}
    public GameObject BalloonMesh {get;} 
    public Color BalloonColor {get;}


    // Optional data

    public void SetBalloonData(List<string> _dataString) {
        this.DataString = _dataString;
    }
    public List<string> DataString {get; set;}

}
