using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class WingdingsScript : MonoBehaviour
{
    public KMAudio audio;
    public KMBombInfo bomb;
    public KMNeedyModule needyWingdings;

    //Interactables
    public KMSelectable[] cyclers;
    public KMSelectable submit;
    public GameObject display;

    //Variables
    public string[] words = {"Hello", "Food", "Welcome","Great", "Passport", "Gasp", "Grasp", "Bait", "Jail", "Mail", "Man", "Straw", "Fruits", "Pantry", "House", "Field", "Sports", "Strike", "Solve", "Defuse", "Hoses",
                             "Trick", "Bravo", "Vector","Brain",
                             "Boxes", "Alien", "Beats", "Bombs",
                             "Sting", "Steak", "Leaks", "Verse",
                             "Brick", "Break", "Hello", "Halls",
                             "Shell", "Bistro","Strobe","Slick",
                             "Flick", "There", "Which", "Their", "Other", "About", "These", "Would",
                             "Write", "Could", "First", "Water", "Sound", "Place", "After",
                             "Thing", "Think", "Great", "Where", "Right", "Three", "Small",
                             "Large", "Again", "Spell", "House", "Point", "Found", "Study",
                             "Still", "Learn", "World", "Every", "Below", "Plant", "Never", "Aback", "Abbey", "Abbot", "Above", "Abuse", "Acids", "Acres", "Acted", "Actor", "Acute", "Adapt", "Added", "Admit", "Adopt", "Adult", "Agent", "Agony", "Agree",
                             "Ahead", "Aided", "Aimed", "Aisle", "Alarm", "Album", "Alert", "Algae", "Alike", "Alive", "Alley", "Allow", "Alloy", "Alone", "Along", "Aloof", "Aloud",
                             "Alpha", "Altar", "Alter", "Amend", "Amino", "Among", "Ample", "Angel", "Anger", "Angle", "Angry", "Ankle", "Apart", "Apple", "Apply", "Apron", "Areas", "Arena",
                             "Argue", "Arise", "Armed", "Aroma", "Arose", "Array", "Arrow", "Arson", "Ashes", "Aside", "Asked", "Assay", "Asset", "Atoms", "Attic", "Audio", "Audit", "Avoid",
                             "Await", "Awake", "Award", "Aware", "Awful", "Awoke", "Backs", "Bacon", "Badge", "Badly", "Baked", "Baker", "Balls", "Bands", "Banks", "Barge", "Baron", "Basal",
                             "Based", "Bases", "Basic", "Basin", "Basis", "Batch", "Baths", "Beach", "Beads", "Beams", "Beans", "Beard", "Bears", "Beast", "Beech", "Beers", "Began", "Begin",
                             "Begun", "Being", "Bells", "Belly", "Belts", "Bench", "Bible", "Bikes", "Bills", "Birds", "Birth", "Black", "Blade", "Blame", "Bland", "Blank", "Blast",
                             "Blaze", "Bleak", "Bleat", "Blend", "Bless", "Blind", "Block", "Bloke", "Blond", "Blood", "Bloom", "Blown", "Blows", "Blues", "Blunt", "Board", "Boats", "Bogus",
                             "Bolts", "Bonds", "Bones", "Bonus", "Books", "Boost", "Boots", "Bored", "Borne", "Bound", "Bowed", "Bowel", "Bowls", "Boxed", "Boxer",
                             "Brake", "Brand", "Brass", "Brave", "Bread", "Bream", "Breed", "Bride", "Brief", "Bring", "Brink", "Brisk", "Broad", "Broke", "Broom", "Brown",
                             "Brows", "Brush", "Build", "Built", "Bulbs", "Bulky", "Bulls", "Bunch", "Bunny", "Burns", "Burnt", "Burst", "Buses", "Buyer", "Cabin", "Cable", "Cache", "Cakes",
                             "Calls", "Camps", "Canal", "Candy", "Canoe", "Canon", "Cards", "Cared", "Carer", "Cares", "Cargo", "Carry", "Cases", "Catch", "Cater", "Cause", "Caves", "Cease",
                             "Cells", "Cents", "Chain", "Chair", "Chalk", "Chaos", "Chaps", "Charm", "Chart", "Chase", "Cheap", "Check", "Cheek", "Cheer", "Chess", "Chest", "Chief", "Child",
                             "Chill", "China", "Chips", "Choir", "Chord", "Chose", "Chunk", "Cider", "Cigar", "Cited", "Cites", "Civic", "Civil", "Claim", "Clash", "Class", "Claws", "Clean",
                             "Clear", "Clerk", "Click", "Cliff", "Climb", "Cloak", "Clock", "Close", "Cloth", "Cloud", "Clown", "Clubs", "Cluck", "Clues", "Clung", "Coach", "Coast", "Coats",
                             "Cocoa", "Codes", "Coins", "Colon", "Comes", "Comic", "Coral", "Corps", "Costs", "Couch", "Cough", "Count", "Court", "Cover", "Crack", "Craft", "Crane", "Crash",
                             "Crate", "Crazy", "Cream", "Creed", "Crept", "Crest", "Crews", "Cried", "Cries", "Crime", "Crisp", "Crops", "Cross", "Crowd", "Crown", "Crude", "Cruel", "Crust",
                             "Crypt", "Cubic", "Curls", "Curly", "Curry", "Curse", "Curve", "Cycle", "Daddy", "Daily", "Dairy", "Dance", "Dared", "Dated", "Dates", "Deals", "Dealt", "Death",
                             "Debit", "Debts", "Debut", "Decay", "Decor", "Decoy", "Deeds", "Deity", "Delay", "Dense", "Depot", "Depth", "Derby", "Derry", "Desks", "Deter", "Devil", "Diary",
                             "Diets", "Dimly", "Dirty", "Disco", "Discs", "Disks", "Ditch", "Dived", "Dizzy", "Docks", "Dodgy", "Doing", "Dolls", "Donor", "Doors", "Doses", "Doubt", "Dough",
                             "Downs", "Dozen", "Draft", "Drain", "Drama", "Drank", "Drawn", "Draws", "Dread", "Dream", "Dress", "Dried", "Drift", "Drill", "Drily", "Drink", "Drive", "Drops",
                             "Drove", "Drown", "Drugs", "Drums", "Drunk", "Duchy", "Ducks", "Dunes", "Dusty", "Dutch", "Dwarf", "Dying", "Eager", "Eagle", "Early", "Earth", "Eased", "Eaten",
                             "Edges", "Eerie", "Eight", "Elbow", "Elder", "Elect", "Elite", "Elves", "Empty", "Ended", "Enemy", "Enjoy", "Enter", "Entry", "Envoy", "Equal", "Erect", "Error",
                             "Essay", "Ethos", "Event", "Exact", "Exams", "Exert", "Exile", "Exist", "Extra", "Faced", "Faces", "Facts", "Faded", "Fails", "Faint", "Fairs", "Fairy", "Faith",
                             "Falls", "False", "Famed", "Fancy", "Fares", "Farms", "Fatal", "Fatty", "Fault", "Fauna", "Fears", "Feast", "Feels", "Fella", "Fence", "Feret", "Ferry", "Fetal",
                             "Fetch", "Fever", "Fewer", "Fibre", "Field", "Fiery", "Fifth", "Fifty", "Fight", "Filed", "Files", "Fills", "Films", "Final", "Finds", "Fined", "Finer", "Fines",
                             "Fired", "Fires", "Firms", "Fists", "Fiver", "Fixed", "Flags", "Flair", "Flame", "Flank", "Flash", "Flask", "Flats", "Flaws", "Fleet", "Flesh", "Flies", "Float",
                             "Flock", "Flood", "Floor", "Flora", "Flour", "Flown", "Flows", "Fluid", "Flung", "Flunk", "Flush", "Flute", "Focal", "Focus", "Folds", "Folks", "Folly", "Fonts",
                             "Foods", "Fools", "Force", "Forms", "Forth", "Forty", "Forum", "Fours", "Foxes", "Foyer", "Frail", "Frame", "Franc", "Frank", "Fraud", "Freak", "Freed", "Fresh",
                             "Fried", "Frogs", "Front", "Frost", "Frown", "Froze", "Fruit", "Fuels", "Fully", "Fumes", "Funds", "Funny", "Gains", "Games", "Gangs", "Gases", "Gates", "Gauge",
                             "Gazed", "Geese", "Genes", "Genre", "Genus", "Ghost", "Giant", "Gifts", "Girls", "Given", "Gives", "Glare", "Glass", "Gleam", "Globe", "Gloom", "Glory", "Gloss",
                             "Glove", "Goals", "Goats", "Going", "Goods", "Goose", "Gorge", "Grace", "Grade", "Grain", "Grand", "Grant", "Graph", "Grasp", "Grass", "Grave", "Greed", "Greek",
                             "Green", "Greet", "Grief", "Grill", "Grips", "Groom", "Gross", "Group", "Grown", "Grows", "Guard", "Guess", "Guest", "Guide", "Guild", "Guilt", "Guise",
                             "Gulls", "Gully", "Gypsy", "Habit", "Hairs", "Hairy", "Hands", "Handy", "Hangs", "Happy", "Hardy", "Harsh", "Haste", "Hasty", "Hatch", "Hated", "Hates",
                             "Haven", "Havoc", "Heads", "Heady", "Heard", "Hears", "Heart", "Heath", "Heavy", "Hedge", "Heels", "Hefty", "Heirs", "Helps", "Hence", "Henry", "Herbs",
                             "Herds", "Hills", "Hints", "Hired", "Hobby", "Holds", "Holes", "Holly", "Homes", "Honey", "Hooks", "Hoped", "Hopes", "Horns", "Horse", "Hosts", "Hotel", "Hours",
                             "Human", "Humus", "Hurry", "Hurts", "Hymns", "Icing", "Icons", "Ideal", "Ideas", "Idiot", "Image", "Imply", "Index", "India", "Inert", "Infer", "Inner", "Input",
                             "Irony", "Issue", "Items", "Ivory", "Japan", "Jeans", "Jelly", "Jewel", "Joins", "Joint", "Joker", "Jokes", "Jolly", "Joule", "Joust", "Judge", "Juice",
                             "Keeps", "Kicks", "Kills", "Kinds", "Kings", "Knees", "Knelt", "Knife", "Knobs", "Knock", "Knots", "Known", "Knows", "Label", "Lacks", "Lager", "Lakes", "Lambs",
                             "Lamps", "Lands", "Lanes", "Laser", "Lasts", "Later", "Laugh", "Lawns", "Layer", "Leads", "Leant", "Leapt", "Lease", "Least", "Leave", "Ledge", "Legal", "Lemon",
                             "Level", "Lever", "Libel", "Lifts", "Light", "Liked", "Likes", "Limbs", "Limit", "Lined", "Linen", "Liner", "Lines", "Links", "Lions", "Lists", "Litre", "Lived",
                             "Liver", "Lives", "Loads", "Loans", "Lobby", "Local", "Locks", "Locus", "Lodge", "Lofty", "Logic", "Looks", "Loops", "Loose", "Lords", "Lorry", "Loser", "Loses",
                             "Lotus", "Loved", "Lover", "Loves", "Lower", "Loyal", "Lucky", "Lumps", "Lunch", "Lungs", "Lying", "Macho", "Madam", "Magic", "Mains", "Maize", "Major", "Maker",
                             "Makes", "Males", "Manor", "March", "Marks", "Marry", "Marsh", "Masks", "Match", "Mates", "Maths", "Maybe", "Mayor", "Meals", "Means", "Meant", "Medal", "Media",
                             "Meets", "Menus", "Mercy", "Merge", "Merit", "Merry", "Messy", "Metal", "Meter", "Metre", "Micro", "Midst", "Might", "Miles", "Mills", "Minds", "Miner", "Mines",
                             "Minor", "Minus", "Misty", "Mixed", "Model", "Modem", "Modes", "Moist", "Moles", "Money", "Monks", "Month", "Moods", "Moors", "Moral", "Motif", "Motor", "Motto",
                             "Mould", "Mound", "Mount", "Mouse", "Mouth", "Moved", "Moves", "Movie", "Muddy", "Mummy", "Mused", "Music", "Myths", "Nails", "Naive", "Named", "Names",
                             "Nanny", "Nasty", "Naval", "Necks", "Needs", "Nerve", "Nests", "Newer", "Newly", "Nicer", "Niche", "Niece", "Night", "Ninth", "Noble", "Nodes", "Noise",
                             "Noisy", "Nomes", "Norms", "North", "Noses", "Noted", "Notes", "Novel", "Nurse", "Nutty", "Nylon", "Occur", "Ocean", "Oddly", "Odour", "Offer", "Often", "Older",
                             "Olive", "Onion", "Onset", "Opens", "Opera", "Orbit", "Order", "Organ", "Ought", "Ounce", "Outer", "Overs", "Overt", "Owned", "Owner", "Oxide", "Ozone", "Packs",
                             "Pages", "Pains", "Paint", "Pairs", "Palms", "Panel", "Panic", "Pants", "Papal", "Paper", "Parks", "Parts", "Party", "Pasta", "Paste", "Patch", "Paths", "Patio",
                             "Pause", "Peace", "Peaks", "Pearl", "Pears", "Peers", "Penal", "Pence", "Penny", "Pests", "Petty", "Phase", "Phone", "Photo", "Piano", "Picks", "Piece", "Piers",
                             "Piled", "Piles", "Pills", "Pilot", "Pinch", "Pints", "Pious", "Pipes", "Pitch", "Pizza", "Plain", "Plane", "Plans", "Plate", "Plays", "Plead", "Pleas", "Plots",
                             "Plump", "Poems", "Poets", "Polar", "Poles", "Polls", "Ponds", "Pools", "Porch", "Pores", "Ports", "Posed", "Poses", "Posts", "Pound", "Power", "Press", "Price",
                             "Pride", "Prime", "Print", "Prior", "Privy", "Prize", "Probe", "Prone", "Proof", "Prose", "Proud", "Prove", "Proxy", "Pulls", "Pulse", "Pumps", "Punch", "Pupil",
                             "Puppy", "Purse", "Quack", "Queen", "Query", "Quest", "Queue", "Quick", "Quiet", "Quite", "Quota", "Quote", "Raced", "Races", "Radar", "Radio", "Raids", "Rails",
                             "Raise", "Rally", "Range", "Ranks", "Rapid", "Rated", "Rates", "Ratio", "Razor", "Reach", "React", "Reads", "Ready", "Realm", "Rebel", "Refer", "Reign",
                             "Reins", "Relax", "Remit", "Renal", "Renew", "Rents", "Repay", "Reply", "Resin", "Rests", "Rider", "Ridge", "Rifle", "Rigid", "Rings", "Riots", "Risen", "Rises",
                             "Risks", "Risky", "Rites", "Rival", "River", "Roads", "Robes", "Robot", "Rocks", "Rocky", "Rogue", "Roles", "Rolls", "Roman", "Roofs", "Rooms", "Roots", "Ropes",
                             "Roses", "Rotor", "Rouge", "Rough", "Round", "Route", "Rover", "Royal", "Rugby", "Ruins", "Ruled", "Ruler", "Rules", "Rural", "Rusty", "Sadly", "Safer", "Sails",
                             "Saint", "Salad", "Sales", "Salon", "Salts", "Sands", "Sandy", "Satin", "Sauce", "Saved", "Saves", "Scale", "Scalp", "Scant", "Scarf", "Scars", "Scene", "Scent",
                             "Scoop", "Scope", "Score", "Scots", "Scrap", "Screw", "Scrum", "Seals", "Seams", "Seats", "Seeds", "Seeks", "Seems", "Seize", "Sells", "Sends", "Sense", "Serum",
                             "Serve", "Seven", "Sexes", "Shade", "Shady", "Shaft", "Shake", "Shaky", "Shall", "Shame", "Shape", "Share", "Sharp", "Sheep", "Sheer", "Sheet", "Shelf",
                             "Shift", "Shiny", "Ships", "Shire", "Shirt", "Shock", "Shoes", "Shone", "Shook", "Shoot", "Shops", "Shore", "Short", "Shots", "Shout", "Shown", "Shows", "Shrug",
                             "Sides", "Siege", "Sight", "Signs", "Silly", "Since", "Sings", "Sites", "Sixth", "Sixty", "Sizes", "Skies", "Skill", "Skins", "Skirt", "Skull", "Slabs", "Slate",
                             "Slave", "Sleek", "Sleep", "Slept", "Slice", "Slide", "Slope", "Slots", "Slump", "Smart", "Smell", "Smile", "Smoke", "Snake", "Sober", "Socks", "Soils", "Solar",
                             "Solid", "Solve", "Songs", "Sorry", "Sorts", "Souls", "South", "Space", "Spade", "Spare", "Spark", "Spate", "Spawn", "Speak", "Speed", "Spend", "Spent", "Spies",
                             "Spine", "Splat", "Split", "Spoil", "Spoke", "Spoon", "Sport", "Spots", "Spray", "Spurs", "Squad", "Stack", "Staff", "Stage", "Stain", "Stair", "Stake", "Stale",
                             "Stall", "Stamp", "Stand", "Stare", "Stark", "Stars", "Start", "State", "Stays", "Steal", "Steam", "Steel", "Steep", "Steer", "Stems", "Steps", "Stern",
                             "Stick", "Stiff", "Stock", "Stole", "Stone", "Stony", "Stood", "Stool", "Stops", "Store", "Storm", "Story", "Stout", "Stove", "Strap", "Straw", "Stray",
                             "Strip", "Stuck", "Stuff", "Style", "Suede", "Sugar", "Suite", "Suits", "Sunny", "Super", "Surge", "Swans", "Swear", "Sweat", "Sweep", "Sweet", "Swept", "Swift",
                             "Swing", "Swiss", "Sword", "Swore", "Sworn", "Swung", "Table", "Tacit", "Tails", "Taken", "Takes", "Tales", "Talks", "Tanks", "Tapes", "Tasks", "Taste", "Tasty",
                             "Taxed", "Taxes", "Taxis", "Teach", "Teams", "Tears", "Teddy", "Teens", "Teeth", "Tells", "Telly", "Tempo", "Tends", "Tenor", "Tense", "Tenth", "Tents", "Terms",
                             "Tests", "Texas", "Texts", "Thank", "Theft", "Theme", "Thick", "Thief", "Thigh", "Third", "Those", "Threw", "Throw", "Thumb", "Tidal", "Tides", "Tiger", "Tight",
                             "Tiles", "Times", "Timid", "Tired", "Title", "Toast", "Today", "Token", "Tones", "Tonic", "Tonne", "Tools", "Toons", "Tooth", "Topic", "Torch", "Total", "Touch",
                             "Tough", "Tours", "Towel", "Tower", "Towns", "Toxic", "Trace", "Track", "Tract", "Trade", "Trail", "Train", "Trait", "Tramp", "Trams", "Trays", "Treat", "Trees",
                             "Trend", "Trial", "Tribe", "Tried", "Tries", "Trips", "Troop", "Trout", "Truce", "Truck", "Truly", "Trunk", "Trust", "Truth", "Tubes", "Tummy", "Tunes",
                             "Tunic", "Turks", "Turns", "Tutor", "Twice", "Twins", "Twist", "Tying", "Types", "Tyres", "Ulcer", "Unban", "Uncle", "Under", "Undue", "Unfit", "Union", "Unite",
                             "Units", "Unity", "Until", "Upper", "Upset", "Urban", "Urged", "Urine", "Usage", "Users", "Using", "Usual", "Utter", "Vague", "Valid", "Value", "Valve", "Vault",
                             "Veins", "Venue", "Verbs", "Verge", "Vicar", "Video", "Views", "Villa", "Vines", "Vinyl", "Virus", "Visit", "Vital", "Vivid", "Vocal", "Vodka", "Voice",
                             "Voted", "Voter", "Votes", "Vowed", "Vowel", "Wages", "Wagon", "Waist", "Waits", "Walks", "Walls", "Wants", "Wards", "Wares", "Warns", "Waste", "Watch", "Waved",
                             "Waves", "Wears", "Weary", "Wedge", "Weeds", "Weeks", "Weigh", "Weird", "Wells", "Welsh", "Whale", "Wheat", "Wheel", "While", "White", "Whole", "Whose", "Widen",
                             "Wider", "Widow", "Width", "Wills", "Winds", "Windy", "Wines", "Wings", "Wiped", "Wires", "Wiser", "Witch", "Witty", "Wives", "Woken", "Woman", "Women", "Woods",
                             "Words", "Works", "Worms", "Worry", "Worse", "Worst", "Worth", "Wound", "Woven", "Wrath", "Wreck", "Wrist", "Wrong", "Wrote", "Wryly", "Xerox", "Yacht", "Yards",
                             "Yawns", "Years", "Yeast", "Yield", "Young", "Yours", "Youth", "Zilch", "Zones"};

    string answer;
    int answerIndex;
    int ansIndex;
    int index;
    int currentIndex = 0;
    string[] choices = {" ", " ", " ", " ", " "};
    List<int> usedIndices = new List<int>();
  

    //Logging
    static int moduleCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleCounter++;
        needyWingdings = GetComponent<KMNeedyModule>();
        needyWingdings.OnNeedyActivation += OnNeedyActivation;
        needyWingdings.OnNeedyDeactivation += OnNeedyDeactivation;
        needyWingdings.OnTimerExpired += OnTimerExpired;
        foreach(KMSelectable cycler in cyclers)
        {
            cycler.OnInteract += delegate () { CycleWords(cycler); return false; };
        }
        submit.OnInteract += delegate () { SubmitWord(); return false; };

    }

    void Start()
    {

    }

    void OnNeedyActivation()
    {
        currentIndex = 0;
        usedIndices.Clear();
        answerIndex = UnityEngine.Random.Range(0, words.Length);
        answer = words[answerIndex];
        ansIndex = UnityEngine.Random.Range(0, 5);
        choices[ansIndex] = answer;
        usedIndices.Add(answerIndex);
        for(int i = 0; i < 5; i++)
        {
            if(i != ansIndex)
            {
                do
                {
                    index = UnityEngine.Random.Range(0, words.Length);
                } while (usedIndices.Contains(index));
                usedIndices.Add(index);
                choices[i] = words[index];
            }
        }
        display.GetComponent<TextMesh>().text = answer;
        submit.GetComponentInChildren<TextMesh>().text = choices[currentIndex];
        Debug.LogFormat("[Needy Wingdings #{0}] Possible words are {1}, {2}, {3}, {4}, {5}", moduleId, choices[0], choices[1], choices[2], choices[3], choices[4]);
        Debug.LogFormat("[Needy Wingdings #{0}] Correct word is: {1}", moduleId, choices[ansIndex]);
    }

    void OnNeedyDeactivation()
    {
        needyWingdings.HandlePass();
    }
   
    void OnTimerExpired()
    {
        Debug.LogFormat("[Needy Wingdings #{0}] Strike! You ran out of time", moduleId);
        needyWingdings.HandleStrike();
        OnNeedyDeactivation();
    }

    void CycleWords(KMSelectable cycler)
    {
        if(cycler == cyclers[0])
        {
            if(currentIndex != 4)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }
        else
        {
            if(currentIndex != 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = 4;
            }
        }
        submit.GetComponentInChildren<TextMesh>().text = choices[currentIndex];
    }

    void SubmitWord()
    {
        if (choices[currentIndex] == words[answerIndex])
        {
            Debug.LogFormat("[Needy Wingdings #{0}] Correct answer submitted, module defuse... For now", moduleId);
            OnNeedyDeactivation();
        }
        else
        {
            Debug.LogFormat("[Needy Wingdings #{0}] Wrong answer submitted, strike received.", moduleId);
            needyWingdings.HandleStrike();
            Debug.LogFormat("[Needy Wingdings #{0}] Resetting module...", moduleId);
            OnNeedyActivation();
        }
    }
}
