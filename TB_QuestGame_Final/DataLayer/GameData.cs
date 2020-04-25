using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame_S1.Models;

namespace TBQuestGame_S1.DataLayer
{
    class GameData
    {
        Random rand = new Random();

        #region Player data

        /// <summary>
        /// static player data
        /// </summary>
        public static Player PlayerData()
        {
            return new Player()
            {
                ID = "PLAYER1",
                Name = "Spartacus",
                LegionName = "LEG IV",
                Title = Character.CharacterTitle.Praetor,
                Power = 450,
                TacticalAdvantage = 1,
                Rank = 1,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById("GLD"), 150),
                    new GameItemQuantity(GameItemById("GEM"), 0),
                    //new GameItemQuantity(GameItemById("INS"), 1),
                    //new GameItemQuantity(GameItemById("TRI"), 1)
                },
                ArmorInventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById("SWD"), 0),
                    new GameItemQuantity(GameItemById("HEL"), 0),
                    new GameItemQuantity(GameItemById("CUR"), 0),
                    new GameItemQuantity(GameItemById("BRA"), 0),
                    new GameItemQuantity(GameItemById("BOO"), 0)
                },
                BuffsInventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById("INS"), 0),
                     new GameItemQuantity(GameItemById("TRI"), 0),
                      new GameItemQuantity(GameItemById("BOL"), 0),
                },
                Missions = new ObservableCollection<Mission>()
                {
                    MissionById("SEIGE"),
                    MissionById("THIEF"),
                    MissionById("LOCATE"),
                    MissionById("RELIC"),
                    MissionById("HELLFIRE")
                },
                LegionnaireNumbers = 450
            };
        }

        #endregion

        #region Locations

        /// <summary>
        /// Adds locations
        /// </summary>
        public static Map GameMap()
        {
            Map gameMap = new Map();
            Random rand = new Random();

            gameMap.Locations.Add(new Location()
            {
                ID = 1,
                Name = "Aquila Empire",
                Description = "\t The might of the Aquila Empire is unmatched by any in the world of Mundas. " +
                "The legions of the Aquila Empire are led by high ranking generals known as Imperators who have " +
                "been tasked with crushing any who oppose the mighty empire.",
                EnemyRank = 0,
                IsAccessible = true
            });

            gameMap.Locations.Add(new Location()
            {
                ID = 2,
                Name = "Alheimurrinn",
                Description = "\t Alheimurinn is a powerful kingdom located west of the Aquila Empire. " +
                "They are the greatest threat to the Empire and must be destroyed, but take heed as it will " +
                "take a mighty legion to topple this kingdom.",
                EnemyRank = 5,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY1"),
                    NpcById("ENEMYCOURIER")
                }
            });

            gameMap.Locations.Add(new Location()
            {
                ID = 3,
                Name = "Dore",
                Description = "\t The kingdom of Dore is a wealthy country at the edge of the southern desert. " +
                "They have a rather impressive army despite the kingdom's small size. Conquer Dore and discover the " +
                "treasures it holds.",
                EnemyRank = 3,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY2"),
                    NpcById("FALSEMERCHANT")
                }
            });

            gameMap.Locations.Add(new Location()
            {
                ID = 4,
                Name = "Qua Redi",
                Description = "\t The Empire of Qua Redi is the kingdom of Dore's western neighbor. This vast " +
                "empire dominates the southern desert with a massive army. Crippling this Empire will require " +
                "careful planning. ",
                EnemyRank = 4,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY3"),
                    NpcById("NOBLE")
                }

            });

            gameMap.Locations.Add(new Location()
            {
                ID = 5,
                Name = "North Bourg",
                Description = "\t North Bourg is the Aquila Empire's eastern neighbor. North Bourg is comprised " +
                "primarily of small towns and settlements. The kingdom is constantly at war with South Bourg, and as such " +
                "they have been severely weakened.",
                EnemyRank = 1,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY4"),
                    NpcById("HORSEMAN"),
                    NpcById("STRANGER"),
                    NpcById("WORSHIPPER")
                }
            });

            gameMap.Locations.Add(new Location()
            {
                ID = 6,
                Name = "South Bourg",
                Description = "\t South and North Bourg were once a single kingdom called Bourg. However, it has been " +
                "split into two kingdoms. South Bourg stands as weak and vulnerable as North Bourg, making it the perfect " +
                "target for an inexperienced Imperator.",
                EnemyRank = 2,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY5"),
                    NpcById("FARMER"),
                    NpcById("PILGRIMS"),
                    NpcById("SCOUT")
                }
            });

            gameMap.Locations.Add(new Location()
            {
                ID = 7,
                Name = "Elkmire",
                Description = "\t Elkmire sits south of the Aquila Empire. Securing its ports is the key " +
                "to reaching the desert nations of Dore and Qua Redi.",
                EnemyRank = 3,
                IsAccessible = true,
                NPCS = new ObservableCollection<NPC>()
                {
                    NpcById("ENEMY6"),
                    NpcById("WANDERER"),
                    NpcById("TRADER"),
                    NpcById("HAMLET")
                }
            });

            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.ID == 1);

            return gameMap;
        }

        #endregion

        #region Game Items

        /// <summary>
        /// Adds game items
        /// </summary>
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>
            {
                new Buff("INS", "Inspiring Presence", 150, "Your presence on the battlefield inspires your troops to fight harder.", 100, 0),
                new Buff("BOL", "Bolster the Ranks", 100, "Reinforcements have arrived!", 0, 0),
                new Buff("TRI", "Tribute", 0, "The high council has sent you a chest of gold to aid in your campaign", 0, 1000),
                new Gem("GEM", "Hellfire Gems", 2000, "Extremely rare and valuable gems. They are said to have been crafted in the bowels Hell."),
                new ArmorSet("SWD", "Sword of King Midas", 5000, "A marvelous 500 year-old blade that belonged to King Midas. It is said that the blade holds the power to inspire thousands"),
                new ArmorSet("HEL", "Helmet of King Midas", 3000, "A dark steele helmet trimmed with glistening gold."),
                new ArmorSet("CUR", "Cuirass of King Midas", 10000, "A dark steele cuirass trimmed with gold and a golden bull featured prominently in the center of the chest."),
                new ArmorSet("BRA", "Bracers of King Midas", 3000, "Dark steele bracers that are etched with the golden head of a bull."),
                new ArmorSet("BOO", "Greaves of King Midas", 4000, "Dark steele greaves trimmed with gold."),
                new Treasure("GLD", "Gold", 1, "Gold is the key to building a powerful legion", Treasure.TreasureType.Coin)
            };
        }

        #endregion

        #region NPC's

        public static List<NPC> Npcs()
        {
            Random rand = new Random();

            return new List<NPC>()
            {
                new EnemyMilitary()
                {
                    ID = "ENEMY1",
                    Name = "Army of Alheimurrinn",
                    Description = "Rank 5",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "You cannot withstand our might!",
                        "Retreat or die!",
                        "Remove yourself from our lands or face your doom."
                    },
                    Rank = 5,
                    Power = rand.Next(1250, 1500)
                },

                new EnemyMilitary()
                {
                    ID = "ENEMY2",
                    Name = "Kingdom of Dore",
                    Description = "Rank 3",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "You cannot withstand our might!",
                        "Retreat or die!",
                        "Remove yourself from our lands or face your doom."
                    },
                    Rank = 3,
                    Power = rand.Next(750, 999)
                },

                new EnemyMilitary()
                {
                    ID = "ENEMY3",
                    Name = "Legions of Qua Redi",
                    Description = "Rank 4",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "You cannot withstand our might!",
                        "Retreat or die!",
                        "Remove yourself from our lands or face your doom."
                    },
                    Rank = 4,
                    Power = rand.Next(1000, 1249)
                },

                new EnemyMilitary()
                {
                    ID = "ENEMY4",
                    Name = "Tribes of North Bourg",
                    Description = "Rank 1",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "Leave our lands!",
                        "We will not be oppressed by you!"
                    },
                    Rank = 1,
                    Power = rand.Next(300, 499)
                },


                new EnemyMilitary()
                {
                    ID = "ENEMY5",
                    Name = "Tribes of South Bourg",
                    Description = "Rank 2",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "It would be wise of you to retreat. "
                    },
                    Rank = 2,
                    Power = rand.Next(500, 749)
                },

                new EnemyMilitary()
                {
                    ID = "ENEMY6",
                    Name = "Kingdom of Elkmire",
                    Description = "Rank 3",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "Leave our lands!",
                        "We will not be oppressed by you!"
                    },
                    Rank = 3,
                    Power = rand.Next(750, 999)
                },

                new EnemyMilitary()
                {
                    ID = "STRANGER",
                    Name = "Strange Man",
                    Description = "A man in tattered clothes. He appears to be a pilgrim, but you notice a pin sticking out " +
                    "of his breast pocket that appears to be a lion wearing a crown. The symbol is often used by the wealthy lords of " +
                    "Dore. Could he be a Dornish spy?",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "Please pay me no mind as I am just a simple pilgrim.",
                        "I am on my way to an ancient temple high in the norther mountains. I hope to reach it by nightfall."
                    },
                    Rank = 0,
                    Power = 0,
                },

                 new EnemyMilitary()
                {
                    ID = "FARMER",
                    Name = "FARMER",
                    Description = "The man appears to be a simple farmer, though his clothes seem a bit nice for someone " +
                    "in his line of work.",
                    Title = Character.CharacterTitle.Enemy,
                    Messages = new List<string>()
                    {
                        "Hoping for a good harvest this year.",
                        "Ye must forgive me, but I must return to my flock."
                    },
                    Rank = 0,
                    Power = 0,
                },

                new EnemyMilitary()
                {
                    ID = "TRADER",
                    Name = "Wandering Trader",
                    Description = "A woman leading a mule that is pulling a small wagon filled with vegetables. Given the " +
                    "content of her wares, it is odd that she has such a large sack of gold hanging from her waist.",
                    Title = Character.CharacterTitle.Trader,
                    Messages = new List<string>()
                    {
                        "Fresh vegetables for sale!",
                        "Delicious vegetables, fresh and affordable."
                    },
                    Rank = 0,
                    Power = 0
                },

                new EnemyMilitary()
                {
                    ID = "FALSEMERCHANT",
                    Name = "Traveling Merchant",
                    Description = "An elderly man sitting atop a wagon that has been pulled to the side of the road. " +
                    "You notice a curved blade hidden under a sack in the rear of the wagon. It is unusual for merchants " +
                    "to carry blades of this type.",
                    Title = Character.CharacterTitle.Trader,
                    Messages = new List<string>()
                    {
                        "Would you like to take a look at my wares?",
                        "Come take a look at my wares!"
                    },
                    Rank = 0,
                    Power = 0
                },

                new EnemyMilitary()
                {
                    ID = "WANDERER",
                    Name = "Wandering Woman",
                    Description = "A woman in a dark cloak. You notice a dagger on her waist, which appears to have a " +
                    "viridescent sheen. It is well known that the master blacksmiths of Alheimurrinn are capable of forging viridian blades.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        "I want no part in your war, I only wish to return to my home."
                    },
                    Rank = 0,
                    Power = 0
                },

                new EnemyMilitary()
                {
                    ID = "HORSEMAN",
                    Name = "Man on a Horse",
                    Description = "A man riding with great haste with a large sack on his back. You also notice that he has " +
                    "the sigil of the Aquila Empire embroidered on his gambeson.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        "Apologies, but I am on an important diplomatic mission to South Bourg. I was ordered by the high council " +
                        "to deliver piece terms to the warlords of South Bourg."
                    },
                    Rank = 0,
                    Power = 0
                },

                 new Citizen()
                {
                    ID = "SCOUT",
                    Name = "Aquila Empire Scout",
                    Description = "One of your forward scouts.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        "Imperator, I must speak with you at once."
                    },
                    Rank = 0,
                    Power = 0
                },


                 new Citizen()
                {
                    ID = "ENEMYCOURIER",
                    Name = "An Enemy Courier",
                    Description = "This man is a courier and is likely running information between enemy camps. He should be " +
                    "questioned.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        "Please Imperator, have mercy! I wll tell you whatever you want to know."
                    },
                    Rank = 0,
                    Power = 0
                },

                    new Citizen()
                {
                    ID = "WORSHIPPER",
                    Name = "Small worshippers hut",
                    Description = "A small hut with the crest of the fire god on its door. This place must be home to worshippers " +
                    "of the burning god. It appears that someone is hidding inside.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        " "
                    },
                    Rank = 0,
                    Power = 0
                },

                new Citizen()
                {
                    ID = "PILGRIMS",
                    Name = "Pilgrims cave",
                    Description = "A cave clearly home to pilgrims, though they must be hiding deeper in the cave.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        ""
                    },
                    Rank = 0,
                    Power = 0
                },

                 new Citizen()
                {
                    ID = "NOBLE",
                    Name = "Traveling Noble",
                    Description = "A man adorned in expensive jewelry. From the look of his clothes he appears to be from Qua Redi.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        "Good day Imperator."
                    },
                    Rank = 0,
                    Power = 0
                },

                new Citizen()
                {
                    ID = "HAMLET",
                    Name = "Small Hamlet",
                    Description = "A small hamlet on the outskirts of the Elkmire castle.",
                    Title = Character.CharacterTitle.Wanderer,
                    Messages = new List<string>()
                    {
                        ""
                    },
                    Rank = 0,
                    Power = 0
                }
            };
        }

        #endregion

        #region Missions

        public static List<Mission> Missions()
        {
            return new List<Mission>()
            {
                new SeigeMission()
                {
                    ID = "SEIGE",
                    Name = "Battle for Mundas",
                    Description = "Defeat the enemies of the Aquila Empire!",
                    Status = Mission.MissionStatus.incomplete,
                    AllEnemiesDefeated = false
                },
                new LocateMission()
                {
                    ID = "LOCATE",
                    Name = "Locate the Enemy Spies",
                    Description = "Scouts have reported seeing strangers wandering" + Environment.NewLine + 
                                  "the roads of Mundas. They may be enemy spies" + Environment.NewLine +  
                                  "trying to gain intel on our troop movements." + Environment.NewLine +  
                                  "You must locate and eliminate these spies.",
                    Status = Mission.MissionStatus.incomplete,
                    AllSpiesDefeated = false
                },
                new AncientRelicMission()
                {
                    ID = "RELIC",
                    Name = "King Midas' Armor Set",
                    Description = "Find King Midas' legendary armor set" + Environment.NewLine +
                                  "The armor set was scattered all over" + Environment.NewLine +  
                                  "Mundas nearly 500 years ago.",
                    Status = Mission.MissionStatus.incomplete,
                    HasArmorSet = false,
                    RequiredGameItems = new List<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById("SWD"), 1),
                        new GameItemQuantity(GameItemById("HEL"), 1),
                        new GameItemQuantity(GameItemById("CUR"), 1),
                        new GameItemQuantity(GameItemById("BRA"), 1),
                        new GameItemQuantity(GameItemById("BOO"), 1),
                    }
                },
                new HellfireGemMission()
                {
                    ID = "HELLFIRE",
                    Name = "Aquire Hellfire Gems",
                    Description = "Hellfire Gems are said to have been forged in the" + Environment.NewLine +  
                                  "bowels of hell. many believe the gems have" + Environment.NewLine +  
                                  "magical properties and can even raise the dead." + Environment.NewLine +  
                                  "One thing is for certain, the gems are incredibly" + Environment.NewLine +  
                                  "valuable and should belong to the Empire. There" + Environment.NewLine +  
                                  "are five gems known to be " +
                    "in Mundas.",
                    Status = Mission.MissionStatus.incomplete,
                    HasAllGems = false,
                    RequiredGameItems = new List<GameItemQuantity>
                    {
                        new GameItemQuantity(GameItemById("GEM"), 5)
                    }
                },

                new CrownMission()
                {
                    ID = "THIEF",
                    Name = "Stop the Thief!",
                    Description = "A thief has stolen the emperors crown! The thief" + Environment.NewLine +
                                  "was last seen heading east towards North Bourg",
                    Status = Mission.MissionStatus.incomplete,
                    ThiefIsCaptured = false
                }
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// gets npc by id
        /// </summary>
        private static NPC NpcById(string id)
        {
            return Npcs().FirstOrDefault(i => i.ID == id);
        }

        /// <summary>
        /// gets the game item that matches the selected ID
        /// </summary>
        private static GameItem GameItemById(string id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// gets the mission that matches the selected mission ID
        /// </summary>
        private static Mission MissionById(string id)
        {
            return Missions().FirstOrDefault(m => m.ID == id);
        }

        /// <summary>
        /// intitial message
        /// </summary>
        public static List<string> InitialMessage()
        {
            return new List<string>()
            {
                "Welcome to Mundas, a land that is ravaged by waring factions and barbarian hordes. " +
                "You are an Imperator, a high ranking general, of the Aquila Empire. " +
                "You have been tasked by your Emperor and the High Council to lay seige on enemy lands. " +
                "Along with the title of Imperator, you have been given a legion and a starting sum of gold. " +
                "Use your newfound status and wealth wisely. The Emperor will not tolerate failure. "
            };
        }

        #endregion
    }
}
