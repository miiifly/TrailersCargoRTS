using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle
{
    public interface IVehicleMovement
    {
        void UpdateRotation(int steerSide);
        void UpdateMovement(int moveSide, float maxSpeed);
        void UdpateSuspension();
    }
}
