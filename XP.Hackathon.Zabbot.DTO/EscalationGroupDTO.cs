using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using XP.Hackathon.Zabbot.Interface.DTO;

namespace XP.Hackathon.Zabbot.DTO
{
    public class EscalationGroupDTO : IEscalationGroupDTO
    {

        public EscalationGroupDTO
	    (
	  	    IEscalationGroupService IescalationGroupService
	    )
	    {
	    }

        public EscalationGroup ToModel(EscalationGroupMessage input)
        {
            if (input == null)
                return null;

            var output = new EscalationGroup();

            output.Id = input.Id;
            output.Name = input.Name;
            output.Email = input.Email;
            output.TagName = input.TagName;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public EscalationGroupMessage ToMessage(EscalationGroup input)
        {
            if (input == null)
                return null;

            var output = new EscalationGroupMessage();

            output.Id = input.Id;
            output.Name = input.Name;
            output.Email = input.Email;
            output.TagName = input.TagName;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public IEnumerable<EscalationGroup> ToModel(IEnumerable<EscalationGroupMessage> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<EscalationGroup>();  

            foreach (var input in inputs)
            {
                var output = new EscalationGroup();  

                output.Id = input.Id;
                output.Name = input.Name;
                output.Email = input.Email;
                output.TagName = input.TagName;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

        public IEnumerable<EscalationGroupMessage> ToMessage(IEnumerable<EscalationGroup> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<EscalationGroupMessage>();  

            foreach (var input in inputs)
            {
                var output = new EscalationGroupMessage();  

                output.Id = input.Id;
                output.Name = input.Name;
                output.Email = input.Email;
                output.TagName = input.TagName;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

    }
}