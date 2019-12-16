using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
		private MilitaryType _typeOfPlane;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
							: base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _typeOfPlane = type;
        }

		public MilitaryType GetMilitaryType()
		{
			return _typeOfPlane;
		}

        public override bool Equals(object obj)
        {
			return obj is MilitaryPlane plane &&
				   base.Equals(obj) &&
				   _typeOfPlane == plane._typeOfPlane;
		}

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            return (hashCode * -1521134295 + base.GetHashCode()) * -1521134295 + _typeOfPlane.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + _typeOfPlane +
                    '}');
        }
    }
}
