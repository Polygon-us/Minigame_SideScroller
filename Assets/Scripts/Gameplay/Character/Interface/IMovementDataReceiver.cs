namespace Gameplay.Character
{
    public interface IMovementDataReceiver
    {
        public float maxAcceleration { get; set; }
        public float maxSpeed { get; set; }
        public float maxDecceleration { get; set; }
        public float maxTurnSpeed { get; set; }
        public float maxAirDeceleration { get; set; }
        public float maxAirAcceleration { get; set; }
        public float maxAirTurnSpeed { get; set; }
    }
}