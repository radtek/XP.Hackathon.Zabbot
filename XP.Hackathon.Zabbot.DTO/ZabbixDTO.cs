using System;
using System.Collections.Generic;
using System.Linq;
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

        public Escalation ToModel(EscalationMessage input)
        {
            if (input == null)
                return null;

            var output = new Escalation();

            output.Id = input.Id;
            output.GroupId = Convert.ToInt64(input.GroupId);
            output.Sequence = Convert.ToInt32(input.Sequence);
            //output.HourStart = TimeSpan.Parse(input.HourStart);
            //output.HourEnd = TimeSpan.Parse(input.HourEnd);
            output.Role = input.Role;
            output.Name = input.Name;
            output.Contact = input.Contact;
            output.Email = input.Email;
            output.Note = input.Note;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public EscalationMessage ToMessage(Escalation input)
        {
            if (input == null)
                return null;

            var output = new EscalationMessage();

            output.Id = input.Id;
            output.GroupId = input.GroupId.ToString();
            output.Sequence = input.Sequence.ToString();
            //output.HourStart = input.HourStart.ToString();
            //output.HourEnd = input.HourEnd.ToString();
            output.Role = input.Role;
            output.Name = input.Name;
            output.Contact = input.Contact;
            output.Email = input.Email;
            output.Note = input.Note;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public IEnumerable<Escalation> ToModel(IEnumerable<EscalationMessage> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<Escalation>();  

            foreach (var input in inputs)
            {
                var output = new Escalation();  

                output.Id = input.Id;
                output.GroupId = Convert.ToInt64(input.GroupId);
                output.Sequence = Convert.ToInt32(input.Sequence);
                //output.HourStart = TimeSpan.Parse(input.HourStart);
                //output.HourEnd = TimeSpan.Parse(input.HourEnd);
                output.Role = input.Role;
                output.Name = input.Name;
                output.Contact = input.Contact;
                output.Email = input.Email;
                output.Note = input.Note;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

        public IEnumerable<EscalationMessage> ToMessage(IEnumerable<Escalation> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<EscalationMessage>();  

            foreach (var input in inputs)
            {
                var output = new EscalationMessage();  

                output.Id = input.Id;
                output.GroupId = input.GroupId.ToString();
                output.Sequence = input.Sequence.ToString();
               //output.HourStart = input.HourStart.ToString();
                //output.HourEnd = input.HourEnd.ToString();
                output.Role = input.Role;
                output.Name = input.Name;
                output.Contact = input.Contact;
                output.Email = input.Email;
                output.Note = input.Note;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

    }
}