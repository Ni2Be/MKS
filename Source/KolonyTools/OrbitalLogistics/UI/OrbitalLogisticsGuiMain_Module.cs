using UnityEngine;
using USITools.UI;

namespace KolonyTools
{
    /// <summary>
    /// Displays the UI for <see cref="ModuleOrbitalLogistics"/>.
    /// </summary>
    public class OrbitalLogisticsGuiMain_Module : Window, ITransferRequestViewParent
    {
        #region Local instance variables
        private readonly ModuleOrbitalLogistics _module;
        private ScenarioOrbitalLogistics _scenario;
        private Vector2 _scrollPositionCurrentTransfers;
        private Vector2 _scrollPositionPreviousTransfers;
        #endregion

        #region Public instance properties
        public OrbitalLogisticsGui_CreateTransfer CreateTransferGui { get; set; }
        public OrbitalLogisticsGui_ReviewTransfer ReviewTransferGui { get; set; }
        #endregion

        #region Constructors
        public OrbitalLogisticsGuiMain_Module(ModuleOrbitalLogistics partModule, ScenarioOrbitalLogistics scenario)
            : base("Orbital Logistics", 460, 460)
        {
            _module = partModule;
            _scenario = scenario;

            SetVisible(true);
        }
        #endregion

        /// <summary>
        /// Called by <see cref="MonoBehaviour"/>.OnGUI to render the UI.
        /// </summary>
        /// <param name="windowId"></param>
        protected override void DrawWindowContents(int windowId)
        {
            // Allocate some variables for later
            GUIStyle labelStyle;
            GUIStyle rAlignLabelStyle;

            GUILayout.BeginVertical();

            // Display pending transfers section header
            GUILayout.Label(HelpText.OrbLogPending, UIHelper.labelStyle, GUILayout.Width(200));
            _scrollPositionCurrentTransfers = GUILayout.BeginScrollView(_scrollPositionCurrentTransfers);

            // Display pending transfers column headers
            GUILayout.BeginHorizontal();
            GUILayout.Label(string.Empty, UIHelper.labelStyle, GUILayout.Width(25));
            GUILayout.Label(HelpText.OrbLogOrigin, UIHelper.whiteLabelStyle, GUILayout.Width(155));
            GUILayout.Label(HelpText.OrbLogDestination, UIHelper.whiteLabelStyle, GUILayout.Width(155));
            GUILayout.Label(HelpText.OrbLogArrival, UIHelper.whiteRightAlignLabelStyle, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            // Display pending transfers
            foreach (OrbitalLogisticsTransferRequest transfer in _scenario.PendingTransfers)
            {
                // Only show transfers in the module's SoI
                if (transfer.Destination == null
                    || transfer.Origin == null
                    || (transfer.Destination.mainBody != _module.vessel.mainBody
                        && transfer.Origin.mainBody != _module.vessel.mainBody))
                    continue;

                // Determine text color based on transfer status
                if (transfer.Status == DeliveryStatus.Returning)
                {
                    labelStyle = UIHelper.redLabelStyle;
                    rAlignLabelStyle = UIHelper.redRightAlignLabelStyle;
                }
                else
                {
                    labelStyle = UIHelper.yellowLabelStyle;
                    rAlignLabelStyle = UIHelper.yellowRightAlignLabelStyle;
                }

                GUILayout.BeginHorizontal();
                if (GUILayout.Button(HelpText.OrbLogDetails, UIHelper.buttonStyle, GUILayout.Width(25), GUILayout.Height(22)))
                {
                    if (ReviewTransferGui == null)
                        ReviewTransferGui = new OrbitalLogisticsGui_ReviewTransfer(transfer, this);
                    else
                        ReviewTransferGui.Transfer = transfer;

                    ReviewTransferGui.SetVisible(true);
                }
                GUILayout.Label(" " + transfer.OriginVesselName, labelStyle, GUILayout.Width(155));
                GUILayout.Label(transfer.DestinationVesselName, labelStyle, GUILayout.Width(155));
                GUILayout.Label(
                    Utilities.FormatTime(transfer.GetArrivalTime() - Planetarium.GetUniversalTime()),
                    rAlignLabelStyle, GUILayout.Width(80)
                );
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();

            // Display expired transfers section header
            GUILayout.Label(HelpText.OrbLogExpired, UIHelper.labelStyle, GUILayout.Width(200));
            _scrollPositionPreviousTransfers = GUILayout.BeginScrollView(_scrollPositionPreviousTransfers);

            // Display expired transfers column headers
            GUILayout.BeginHorizontal();
            GUILayout.Label(string.Empty, UIHelper.labelStyle, GUILayout.Width(25));
            GUILayout.Label(HelpText.OrbLogOrigin, UIHelper.whiteLabelStyle, GUILayout.Width(155));
            GUILayout.Label(HelpText.OrbLogDestination, UIHelper.whiteLabelStyle, GUILayout.Width(155));
            GUILayout.Label(HelpText.OrbLogStatus, UIHelper.whiteLabelStyle, GUILayout.Width(80));
            GUILayout.EndHorizontal();

            // Display expired transfers
            foreach (OrbitalLogisticsTransferRequest transfer in _scenario.ExpiredTransfers)
            {
                // Only show transfers in the module's SoI
                if (transfer.Destination == null
                    || transfer.Origin == null
                    || (transfer.Destination.mainBody != _module.vessel.mainBody
                        && transfer.Origin.mainBody != _module.vessel.mainBody))
                    continue;

                // Determine text color based on transfer status
                if (transfer.Status == DeliveryStatus.Delivered)
                {
                    labelStyle = UIHelper.yellowLabelStyle;
                }
                else
                {
                    labelStyle = UIHelper.redLabelStyle;
                }

                GUILayout.BeginHorizontal();
                if (GUILayout.Button(HelpText.OrbLogDetails, UIHelper.buttonStyle, GUILayout.Width(25), GUILayout.Height(22)))
                {
                    if (ReviewTransferGui == null)
                        ReviewTransferGui = new OrbitalLogisticsGui_ReviewTransfer(transfer, this);
                    else
                        ReviewTransferGui.Transfer = transfer;

                    ReviewTransferGui.SetVisible(true);
                }
                GUILayout.Label(" " + transfer.OriginVesselName, labelStyle, GUILayout.Width(155));
                GUILayout.Label(transfer.DestinationVesselName, labelStyle, GUILayout.Width(155));
                GUILayout.Label(transfer.Status.ToString(), labelStyle, GUILayout.Width(80));
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();

            GUILayout.BeginHorizontal();
            GUILayout.Label(string.Empty, UIHelper.labelStyle, GUILayout.Width(100));
            if (GUILayout.Button(HelpText.OrbLogNewTransfer, UIHelper.buttonStyle, GUILayout.Width(120)))
            {
                _module.MakeBodyVesselList();

                CreateTransferGui = new OrbitalLogisticsGui_CreateTransfer(_module, _scenario);
            }
            if (GUILayout.Button("Close", UIHelper.buttonStyle, GUILayout.Width(120)))
            {
                SetVisible(false);
            }
            if (GUILayout.Button(HelpText.OrbLogHelp, UIHelper.buttonStyle, GUILayout.Width(25)))
            {
                KolonizationMonitor.ShowHelp(HelpText.TOPIC_ORBITAL_LOGISTICS, _windowPos);
            }
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            Tooltip.Draw(_windowPos);
        }

        /// <summary>
        /// Implementation of <see cref="Window.SetVisible(bool)"/>.
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetVisible(bool newValue)
        {
            base.SetVisible(newValue);

            // Always hide child windows when main window visibility is altered
            if (CreateTransferGui != null)
                CreateTransferGui.SetVisible(false);

            if (ReviewTransferGui != null)
                ReviewTransferGui.SetVisible(false);
        }

        /// <summary>
        /// Aborts a transfer via <see cref="ScenarioOrbitalLogistics"/>.
        /// </summary>
        /// <remarks>
        /// Implementation of <see cref="ITransferRequestViewParent.AbortTransfer(OrbitalLogisticsTransferRequest)"/>.
        /// </remarks>
        /// <param name="transfer"></param>
        public void AbortTransfer(OrbitalLogisticsTransferRequest transfer)
        {
            _scenario.AbortTransfer(transfer);
        }

        /// <summary>
        /// Resumes a cancelled transfer via <see cref="ScenarioOrbitalLogistics"/>.
        /// </summary>
        /// <remarks>
        /// Implementation of <see cref="ITransferRequestViewParent.ResumeTransfer(OrbitalLogisticsTransferRequest)"/>.
        /// </remarks>
        /// <param name="transfer"></param>
        public void ResumeTransfer(OrbitalLogisticsTransferRequest transfer)
        {
            _scenario.ResumeTransfer(transfer);
        }
    }
}