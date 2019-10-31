using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType TypeOfPlane { get; set; }

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
                      : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            TypeOfPlane = type;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   TypeOfPlane == plane.TypeOfPlane;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            return (hashCode * -1521134295 + base.GetHashCode()) * -1521134295 + TypeOfPlane.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + TypeOfPlane +
                    '}');
        }
    }
}
