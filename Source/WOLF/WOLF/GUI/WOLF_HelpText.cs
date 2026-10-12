using UnityEngine;

namespace WOLF
{
    public class WOLF_HelpTopic
    {
        public readonly string Title;
        public readonly string Body;

        public WOLF_HelpTopic(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }

    /// <summary>
    /// All of the tooltip and help window text for the WOLF Dashboard.
    /// </summary>
    public static class WOLF_HelpText
    {
        private const string H = "<color=#FFD900><b>";
        private const string H_END = "</b></color>";

        #region Help topics
        public const int TOPIC_OVERVIEW = 0;
        public const int TOPIC_DEPOTS = 1;
        public const int TOPIC_HARVESTING = 2;
        public const int TOPIC_ROUTES = 5;
        public const int TOPIC_PLANNER = 6;

        /// <summary>
        /// The topic for a tab of the WOLF Dashboard.
        /// </summary>
        public static int TopicForTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    return TOPIC_DEPOTS;
                case 1:
                    return TOPIC_HARVESTING;
                case 2:
                    return TOPIC_ROUTES;
                case 3:
                    return TOPIC_PLANNER;
                default:
                    return TOPIC_OVERVIEW;
            }
        }

        public static readonly WOLF_HelpTopic[] Topics =
        {
            new WOLF_HelpTopic("What WOLF is",
                H + "Infrastructure instead of bases" + H_END + "\n" +
                "WOLF turns parts into permanent, abstract infrastructure. You fly a WOLF part to a biome, connect it to that biome's depot, and the vessel disappears. What stays behind is its effect: a steady flow of resources at that depot, forever, with no part count and nothing to maintain.\n\n" +
                H + "Flows, not stockpiles" + H_END + "\n" +
                "Every number in this dashboard is a flow. A depot never fills up or runs out. A resource is either supplied in a large enough quantity to cover what is drawn from it, or it is not.\n" +
                "<b>Incoming</b>  what is supplied to the depot.\n" +
                "<b>Outgoing</b>  what is already used by modules, hoppers and routes.\n" +
                "<b>Available</b>  Incoming minus Outgoing. This is what you can still build on.\n\n" +
                H + "The usual order" + H_END + "\n" +
                " 1. Survey a biome to see what can be harvested there.\n" +
                " 2. Establish a depot in it.\n" +
                " 3. Connect harvesters, then converters, each one using what the depot has available.\n" +
                " 4. Connect biomes with transport routes and move the surplus where it is needed.\n" +
                " 5. Use hoppers to turn a depot's flow back into real resources for a normal base or ship.\n\n" +
                H + "Careful" + H_END + "\n" +
                "Connecting to a depot is permanent. The vessel is removed from the game, and so are the kerbals aboard it: they become the depot's crew."),

            new WOLF_HelpTopic("Depots",
                H + "What this tab shows" + H_END + "\n" +
                "Every depot, grouped by body and biome, with the flow of each resource. Expand a depot with the + button.\n\n" +
                H + "Establishing a depot" + H_END + "\n" +
                " - One depot per biome. Low orbit around a body counts as one biome called Orbit.\n" +
                " - The vessel must be landed, splashed down, or in a low orbit with eccentricity below 0.1.\n" +
                " - The depot vessel must not carry any other WOLF part or any crew.\n" +
                " - Use <b>Establish depot</b> in the right-click menu of the WOLF Depot. The vessel disappears.\n" +
                "A new depot supplies a little Power to get started. On the surface of the home world it also supplies some Food, Oxygen, Water and MaterialKits.\n\n" +
                H + "Adding modules" + H_END + "\n" +
                "Land a vessel with WOLF modules in a biome that has a depot and use <b>Connect to depot</b>. All the WOLF modules and crew on that vessel are checked together. If the depot cannot supply everything they need, nothing happens and a message lists what is missing. If it can, the vessel disappears and its outputs are added to the depot.\n" +
                "The part info in the editor lists what each module Needs and Provides.\n\n" +
                H + "Crew" + H_END + "\n" +
                "Each kerbal on a connecting vessel needs 1 LifeSupport and 1 Habitation, and provides CrewPoints of their profession: 2 per experience level, and at least 1. Some modules need CrewPoints of a particular profession to run.\n\n" +
                H + "Filters" + H_END + "\n" +
                "The buttons above the list hide or show groups of resources. A resource is listed when any group it belongs to is switched on."),

            new WOLF_HelpTopic("Harvestable Resources",
                H + "What this tab shows" + H_END + "\n" +
                "The raw resources found in each surveyed biome.\n" +
                "<b>Abundance</b>  how much the biome can supply in total.\n" +
                "<b>Harvested</b>  how much your harvesters already take.\n" +
                "<b>Available</b>  what is left for more harvesters.\n\n" +
                H + "Surveying" + H_END + "\n" +
                "Fit a Surface Scanning Module to a vessel, take it to the biome and use <b>Survey WOLF Biome</b> in its right-click menu. The vessel is not consumed, so one scanner can survey many biomes. A survey also earns Science.\n" +
                "What you find depends on whether you are landed, splashed down or in orbit.\n\n" +
                H + "Harvesting" + H_END + "\n" +
                "Harvesters turn a biome's abundance into a raw resource at the depot. Like every module they must be connected to an established depot in that biome, so a biome needs both a survey and a depot before it produces anything."),

            new WOLF_HelpTopic("Converters and recipes",
                H + "Chains" + H_END + "\n" +
                "Each WOLF module has a recipe: what it Needs from the depot and what it Provides. Raw resources feed refineries, refined resources feed fabricators, and so on.\n\n" +
                H + "Support resources" + H_END + "\n" +
                "Most modules also need resources that other modules provide:\n" +
                " - <b>Power</b> from Power Modules\n" +
                " - <b>Maintenance</b> from Maintenance Modules\n" +
                " - <b>Lab</b> from Science Modules, for life support modules\n" +
                " - <b>CrewPoints</b> from kerbals\n" +
                " - <b>Habitation</b> and <b>LifeSupport</b> for those kerbals\n\n" +
                H + "Changing a recipe" + H_END + "\n" +
                "Modules with several recipes have Next Recipe and Previous Recipe in their right-click menu. Pick the recipe before connecting: once the vessel is gone it cannot be changed.\n\n" +
                H + "Planning" + H_END + "\n" +
                "Build the vessel in the editor and open the Planner tab there. It shows what the depot would look like after connecting it."),

            new WOLF_HelpTopic("Hoppers",
                H + "What they are" + H_END + "\n" +
                "A hopper is the way back from WOLF to real resources. It is a normal part that stays in the game, draws a flow from the depot in its biome and fills ordinary tanks with it.\n\n" +
                H + "How to use one" + H_END + "\n" +
                " - Place the hopper in a biome with an established depot and use <b>Connect to depot</b>.\n" +
                " - The depot must have the hopper's input available. That amount is reserved for as long as the hopper is connected.\n" +
                " - Start the hopper like a converter. It produces real resources into the vessel.\n\n" +
                H + "Rules" + H_END + "\n" +
                " - A hopper cannot be on the same vessel as a depot or other WOLF modules when it connects.\n" +
                " - Disconnect it before changing its recipe.\n" +
                " - Disconnecting, recovering or losing the vessel gives the reserved flow back to the depot.\n" +
                " - Moving it out of the biome breaks the connection."),

            new WOLF_HelpTopic("Routes and transfers",
                H + "What this tab shows" + H_END + "\n" +
                "Each transport route between two depots, how much cargo space it has, and which resources are assigned to it.\n\n" +
                H + "Creating a route" + H_END + "\n" +
                " 1. Build a vessel with a WOLF Transport Computer and one or more WOLF Cargo Kontainers.\n" +
                " 2. In a biome with a depot, use <b>Connect to origin depot</b>.\n" +
                " 3. Fly the vessel to another biome with a depot.\n" +
                " 4. Use <b>Connect to destination depot</b>.\n" +
                "The vessel is not consumed, so it can fly more routes.\n\n" +
                H + "Cargo space and cost" + H_END + "\n" +
                "<b>Cargo space</b> is the total Payload of the Cargo Kontainers. Flying the same route again adds to it.\n" +
                "<b>Cost</b> is the mass the vessel lost on the way, in tonnes: fuel burned and stages dropped. It is paid in TransportCredits, which the origin depot must have available. Transport Modules provide them. An efficient flight makes a cheap route.\n\n" +
                H + "Assigning resources" + H_END + "\n" +
                "A route moves nothing until you assign resources to it. Open <b>Manage Transfers</b>, pick the route, pick a resource the origin has available, and enter an amount. That amount becomes Outgoing at the origin and Incoming at the destination.\n" +
                "A transfer cannot be removed while something at the destination depends on it.\n\n" +
                H + "Crew routes" + H_END + "\n" +
                "Kerbals travel between WOLF Terminals on routes flown with Crew Cargo Kontainers. Those are managed from the terminal's own window."),

            new WOLF_HelpTopic("Planner",
                H + "What it is" + H_END + "\n" +
                "A preview, in the editor, of what the vessel you are building would do to a depot if you connected it there.\n\n" +
                H + "How to read it" + H_END + "\n" +
                "Pick a depot at the top. For every resource the vessel touches:\n" +
                "<b>Incoming</b>  the depot's current supply, and in brackets what this vessel would add.\n" +
                "<b>Outgoing</b>  the depot's current use, and in brackets what this vessel would take.\n" +
                "<b>Available</b>  the result. Red means the depot cannot support the vessel yet.\n\n" +
                "Crew assigned in the editor are included: their LifeSupport and Habitation needs, and the CrewPoints they provide.\n\n" +
                "The second table does the same for the biome's harvestable resources.\n\n" +
                H + "Tip" + H_END + "\n" +
                "Fix every red number before launch. A vessel only connects if the depot can supply all of it at once.")
        };
        #endregion

