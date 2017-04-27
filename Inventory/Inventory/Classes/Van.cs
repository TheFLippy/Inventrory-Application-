namespace Inventory
{
    class Van
    {
        public Van(string noPlate, float volume, float weight, string location, int inUse, string state, string make, string model, string engSize, int YoM)
        {
            this.NoPlate = noPlate;
            this.Volume = volume;
            this.Weight = weight;
            this.Location = location;
            this.InUse = inUse;
            this.State = state;
            this.Make = make;
            this.Model = model;
            this.EngSize = engSize;
            this.YOM = YoM;
        }

        public string EngSize { get;  set; }
        public int InUse { get;  set; }
        public string Location { get;  set; }
        public string Make { get;  set; }
        public string Model { get;  set; }
        public string NoPlate { get; set; }
        public string State { get;  set; }
        public float Volume { get;  set; }
        public float Weight { get;  set; }
        public int YOM { get;  set; }
    }
}
