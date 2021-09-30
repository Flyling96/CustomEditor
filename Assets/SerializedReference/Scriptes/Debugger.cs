using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Info
{
    public int m_Tid;
    public ulong m_Uid;
}

[Serializable]
public class TestInfo : Info
{
    public Vector2 m_Test;
}

[Serializable]
public class Shell
{
    [SerializeReference]
    public Info m_Info;

    public Shell()
    {
        m_Info = new TestInfo();
    }
}


[Serializable]
public class Shape
{
    public Vector3 m_Position;

    //public Shell[] m_Shells;

    [SerializeReference]
    public List<Info> infos = new List<Info>() { new TestInfo() }; 
}

[Serializable]
public class Box : Shape
{
    public Vector3 m_Elur;
    public Vector3 m_Scale;
}

[Serializable]

public class Sphere : Shape
{
    public float m_Radius;
}



public class Debugger : MonoBehaviour
{
    [SerializeReference]
    public Shape m_Shape = new Box();
}
