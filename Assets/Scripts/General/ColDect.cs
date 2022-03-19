using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ColDect : MonoBehaviour
{
    public Text OutOfBoundsAlarm;

    private void Start()
    {
        OutOfBoundsAlarm.enabled = false;
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(OutOfBounds());
        }
    }

    IEnumerator OutOfBounds()
    {
        OutOfBoundsAlarm.enabled = true;
        OutOfBoundsAlarm.text = "You can not move out of the maze";
        yield return new WaitForSeconds(3);
        OutOfBoundsAlarm.enabled = false;

    }
}
