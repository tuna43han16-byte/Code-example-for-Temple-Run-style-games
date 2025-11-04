using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject yolPrefab; 
    public Transform oyuncu; 
    public float yolUzunlugu = 200f; 
    
    private List<GameObject> aktifYollar = new List<GameObject>();
    private float spawnPozisyonZ = 0f; 

    void Start()
    {
        // Başlangıçta birkaç tane yol oluşturalım
        for (int i = 0; i < 3; i++)
        {
            SpawnYol();
        }
    }

    void Update()
    {

        if (oyuncu.position.z > (spawnPozisyonZ - 2 * yolUzunlugu))
        {
            SpawnYol();
            EskiYoluSil();
        }
    }

    private void SpawnYol()
    {
        GameObject yeniYol = Instantiate(yolPrefab, new Vector3(0, 0, spawnPozisyonZ), Quaternion.identity);
        aktifYollar.Add(yeniYol); 
        
        spawnPozisyonZ += yolUzunlugu;
    }

    private void EskiYoluSil()
    {
        if (aktifYollar.Count > 3)
        {
            Destroy(aktifYollar[0]); // En eski yolu (listenin başındakini) sil
            aktifYollar.RemoveAt(0); // Listeden çıkar
        }
    }
}
