using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.Linq;
using System.Text;
using System.IO;
using System;

public class TracerGlobal {
    // Singleton related
    private static TracerGlobal _singleton;

    public static TracerGlobal Instance
    {
        get {
            if (_singleton == null)
            {
                _singleton = new TracerGlobal();
            }
            return _singleton;
        }
    }

    // Tracer related
    class LogEntry
    {
        public float timer;
        public object data;

        public override string ToString()
        {
            return timer.ToString() + "," + data.ToString();
        }
    }

    private Dictionary<string, List<LogEntry>> log_ = new Dictionary<string, List<LogEntry>>();

    public void Record(string target, float timer, object data)
    {
        if (!log_.ContainsKey(target))
        {
            log_[target] = new List<LogEntry>();
        }

        Debug.Assert(log_.ContainsKey(target));

        log_[target].Add(new LogEntry
        {
            timer = timer,
            data = data
        });
    }

    public void DumpToFile()
    {
        foreach (KeyValuePair<string, List<LogEntry>> kv in log_)
        {
            string filename = kv.Key;
            List<LogEntry> logs = kv.Value;
            
            UnityEngine.Windows.File.WriteAllBytes(
                Path.Combine(Application.dataPath, filename + ".log"),
                Encoding.UTF8.GetBytes(
                    logs
                    .Select(log => log.ToString())
                    .Aggregate((left, right) => left + "\n" + right)));
        }
    }

}
