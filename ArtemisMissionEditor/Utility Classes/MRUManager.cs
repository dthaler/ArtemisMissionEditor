using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;

namespace ArtemisMissionEditor
{
    public interface IMRUClient
    {
        void OpenMRUFile(string fileName);
    }

    public sealed class MRUManager
    {
        private static MRUManager _current = new MRUManager();
        public static MRUManager Current => _current;

        public ToolStripMenuItem MRUMenu;

        private Form _ownerForm;
        private ToolStripMenuItem _menuItemParent; // Recent Files menu item parent

        public void Add(string missionFileName, bool latest = true)
        {
            Remove(missionFileName);

            var item = new ToolStripMenuItem(missionFileName);
            if (latest)
            {
                MRUMenu.DropDownItems.Insert(0, item);
            } else
            {
                MRUMenu.DropDownItems.Add(item);
            }
            item.Click += Item_Click;

            SaveMRU();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            string missionFileName = item.Text;
            if (File.Exists(missionFileName))
            {
                ((IMRUClient)_ownerForm).OpenMRUFile(missionFileName);
            } else
            {
                MessageBox.Show("File no longer exists, removing it from recent files...");
                Remove(missionFileName);
            }
        }

        public void Remove(string missionFileName)
        {
            foreach (var item in MRUMenu.DropDownItems)
            {
                var mruItem = item as ToolStripMenuItem;
                if (mruItem == null)
                    continue;
                if (mruItem.Text == missionFileName)
                {
                    MRUMenu.DropDownItems.Remove(mruItem);
                    return;
                }
            }
        }

        public void Initialize(Form owner, ToolStripMenuItem parent, ToolStripMenuItem mruMenuItem)
        {
            _ownerForm = owner;

            // check if owner form implements IMRUClient interface
            if (!(owner is IMRUClient))
            {
                throw new Exception("MRUManager: Owner form doesn't implement IMRUClient interface");
            }

            MRUMenu = mruMenuItem;

            // keep reference to MRU menu item parent
            _menuItemParent = parent;
            if (_menuItemParent == null)
            {
                throw new Exception("MRUManager: Cannot find parent of MRU menu item");
            }

            // subscribe to MRU parent Popup event
            _menuItemParent.DropDownOpening += new EventHandler(OnFileMenuOpening);

            // subscribe to owner form Closing event
            _ownerForm.Closing += new System.ComponentModel.CancelEventHandler(OnFormClosing);

            LoadMRU();
        }

        private static RegistryKey GetRegistryKey()
        {
            RegistryKey key = Settings.GetRegistryKey();
            RegistryKey mru = key.OpenSubKey("Recent Files List", true);
            if (mru == null)
                mru = key.CreateSubKey("Recent Files List");
            return mru;
        }

        /// <summary>
        /// Read the MRU list from registry. 
        /// </summary>
        private void LoadMRU()
        {
            MRUMenu.DropDownItems.Clear();

            var key = GetRegistryKey();
            foreach (string valueName in key.GetValueNames())
            {
                string missionFileName = key.GetValue(valueName) as string;
                Add(missionFileName, false);
            }
        }

        /// <summary>
        /// Save MRU list to registry.
        /// </summary>
        private void SaveMRU()
        {
            var key = GetRegistryKey();

            for (int index = 0; index < MRUMenu.DropDownItems.Count; index++)
            {
                var mruItem = MRUMenu.DropDownItems[index];

                var name = String.Format("File{0}", index + 1);
                var value = mruItem.Text;

                key.SetValue(name, value);
            }
        }

        // The OnMRUParentClosing method is called when the owner form is closed and saves the MRU list to the registry. 
        private void OnFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveMRU();
        }

        private void OnFileMenuOpening(object sender, EventArgs e)
        {
            MRUMenu.Enabled = (MRUMenu.DropDownItems.Count > 0);
        }
    }
}
