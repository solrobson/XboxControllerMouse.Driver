using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using XboxControllerMouse.Library.Actions;
using XboxControllerMouse.Library.Actions.MouseEvents;

namespace XboxControllerMouse.Library.Configuration
{
    public class XInputControllerConfigManager
    {
        private Dictionary<string, IXinputAction> ActionDictionary;

        public XInputControllerConfigManager()
        {
            ActionDictionary = new Dictionary<string, IXinputAction>();
        }

        public void ExecuteAction(string key)
        {
            IXinputAction action;

            if (!ActionDictionary.ContainsKey(key))
            {
                action = GetAction(key);

                if (action == null)
                {
                    return;
                }

                ActionDictionary.Add(key, action);
            }

            action = ActionDictionary[key];

            action.Event();
        }

        private IXinputAction GetAction(string key)
        {
            var assembly = ConfigurationManager.AppSettings[key];

            if(String.IsNullOrWhiteSpace(assembly))
            {
                return new DefaultAction();
            }

            var action = Assembly.GetExecutingAssembly().CreateInstance(assembly) as IXinputAction;
            return action;
        }
    }
}
