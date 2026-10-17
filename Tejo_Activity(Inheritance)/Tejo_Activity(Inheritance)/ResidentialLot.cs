using System;
namespace AssetSystem
{
	public class ResidentialLot : PropertyAsset
	{
		public double Frontage;
		public double Depth;

		public ResidentialLot(string code, double taxRate, double frontage, double depth)
			: base(code, taxRate)
		{
			Frontage = frontage;
			Depth = depth;
		}

        public override double ComputeFootprintArea()
        {
			return Frontage * Depth;
        }

		public override double ComputeEnclosurePerimeter()
		{
			return 2 * (Frontage + Depth);
		}

		public string DisplayResidentialLot()
		{
			return $"================================================\n" +
				   $"|               RESIDENTIAL LOT                |\n" +
				   $"================================================\n" +
				   $"|CODE: {PropertyCode}\n" +
				   $"|AREA: {ComputeFootprintArea(), 8:F2}\n" +
				   $"|PERIMETER: {ComputeEnclosurePerimeter(), 8:F2}\n" +
				   $"|ESTIMATED TAX: {ComputeEstimatedTax(), 8:F2}\n" +
                   $"================================================\n"
                   ;

		}
    }
}