        #region WOLF Dashboard
        public static readonly GUIContent[] TabLabels =
        {
            new GUIContent("Depots", "Resource flows at each depot."),
            new GUIContent("Harvestable Resources", "Raw resources found in each surveyed biome, and how much of them is already harvested."),
            new GUIContent("Routes", "Transport routes between depots and the resources assigned to them.")
        };
        public static readonly GUIContent PlannerTabLabel = new GUIContent("Planner", "Preview what the vessel you are building would do to a depot.");

        public static readonly GUIContent HelpButton = new GUIContent("?", "Open the help window on the topic for this tab.");
        public static readonly GUIContent ExpandAll = new GUIContent("+", "Expand all.");
        public static readonly GUIContent CollapseAll = new GUIContent("-", "Collapse all.");
        public static readonly GUIContent Expand = new GUIContent("+", "Show the details.");
        public static readonly GUIContent Collapse = new GUIContent("-", "Hide the details.");

        // Depots and Harvestable Resources
        public static readonly GUIContent BodyBiome = new GUIContent("Body/Biome", "Each depot serves one biome. Orbit counts as a biome of its own.");
        public static readonly GUIContent Resource = new GUIContent("Resource", "These are steady flows, not stockpiles.");
        public static readonly GUIContent Incoming = new GUIContent("Incoming", "What is supplied to this depot by modules, routes and its starting resources.");
        public static readonly GUIContent Outgoing = new GUIContent("Outgoing", "What is already used by modules, hoppers and routes.");
        public static readonly GUIContent Available = new GUIContent("Available", "Incoming minus Outgoing. This is what new modules, hoppers and routes can use.");
        public static readonly GUIContent Abundance = new GUIContent("Abundance", "How much of this raw resource the biome can supply, as found by the survey.");
        public static readonly GUIContent Harvested = new GUIContent("Harvested", "How much of it your harvesters already take.");
        public static readonly GUIContent HarvestAvailable = new GUIContent("Available", "What is left for more harvesters.");

