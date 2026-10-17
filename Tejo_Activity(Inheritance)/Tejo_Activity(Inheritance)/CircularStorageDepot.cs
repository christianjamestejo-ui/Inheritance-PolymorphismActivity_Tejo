using System;
namespace AssetSystem
{
	public class CircularStorageDepot : PropertyAsset
	{
		public double Radius;
		public CircularStorageDepot(string code, double taxRate, double radius)
            : base(code, taxRate)
        {
            PropertyCode = code;
            Radius = radius;
		}

        public override double ComputeFootprintArea()
        {
			return Math.PI * Radius * Radius;
        }

        public override double ComputeEnclosurePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public string DisplayCircularStorageDepot()
        {
            return $"================================================\n" +
                   $"|            CIRCULAR STORAGE DEPOT            |\n" +
                   $"================================================\n" +
                   $"|CODE: {PropertyCode}\n" +
                   $"|AREA: {ComputeFootprintArea(),8:F2}\n" +
                   $"|PERIMETER: {ComputeEnclosurePerimeter(),8:F2}\n" +
                   $"|ESTIMATED TAX: {ComputeEstimatedTax(),8:F2}\n" +
                   $"================================================\n"
                   ;

        }
    }
}

