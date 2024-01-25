using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour
{
    public GameObject player;
    public GameObject blankets;
    public GameObject blankets2;
    public GameObject matches;
    public GameObject wood;
    int itemsFound; // shows the number of items found out of total
    int totalItems; // notebook, blankets, matches, wood
    bool notebookFound;
    bool blanketsFound;
    bool matchesFound;
    bool woodFound;
    string text;
    // Start is called before the first frame update
    void Start()
    {
        itemsFound = 0;
        totalItems = 4;
        notebookFound = false;
        blanketsFound = false;
        matchesFound = false;
        woodFound = false;
        text = " ";
    }

    // Script's kind of broken??? Only matches work on my end
    // Anyways it's supposed to find the distance between player and object they want to collect
    // If they haven't collected it, then "collect" by updating text
    // If they've already collected it - do nothing (this is controlled by the booleans)
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1) {
            if (notebookFound == false) {
                notebookFound = true;
                text = "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
                itemsFound++;
            }
        }

        if (Vector3.Distance(player.transform.position, blankets.transform.position) < 1) {
            if (blanketsFound == false) {
                blanketsFound = true;
                itemsFound++;
                text = "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
            }
        }

        if (Vector3.Distance(player.transform.position, blankets2.transform.position) < 1) {
            if (blanketsFound == false) {
                blanketsFound = true;
                itemsFound++;
                text = "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
            }
        }

        if (Vector3.Distance(player.transform.position, matches.transform.position) < 1) {
            if (matchesFound == false) {
                matchesFound = true;
                itemsFound++;
                text = "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
            }
        }

        if (Vector3.Distance(player.transform.position, wood.transform.position) < 1) {
            if (woodFound == false) {
                woodFound = true;
                itemsFound++;
                text = "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
            }
        }
    }

    void OnGUI() {

        if (GUI.Button (new Rect (25, 25, 300, 200), text)) {
        }
    }
}
