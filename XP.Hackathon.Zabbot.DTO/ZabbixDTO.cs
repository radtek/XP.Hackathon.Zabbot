using System;
using System.Collections.Generic;
using XP.Hackathon.Zabbot.Interface.DTO;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;

namespace XP.Hackathon.Zabbot.DTO
{
    public class ZabbixDTO : IZabbixDTO
    {

        public ZabbixDTO
        (
	  	    IEscalationService IescalationService
	    )
	    {
	    }

        public TeamsEvent GetTeamsMessage(ZabbixEvent input)
        {
            if (input == null)
                return null;

            var output = new TeamsEvent();

            output.type = "MessageCard";
            output.context = "http://schema.org/extensions";
            output.themeColor = "0076D7";
            output.summary = input.Subject;
            output.sections = new List<Section>();
            var section = new Section();
            section.activityTitle = "![TestImage](https://assets.zabbix.com/img/newsletter/2016/icons/share-logo-z.png)Zabbot";
            section.activityImage = "https://assets.zabbix.com/img/newsletter/2016/icons/share-logo-z.png";
            section.activitySubtitle = input.Subject;
            section.markdown = true;

            var fact1 = new Fact();
            fact1.name = "Data";
            fact1.value = DateTime.Now.ToString("dd/MM/yyyy").ToString();

            var fact2 = new Fact();
            fact2.name = "Status";
            fact2.value = "Alarme";

            section.facts = new List<Fact>();
            section.facts.Add(fact1);
            section.facts.Add(fact2);

            output.sections.Add(section);

            output.potentialAction = new List<Potentialaction>();

            var potAct1 = new Potentialaction();
            potAct1.type = "ActionCard";
            potAct1.name = "Já estou analisando";
            potAct1.inputs = new List<Input>();
            var inp = new Input();
            inp.type = "TextInput";
            inp.id = "comment";
            inp.isMultiline = false;
            inp.title = "Informe seu usuario U. ex:'U000000'";
            potAct1.inputs.Add(inp);
            potAct1.actions = new List<Model.Action>();
            var act = new Model.Action();
            act.type = "HttpPOST";
            act.name = "Save";
            act.target = "http://...";
            potAct1.actions.Add(act);
            output.potentialAction.Add(potAct1);

            var potAct2 = new Potentialaction();
            potAct2.type = "ActionCard";
            potAct2.name = "Não é da minha equipe";
            potAct2.actions = new List<Model.Action>();
            var act2 = new Model.Action();
            act2.type = "HttpPOST";
            act2.name = "Save";
            act2.target = "http://...";
            potAct2.actions.Add(act2);
            output.potentialAction.Add(potAct2);

            var potAct3 = new Potentialaction();
            potAct3.type = "ActionCard";
            potAct3.name = "Não é da minha equipe";
            potAct3.actions = new List<Model.Action>();
            var act3 = new Model.Action();
            act3.type = "HttpPOST";
            act3.name = "Save";
            act3.target = "http://...";
            potAct3.actions.Add(act3);
            output.potentialAction.Add(potAct3);

            return output;
        }

        public void GetZabbotAckEvent(AckEvent input, ZabbotEvent output)
        {
            if (input == null)
                return;

            output.jsonrpc = "2.0";
            output.method = "event.acknowledge";
            output.id = 1;
            output._params = new AckParams()
            {
                eventids = input.EventId,
                message = $"{input.OperatingUser}{input.Message}",
                action = (int)input.Action
            };
            output.auth = output.result;
        }

    }
}