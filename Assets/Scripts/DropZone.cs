using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null && dropped.CompareTag("Paket"))
        {
          
            RectTransform dropZoneRT = GetComponent<RectTransform>();
            Vector2 localPoint;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dropZoneRT,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint
            );

            dropped.transform.SetParent(this.transform);

           
            RectTransform rt = dropped.GetComponent<RectTransform>();
            rt.anchoredPosition = localPoint;

         
            PaketSpawnerTroli spawner = FindObjectOfType<PaketSpawnerTroli>();
            if (spawner != null)
            {
                spawner.HentikanGerakPaket(dropped);
            }
        }
    }
}
