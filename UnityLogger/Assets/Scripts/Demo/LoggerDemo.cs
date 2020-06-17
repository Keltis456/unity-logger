using UnityEngine;
using Logger;

namespace Demo
{
    public class LoggerDemo : MonoBehaviour
    {
        private readonly ILog log = LogFactory.CreateFor<LoggerDemo>();

        private void Awake()
        {
            log.Debug("Awake");
        }

        private void Start()
        {
            log.Debug("Start");
            log.Warning("Warning");
            log.Error("Error");
        }
    }
}
