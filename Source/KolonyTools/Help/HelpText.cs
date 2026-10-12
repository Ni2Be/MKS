using UnityEngine;

namespace KolonyTools
{
    public class HelpTopic
    {
        public readonly string Title;
        public readonly string Body;

        public HelpTopic(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }

    /// <summary>
    /// All of the tooltip and help window text for the Kolonization Dashboard and Orbital Logistics windows.
    /// </summary>
    public static class HelpText
    {
        private const string H = "<color=#FFD900><b>";
        private const string H_END = "</b></color>";

        #region Help topics
        public const int TOPIC_OVERVIEW = 0;
        public const int TOPIC_ORBITAL_LOGISTICS = 5;

        /// <summary>
        /// The topic for a tab of the Kolonization Dashboard. Topics 1 to 5 are in the same order as the tabs.
        /// </summary>
        public static int TopicForTab(int tab)
        {
            return tab + 1;
        }

        public static readonly HelpTopic[] Topics =
        {
            new HelpTopic("How MKS fits together",
                H + "Bases work by distance" + H_END + "\n" +
                "A base is a group of landed vessels near each other. They do not have to be docked: most MKS systems reach nearby vessels on their own.\n\n" +
                H + "Ranges" + H_END + "\n" +
                "<b>150 m</b>  Local Logistics and Kolony Inventory, between landed vessels.\n" +
                "<b>500 m</b>  Efficiency parts, and the crew that Planetary Logistics needs.\n" +
                "<b>Same body</b>  Planetary Logistics (landed vessels) and Orbital Logistics (landed or in orbit).\n\n" +
                H + "What makes a converter faster" + H_END + "\n" +
                "MKS converters, drills and farms multiply their output by:\n" +
                " - the research bonuses of the body they are on (Kolony Statistics tab)\n" +
                " - efficiency parts of the matching type running on landed vessels within 500 m. Their boost is shared between all the running converters of that type, so more converters each get a smaller share.\n" +
                " - the Governor slider in the part's right-click menu, which can only slow a part down\n\n" +
                H + "Moving resources" + H_END + "\n" +
                " - <b>Local Logistics</b>: by hand, between landed vessels within 150 m.\n" +
                " - <b>Planetary Logistics</b>: automatic, through one shared stockpile per body.\n" +
                " - <b>Orbital Logistics</b>: timed deliveries between two logistics vessels around the same body, paid for with Transport Credits.\n\n" +
                "Each tab of the dashboard has its own topic in the list on the left."),

            new HelpTopic("Kolony Statistics",
                H + "What this tab shows" + H_END + "\n" +
                "One row per body you have a base on, with its three research bonuses. 100% means no bonus yet. The number in brackets is how many kerbals are raising that bonus right now.\n\n" +
                H + "What the bonuses do" + H_END + "\n" +
                "<b>Geology</b> speeds up every MKS converter and drill on that body.\n" +
                "<b>Botany</b> gives a second boost to farms and other agriculture parts.\n" +
                "<b>Kolonization</b> gives a second boost to habitation and medical parts, and extends habitation time on that body.\n" +
                "Parts that are neither get the Geology bonus twice.\n\n" +
                H + "How to raise them" + H_END + "\n" +
                "Research grows while kerbals of the right profession are aboard a vessel with MKS parts:\n" +
                " - Geology: Engineers, Miners, Technicians, Mechanics, Geologists, Kolonists\n" +
                " - Botany: Scientists, Biologists, Farmers, Medics, Kolonists\n" +
                " - Kolonization: Pilots, Quartermasters, Farmers, Medics, Kolonists\n" +
                "More kerbals means faster research, but each bonus grows with the square root of the time invested, so it slows down as it climbs.\n\n" +
                H + "Limits" + H_END + "\n" +
                "Nothing is earned on the home world. With the default settings, vessels in orbit earn nothing either: the base has to be landed.\n\n" +
                H + "Rewards" + H_END + "\n" +
                "The same kerbals also earn Funds, Science and Reputation over time. Collect them with <b>Check Kolony Rewards</b> in the right-click menu of a part that offers it."),

            new HelpTopic("Local Logistics",
                H + "What it is" + H_END + "\n" +
                "A manual pump between two landed vessels that are close together, without docking them.\n\n" +
                H + "What you need" + H_END + "\n" +
                " - The active vessel and at least one other vessel, all landed and within 150 m of the active vessel\n" +
                " - At least one kerbal aboard one of them\n" +
                " - A resource both vessels can store\n\n" +
                H + "How to use it" + H_END + "\n" +
                "Pick the two vessels with the arrow buttons at the top. The left vessel is shown in white, the right one in yellow.\n" +
                "Each resource row has five buttons:\n" +
                " - first button: slow flow to the left vessel\n" +
                " - second button: fast flow to the left vessel\n" +
                " - X: stop\n" +
                " - fourth button: fast flow to the right vessel\n" +
                " - fifth button: slow flow to the right vessel\n" +
                "A flow keeps running until you press X, the source is empty or the target is full. It only runs while this tab is open.\n\n" +
                "The value in square brackets is the free space left in that vessel.\n\n" +
                H + "Not transferable" + H_END + "\n" +
                "Machinery, EnrichedUranium, DepletedFuel, ElectricCharge and resources that cannot flow between parts."),

            new HelpTopic("Planetary Logistics",
                H + "What it is" + H_END + "\n" +
                "One shared stockpile per body. Bases anywhere on the surface push their surplus into it and pull from it when they run low, with no flying involved. This tab lists what is stored on each body.\n\n" +
                H + "What you need" + H_END + "\n" +
                " - A landed vessel with a planetary logistics part, such as the Tundra Pioneer modules, the Duna Logistics Center, the Material Processing Units or the Atlas domes\n" +
                " - Storage on that same vessel with <b>Planetary Warehouse</b> switched on in its right-click menu\n" +
                " - To pull from the stockpile: a Pilot or Quartermaster within 500 m\n\n" +
                H + "How it behaves" + H_END + "\n" +
                " - Above 75% full, a warehouse sends the excess down to 50% into the stockpile\n" +
                " - Below 25% full, it pulls back up to 50%, if the stockpile has that resource and the crew is present\n" +
                " - 5% of everything pushed is lost as a tax\n" +
                " - A resource whose flow is switched off in its tank is pushed in completely, if the stockpile already holds some of it\n\n" +
                "Not handled: ElectricCharge, EnrichedUranium, DepletedFuel, Construction, ReplacementParts."),

            new HelpTopic("Kolony Inventory",
                H + "What this tab shows" + H_END + "\n" +
                "The resources of the active vessel together with the landed vessels within 150 m of it, and how fast each one is changing.\n\n" +
                H + "Columns" + H_END + "\n" +
                "<b>Inventory</b>  how full the storage is. Green is rising, red is falling, grey is steady.\n" +
                "<b>Rate</b>  the change per second, minute, hour or day.\n" +
                "<b>Supply</b>  at the current rate, the time until the resource runs out (falling) or the storage is full (rising).\n\n" +
                "Use it to spot the resource that will stall your base first. Only available in flight."),

            new HelpTopic("Orbital Logistics",
                H + "What it is" + H_END + "\n" +
                "Deliveries between two vessels around the same body, on the surface or in orbit, without flying them yourself. This tab lists every transfer. Create new ones from <b>Orbital Logistics</b> in the right-click menu of a logistics part.\n\n" +
                H + "What you need" + H_END + "\n" +
                " - An orbital logistics part on both vessels, such as the Tundra Pioneer modules, the Duna Logistics Center or the Atlas domes\n" +
                " - Both vessels landed, splashed down or in orbit around the same body\n" +
                " - Enough <b>Transport Credits</b> (T-Credits) on the sending vessel. The Tundra Pioneer modules, the Duna Logistics Center and the Atlas Factory make them from ElectricCharge while running.\n\n" +
                H + "Cost and time" + H_END + "\n" +
                "The cost is an estimate of the fuel a delivery craft would burn for the trip there and back, so heavy loads and deep gravity wells are expensive. T-Credits are taken from the sending vessel at launch.\n" +
                "The delivery takes time: loading, flight and docking. The resources leave the sender at launch and arrive when the timer runs out.\n\n" +
                H + "Statuses" + H_END + "\n" +
                "<b>Launched</b>  on its way.\n" +
                "<b>Returning</b>  aborted, the cargo is on its way back to the sender.\n" +
                "<b>Delivered</b>  arrived in full.\n" +
                "<b>Partial</b>  the destination did not have room for all of it.\n" +
                "<b>Cancelled</b>  aborted and returned.\n" +
                "<b>Failed</b>  a vessel is gone, has left the body, or has lost its logistics part.\n\n" +
                "Only resources that have mass and that both vessels can store can be sent.")
        };
        #endregion

