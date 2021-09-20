using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class CarViewModel : EntityGenericViewModel
    {
        [JsonProperty("Placa do Carro")]
        public string License { get; set; }
        
        [JsonProperty("Cor do Carro")]
        public string Color { get; set; }

        [JsonProperty("Marca do Carro")]
        public string Brand { get; set; }
    }
}
