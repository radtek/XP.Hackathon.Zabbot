using XP.Hackathon.Zabbot.Model;
using XP.Hackathon.Zabbot.Interface.Service;
using System.Collections.Generic;
using System.Linq;
using XP.Hackathon.Zabbot.Interface.DTO;

namespace XP.Hackathon.Zabbot.DTO
{
    public class ProductDTO : IProductDTO
    {

        public ProductDTO
	    (
	  	    IProductService IproductService
	    )
	    {
	    }

        public Product ToModel(ProductMessage input)
        {
            if (input == null)
                return null;

            var output = new Product();

            output.Id = input.Id;
            output.SinapiId = input.SinapiId;
            output.Name = input.Name;
            output.Unity = input.Unity;
            output.AveragePrice = input.AveragePrice;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public ProductMessage ToMessage(Product input)
        {
            if (input == null)
                return null;

            var output = new ProductMessage();

            output.Id = input.Id;
            output.SinapiId = input.SinapiId;
            output.Name = input.Name;
            output.Unity = input.Unity;
            output.AveragePrice = input.AveragePrice;
            output.Created = input.Created;
            output.Updated = input.Updated;
            output.Active = input.Active;

            return output;
        }

        public IEnumerable<Product> ToModel(IEnumerable<ProductMessage> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<Product>();  

            foreach (var input in inputs)
            {
                var output = new Product();  

                output.Id = input.Id;
                output.SinapiId = input.SinapiId;
                output.Name = input.Name;
                output.Unity = input.Unity;
                output.AveragePrice = input.AveragePrice;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

        public IEnumerable<ProductMessage> ToMessage(IEnumerable<Product> inputs)
        {
            if (inputs == null || !inputs.Any())
                return null;

            var outputs = new List<ProductMessage>();  

            foreach (var input in inputs)
            {
                var output = new ProductMessage();  

                output.Id = input.Id;
                output.SinapiId = input.SinapiId;
                output.Name = input.Name;
                output.Unity = input.Unity;
                output.AveragePrice = input.AveragePrice;
                output.Created = input.Created;
                output.Updated = input.Updated;
                output.Active = input.Active;

                outputs.Add(output);
            }

            return outputs;
        }

    }
}
