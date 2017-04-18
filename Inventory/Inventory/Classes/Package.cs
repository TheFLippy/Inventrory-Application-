namespace Inventory
{
    class Package
    {
        public Package(float deliveryNumber, float height, float length, float weight, float width, float returnNumber, string deliveryAddress1, string deliveryAddress2, string deliveryCity, string deliveryCountry, string deliveryName, string deliveryPostcode, string deliverySurname, string returnAddress1, string returnAddress2, string returnCity, string returnCountry, string returnName, string returnPostcode, string returnSurname, float packageNumber)
        {
            this.deliverynumber = deliveryNumber;
            this.height = height;
            this.length = length;
            this.weight = weight;
            this.width = width;
            this.returnnumber = returnNumber;
            this.deliveryaddress1 = deliveryAddress1;
            this.deliveryaddress2 = deliveryAddress2;
            this.deliverycity = deliveryCity;
            this.deliverycountry = deliveryCountry;
            this.deliveryname = deliveryName;
            this.deliverypostcode = deliveryPostcode;
            this.deliverysurname = deliverySurname;
            this.returnaddress1 = returnAddress1;
            this.returnaddress2 = returnAddress2;
            this.returncity = returnCity;
            this.returncountry = returnCountry;
            this.returnname = returnName;
            this.returnpostcode = returnPostcode;
            this.returnsurname = returnSurname;
            this.packagenumber = packageNumber;
        }



        public float deliverynumber { get; set; }
        public float height { get; set; }
        public float length { get; set; }
        public float weight { get; set; }
        public float width { get; set; }
        public float returnnumber { get; set; }
        public string deliveryaddress1 { get; set; }
        public string deliveryaddress2 { get; set; }
        public string deliverycity { get; set; }
        public string deliverycountry { get; set; }
        public string deliveryname { get; set; }
        public string deliverypostcode{ get; set; }
        public string deliverysurname { get; set; }
        public string returnaddress1 { get; set; }
        public string returnaddress2 { get; set; }
        public string returncity { get; set; }
        public string returncountry { get; set; }
        public string returnname { get; set; }
        public string returnpostcode { get; set; }
        public string returnsurname { get; set; }
        public float packagenumber{ get; set; }
    }
}
