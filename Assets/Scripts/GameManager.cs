using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Alteruna.Trinity;

public class GameManager : MonoBehaviour
{
    private FoodFactory foodFactory;
    private Multiplayer Multiplayer;


    void Procedure(ushort fromUser, ProcedureParameters parameters, uint callid, ITransportStreamReader processor)
    {
        Debug.Log("Procedure");
        int anInt = parameters.Get("fVal", 1);
        //GetComponentInChildren<PlayerDataSynchronizable>().Score += anInt;
        Debug.Log(anInt);
    }

    void InvokeProcedureCall()
    {
        Debug.Log("InvokeProcedureCall");
        ProcedureParameters parameters = new();
        parameters.Set("fVal", 50);
        Multiplayer.InvokeRemoteProcedure("Procedure", UserId.All, parameters);
    }


    void Start()
    {
        foodFactory = GetComponent<FoodFactory>();
        Multiplayer = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<Multiplayer>();
        Multiplayer.RegisterRemoteProcedure("Procedure", Procedure);
    }
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            foodFactory.Create(1, new Vector3(Random.Range(-19, 19), Random.Range(-9, 9)));
            foodFactory.Create(2, new Vector3(Random.Range(-19, 19), Random.Range(-9, 9)));

        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            InvokeProcedureCall();
        }
    }
    
}
