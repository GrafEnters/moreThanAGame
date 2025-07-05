using UnityEngine;
public class Plant : MonoBehaviour {
  
    public float Height = 5;
    public float GrowSpeed;

    public float MaxHeight = 20;
    public float StartingHeight = 10;
    public float TopRadius = 5;
    public float HeightPerApple = 1;
    
    [Header("Links")]
    public Transform PlantTransform;
    public Transform PlantTop;
    public GameObject Crop;
    
    void Start() {
        Height = StartingHeight;
        UpdateHeight();
    }
    
    public void DropCrop() {
        Height = Height - HeightPerApple;
        CreateApple();
        UpdateHeight();
    }
  
    void UpdateHeight() {
        var vec = PlantTransform.localScale;
        vec.y = Height;
        PlantTransform.localScale = vec;
        
        var pos = PlantTransform.position;
        pos.y = Height;
        PlantTransform.position = pos;
        

        var vec1 = PlantTop.position;
        vec1.y = Height*2;
        PlantTop.position = vec1;
    }

    void MoveTopToPlant() {
        var vec = PlantTop.position;
        vec.z = PlantTransform.position.z;
        vec.x = PlantTransform.position.x;
        PlantTop.position = vec;
    }
    
    void Update() {
        Height += GrowSpeed;
        if (Height > MaxHeight) {
            DropCrop();
        }
        UpdateHeight();
        MoveTopToPlant();
    }
    void CreateApple() {
        var plantPos = PlantTop.position;
        var appleShift = new Vector3(Random.Range(-TopRadius, TopRadius), 0, Random.Range(-TopRadius, TopRadius));

        Instantiate(Crop, plantPos + appleShift, Quaternion.identity);
    }
}