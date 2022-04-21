using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using Dummiesman;

public class MeshDownloader : MonoBehaviour
{
    string APIkey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwdWJsaWNfaWQiOiI0NjdjMWExOS0xOWU4LTRlOTItYjc2ZC00ZmVjYWIwMWJjMjIifQ.WfCD9CvA7DAFUEobFlAmCHZX41jddclXDJgiBxCpqko";
    long seg_id = 864691135822954356;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("downloadMesh");
        //yield return www.SendWebRequest();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    IEnumerator downloadMesh()
    {
        string url = "https://mesh.neuvue.io/download";
        url += "?seg_ids=" + seg_id;
        string meshDownloadPath = Path.Combine(Application.temporaryCachePath, seg_id + ".obj");
        UnityWebRequest DownloadRequest = UnityWebRequest.Get(url);
        DownloadRequest.SetRequestHeader("x-access-tokens", APIkey);
        DownloadRequest.downloadHandler = new DownloadHandlerFile(meshDownloadPath);

        yield return DownloadRequest.SendWebRequest();

        if (DownloadRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(DownloadRequest.error);
        }
        else
        {
            GameObject loadedMesh = new OBJLoader().Load(meshDownloadPath);
            //loadedMesh.GetComponentInChildren<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

            loadedMesh.GetComponentInChildren<Transform>().localScale = new Vector3(0.001f, 0.001f, 0.001f);
            //Debug.Log(meshDownloadPath);
            //GameObject mesh = Resources.Load(meshDownloadPath) as GameObject;
            //GameObject meshInstance = Instantiate(mesh);


        }

        //JSONNode METARInfo = JSON.Parse(METARInfoRequest.downloadHandler.text);

        //string METAR = METARInfo["sanitized"];

        //print("The METAR for EGSS is: " + METAR);
    }

}