        // Filters
        public const string FilterOriginTip = "Show only the depots on this body, and optionally in one biome.";
        public const string FilterDestinationTip = "Destination body and biome.";
        public const string FilterRawTip = "Show or hide raw resources, such as Ore, Water and Minerals.";
        public const string FilterRefinedTip = "Show or hide refined resources, such as Metals, Chemicals and Fuel.";
        public const string FilterAssembledTip = "Show or hide assembled resources, such as MaterialKits, Machinery and TransportCredits.";
        public const string FilterLifeSupportTip = "Show or hide life support resources, such as Food, Habitation and LifeSupport.";
        public const string FilterCrewTip = "Show or hide the CrewPoints provided by kerbals.";
        public const string FilterResetTip = "Show every depot and every group of resources again.";

        // Routes
        public static readonly GUIContent ManageTransfers = new GUIContent("Manage Transfers", "Assign resources to a route, or remove them. A route moves nothing until you do.");
        public static readonly GUIContent RouteOrigin = new GUIContent("Origin", "The depot the resources leave from.");
        public static readonly GUIContent RouteDestination = new GUIContent("Destination", "The depot the resources arrive at.");
        public static readonly GUIContent RouteCargoSpace = new GUIContent("Cargo Space",
            "Total cargo space of the route, from the Cargo Kontainers on the vessels that flew it. Flying the route again adds more.");
        public static readonly GUIContent RouteResource = new GUIContent("Resource", "Resources assigned to this route.");
        public static readonly GUIContent RouteQuantity = new GUIContent("Quantity", "Cargo space used by this resource.");