        #region Kolonization Dashboard
        public static readonly GUIContent[] TabLabels =
        {
            new GUIContent("Kolony Statistics", "Research bonuses for each body you have a base on."),
            new GUIContent("Local Logistics", "Move resources by hand between landed vessels within 150 m."),
            new GUIContent("Planetary Logistics", "The shared stockpile on each body that bases push to and pull from."),
            new GUIContent("Kolony Inventory", "Resources of the active vessel and its neighbours, with rates of change."),
            new GUIContent("Orbital Logistics", "Deliveries between vessels around the same body.")
        };

        public static readonly GUIContent HelpButton = new GUIContent("?", "Open the help window on the topic for this tab.");

        // Kolony Statistics
        public static readonly GUIContent StatsBody = new GUIContent("Body Name", "Bodies with a base that has earned research. The one you are at is listed first.");
        public static readonly GUIContent StatsGeology = new GUIContent("Geology",
            "Speeds up every MKS converter and drill on this body. 100% means no bonus yet.\n\nRaised by Engineers, Miners, Technicians, Mechanics, Geologists and Kolonists. The number in brackets is how many are working on it now.");
        public static readonly GUIContent StatsBotany = new GUIContent("Botany",
            "Extra boost for farms and other agriculture parts on this body.\n\nRaised by Scientists, Biologists, Farmers, Medics and Kolonists. The number in brackets is how many are working on it now.");
        public static readonly GUIContent StatsKolonization = new GUIContent("Kolonization",
            "Extra boost for habitation and medical parts on this body, and longer habitation time.\n\nRaised by Pilots, Quartermasters, Farmers, Medics and Kolonists. The number in brackets is how many are working on it now.");
        public const string StatsEmpty =
            "No research yet. Land a vessel with MKS parts and crew on a body other than the home world to start earning bonuses.";

