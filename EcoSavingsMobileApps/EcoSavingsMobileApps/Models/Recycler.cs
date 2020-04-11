namespace EcoSavingsMobileApps.Models
{
    class Recycler 
    {
        public string RecyclerUsername { get; set; }
        public string RecyclerPassword { get; set; }
        public string RecyclerFullName { get; set; }
        public int RecyclerTotalPoints { get; set; }
        public string RecyclerEcoLevel { get; set; }

        public const string EcoLevelOne = "NewBie";
        public const string EcoLevelTwo = "Eco-Saver";
        public const string EcoLevelThree = "Eco-Hero";
        public const string EcoLevelFour = "Eco-Warrior";

    }
}
