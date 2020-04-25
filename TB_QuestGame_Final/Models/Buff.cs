using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_S1.Models
{
    class Buff : GameItem
    {
        #region Enums
        public enum UserAction
        {
            OPENLOCATION
        }
        #endregion

        #region Properties
        public int DefenseChange { get; set; }
        public int AddGold { get; set; }
        #endregion

        #region Constructors
        public Buff(string id, string name, int value, string description, int defenseChange, int addGold) 
            : base(id, name, value, description)
        {
            DefenseChange = defenseChange;
            AddGold = addGold;
        }
        #endregion

        #region Methods
        public override string InformationString()
        {
            if (DefenseChange != 0)
            {
                return $"{Name}: {Description}\nDefense: {DefenseChange}";
            }
            else if (AddGold != 0)
            {
                return $"{Name}: {Description}\nGold: {AddGold}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
        #endregion
    }
}
