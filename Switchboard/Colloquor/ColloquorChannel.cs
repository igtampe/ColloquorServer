using Switchboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colloquor {
        public class ColloquorChannel {

        private String LastMessage;
        
        private readonly String Name;
        private readonly String Welcome;
        private readonly String Password;

        public ColloquorChannel(String Name,  String Welcome,String Password) {
            this.Name = Name;
            this.Welcome = Welcome;
            this.Password = Password;
        }

        public Boolean VerifyPassword(String Attempt) {
            if(!HasPassword()) { return true; } //I guess if a channel doesn't have a password any password should do.
            return Password == Attempt;
        }

        public String GetWelcome() { return Welcome; }

        public void ReceiveMessage(String Message) { LastMessage = Message; }
        public string GetLastMessage() { return LastMessage; }

        public bool HasPassword() { return String.IsNullOrWhiteSpace(Password); }

        public override string ToString() {return String.Join(":",Name,Welcome,Password);}
        public String ToListChannelString() {return String.Join(":",Name,HasPassword()); }

    }
}
