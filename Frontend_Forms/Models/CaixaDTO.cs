using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialSkin.Controls.MaterialSlider;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Komercio.Models
{
    public class CaixaDTO
    {
        [JsonProperty("id_transiction")]
        public int IDTransiction { get; set; }
        [JsonProperty("value_changed")]
        public float ValueChanged { get; set; }
        [JsonProperty("change_type")]
        public string ChangeType { get; set; }
        [JsonProperty("change_origin")]
        public string ChangeOrigin { get; set; }
        [JsonProperty("change_date")]
        public DateTime ChangeDate { get; set; }
        [JsonProperty("vendedor_id")]
        public int VendedorID { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("observations")]
        public string Observations { get; set; }
    }
}


