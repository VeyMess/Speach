using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Speach
{
    class Profiles
    {
        private XmlDocument doc;
        private List<Rule> rules;
        private string name;

        private Dictionary<string,Rule> wordRule;

        private void OpenXmlProf()
        {
            doc.Load(Application.StartupPath + "\\Profiles\\" + name + ".spprof");

            XmlElement root = doc.DocumentElement;
            foreach(XmlNode rule in root.ChildNodes)
            {
                if(rule.Name=="rule")
                {
                    Rule rnd = new Rule(rule.Attributes["id"].Value);

                    foreach(XmlNode rNode in rule.ChildNodes)
                    {
                        if(rNode.Name=="dictionary")
                        {
                            foreach(XmlNode wNode in rNode.ChildNodes)
                            {
                                if(wNode.Name=="word")
                                {
                                    rnd.AddWord(wNode.InnerText); 
                                }
                            }
                        }
                        else if(rNode.Name=="command")
                        {
                            rnd.Command = rNode.InnerText;
                        }
                    }

                    rules.Add(rnd);
                }
            }

            foreach(Rule rnd in rules)
            {
                foreach(string word in rnd)
                {
                    wordRule.Add(word,rnd);
                }
            }
        }
    }
}