        // Planner
        public static readonly GUIContent PlannerDepot = new GUIContent("Depot", "The depot to compare the vessel against.");
        public static readonly GUIContent PlannerPrevious = new GUIContent('◄'.ToString(), "Previous depot.");
        public static readonly GUIContent PlannerNext = new GUIContent('►'.ToString(), "Next depot.");
        public static readonly GUIContent PlannerResource = new GUIContent("Resource", "Resources this vessel needs or provides.");
        public static readonly GUIContent PlannerIncoming = new GUIContent("Incoming", "The depot's current supply. In brackets: what this vessel would add.");
        public static readonly GUIContent PlannerOutgoing = new GUIContent("Outgoing", "The depot's current use. In brackets: what this vessel would take.");
        public static readonly GUIContent PlannerAvailable = new GUIContent("Available",
            "What would be left after connecting this vessel. Red means the depot cannot support it yet.");
        public static readonly GUIContent PlannerHarvestable = new GUIContent("Harvestable Resource", "Raw resources of the biome that this vessel would harvest.");
        public static readonly GUIContent PlannerAbundance = new GUIContent("Abundance", "How much the biome can supply.");
        public static readonly GUIContent PlannerHarvested = new GUIContent("Harvested", "What is already harvested. In brackets: what this vessel would take.");
        public static readonly GUIContent PlannerHarvestAvailable = new GUIContent("Available",
            "What would be left after connecting this vessel. Red means the biome does not have enough.");
        #endregion

        #region Manage Transfers window
        public static readonly GUIContent TransferRoute = new GUIContent("Route", "The route to assign resources to.");
        public static readonly GUIContent TransferPrevious = new GUIContent('◄'.ToString(), "Previous route.");
        public static readonly GUIContent TransferNext = new GUIContent('►'.ToString(), "Next route.");
        public static readonly GUIContent TransferResource = new GUIContent(" Resource", "Resources at the origin depot that can be sent on a route.");
        public static readonly GUIContent TransferAvailable = new GUIContent("Available", "What the origin depot has available.");
        public static readonly GUIContent TransferSelect = new GUIContent('▼'.ToString(), "Select this resource to send it on the route.");
        public static readonly GUIContent TransferSelectedOrigin = new GUIContent("Origin:", "Available at the origin depot.");
        public static readonly GUIContent TransferSelectedDestination = new GUIContent("Destination:", "Available / Incoming at the destination depot.");
        public static readonly GUIContent TransferAmount = new GUIContent("Transfer Amount",
            "A whole number, no more than the origin has available and no more than the route's available payload.");
        public static readonly GUIContent TransferButton = new GUIContent("Transfer",
            "Assign this amount to the route. It becomes Outgoing at the origin and Incoming at the destination.");
        public static readonly GUIContent TransferQuantity = new GUIContent("Quantity", "Cargo space used by this resource.");
        public static readonly GUIContent TransferRemove = new GUIContent('×'.ToString(),
            "Remove this resource from the route. Not possible while something at the destination depends on it.");
        public static readonly GUIContent TransferAvailablePayload = new GUIContent("Available Payload:", "Cargo space on this route that is not assigned yet.");
        public static readonly GUIContent TransferTotalPayload = new GUIContent("Total Payload:", "Total cargo space of this route.");
        #endregion
    }
}
