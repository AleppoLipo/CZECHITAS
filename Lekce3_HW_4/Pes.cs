using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekce3_HW_4
{
	internal class Pes
	{
		public string Plemeno { get; set; }
		public PohlaviKod Pohlavi { get; set; }
		public int Vek { get; set; }
	}

	public enum PohlaviKod
	{
		Pes,
		Fena,
	}
}