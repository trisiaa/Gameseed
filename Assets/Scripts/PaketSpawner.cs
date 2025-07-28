using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaketSpawnerTroli : MonoBehaviour
{
    public GameObject[] paketPrefabs;
    public RectTransform spawnPoint;
    public RectTransform targetPoint;
    public float spawnInterval = 3f;
    public float speedTurun = 50f;
    public float jarakTumpuk = 300f;

    private List<GameObject> semuaPaket = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnPaketBaru();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        for (int i = 0; i < semuaPaket.Count; i++)
        {
            if (semuaPaket[i] != null)
            {
                RectTransform rt = semuaPaket[i].GetComponent<RectTransform>();

                float targetY = targetPoint.anchoredPosition.y + i * jarakTumpuk;

                Vector2 current = rt.anchoredPosition;
                current.y = Mathf.MoveTowards(current.y, targetY, speedTurun * Time.deltaTime);
                rt.anchoredPosition = current;
            }
        }
    }

    void SpawnPaketBaru()
    {
        int index = Random.Range(0, paketPrefabs.Length);
        GameObject paket = Instantiate(paketPrefabs[index], spawnPoint);
        RectTransform rt = paket.GetComponent<RectTransform>();
        rt.localScale = Vector3.one;
        rt.anchoredPosition = Vector2.zero;

        semuaPaket.Add(paket);
    }

    public void HentikanGerakPaket(GameObject paket)
    {
        if (semuaPaket.Contains(paket))
        {
            semuaPaket.Remove(paket);
        }
    }
}
