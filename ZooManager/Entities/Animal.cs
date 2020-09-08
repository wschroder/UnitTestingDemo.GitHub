using System;
using ZooManager.Providers;
using ZooManager.ValueObjects;

namespace ZooManager.Entities
{
    public class Animal : BaseEntity
    {
        public DateTime? BirthDate { get; }

        public Taxonomy Taxonomy { get; }

        public Animal(string name, DateTime? birthDate, Taxonomy taxonomy): base(name)
        {
            BirthDate = birthDate;
            Taxonomy = taxonomy;
        }
    }
}
