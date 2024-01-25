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

    // Find the distance between player and object they want to collect
    // If they haven't collected it, then "collect" by updating text
    // If they've already collected it - do nothing (this is controlled by the booleans)
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1.5) {
            if (notebookFound == false) {
                notebookFound = true;
                itemsFound++;
                text = newHint();
            }
        }


        if (notebookFound) {
            if (Vector3.Distance(player.transform.position, blankets.transform.position) < 2
            || Vector3.Distance(player.transform.position, blankets2.transform.position) < 2) {
                if (blanketsFound == false) {
                    blanketsFound = true;
                    itemsFound++;
                    text = newHint();
                }
            }

            if (Vector3.Distance(player.transform.position, matches.transform.position) < 1) {
                if (matchesFound == false) {
                    matchesFound = true;
                    itemsFound++;
                    text = newHint();
                }
            }

            if (Vector3.Distance(player.transform.position, wood.transform.position) < 1.5) {
                if (woodFound == false) {
                    woodFound = true;
                    itemsFound++;
                    text = newHint();
                }
            }
        }
    }

    string newHint() {
        if (itemsFound == 4) {
            return "Congrats! You've found all the items. \n \n 4/4";
        } else if (!woodFound) {
            return "To do: restock wood in backroom. \n \n " + itemsFound + " / " + totalItems;
        } else if (!blanketsFound) {
            return "Too lazy to make my bed properly today. \n \n " + itemsFound + " / " + totalItems;
        } else {
            return "Left the matches out after lighting the birthday cake candles. I should buy more cake. \n \n " + itemsFound + " / " + totalItems;
        }
        return " ";
    }

    void OnGUI() {

        if (GUI.Button (new Rect (25, 25, 300, 200), text)) {
        }
    }
}
