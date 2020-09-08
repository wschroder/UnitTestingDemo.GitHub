namespace ZooManager.ValueObjects
{
    public class Taxonomy
    {
        public string PhylumName { get; }
        public string ClassName { get; }
        public string OrderName { get; }
        public string FamilyName { get; }
        public string GenusName { get; }
        public string SpeciesName { get; }

        public Taxonomy(string phylumName, string className, string orderName, string familyName, string genusName, string speciesName)
        {
            PhylumName = phylumName;
            ClassName = className;
            OrderName = orderName;
            FamilyName = familyName;
            GenusName = genusName;
            SpeciesName = speciesName;
        }
    }
}
