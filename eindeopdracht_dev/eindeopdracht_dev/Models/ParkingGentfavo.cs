using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace eindopdracht.Models
{
    public class ParkingGentFavo
    {
        public class Rootobject
        {
            [JsonProperty("records")]
            public Record[] Records { get; set; }
        }

        public class Record
        {
            [JsonProperty("datasetid")]
            public string Datasetid { get; set; }
            [JsonProperty("recordid")]
            public string Recordid { get; set; }
            [JsonProperty("fields")]
            public Fields Fields { get; set; }
            [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }
            [JsonProperty("record_timestamp")]
            public DateTime Record_timestamp { get; set; }
        }

        public class Fields
        {
            [JsonProperty("lastupdate")]
            public DateTime Lastupdate { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("occupation")]
            public int Occupation { get; set; }

            [JsonProperty("operatorinformation")]
            public string Operatorinformation { get; set; }

            [JsonProperty("location")]
            public float[] Location { get; set; }

            [JsonProperty("occupancytrend")]
            public string Occupancytrend { get; set; }

            [JsonProperty("urllinkaddress")]
            public string Urllinkaddress { get; set; }

            [JsonProperty("isopennow")]
            public int Isopennow { get; set; }

            [JsonProperty("availablecapacity")]
            public double Availablecapacity { get; set; }

            [JsonProperty("freeparking")]
            public int Freeparking { get; set; }

            [JsonProperty("temporaryclosed")]
            public int Temporaryclosed { get; set; }

            [JsonProperty("openingtimesdescription")]
            public string Openingtimesdescription { get; set; }

            [JsonProperty("totalcapacity")]
            public double Totalcapacity { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("kleur")]
            public string Kleur
            {
                get
                {

                    double procent;
                    procent = Availablecapacity / Totalcapacity * 100;
                    if (procent > 60)
                    {
                        return "green";
                    }
                    else if (procent > 10)
                    {
                        return "orange";
                    }
                    else if (procent <= 10)
                    {
                        return "red";
                    }
                    return "blue";
                }
            }

            public string Foto
            {
                get
                {
                    return $"eindopdracht_dev/Assets/{Name}.jpg";
                }
            }
            public ImageSource ImageSource
            {
                get
                {


                    return ImageSource.FromResource($"eindeopdracht_dev.Assets.{this.Name.ToLower()}.png");



                }
            }

            public string open
            {
                get
                {
                    if (Isopennow == 1)
                    {
                        return "De parking is geopend";
                    }
                    return "De garage is gesloten";
                }
            }
        }

        public class Geometry
        {
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("coordinates")]
            public float[] Coordinates { get; set; }
        }


    }
}

