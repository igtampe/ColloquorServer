using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Colloquor {
    public partial class ColloquorSettings:Form {

        //------------------------------[Variables]------------------------------

        public int PermissionLevel = 1;
        public List<ColloquorChannel> AllChannels;

        //------------------------------[Constructor]------------------------------

        public ColloquorSettings(int PermissionLevel, List<ColloquorChannel> AllChannels) {
            InitializeComponent();
            this.PermissionLevel = PermissionLevel;
            this.AllChannels = AllChannels;

            ChannelsListview.MultiSelect = false;
            ChannelsListview.FullRowSelect = true;

            UpdateListview();
        }

        //------------------------------[Buttons]------------------------------

        private void OKBTN_Click(object sender,EventArgs e) {
            DialogResult = DialogResult.OK;
            //Saving is handled by the Settings Subroutine.
            Close();
        }

        private void CANCELBTN_Click(object sender,EventArgs e) { 
            DialogResult = DialogResult.Cancel; 
            Close(); 
        }

        private void AddChannelBTN_Click(object sender,EventArgs e) {
            //TODO CHANNELFORM new

        }

        private void ModifyChannelBTN_Click(object sender,EventArgs e) {
            int Index = GetSelectedIndex(ChannelsListview);
            if(Index == -2) { return; }
            
            //TODO: CHANNELFORM with the specified channel.

        }

        private void DeleteChannelBTN_Click(object sender,EventArgs e) {
            int Index = GetSelectedIndex(ChannelsListview);
            if(Index == -2) {return;}
            if(AreYouSure("Are you sure you want to delete this channel?")) {AllChannels.RemoveAt(Index);}
        }

        private void PermissionLevelUpDown_ValueChanged(object sender,EventArgs e) {PermissionLevel = Decimal.ToInt32(PermissionLevelUpDown.Value);}

        //------------------------------[Functions]------------------------------

        /// <summary>Updates the list view</summary>
        private void UpdateListview() {
            ChannelsListview.Items.Clear();
            foreach(ColloquorChannel Channel in AllChannels) {
                ListViewItem NLI = new ListViewItem(Channel.GetName());
                NLI.SubItems.Add(Channel.GetPassword());
                ChannelsListview.Items.Add(NLI);
            }

        }

        /// <summary>Gets the selected item index on a listview.</summary>
        /// <returns>-2 if no items are selected, otherwise the first selected index.</returns>
        public int GetSelectedIndex(ListView List) {
            if(List.SelectedItems.Count != 1) {
                MessageBox.Show("No item selected!","n o",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return -2; 
            }
            return List.SelectedIndices[0];
        }

        /// <summary>Shows A Yes/No Message box</summary>
        /// <param name="Message">Question you want to ask the user</param>
        /// <returns>True if the user clicks yes, false otherwise.</returns>
        public bool AreYouSure(String Message) {return MessageBox.Show(Message,"Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes;}

      
    }
}
