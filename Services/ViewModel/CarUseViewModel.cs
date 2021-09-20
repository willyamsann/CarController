using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class CarUseViewModel : EntityGenericViewModel
    {

        [JsonProperty("Data de início da utilização")]
        public DateTime DateStart { get; set; }

        [JsonProperty("Data de fim da utilização")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("Id Motorista")]
        public int DriverId { get; set; }

        [JsonProperty("Motorista")]
        public DriverViewModel Driver { get; set; }

        [JsonProperty("Id do Carro")]
        public int CarId { get; set; }

        [JsonProperty("Carro")]
        public CarViewModel Car { get; set; }

        [JsonProperty("Motivo da utilização")]
        public string ReasonForUse { get; set; }

        [JsonProperty("Finalizado?")]
        public bool Finished { get; set; }
    }
}
