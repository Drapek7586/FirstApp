using static RealTimeAPIReader.Models.ApiModel;

namespace RealTimeAPIReader.Models
{
    public class ApiModel : IEquatable<ApiModel>
    {
        public List<double> ApiData { get; set; }
        public string? Label { get; set; }
        public string? DateAPI { get; set; }


        public override string ToString()
        {
            return "Label " + Label;
        }
        

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ApiModel objAsPart = obj as ApiModel;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ApiModel other)
        {
            if (other == null) return false;
            return (this.DateAPI.Equals(other.DateAPI));
        }



        public ApiModel()
        {
            ApiData = new List<double>();
        }

    }

    public class Rate : IEquatable<Rate>
    {
        public string currency { get; set; }
        public string code { get; set; }
        public double mid { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Rate objAsPart = obj as Rate;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return (int)mid;
        }

        public bool Equals(Rate other)
        {
            if (other == null) return false;
            return (this.currency.Equals(other.currency));
        }
    }
    public class Root
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Rate> rates { get; set; }
    }
}