        // Local Logistics
        public const string LocalNoVessels =
            "Nothing to transfer with. This needs at least two landed vessels within 150 m of the active vessel, and a kerbal aboard one of them.";
        public const string LocalNoResources = "These two vessels have no transferable resource in common.";
        public static readonly GUIContent LocalPrevLeft = new GUIContent("<", "Previous vessel for the left side.");
        public static readonly GUIContent LocalNextLeft = new GUIContent(">", "Next vessel for the left side.");
        public static readonly GUIContent LocalPrevRight = new GUIContent("<", "Previous vessel for the right side.");
        public static readonly GUIContent LocalNextRight = new GUIContent(">", "Next vessel for the right side.");
        public static readonly GUIContent LocalSlowLeft = new GUIContent("<", "Slow flow to the left vessel. Keeps running until you press X.");
        public static readonly GUIContent LocalFastLeft = new GUIContent("<<", "Fast flow to the left vessel. Keeps running until you press X.");
        public static readonly GUIContent LocalStop = new GUIContent("X", "Stop this transfer.");
        public static readonly GUIContent LocalFastRight = new GUIContent(">>", "Fast flow to the right vessel. Keeps running until you press X.");
        public static readonly GUIContent LocalSlowRight = new GUIContent(">", "Slow flow to the right vessel. Keeps running until you press X.");
        public const string LocalAmountTip = "Amount / capacity in this vessel. The value in brackets is the free space.";

        // Planetary Logistics
        public const string PlanetaryEmpty =
            "Nothing stored yet. A landed vessel with a planetary logistics part pushes surplus here from storage that has Planetary Warehouse switched on.";
        public const string PlanetaryBodyTip = "Stockpile shared by every base on this body.";
        public const string PlanetaryAmountTip =
            "Units in the stockpile. Warehouses below 25% pull from it when a Pilot or Quartermaster is within 500 m.";

        // Kolony Inventory
        public static readonly GUIContent InventoryResource = new GUIContent("<color=#FFFFFF>Resource</color>",
            "Resources on the active vessel and on landed vessels within 150 m.");
        public static readonly GUIContent InventoryAmount = new GUIContent("<color=#FFFFFF>Inventory</color>",
            "How full the storage is. Green is rising, red is falling, grey is steady.");
        public static readonly GUIContent InventoryRate = new GUIContent("<color=#FFFFFF>Rate</color>", "Change over time, measured between refreshes.");
        public static readonly GUIContent InventorySupply = new GUIContent("<color=#FFFFFF>Supply</color>",
            "At the current rate: time until this runs out if it is falling, or until storage is full if it is rising.");
        #endregion

