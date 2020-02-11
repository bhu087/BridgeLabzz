namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// This is the class for inventory management for Rice Wheat and Pulses.
    /// </summary>
    public class InventoryDataManagement
    {
        /// <summary>
        /// Data management.
        /// </summary>
        public static void DataManagement()
        {
            Utility managementUtility = new Utility();
            Items items = managementUtility.DeserealizeItem();
            Console.WriteLine("Item selection\n1 for Rice\n2 for Wheat\n3 for Pulses");
            int itemSelection = managementUtility.IntInput();
            if (itemSelection == 1)
            {
                ////this line prints the Rice details
                managementUtility.PrintItemInfo(items.Rice);
                ////This line selects the which rice to be update (0- Rice1 1- Rice2 2- Rice3)
                int selectByName = managementUtility.SelectItemByName("Rice");
                ////This line selects the Which Content to be update (0- Name 1- Weight 3- Rate)
                int selectInfoByName = managementUtility.SelectInfoByName("Rice", selectByName);
                ////This line updates the content of the rice by selecting one
                managementUtility.UpdateHere("Rice", selectByName, selectInfoByName);
            }

            if (itemSelection == 2)
            {
                ////this line prints the Wheat details
                managementUtility.PrintItemInfo(items.Wheat);
                ////This line selects the which rice to be update (0- Wheat1 1- Wheat2 2- Wheat3)
                int selectByName = managementUtility.SelectItemByName("Wheat");
                ////This line selects the Which Content to be update (0- Name 1- Weight 3- Rate)
                int selectInfoByName = managementUtility.SelectInfoByName("Wheat", selectByName);
                ////This line updates the content of the Wheat by selecting one
                managementUtility.UpdateHere("Wheat", selectByName, selectInfoByName);
            }

            if (itemSelection == 3)
            {
                ////this line prints the Pulses details
                managementUtility.PrintItemInfo(items.Pulses);
                ////This line selects the which rice to be update (0- Pulses1 1- Pulses2 2- Pulses3)
                int selectByName = managementUtility.SelectItemByName("Pulses");
                ////This line selects the Which Content to be update (0- Name 1- Weight 3- Rate)
                int selectInfoByName = managementUtility.SelectInfoByName("Pulses", selectByName);
                ////This line updates the content of the Pulses by selecting one
                managementUtility.UpdateHere("Pulses", selectByName, selectInfoByName);
            }
        }
    }
}