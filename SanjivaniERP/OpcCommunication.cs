using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TitaniumAS.Opc.Client.Common;
using TitaniumAS.Opc.Client.Da;

namespace SanjivaniERP
{
    public class OpcCommunication
    {
        private const string ServerUri = "ICONICS.ModbusOPC.3";
        private const int UpdateRateInMilliseconds = 1;
        public static string ReadRegister_old(string GroupName, string SubscribeItemId)
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            var itemDefinitions = new[]
            {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = SubscribeItemId, //itemid for opc server item
            }

        };

            Uri url = UrlBuilder.Build(ServerUri); //build url

            using (var server = new OpcDaServer(url))
            {
                // Connect to the server first.
                server.Connect();

                //OpcDaItem xy = server.Read()
                OpcDaGroup @group = server.AddGroup(GroupName, groupState); //add group on OPC server
                OpcDaItemResult[] results = @group.AddItems(itemDefinitions); //add items on OPC server

                foreach (OpcDaItemResult result in results) //print errors
                {
                    if (result.Error.Failed)
                    {
                        Console.WriteLine("Error on create item: '{0}'", result.Error);
                    }
                }

                OpcDaItemValue[] values1 = group.Read(group.Items, OpcDaDataSource.Device);
                string abc = Convert.ToString(values1[0].Value);

                server.Disconnect();
                return abc;

            }
        }
        public static OpcDaServer server;
        public static OpcDaGroup @group;
        public static OpcDaGroup @groupMaualRead;
        public static OpcDaGroup @groupIORead;
        public static OpcDaGroup @groupIOLocation;

        public static OpcDaGroup @groupManualWrite;
        public static OpcDaGroup @groupRunTo;
        public static OpcDaGroup @groupRack;
        public static OpcDaGroup @groupInitialLoadRead;
        public static OpcDaGroup @groupAutoLoadRead;
        public static OpcDaGroup @groupTraySetting;
        public static OpcDaGroup @groupSensor;
        public static OpcDaGroup @groupFault;
        public static OpcDaGroup @groupBloackLocation;
        public static OpcDaGroup @groupSections;
        public static OpcDaGroup @groupFrontSections;
        public static OpcDaGroup @groupCommon;
        public static OpcDaGroup @groupHeightLocation;
        public static OpcDaGroup @groupTrayLocation;
        public static OpcDaGroup @groupWriteDatabase;
        public static OpcDaGroup @grp1;
        public static OpcDaGroup @groupAutoIndication;
        public static OpcDaGroup @GroupLifter;
        public static void ConnectOPCServer()
        {
            Uri url = UrlBuilder.Build(ServerUri); //build url
            server = new OpcDaServer(url);
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            server.Connect();

            @group = server.AddGroup("groupManual", groupState); //add group on OPC server
                                                                 //Manual Drive Item
                                                                 //   @groupMaualRead = server.AddGroup("groupMaualRead", groupState); //add group on OPC server
                                                                 /// @groupManualWrite = server.AddGroup("groupManualWrite", groupState);
            ManualRead();
            ManualWrite();
            RunTo();
            IORead();
            InitialLoadRead();
            AutoLoadRead();
            LocationRead();
            Rack();
            TraySetting();
            ByPassSensor();
            Fault();
            BlockLocation();
            Sections();
            FrontSections();
            HeightLocation();
            Common();
            TrayLocation();
            Writedatabase();
            Hardwareselftest();
            AutoIndication();
            groupLifter();
        }
        private static void groupLifter()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @GroupLifter = server.AddGroup("GroupLifter", groupState);

            AddItemToGroup(@GroupLifter, "LFConvPositionLH");

            AddItemToGroup(@GroupLifter, "LFConvSpeedRH");
            AddItemToGroup(@GroupLifter, "Position");
            Task<OpcDaItemValue[]> task = GroupLifter.ReadAsync(GroupLifter.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });
        }
        //New Indication
        private static void AutoIndication()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupAutoIndication = server.AddGroup("groupAutoIndication", groupState);


            AddItemToGroup(@groupAutoIndication, "AutoLoadIndication");
            AddItemToGroup(@groupAutoIndication, "IO-46");
            AddItemToGroup(@groupAutoIndication, "IO-44");
            Task<OpcDaItemValue[]> task = groupAutoIndication.ReadAsync(groupAutoIndication.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });


        }


        private static void HeightLocation()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupHeightLocation = server.AddGroup("groupHeightLocation", groupState);


            AddItemToGroup(@groupHeightLocation, "Height_Location1");
            AddItemToGroup(@groupHeightLocation, "Height_Location2");
            AddItemToGroup(@groupHeightLocation, "Height_Location3");
            AddItemToGroup(@groupHeightLocation, "Height_Location4");
            AddItemToGroup(@groupHeightLocation, "Height_Location5");
            AddItemToGroup(@groupHeightLocation, "Height_Location6");
            AddItemToGroup(@groupHeightLocation, "Height_Location7");
            AddItemToGroup(@groupHeightLocation, "Height_Location8");
            AddItemToGroup(@groupHeightLocation, "Height_Location9");
            AddItemToGroup(@groupHeightLocation, "Height_Location10");
            AddItemToGroup(@groupHeightLocation, "Height_Location11");
            AddItemToGroup(@groupHeightLocation, "Height_Location12");
            AddItemToGroup(@groupHeightLocation, "Height_Location13");
            AddItemToGroup(@groupHeightLocation, "Height_Location14");
            AddItemToGroup(@groupHeightLocation, "Height_Location15");
            AddItemToGroup(@groupHeightLocation, "Height_Location16");
            AddItemToGroup(@groupHeightLocation, "Height_Location17");
            AddItemToGroup(@groupHeightLocation, "Height_Location18");
            AddItemToGroup(@groupHeightLocation, "Height_Location19");
            AddItemToGroup(@groupHeightLocation, "Height_Location20");
            AddItemToGroup(@groupHeightLocation, "Height_Location21");
            AddItemToGroup(@groupHeightLocation, "Height_Location22");
            AddItemToGroup(@groupHeightLocation, "Height_Location23");
            AddItemToGroup(@groupHeightLocation, "Height_Location24");
            AddItemToGroup(@groupHeightLocation, "Height_Location25");
            AddItemToGroup(@groupHeightLocation, "Height_Location26");
            AddItemToGroup(@groupHeightLocation, "Height_Location27");
            AddItemToGroup(@groupHeightLocation, "Height_Location28");
            AddItemToGroup(@groupHeightLocation, "Height_Location29");
            AddItemToGroup(@groupHeightLocation, "Height_Location30");
            AddItemToGroup(@groupHeightLocation, "Height_Location31");
            AddItemToGroup(@groupHeightLocation, "Height_Location32");
            AddItemToGroup(@groupHeightLocation, "Height_Location33");
            AddItemToGroup(@groupHeightLocation, "Height_Location34");
            AddItemToGroup(@groupHeightLocation, "Height_Location35");
            AddItemToGroup(@groupHeightLocation, "Height_Location36");
            AddItemToGroup(@groupHeightLocation, "Height_Location37");
            AddItemToGroup(@groupHeightLocation, "Height_Location38");
            AddItemToGroup(@groupHeightLocation, "Height_Location39");
            AddItemToGroup(@groupHeightLocation, "Height_Location40");
            AddItemToGroup(@groupHeightLocation, "Height_Location41");
            AddItemToGroup(@groupHeightLocation, "Height_Location42");
            AddItemToGroup(@groupHeightLocation, "Height_Location43");
            AddItemToGroup(@groupHeightLocation, "Height_Location44");
            AddItemToGroup(@groupHeightLocation, "Height_Location45");
            AddItemToGroup(@groupHeightLocation, "Height_Location46");
            AddItemToGroup(@groupHeightLocation, "Height_Location47");
            AddItemToGroup(@groupHeightLocation, "Height_Location48");
            AddItemToGroup(@groupHeightLocation, "Height_Location49");
            AddItemToGroup(@groupHeightLocation, "Height_Location50");
            AddItemToGroup(@groupHeightLocation, "Height_Location51");
            AddItemToGroup(@groupHeightLocation, "Height_Location52");
            AddItemToGroup(@groupHeightLocation, "Height_Location53");
            AddItemToGroup(@groupHeightLocation, "Height_Location54");
            AddItemToGroup(@groupHeightLocation, "Height_Location55");
            AddItemToGroup(@groupHeightLocation, "Height_Location56");
            AddItemToGroup(@groupHeightLocation, "Height_Location57");
            AddItemToGroup(@groupHeightLocation, "Height_Location58");
            AddItemToGroup(@groupHeightLocation, "Height_Location59");
            AddItemToGroup(@groupHeightLocation, "Height_Location60");
            AddItemToGroup(@groupHeightLocation, "Height_Location61");
            AddItemToGroup(@groupHeightLocation, "Height_Location62");
            AddItemToGroup(@groupHeightLocation, "Height_Location63");
            AddItemToGroup(@groupHeightLocation, "Height_Location64");
            AddItemToGroup(@groupHeightLocation, "Height_Location65");
            AddItemToGroup(@groupHeightLocation, "Height_Location66");
            AddItemToGroup(@groupHeightLocation, "Height_Location67");
            AddItemToGroup(@groupHeightLocation, "Height_Location68");
            AddItemToGroup(@groupHeightLocation, "Height_Location69");
            AddItemToGroup(@groupHeightLocation, "Height_Location70");
            AddItemToGroup(@groupHeightLocation, "Height_Location71");
            AddItemToGroup(@groupHeightLocation, "Height_Location72");
            AddItemToGroup(@groupHeightLocation, "Height_Location73");
            AddItemToGroup(@groupHeightLocation, "Height_Location74");
            AddItemToGroup(@groupHeightLocation, "Height_Location75");
            AddItemToGroup(@groupHeightLocation, "Height_Location76");
            AddItemToGroup(@groupHeightLocation, "Height_Location77");
            AddItemToGroup(@groupHeightLocation, "Height_Location78");
            AddItemToGroup(@groupHeightLocation, "Height_Location79");
            AddItemToGroup(@groupHeightLocation, "Height_Location80");
            AddItemToGroup(@groupHeightLocation, "Height_Location81");
            AddItemToGroup(@groupHeightLocation, "Height_Location82");
            AddItemToGroup(@groupHeightLocation, "Height_Location83");
            AddItemToGroup(@groupHeightLocation, "Height_Location84");
            AddItemToGroup(@groupHeightLocation, "Height_Location85");
            AddItemToGroup(@groupHeightLocation, "Height_Location86");
            AddItemToGroup(@groupHeightLocation, "Height_Location87");
            AddItemToGroup(@groupHeightLocation, "Height_Location88");
            AddItemToGroup(@groupHeightLocation, "Height_Location89");
            AddItemToGroup(@groupHeightLocation, "Height_Location90");
            AddItemToGroup(@groupHeightLocation, "Height_Location91");
            AddItemToGroup(@groupHeightLocation, "Height_Location92");
            AddItemToGroup(@groupHeightLocation, "Height_Location93");
            AddItemToGroup(@groupHeightLocation, "Height_Location94");
            AddItemToGroup(@groupHeightLocation, "Height_Location95");
            AddItemToGroup(@groupHeightLocation, "Height_Location96");
            AddItemToGroup(@groupHeightLocation, "Height_Location97");
            AddItemToGroup(@groupHeightLocation, "Height_Location98");
            AddItemToGroup(@groupHeightLocation, "Height_Location99");
            AddItemToGroup(@groupHeightLocation, "Height_Location100");
            AddItemToGroup(@groupHeightLocation, "Height_Location101");
            AddItemToGroup(@groupHeightLocation, "Height_Location102");
            AddItemToGroup(@groupHeightLocation, "Height_Location103");
            AddItemToGroup(@groupHeightLocation, "Height_Location104");
            AddItemToGroup(@groupHeightLocation, "Height_Location105");
            AddItemToGroup(@groupHeightLocation, "Height_Location106");
            AddItemToGroup(@groupHeightLocation, "Height_Location107");
            AddItemToGroup(@groupHeightLocation, "Height_Location108");
            AddItemToGroup(@groupHeightLocation, "Height_Location109");
            AddItemToGroup(@groupHeightLocation, "Height_Location110");
            AddItemToGroup(@groupHeightLocation, "Height_Location111");
            AddItemToGroup(@groupHeightLocation, "Height_Location112");
            AddItemToGroup(@groupHeightLocation, "Height_Location113");
            AddItemToGroup(@groupHeightLocation, "Height_Location114");
            AddItemToGroup(@groupHeightLocation, "Height_Location115");
            AddItemToGroup(@groupHeightLocation, "Height_Location116");
            AddItemToGroup(@groupHeightLocation, "Height_Location117");
            AddItemToGroup(@groupHeightLocation, "Height_Location118");
            AddItemToGroup(@groupHeightLocation, "Height_Location119");
            AddItemToGroup(@groupHeightLocation, "Height_Location120");
            AddItemToGroup(@groupHeightLocation, "Height_Location121");
            AddItemToGroup(@groupHeightLocation, "Height_Location122");
            AddItemToGroup(@groupHeightLocation, "Height_Location123");
            AddItemToGroup(@groupHeightLocation, "Height_Location124");
            AddItemToGroup(@groupHeightLocation, "Height_Location125");
            AddItemToGroup(@groupHeightLocation, "Height_Location126");
            AddItemToGroup(@groupHeightLocation, "Height_Location127");
            AddItemToGroup(@groupHeightLocation, "Height_Location128");
            AddItemToGroup(@groupHeightLocation, "Height_Location129");
            AddItemToGroup(@groupHeightLocation, "Height_Location130");
            AddItemToGroup(@groupHeightLocation, "Height_Location131");
            AddItemToGroup(@groupHeightLocation, "Height_Location132");
            AddItemToGroup(@groupHeightLocation, "Height_Location133");
            AddItemToGroup(@groupHeightLocation, "Height_Location134");
            AddItemToGroup(@groupHeightLocation, "Height_Location135");
            AddItemToGroup(@groupHeightLocation, "Height_Location136");
            AddItemToGroup(@groupHeightLocation, "Height_Location137");
            AddItemToGroup(@groupHeightLocation, "Height_Location138");
            AddItemToGroup(@groupHeightLocation, "Height_Location139");
            AddItemToGroup(@groupHeightLocation, "Height_Location140");
            AddItemToGroup(@groupHeightLocation, "Height_Location141");
            AddItemToGroup(@groupHeightLocation, "Height_Location142");
            AddItemToGroup(@groupHeightLocation, "Height_Location143");
            AddItemToGroup(@groupHeightLocation, "Height_Location144");
            AddItemToGroup(@groupHeightLocation, "Height_Location145");
            AddItemToGroup(@groupHeightLocation, "Height_Location146");
            AddItemToGroup(@groupHeightLocation, "Height_Location147");
            AddItemToGroup(@groupHeightLocation, "Height_Location148");
            AddItemToGroup(@groupHeightLocation, "Height_Location149");
            AddItemToGroup(@groupHeightLocation, "Height_Location150");
        }
        private static void TrayLocation()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupTrayLocation = server.AddGroup("groupTrayLocation", groupState);


            AddItemToGroup(@groupTrayLocation, "Tray_Location1");
            AddItemToGroup(@groupTrayLocation, "Tray_Location2");
            AddItemToGroup(@groupTrayLocation, "Tray_Location3");
            AddItemToGroup(@groupTrayLocation, "Tray_Location4");
            AddItemToGroup(@groupTrayLocation, "Tray_Location5");
            AddItemToGroup(@groupTrayLocation, "Tray_Location6");
            AddItemToGroup(@groupTrayLocation, "Tray_Location7");
            AddItemToGroup(@groupTrayLocation, "Tray_Location8");
            AddItemToGroup(@groupTrayLocation, "Tray_Location9");
            AddItemToGroup(@groupTrayLocation, "Tray_Location10");
            AddItemToGroup(@groupTrayLocation, "Tray_Location11");
            AddItemToGroup(@groupTrayLocation, "Tray_Location12");
            AddItemToGroup(@groupTrayLocation, "Tray_Location13");
            AddItemToGroup(@groupTrayLocation, "Tray_Location14");
            AddItemToGroup(@groupTrayLocation, "Tray_Location15");
            AddItemToGroup(@groupTrayLocation, "Tray_Location16");
            AddItemToGroup(@groupTrayLocation, "Tray_Location17");
            AddItemToGroup(@groupTrayLocation, "Tray_Location18");
            AddItemToGroup(@groupTrayLocation, "Tray_Location19");
            AddItemToGroup(@groupTrayLocation, "Tray_Location20");
            AddItemToGroup(@groupTrayLocation, "Tray_Location21");
            AddItemToGroup(@groupTrayLocation, "Tray_Location22");
            AddItemToGroup(@groupTrayLocation, "Tray_Location23");
            AddItemToGroup(@groupTrayLocation, "Tray_Location24");
            AddItemToGroup(@groupTrayLocation, "Tray_Location25");
            AddItemToGroup(@groupTrayLocation, "Tray_Location26");
            AddItemToGroup(@groupTrayLocation, "Tray_Location27");
            AddItemToGroup(@groupTrayLocation, "Tray_Location28");
            AddItemToGroup(@groupTrayLocation, "Tray_Location29");
            AddItemToGroup(@groupTrayLocation, "Tray_Location30");
            AddItemToGroup(@groupTrayLocation, "Tray_Location31");
            AddItemToGroup(@groupTrayLocation, "Tray_Location32");
            AddItemToGroup(@groupTrayLocation, "Tray_Location33");
            AddItemToGroup(@groupTrayLocation, "Tray_Location34");
            AddItemToGroup(@groupTrayLocation, "Tray_Location35");
            AddItemToGroup(@groupTrayLocation, "Tray_Location36");
            AddItemToGroup(@groupTrayLocation, "Tray_Location37");
            AddItemToGroup(@groupTrayLocation, "Tray_Location38");
            AddItemToGroup(@groupTrayLocation, "Tray_Location39");
            AddItemToGroup(@groupTrayLocation, "Tray_Location40");
            AddItemToGroup(@groupTrayLocation, "Tray_Location41");
            AddItemToGroup(@groupTrayLocation, "Tray_Location42");
            AddItemToGroup(@groupTrayLocation, "Tray_Location43");
            AddItemToGroup(@groupTrayLocation, "Tray_Location44");
            AddItemToGroup(@groupTrayLocation, "Tray_Location45");
            AddItemToGroup(@groupTrayLocation, "Tray_Location46");
            AddItemToGroup(@groupTrayLocation, "Tray_Location47");
            AddItemToGroup(@groupTrayLocation, "Tray_Location48");
            AddItemToGroup(@groupTrayLocation, "Tray_Location49");
            AddItemToGroup(@groupTrayLocation, "Tray_Location50");
            AddItemToGroup(@groupTrayLocation, "Tray_Location51");
            AddItemToGroup(@groupTrayLocation, "Tray_Location52");
            AddItemToGroup(@groupTrayLocation, "Tray_Location53");
            AddItemToGroup(@groupTrayLocation, "Tray_Location54");
            AddItemToGroup(@groupTrayLocation, "Tray_Location55");
            AddItemToGroup(@groupTrayLocation, "Tray_Location56");
            AddItemToGroup(@groupTrayLocation, "Tray_Location57");
            AddItemToGroup(@groupTrayLocation, "Tray_Location58");
            AddItemToGroup(@groupTrayLocation, "Tray_Location59");
            AddItemToGroup(@groupTrayLocation, "Tray_Location60");
            AddItemToGroup(@groupTrayLocation, "Tray_Location61");
            AddItemToGroup(@groupTrayLocation, "Tray_Location62");
            AddItemToGroup(@groupTrayLocation, "Tray_Location63");
            AddItemToGroup(@groupTrayLocation, "Tray_Location64");
            AddItemToGroup(@groupTrayLocation, "Tray_Location65");
            AddItemToGroup(@groupTrayLocation, "Tray_Location66");
            AddItemToGroup(@groupTrayLocation, "Tray_Location67");
            AddItemToGroup(@groupTrayLocation, "Tray_Location68");
            AddItemToGroup(@groupTrayLocation, "Tray_Location69");
            AddItemToGroup(@groupTrayLocation, "Tray_Location70");
            AddItemToGroup(@groupTrayLocation, "Tray_Location71");
            AddItemToGroup(@groupTrayLocation, "Tray_Location72");
            AddItemToGroup(@groupTrayLocation, "Tray_Location73");
            AddItemToGroup(@groupTrayLocation, "Tray_Location74");
            AddItemToGroup(@groupTrayLocation, "Tray_Location75");
            AddItemToGroup(@groupTrayLocation, "Tray_Location76");
            AddItemToGroup(@groupTrayLocation, "Tray_Location77");
            AddItemToGroup(@groupTrayLocation, "Tray_Location78");
            AddItemToGroup(@groupTrayLocation, "Tray_Location79");
            AddItemToGroup(@groupTrayLocation, "Tray_Location80");
            AddItemToGroup(@groupTrayLocation, "Tray_Location81");
            AddItemToGroup(@groupTrayLocation, "Tray_Location82");
            AddItemToGroup(@groupTrayLocation, "Tray_Location83");
            AddItemToGroup(@groupTrayLocation, "Tray_Location84");
            AddItemToGroup(@groupTrayLocation, "Tray_Location85");
            AddItemToGroup(@groupTrayLocation, "Tray_Location86");
            AddItemToGroup(@groupTrayLocation, "Tray_Location87");
            AddItemToGroup(@groupTrayLocation, "Tray_Location88");
            AddItemToGroup(@groupTrayLocation, "Tray_Location89");
            AddItemToGroup(@groupTrayLocation, "Tray_Location90");
            AddItemToGroup(@groupTrayLocation, "Tray_Location91");
            AddItemToGroup(@groupTrayLocation, "Tray_Location92");
            AddItemToGroup(@groupTrayLocation, "Tray_Location93");
            AddItemToGroup(@groupTrayLocation, "Tray_Location94");
            AddItemToGroup(@groupTrayLocation, "Tray_Location95");
            AddItemToGroup(@groupTrayLocation, "Tray_Location96");
            AddItemToGroup(@groupTrayLocation, "Tray_Location97");
            AddItemToGroup(@groupTrayLocation, "Tray_Location98");
            AddItemToGroup(@groupTrayLocation, "Tray_Location99");
            AddItemToGroup(@groupTrayLocation, "Tray_Location100");
            AddItemToGroup(@groupTrayLocation, "Tray_Location101");
            AddItemToGroup(@groupTrayLocation, "Tray_Location102");
            AddItemToGroup(@groupTrayLocation, "Tray_Location103");
            AddItemToGroup(@groupTrayLocation, "Tray_Location104");
            AddItemToGroup(@groupTrayLocation, "Tray_Location105");
            AddItemToGroup(@groupTrayLocation, "Tray_Location106");
            AddItemToGroup(@groupTrayLocation, "Tray_Location107");
            AddItemToGroup(@groupTrayLocation, "Tray_Location108");
            AddItemToGroup(@groupTrayLocation, "Tray_Location109");
            AddItemToGroup(@groupTrayLocation, "Tray_Location110");
            AddItemToGroup(@groupTrayLocation, "Tray_Location111");
            AddItemToGroup(@groupTrayLocation, "Tray_Location112");
            AddItemToGroup(@groupTrayLocation, "Tray_Location113");
            AddItemToGroup(@groupTrayLocation, "Tray_Location114");
            AddItemToGroup(@groupTrayLocation, "Tray_Location115");
            AddItemToGroup(@groupTrayLocation, "Tray_Location116");
            AddItemToGroup(@groupTrayLocation, "Tray_Location117");
            AddItemToGroup(@groupTrayLocation, "Tray_Location118");
            AddItemToGroup(@groupTrayLocation, "Tray_Location119");
            AddItemToGroup(@groupTrayLocation, "Tray_Location120");
            AddItemToGroup(@groupTrayLocation, "Tray_Location121");
            AddItemToGroup(@groupTrayLocation, "Tray_Location122");
            AddItemToGroup(@groupTrayLocation, "Tray_Location123");
            AddItemToGroup(@groupTrayLocation, "Tray_Location124");
            AddItemToGroup(@groupTrayLocation, "Tray_Location125");
            AddItemToGroup(@groupTrayLocation, "Tray_Location126");
            AddItemToGroup(@groupTrayLocation, "Tray_Location127");
            AddItemToGroup(@groupTrayLocation, "Tray_Location128");
            AddItemToGroup(@groupTrayLocation, "Tray_Location129");
            AddItemToGroup(@groupTrayLocation, "Tray_Location130");
            AddItemToGroup(@groupTrayLocation, "Tray_Location131");
            AddItemToGroup(@groupTrayLocation, "Tray_Location132");
            AddItemToGroup(@groupTrayLocation, "Tray_Location133");
            AddItemToGroup(@groupTrayLocation, "Tray_Location134");
            AddItemToGroup(@groupTrayLocation, "Tray_Location135");
            AddItemToGroup(@groupTrayLocation, "Tray_Location136");
            AddItemToGroup(@groupTrayLocation, "Tray_Location137");
            AddItemToGroup(@groupTrayLocation, "Tray_Location138");
            AddItemToGroup(@groupTrayLocation, "Tray_Location139");
            AddItemToGroup(@groupTrayLocation, "Tray_Location140");
            AddItemToGroup(@groupTrayLocation, "Tray_Location141");
            AddItemToGroup(@groupTrayLocation, "Tray_Location142");
            AddItemToGroup(@groupTrayLocation, "Tray_Location143");
            AddItemToGroup(@groupTrayLocation, "Tray_Location144");
            AddItemToGroup(@groupTrayLocation, "Tray_Location145");
            AddItemToGroup(@groupTrayLocation, "Tray_Location146");
            AddItemToGroup(@groupTrayLocation, "Tray_Location147");
            AddItemToGroup(@groupTrayLocation, "Tray_Location148");
            AddItemToGroup(@groupTrayLocation, "Tray_Location149");
            AddItemToGroup(@groupTrayLocation, "Tray_Location150");
        }

        private static void FrontSections()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupFrontSections = server.AddGroup("groupFrontSections", groupState);


            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_1");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_1");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_1");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_2");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_2");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_2");


            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_3");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_3");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_3");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_4");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_4");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_4");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_5");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_5");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_5");


            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_6");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_6");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_6");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_7");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_7");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_7");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_8");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_8");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_8");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_9");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_9");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_9");


            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_10");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_10");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_10");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_11");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_11");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_11");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_12");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_12");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_12");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_13");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_13");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_13");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_14");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_14");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_14");

            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_No_15");
            AddItemToGroup(@groupFrontSections, "Front_Rack_End_No_15");
            AddItemToGroup(@groupFrontSections, "Front_Rack_Start_Position_15");
        }

        private static void Sections()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupSections = server.AddGroup("groupSections", groupState);

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_1");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_1");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_1");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_2");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_2");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_2");


            AddItemToGroup(@groupSections, "Back_Rack_Start_No_3");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_3");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_3");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_4");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_4");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_4");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_5");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_5");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_5");


            AddItemToGroup(@groupSections, "Back_Rack_Start_No_6");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_6");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_6");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_7");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_7");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_7");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_8");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_8");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_8");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_9");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_9");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_9");


            AddItemToGroup(@groupSections, "Back_Rack_Start_No_10");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_10");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_10");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_11");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_11");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_11");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_12");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_12");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_12");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_13");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_13");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_13");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_14");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_14");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_14");

            AddItemToGroup(@groupSections, "Back_Rack_Start_No_15");
            AddItemToGroup(@groupSections, "Back_Rack_End_No_15");
            AddItemToGroup(@groupSections, "Back_Rack_Start_Position_15");
            //////




        }


        private static void AddItemToGroup(OpcDaGroup grpName, string ItemName)
        {
            var itemName = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1." + ItemName, //itemid for opc server item
            }

        };
            grpName.AddItems(itemName);
        }


        private static void TraySetting()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupTraySetting = server.AddGroup("groupTraySetting", groupState);

            AddItemToGroup(@groupTraySetting, "OffsetFrontFetch");

            AddItemToGroup(@groupTraySetting, "OffsetFrontReturn");
            AddItemToGroup(@groupTraySetting, "offsetRearFetch");

            AddItemToGroup(@groupTraySetting, "offsetRearFetch");

            AddItemToGroup(@groupTraySetting, "offsetRearReturn");

            AddItemToGroup(@groupTraySetting, "VerticalTraySpeedHigh");

            AddItemToGroup(@groupTraySetting, "VerticalTraySpeedSlow");

            AddItemToGroup(@groupTraySetting, "HorizontalTraySpeedHigh");

            AddItemToGroup(@groupTraySetting, "HorizontalTraySpeedSlow");
            AddItemToGroup(@groupTraySetting, "LiftDownLimit");
            AddItemToGroup(@groupTraySetting, "LiftUpLimt");

        }

        private static void LocationRead()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupIOLocation = server.AddGroup("groupIOLocation", groupState);

            AddItemToGroup(@groupIOLocation, "BackRackNoStart");

            AddItemToGroup(@groupIOLocation, "BackRackNoEnd");

            AddItemToGroup(@groupIOLocation, "FrontRackNostart");

            AddItemToGroup(@groupIOLocation, "FrontRackNoEnd");

            AddItemToGroup(@groupIOLocation, "Fitch");

            AddItemToGroup(@groupIOLocation, "TrayNoStart");

            AddItemToGroup(@groupIOLocation, "TrayNoEnd");

            AddItemToGroup(@groupIOLocation, "BackRackStartPosition");

            AddItemToGroup(@groupIOLocation, "FrontRackStartPosition");

            AddItemToGroup(@groupIOLocation, "LoadPosition");

            AddItemToGroup(@groupIOLocation, "TolaranceAtLevel");

            AddItemToGroup(@groupIOLocation, "LimitUp");

            AddItemToGroup(@groupIOLocation, "LimitDown");

            AddItemToGroup(@groupIOLocation, "HeightTolarance");

            AddItemToGroup(@groupIOLocation, "MaxHeight");

            AddItemToGroup(@groupIOLocation, "MaxWeight");

            AddItemToGroup(@groupIOLocation, "Conv_Length");

            AddItemToGroup(@groupIOLocation, "Home_Tolerance");
            AddItemToGroup(@groupIOLocation, "Locking_Pos");
            AddItemToGroup(@groupIOLocation, "Locking_Position");
            Task<OpcDaItemValue[]> task = groupIOLocation.ReadAsync(groupIOLocation.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });

        }

        private static void IORead()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            groupIORead = server.AddGroup("groupIORead", groupState);
            var itemIO44 = new[]
           {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-44", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO44);

            var itemIO46 = new[]
          {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-46", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO46);


            var itemIO47 = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-47", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO47);


            var itemIO50 = new[]
     {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-50", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO50);


            var itemIO60 = new[]
 {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-60", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO60);


            var itemIO61 = new[]{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.IO-61", //itemid for opc server item
            }
        };

            @groupIORead.AddItems(itemIO61);

            Task<OpcDaItemValue[]> task = groupIORead.ReadAsync(groupIORead.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });


        }

        public static void DisconnectOPC()
        {
            server.Disconnect();
        }
        public static bool GetCommunication(string GroupName, string SubscribeItemId)
        {
            OpcDaItemValue[] values1 = groupMaualRead.Read(groupMaualRead.Items, OpcDaDataSource.Device);
            OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);
            bool abca = (values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId).Quality);
            return abca;
        }
        public static int ReadRegister(string GroupName, string SubscribeItemId)
        {

            string abc = "0";
            if (GroupName == "groupMaualRead")
            {
                OpcDaItemValue[] values1 = groupMaualRead.Read(groupMaualRead.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupWriteDatabase")
            {
                OpcDaItemValue[] values1 = groupWriteDatabase.Read(groupWriteDatabase.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupHeightLocation")
            {
                OpcDaItemValue[] values1 = groupHeightLocation.Read(groupHeightLocation.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupTrayLocation")
            {
                OpcDaItemValue[] values1 = groupTrayLocation.Read(groupTrayLocation.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupManualWrite")
            {
                OpcDaItemValue[] values1 = groupManualWrite.Read(groupManualWrite.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupIORead")
            {
                OpcDaItemValue[] values1 = groupIORead.Read(groupIORead.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);
                ///bool abca= (values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId).Quality);
                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupRunTo")
            {
                OpcDaItemValue[] values1 = groupRunTo.Read(groupRunTo.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupRack")
            {
                OpcDaItemValue[] values1 = groupRack.Read(groupRack.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupInitialLoadRead")
            {
                OpcDaItemValue[] values1 = groupInitialLoadRead.Read(groupInitialLoadRead.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupAutoLoadRead")
            {
                OpcDaItemValue[] values1 = groupAutoLoadRead.Read(groupAutoLoadRead.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupLocation")
            {
                OpcDaItemValue[] values1 = groupIOLocation.Read(groupAutoLoadRead.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupTraySetting")
            {
                OpcDaItemValue[] values1 = groupTraySetting.Read(groupTraySetting.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupSensor")
            {
                OpcDaItemValue[] values1 = groupSensor.Read(groupSensor.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupFault")
            {
                OpcDaItemValue[] values1 = groupFault.Read(groupFault.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupBloackLocation")
            {
                OpcDaItemValue[] values1 = groupBloackLocation.Read(groupBloackLocation.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupCommon")
            {
                OpcDaItemValue[] values1 = groupCommon.Read(groupCommon.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "grp1")
            {
                OpcDaItemValue[] values1 = grp1.Read(grp1.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            else if (GroupName == "groupAutoIndication")
            {
                OpcDaItemValue[] values1 = groupAutoIndication.Read(groupAutoIndication.Items, OpcDaDataSource.Device);
                OpcDaItemValue val = values1.FirstOrDefault(i => i.Item.ItemId == SubscribeItemId);

                abc = Convert.ToString(val.Value);
            }
            if (abc == "")
                return 0;
            else
                return int.Parse(abc);
        }
        private static void GroupOnValuesChanged(object sender, OpcDaItemValuesChangedEventArgs args)
        {
            // Output values.
            foreach (OpcDaItemValue value in args.Values)
            {
                Console.WriteLine("[Subscribe] ItemId: {0}; Value: {1}; Quality: {2}; Timestamp: {3}", value.Item.ItemId,
                    value.Value, value.Quality, value.Timestamp);
            }
        }

        public static void WriteRegister(string GroupName, string SubscribeItemId, string valueRegi)
        {

            if (GroupName == "groupManualWrite")
            {
                OpcDaItem item = @groupManualWrite.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupManualWrite.Write(items, values);
            }

            else if (GroupName == "groupWriteDatabase")
            {
                OpcDaItem item = @groupWriteDatabase.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupWriteDatabase.Write(items, values);
            }
            else if (GroupName == "grp1")
            {
                OpcDaItem item = @grp1.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                grp1.Write(items, values);
            }
            else if (GroupName == "groupHeightLocation")
            {
                OpcDaItem item = @groupHeightLocation.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupHeightLocation.Write(items, values);
            }
            else if (GroupName == "groupTrayLocation")
            {
                OpcDaItem item = @groupTrayLocation.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupTrayLocation.Write(items, values);
            }
            else if (GroupName == "groupMaualRead")
            {
                OpcDaItem item = @groupManualWrite.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupManualWrite.Write(items, values);
            }
            else if (GroupName == "groupRunTo")
            {
                OpcDaItem item = @groupRunTo.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupRunTo.Write(items, values);
            }
            else if (GroupName == "groupRack")
            {
                OpcDaItem item = @groupRack.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupRack.Write(items, values);
            }
            else if (GroupName == "groupInitialLoadRead")
            {
                OpcDaItem item = @groupInitialLoadRead.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupInitialLoadRead.Write(items, values);
            }
            else if (GroupName == "groupAutoLoadRead")
            {
                OpcDaItem item = @groupAutoLoadRead.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupAutoLoadRead.Write(items, values);
            }
            else if (GroupName == "groupTraySetting")
            {
                OpcDaItem item = @groupTraySetting.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupTraySetting.Write(items, values);
            }
            else if (GroupName == "groupLocation")
            {
                OpcDaItem item = groupIOLocation.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupIOLocation.Write(items, values);
            }
            else if (GroupName == "groupSensor")
            {
                OpcDaItem item = groupSensor.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupSensor.Write(items, values);
            }
            else if (GroupName == "groupFault")
            {
                OpcDaItem item = groupFault.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupFault.Write(items, values);
            }
            else if (GroupName == "groupBloackLocation")
            {
                OpcDaItem item = groupBloackLocation.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupBloackLocation.Write(items, values);
            }
            else if (GroupName == "groupSection")
            {
                OpcDaItem item = groupSections.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupSections.Write(items, values);
            }
            else if (GroupName == "groupFrontSections")
            {
                OpcDaItem item = groupFrontSections.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupFrontSections.Write(items, values);
            }

            else if (GroupName == "groupCommon")
            {
                OpcDaItem item = groupCommon.Items.FirstOrDefault(i => i.ItemId == SubscribeItemId);
                //  group.Items.Contains()
                OpcDaItem[] items = { item };
                object[] values = { valueRegi };
                // await groupManualWrite.WriteAsync(items, values);
                groupCommon.Write(items, values);
            }

        }
        public static void WriteBitValueRegister(string GroupName, string SubscribeItemId, string valueRegi, int BitPosition)
        {
            // OpcDaItemValue[] values1 = group.Read(group.Items, OpcDaDataSource.Device);
            int abc = OpcCommunication.ReadRegister(GroupName, SubscribeItemId);

            byte[] HighBytes = BitConverter.GetBytes(abc);

            int Position = 0;
            if (BitPosition < 8)
                Position = 0;
            //else if (BitPosition >= 3 && BitPosition <= 7)
            //    Position = 1;
            //else if (BitPosition >= 7 && BitPosition <= 11)
            //    Position = 2;
            else
                Position = 1;

            byte b = HighBytes[Position];
            int BitinArraypos = 0;
            if (BitPosition == 0 || BitPosition == 8)
                BitinArraypos = 0;
            else if (BitPosition == 1 || BitPosition == 9)
                BitinArraypos = 1;
            else if (BitPosition == 2 || BitPosition == 10)
                BitinArraypos = 2;
            else if (BitPosition == 3 || BitPosition == 11)
                BitinArraypos = 3;
            else if (BitPosition == 4 || BitPosition == 12)
                BitinArraypos = 4;
            else if (BitPosition == 5 || BitPosition == 13)
                BitinArraypos = 5;
            else if (BitPosition == 6 || BitPosition == 14)
                BitinArraypos = 6;
            else if (BitPosition == 7 || BitPosition == 15)
                BitinArraypos = 7;

            else
                BitinArraypos = 3;

            var bit = (b & (1 << BitinArraypos)) != 0;
            if (valueRegi == "True")
            {
                b = (byte)(b | (1 << BitinArraypos));
                bit = (b & (1 << BitinArraypos)) != 0;
            }
            else
            {
                b = (byte)(b & ~(1 << BitinArraypos));
                bit = (b & (1 << BitinArraypos)) != 0;
            }
            HighBytes[Position] = b;
            Int32 x = BitConverter.ToInt32(HighBytes, 0);
            //    object[] values = { x };

            OpcCommunication.WriteRegister(GroupName, SubscribeItemId, x.ToString());

        }

        public static bool ReadBitRegister(string GroupName, string SubscribeItemId, int BitPosition)
        {

            int abc = ReadRegister(GroupName, SubscribeItemId);
            byte[] HighBytes = BitConverter.GetBytes(abc);
            int Position = 0;
            if (BitPosition < 8)
                Position = 0;
            //else if (BitPosition >= 3 && BitPosition <= 7)
            //    Position = 1;
            //else if (BitPosition >= 7 && BitPosition <= 11)
            //    Position = 2;
            else
                Position = 1;

            byte b = HighBytes[Position];
            int BitinArraypos = 0;
            if (BitPosition == 0 || BitPosition == 8)
                BitinArraypos = 0;
            else if (BitPosition == 1 || BitPosition == 9)
                BitinArraypos = 1;
            else if (BitPosition == 2 || BitPosition == 10)
                BitinArraypos = 2;
            else if (BitPosition == 3 || BitPosition == 11)
                BitinArraypos = 3;
            else if (BitPosition == 4 || BitPosition == 12)
                BitinArraypos = 4;
            else if (BitPosition == 5 || BitPosition == 13)
                BitinArraypos = 5;
            else if (BitPosition == 6 || BitPosition == 14)
                BitinArraypos = 6;
            else if (BitPosition == 7 || BitPosition == 15)
                BitinArraypos = 7;

            else
                BitinArraypos = 3;

            var bit = (b & (1 << BitinArraypos)) != 0;

            return (bool)bit;
        }
        public static void ManualRead()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupMaualRead = server.AddGroup("groupMaualRead", groupState);
            var itemLFConvPositionLH = new[]
           {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvPositionLH", //itemid for opc server item
            }
        };

            @groupMaualRead.AddItems(itemLFConvPositionLH);
            var itemLLFConvSpeedRH = new[]
          {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvSpeedRH", //itemid for opc server item
            }
        };
            @groupMaualRead.AddItems(itemLLFConvSpeedRH);
            var itemPosition = new[]
      {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Position", //itemid for opc server item
            }

        };
            @groupMaualRead.AddItems(itemPosition);
            Task<OpcDaItemValue[]> task = groupMaualRead.ReadAsync(groupMaualRead.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });
            //        var itemLifter = new[]
            //{
            //        new OpcDaItemDefinition
            //        {
            //            IsActive = true, //only active item can be subscribed
            //            ItemId = "NewDevice1.Lifter", //itemid for opc server item
            //        }

            //    };
            // @groupMaualRead.AddItems(itemLifter);
        }
        public static void ManualWrite()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupManualWrite = server.AddGroup("groupManualWrite", groupState);

            var itemwritePosition = new[]
      {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Position", //itemid for opc server item
            }

        };
            @groupManualWrite.AddItems(itemwritePosition);
            var itemwriteLifter = new[]
 {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Lifter", //itemid for opc server item
            }

        };
            @groupManualWrite.AddItems(itemwriteLifter);

            var itemwriteRunTo = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.RunTo", //itemid for opc server item
            }

        };
            @groupManualWrite.AddItems(itemwriteRunTo);
        }
        public static void RunTo()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupRunTo = server.AddGroup("groupRunTo", groupState);
            var itemwriteRunTo = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.RunTo", //itemid for opc server item
            }

        };
            @groupRunTo.AddItems(itemwriteRunTo);

            var itemClampNo = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.ClampNo", //itemid for opc server item
            }

        };
            @groupRunTo.AddItems(itemClampNo);
            var itemOpening = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Opening", //itemid for opc server item
            }

        };
            @groupRunTo.AddItems(itemOpening);
            @groupRunTo.AddItems(itemClampNo);
            var itemSetPosition = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.SetPosition", //itemid for opc server item
            }

        };
            @groupRunTo.AddItems(itemSetPosition);
        }
        public static void Rack()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupRack = server.AddGroup("groupRack", groupState);
            var itemRack = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Rack", //itemid for opc server item
            }

        };
            @groupRack.AddItems(itemRack);
        }
        private static void InitialLoadRead()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupInitialLoadRead = server.AddGroup("groupInitialLoadRead", groupState);
            var itemCall_Lift_For_Tray_Load = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Call_Lift_For_Tray_Load", //itemid for opc server item
            }

        };
            @groupInitialLoadRead.AddItems(itemCall_Lift_For_Tray_Load);

            var itemLocation = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Location", //itemid for opc server item
            }

        };
            @groupInitialLoadRead.AddItems(itemLocation);

            var itemTrayNo = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.TrayNo", //itemid for opc server item
            }

        };
            @groupInitialLoadRead.AddItems(itemTrayNo);

            var itemPosition = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Position", //itemid for opc server item
            }

        };
            @groupInitialLoadRead.AddItems(itemPosition);

            var itemHeight = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Height", //itemid for opc server item
            }

        };
            @groupInitialLoadRead.AddItems(itemHeight);
            var itemLFConvPositionLH = new[]
          {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvPositionLH", //itemid for opc server item
            }
        };

            @groupInitialLoadRead.AddItems(itemLFConvPositionLH);
            var itemLFConvSpeedRH = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvSpeedRH", //itemid for opc server item
            }
        };
            @groupInitialLoadRead.AddItems(itemLFConvSpeedRH);
            var itemWeight = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Weight", //itemid for opc server item
            }
        };
            @groupInitialLoadRead.AddItems(itemWeight);
            var itemHeightmm = new[]
        {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Heightmm", //itemid for opc server item
            }
        };
            AddItemToGroup(@groupInitialLoadRead, "AutoLoadIndication");

            Task<OpcDaItemValue[]> task = groupInitialLoadRead.ReadAsync(groupInitialLoadRead.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });
        }
        private static void AutoLoadRead()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupAutoLoadRead = server.AddGroup("groupAutoLoadRead", groupState);
            var itemCall_Lift_For_Tray_Load = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Call_Lift_For_Tray_Load", //itemid for opc server item
            }

        };
            @groupAutoLoadRead.AddItems(itemCall_Lift_For_Tray_Load);

            var itemLocation = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Location", //itemid for opc server item
            }

        };
            @groupAutoLoadRead.AddItems(itemLocation);

            var itemPosition = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Position", //itemid for opc server item
            }

        };
            @groupAutoLoadRead.AddItems(itemPosition);

            var itemTrayNo = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.TrayNo", //itemid for opc server item
            }

        };
            @groupAutoLoadRead.AddItems(itemTrayNo);

            var itemHeight = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Height", //itemid for opc server item
            }

        };
            @groupAutoLoadRead.AddItems(itemHeight);
            var itemLFConvPositionLH = new[]
          {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvPositionLH", //itemid for opc server item
            }
        };

            @groupAutoLoadRead.AddItems(itemLFConvPositionLH);
            var itemLFConvSpeedRH = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LFConvSpeedRH", //itemid for opc server item
            }
        };
            @groupAutoLoadRead.AddItems(itemLFConvSpeedRH);
            var itemWeight = new[]
         {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Weight", //itemid for opc server item
            }
        };
            @groupAutoLoadRead.AddItems(itemWeight);
            var itemHeightmm = new[]
        {
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Heightmm", //itemid for opc server item
            }
        };
            AddItemToGroup(@groupAutoLoadRead, "AutoLoadIndication");
            @groupAutoLoadRead.AddItems(itemHeightmm);

            Task<OpcDaItemValue[]> task = groupAutoLoadRead.ReadAsync(groupAutoLoadRead.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });
        }
        private static void ByPassSensor()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupSensor = server.AddGroup("groupSensor", groupState);
            var itemByPassSensor63 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.ByPassSensor", //itemid for opc server item
            }

        };
            @groupSensor.AddItems(itemByPassSensor63);
            var itemByPassSensor64 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Sensorflg", //itemid for opc server item
            }

        };
            @groupSensor.AddItems(itemByPassSensor64);
        }
        private static void Fault()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupFault = server.AddGroup("groupFault", groupState);
            var itemFault53 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Fault53", //itemid for opc server item
            }

        };
            @groupFault.AddItems(itemFault53);

            var itemFault54 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Fault54", //itemid for opc server item
            }

        };
            @groupFault.AddItems(itemFault54);
            var itemFault55 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Fault55", //itemid for opc server item
            }

        };
            @groupFault.AddItems(itemFault55);
            Task<OpcDaItemValue[]> task = groupFault.ReadAsync(groupFault.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });
        }
        private static void BlockLocation()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupBloackLocation = server.AddGroup("groupBloackLocation", groupState);
            var itemBLocation113To128 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation113To128", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation113To128);
            var itemBLocation129To144 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation129To144", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation129To144);
            var itemBLocation145To160 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation145To160", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation145To160);
            var itemBLocation17To32 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation17To32", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation17To32);
            var itemBLocation1To16 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation1To16", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation1To16);
            var itemBLocation33To48 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation33To48", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation33To48);
            var itemBLocation49To64 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation49To64", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation49To64);
            var itemBLocation65To80 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation65To80", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation65To80);
            var itemBLocation81To96 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation81To96", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation81To96);
            var itemBLocation97To112 = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.BLocation97To112", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBLocation97To112);
            @groupBloackLocation.AddItems(itemBLocation81To96);
            var itemBlock_Location_Number = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.Block_Location_Number", //itemid for opc server item
            }

        };
            @groupBloackLocation.AddItems(itemBlock_Location_Number);
        }
        private static void Common()
        {
            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupCommon = server.AddGroup("groupCommon", groupState);


            AddItemToGroup(@groupCommon, "ActiveStatus");


        }
        private static void Writedatabase()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @groupWriteDatabase = server.AddGroup("groupWriteDatabase", groupState);
            var itemLocationNumberPCToSEW = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.LocationNumberPCToSEW", //itemid for opc server item
            }

        };
            @groupWriteDatabase.AddItems(itemLocationNumberPCToSEW);
            var itemTrayNumberPCToSEW = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.TrayNumberPCToSEW", //itemid for opc server item
            }

        };
            @groupWriteDatabase.AddItems(itemTrayNumberPCToSEW);
            var itemHeightatLocationPCToSEW = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.HeightatLocationPCToSEW", //itemid for opc server item
            }

        };
            @groupWriteDatabase.AddItems(itemHeightatLocationPCToSEW);

        }
        private static void Hardwareselftest()
        {

            var groupState = new OpcDaGroupState
            {
                Culture = CultureInfo.CurrentCulture, //set LCID for group - some OPC servers may be sensitive for this
                IsActive = true, //only active group can be subscribed
                PercentDeadband = 0.0f, //percent deadband
                TimeBias = TimeSpan.Zero,
                UpdateRate = TimeSpan.FromMilliseconds(UpdateRateInMilliseconds),
                UserData = "some userdata" //user data
            };
            @grp1 = server.AddGroup("grp1", groupState);
            var itemHardwareSelfTest = new[]
{
            new OpcDaItemDefinition
            {
                IsActive = true, //only active item can be subscribed
                ItemId = "NewDevice1.HardwareSelfTest", //itemid for opc server item
            }

        };
            @grp1.AddItems(itemHardwareSelfTest);

            Task<OpcDaItemValue[]> task = grp1.ReadAsync(grp1.Items);
            task.ContinueWith(result =>
            {
                OpcDaItemValue[] itemValues = result.Result;
            });

        }
    }
}