        #region Orbital Logistics
        public static readonly GUIContent OrbLogPending = new GUIContent("Pending Transfers", "Deliveries that are on their way, or on their way back after being aborted.");
        public static readonly GUIContent OrbLogExpired = new GUIContent("Expired Transfers", "Deliveries that have finished, failed or been cancelled.");
        public static readonly GUIContent OrbLogOrigin = new GUIContent(" Origin", "The vessel the resources were taken from.");
        public static readonly GUIContent OrbLogDestination = new GUIContent("Destination", "The vessel the resources are going to.");
        public static readonly GUIContent OrbLogCost = new GUIContent("Cost", "Transport Credits paid by the origin vessel at launch.");
        public static readonly GUIContent OrbLogMass = new GUIContent("Mass", "Total mass of the cargo, in tonnes.");
        public static readonly GUIContent OrbLogArrival = new GUIContent("Arrival Time", "Time left until the cargo arrives.");
        public static readonly GUIContent OrbLogStatus = new GUIContent("Status",
            "Delivered: arrived in full.\nPartial: the destination ran out of room.\nCancelled: aborted and returned.\nFailed: a vessel is gone, left the body or lost its logistics part.");
        public static readonly GUIContent OrbLogDetails = new GUIContent('►'.ToString(), "Show the details of this transfer.");
        public static readonly GUIContent OrbLogAbort = new GUIContent('×'.ToString(), "Abort this transfer. The cargo returns to the origin vessel.");
        public static readonly GUIContent OrbLogRemove = new GUIContent('×'.ToString(), "Remove this entry from the list.");
        public static readonly GUIContent OrbLogClearAll = new GUIContent("Clear All", "Remove every expired transfer from the list.");
        public static readonly GUIContent OrbLogNewTransfer = new GUIContent("New Transfer",
            "Send resources from this vessel to another logistics vessel around the same body.");
        public static readonly GUIContent OrbLogHelp = new GUIContent("?", "Open the help window on Orbital Logistics.");

        // New Transfer window
        public static readonly GUIContent CreateOrigin = new GUIContent("Origin", "The vessel that sends the resources and pays the Transport Credits.");
        public static readonly GUIContent CreateDestination = new GUIContent("Destination",
            "Vessels around this body that have an orbital logistics part and are landed, splashed down or in orbit.");
        public static readonly GUIContent CreatePrevVessel = new GUIContent('◄'.ToString(), "Previous destination vessel.");
        public static readonly GUIContent CreateNextVessel = new GUIContent('►'.ToString(), "Next destination vessel.");
        public static readonly GUIContent CreateResource = new GUIContent(" Resource", "Resources that both vessels can store. Resources without mass cannot be sent.");
        public static readonly GUIContent CreateAvailable = new GUIContent("Available", "Amount / capacity on the origin vessel.");
        public static readonly GUIContent CreateSelect = new GUIContent('▼'.ToString(), "Select this resource to add it to the transfer.");
        public static readonly GUIContent CreateSelectedOrigin = new GUIContent("Origin:", "Amount on the origin vessel.");
        public static readonly GUIContent CreateSelectedDestination = new GUIContent("Destination:", "Amount / capacity on the destination vessel.");
        public static readonly GUIContent CreateFill = new GUIContent("Fill", "Enter the amount that fills the destination, or everything the origin has if that is less.");
        public static readonly GUIContent CreateAdd = new GUIContent("Add to Transfer", "Add the entered amount of this resource to the transfer list below.");
        public static readonly GUIContent CreateQuantity = new GUIContent("Quantity", "Units that will be sent.");
        public static readonly GUIContent CreateCost = new GUIContent("Cost", "This resource's share of the Transport Credits, by mass.");
        public static readonly GUIContent CreateRemove = new GUIContent('×'.ToString(), "Remove this resource from the transfer.");
        public static readonly GUIContent CreateTotalMass = new GUIContent("Total Mass:", "Mass of the cargo, in tonnes. Heavier loads cost more and take longer to load.");
        public static readonly GUIContent CreateTotalCost = new GUIContent("Total Cost:",
            "Transport Credits needed / Transport Credits on the origin vessel. Red means the vessel cannot afford it.");
        public static readonly GUIContent CreateTransitTime = new GUIContent("Transit Time:", "How long the delivery takes: loading, flight and docking.");
        public static readonly GUIContent CreateStart = new GUIContent("Start Transfer",
            "Take the resources and the Transport Credits from the origin vessel and launch the delivery.");

        // Transfer Details window
        public static readonly GUIContent ReviewStatus = new GUIContent("Status:",
            "Launched: on its way.\nReturning: aborted, on its way back.\nDelivered, Partial, Cancelled or Failed once it has ended.");
        public static readonly GUIContent ReviewCosts = new GUIContent("Transport Costs", "Each resource's share of the Transport Credits, by mass.");
        public static readonly GUIContent ReviewAbort = new GUIContent("Abort", "Turn the delivery around. The cargo returns to the origin vessel.");
        public static readonly GUIContent ReviewResume = new GUIContent("Resume", "Send the returning cargo to the destination again.");
        public static readonly GUIContent ReviewRemove = new GUIContent("Remove", "Remove this transfer from the list.");
        #endregion
    }
}
