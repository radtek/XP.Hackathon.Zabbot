using System;

namespace XP.Hackathon.Zabbot.Model
{
    public class ZabbixEvent
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string NSeverity { get; set; }
        public string OpData { get; set; }
        public string RecoveryDate { get; set; }
        public string RecoveryTime { get; set; }
        public string Severity { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string Tags { get; set; }
        public string Time { get; set; }
        public string UpdateAction { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateMessage { get; set; }
        public string UpdateStatus { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string Value { get; set; }
        public string HostIp { get; set; }
        public string HostName { get; set; }
        public string ChannelEndpont { get; set; }
        public string TriggerDescription { get; set; }
        public string TriggerId { get; set; }
        public string ZabbixUrl { get; set; }

    }



    public class TeamsEvent
    {
        public string type { get; set; }
        public string context { get; set; }
        public string themeColor { get; set; }
        public string summary { get; set; }
        public Section[] sections { get; set; }
        public Potentialaction[] potentialAction { get; set; }
    }

    public class Section
    {
        public string activityTitle { get; set; }
        public string activitySubtitle { get; set; }
        public string activityImage { get; set; }
        public Fact[] facts { get; set; }
        public bool markdown { get; set; }
    }

    public class Fact
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Potentialaction
    {
        public string type { get; set; }
        public string name { get; set; }
        public Input[] inputs { get; set; }
        public Action[] actions { get; set; }
        public Target[] targets { get; set; }
    }

    public class Input
    {
        public string type { get; set; }
        public string id { get; set; }
        public bool isMultiline { get; set; }
        public string title { get; set; }
    }

    public class Action
    {
        public string type { get; set; }
        public string name { get; set; }
        public string target { get; set; }
    }

    public class Target
    {
        public string os { get; set; }
        public string uri { get; set; }
    }

}
