using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Entities
{

    public class Meal : BaseEntity
    {
        protected Meal()
        {

        }
        public Meal(string description, int calorias, DateTime date, int userID) : base()
        {
            Description = description;
            Calorias = calorias;
            Date = date;
            UserID = userID;
        }

        public string Description { get; private set; }
        public int Calorias { get; private set; }
        public DateTime Date { get; private set; }
        public int UserID { get; private set; }

        public void Update(string description, int calories, DateTime date)
        {
            Description = description;
            Calorias = calories;
            Date = date;
        }
    }
}
