using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRHMDTracer
{
    static public XRHMDTracer Singleton
    {
        get { return _singleton; }
    }

    private static readonly XRHMDTracer _singleton = new XRHMDTracer();

    public class Trace
    {
        public float Timer;
        public Vector3 Direction;
        public Vector3 Position;

        public override string ToString()
        {
            return string.Format("%f,%f,%f,%f,%f,%f,%f",
                Timer, Direction.x, Direction.y, Direction.z, Position.x, Position.y, Position.z);
        }
    }

    public List<Trace> traces = new List<Trace>();

    public void Insert(float timer, Vector3 direction, Vector3 position)
    {
        var trace = new Trace
        {
            Timer = timer,
            Direction = direction,
            Position = position
        };

        traces.Add(trace);
    }

    public void Clear()
    {
        traces.Clear();
    }

    public override string ToString()
    {
        string output = "";

        foreach (var trace in traces)
        {
            output += trace.ToString() + "\n";
        }

        return output;
    }
}
