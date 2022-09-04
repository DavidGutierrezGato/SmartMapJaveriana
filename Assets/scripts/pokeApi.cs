using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class pokeApi
{
    public static pokemon darPokemon()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        return JsonUtility.FromJson<pokemon>(json);

    }
}
