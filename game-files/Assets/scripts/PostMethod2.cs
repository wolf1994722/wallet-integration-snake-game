//PostMethod.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

// public class Mint2
// {
//     public string chain;
//     public string name;
//     public string description;
//     public string file_url;
//     public string mint_to_address;
// }

public class PostMethod2 : MonoBehaviour
{
    private string address;

    InputField outputArea;

    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostDataCoroutine());

    IEnumerator PostDataCoroutine()
    {
        outputArea.text = "Loading...";
        string url = "https://api.nftport.xyz/v0/mints/easy/urls";
        var uwr = new UnityWebRequest(url, "POST");

        // Set the values for the NFT you want to mint
        Mint nft = new Mint();
        nft.chain = "polygon";
        nft.name = "Snake PASS";
        nft.description = "PASS WON FOR SNAKE GAME COLLECTION";
        nft.file_url = "https://gateway.lighthouse.storage/ipfs/QmX5hp2ETEVkGpp4AJBfo8r6Qy5i8T1LstyFiBiihQTZNG";
        nft.mint_to_address = address;

        string json = JsonUtility.ToJson(nft);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);

        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        //Set headers for the request
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.SetRequestHeader("Authorization", "6a6e5864-aedf-463f-b939-19ee2b53192d");

        //Makes request
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
            outputArea.text = uwr.error;
        else
        {
            outputArea.text = uwr.downloadHandler.text;


        }

        if (outputArea.text.Contains("PASS WON FOR SNAKE GAME COLLECTION"))
            SceneManager.LoadScene("Minting");



    }

    public void ReadAddress(string Add)
    {
        address = Add;
        Debug.Log(Add);

    }
}