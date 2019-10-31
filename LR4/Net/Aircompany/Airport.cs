using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return Runner.planes.Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return Runner.militaryPlanes.Where(militaryPlane => 
                                               militaryPlane.TypeOfPlane == MilitaryType.TRANSPORT).
                                               ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MaxLoadCapacity));
        }

        public override string ToString()
        {
            return "Airport {" +
                    "planes = " + string.Join(", ", Planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
