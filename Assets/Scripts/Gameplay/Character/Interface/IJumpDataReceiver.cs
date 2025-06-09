namespace Gameplay.Character
{
    public interface IJumpDataReceiver
    {
        public float jumpHeight { get; set; }
        public float timeToJumpApex { get; set; }
        public float downwardMovementMultiplier { get; set; }
        public float jumpCutOff { get; set; }
        public int maxAirJumps { get; set; }
        public bool variablejumpHeight { get; set; }
    }
}