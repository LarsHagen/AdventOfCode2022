using System;

namespace Day15
{
    public class SensorBeaconPair
    {
        public int SensorX;
        public int SensorY;
        public int BeaconX;
        public int BeaconY;

        public int DistanceToBeacon;

        public SensorBeaconPair(string input)
        {
            input = input
                .Replace("Sensor at ", null)
                .Replace(" closest beacon is at ", null)
                .Replace("x=", null)
                .Replace("y=", null);
            var split = input.Split(":");
            var sensor = split[0].Split(",");
            var beacon = split[1].Split(",");

            SensorX = int.Parse(sensor[0]);
            SensorY = int.Parse(sensor[1]);
            
            BeaconX = int.Parse(beacon[0]);
            BeaconY = int.Parse(beacon[1]);

            DistanceToBeacon = DistanceToSensor(BeaconX, BeaconY);
        }

        public int DistanceToSensor(int x, int y)
        {
            return Math.Abs(SensorX - x) + Math.Abs(SensorY - y);
        }

        public int GetXOutOfRange(int y)
        {
            return SensorX + DistanceToBeacon - Math.Abs(y - SensorY);
        }
    }
}