using UnityEngine;
using System.Collections;

public class GuiInput : MonoBehaviour
{

    public bool guiEnabeled = false;
    public bool guiDisabled = false;
    public bool atTable = false;
    public bool atKeyA = false;
    public bool atKeyQ = false;
    public bool atKeyW = false;
    public bool keyA = false;
    public bool keyQ = false;
    public bool keyW = false;
    static string text = "";

    public string code = "public class game{\n" +
            "\tpublic static void main(String[] args){\n" +
            "\t\tgateLowered = " + "gateLowered" + ";\n" +
            "\t\tdoorOpen = " + "doorOpen" + ";\n";
    public string code2 =
          "\t\tholeOpen = " + "holeOpened" + ";\n" +
            "\t\tballMoving =" + "ballMoving" + ";\n" +
            "\t\t\n" +
            "\t}\n" +
            "}";
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "table")
        {
            atTable = true;
            
        }
        else if(col.gameObject.name == "KeyA"){

            atKeyA = true;
            Debug.Log("at key a");
        }
        else if(col.gameObject.name == "KeyQ")
        {
            atKeyQ = true;
            Debug.Log("at key q");
        }
        else if(col.gameObject.name == "KeyW")
        {
            atKeyW = true;
            Debug.Log("at key w");
        }


    }


    void OnTriggerExit(Collider col)
    {

          

            

         

        if (col.gameObject.name == "table")
        {
            atTable = false;
            guiEnabeled = false;
            guiDisabled = false;
            Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        }
        else if (col.gameObject.name == "KeyA")
        {

            atKeyA = false;
   
            Debug.Log("at key a");
        }
        else if (col.gameObject.name == "KeyQ")
        {
            atKeyQ = false;
            Debug.Log("at key q");
        }
        else if (col.gameObject.name == "KeyW")
        {
            atKeyW = false;
            Debug.Log("at key w");
        }
    }

    public void Update()
    {

        if (atTable)
        {
            if (Input.GetKeyDown("e"))
            {
                if (keyA && keyQ && keyW)
                {
                    guiEnabeled = true;
                    Camera.main.rect = new Rect(0.5f, 0f, 1f, 1f);
                }
                else
                {
                    guiDisabled = true;
                }
            }


        }

            else if (atKeyA)
            {

            if (Input.GetKeyDown("c"))
            {

                Debug.Log("destroy key");
                keyA = true;
                Destroy(GameObject.Find("KeyA"));
                atKeyA = false;
            }

            }


       else if (atKeyQ)
        {

            if (Input.GetKeyDown("c"))
            {

                Debug.Log("destroy key");
                keyQ = true;
                Destroy(GameObject.Find("KeyQ"));
                atKeyQ = false;
            }

        }


        else if (atKeyW)
        {

            if (Input.GetKeyDown("c"))
            {

                Debug.Log("destroy key");
                keyW = true;
                Destroy(GameObject.Find("KeyW"));
                atKeyW = false;
            }

        }

    }

    public void OnGUI()
    {
       
        if (guiEnabeled)
        {
            GUI.skin.label.fontSize = 35;
            GUI.Box(new Rect(0, 0, 960, 1200), "");



            GUI.Label(new Rect(Screen.width * 0.185f, Screen.height * 0.01f, Screen.width * 0.3f, Screen.height * 0.3f), "Input Console");

            text = GUI.TextField(new Rect(Screen.width * 0.1f, Screen.width * 0.20f, Screen.width * 0.3f, Screen.height * 0.05f), text);
            
            GUI.Label(new Rect(Screen.width * 0.1f, Screen.width * 0.25f, Screen.width * 0.75f, Screen.height * 0.9f), code2);

        }
        if (guiDisabled)
        {
            GUI.skin.label.fontSize = 20;
          

            GUI.Label(new Rect(Screen.width * 0.3f, Screen.height * 0.01f, Screen.width * 0.5f, Screen.height * 0.3f), "You must find all the missing keyboard keys to access the console");
        }
    }
}
