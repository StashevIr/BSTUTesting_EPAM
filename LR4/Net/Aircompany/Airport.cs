using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
		private readonly List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

		public IEnumerable<Plane> GetPlanes()
		{
			return _planes;
		}

		public IEnumerable<PassengerPlane> GetPassengerPlanes()
		{
			return _planes.Where(plane => plane.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>();
		}

		public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
		{
			return _planes.Where(plane => plane.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>();
		}

		public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengerPlanes().Aggregate((w, x) 
						=> w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(militaryPlane => militaryPlane.GetMilitaryType() == MilitaryType.TRANSPORT);
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }

        public override string ToString()
        {
            return "Airport {" +
                    "planes = " + string.Join(", ", _planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
