using System.Collections.Generic;
using App.Library.Logger.Handlers;
using App.Library.Logger.Utils;

namespace App.Library.Logger
{
    public class Logger
    {
        private List<AbstractHandler> Handlers;
        private string Name;

        public Logger(string name = "NETCORE-LOGGER")
        {
            Name = name;
            Handlers = new List<AbstractHandler>();
        }

        public string GetName()
        {
            return Name;
        }

        public void AddHandler(AbstractHandler handler)
        {
            Handlers.Add(handler);
        }

        public List<AbstractHandler> GetHandlers()
        {
            return Handlers;
        }

        public void Emergency(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.EMERGENCY);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Alert(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.ALERT);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Critical(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.CRITICAL);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Error(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.ERROR);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Warning(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.WARNING);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Notice(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.NOTICE);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Info(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.INFO);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }

        public void Debug(Dictionary<string, string> data, string[] extras = null)
        {
            foreach (var handler in Handlers)
            {
                handler.SetLevel(LevelUtil.DEBUG);
                handler.SetName(Name);
                handler.Write(data, extras);
            }
        }
    }
}
