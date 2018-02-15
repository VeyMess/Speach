using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Speach
{
    class Rule : IEnumerable
    {
        List<string> words;
        string command;
        string name;

        public Rule(string n)
        {
            this.name = n;
            command = null;
            words = new List<string>();
        }

        public Rule()
        {
            name = null;
            command = null;
            words = new List<string>();
        }

        public void AddWord(string wrd)
        {
            words.Add(wrd);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)words).GetEnumerator();
        }

        public string Command
        {
            set { command = value; }
            get { return command; }
        }
    }
}
